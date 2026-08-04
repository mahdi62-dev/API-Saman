using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class InpatientWardDashboard
{
    private readonly ConvertDtToList _convert = new();

    public List<InpatientWardPatient> GetPatients(int wardID = 0, int depID = 0, string? searchText = null)
    {
        var com = new SqlCommand();
        AddParam(com, "@WardID", wardID);
        AddParam(com, "@DepID", depID);
        AddParam(com, "@SearchText", searchText ?? "");

        const string tsql = @"
SELECT
    ISNULL(e.EncID, ei.EncID) AS EncID,
    ISNULL(e.PatientID, 0) AS PatientID,
    ISNULL(p.NationalCode, N'') AS NationalCode,
    ISNULL(p.FirstName, N'') AS FirstName,
    ISNULL(p.LastName, N'') AS LastName,
    ISNULL(p.FatherName, N'') AS FatherName,
    LTRIM(RTRIM(ISNULL(p.FirstName, N'') + N' ' + ISNULL(p.LastName, N''))) AS FullName,
    ISNULL(e.Age, 0) AS Age,
    ISNULL(p.Gender, 0) AS Gender,
    ISNULL(g.Name, N'') AS GenderName,
    ISNULL(ec.Mobile, N'') AS Mobile,
    ISNULL(e.StartDate, N'') AS StartDate,
    ISNULL(e.EncStatus, 0) AS EncStatus,
    ISNULL(es.Name, N'') AS EncStatusName,
    ISNULL(e.ModID, 0) AS ModID,
    ISNULL(e.DepID, 0) AS EncDepID,
    ISNULL(w.WardID, 0) AS WardID,
    ISNULL(w.WardName, N'') AS WardName,
    ISNULL(w.DepID, 0) AS WardDepID,
    ISNULL(r.RoomID, 0) AS RoomID,
    ISNULL(r.RoomName, r.RoomNo) AS RoomName,
    ISNULL(ei.BedID, 0) AS BedID,
    ISNULL(b.BedNo, N'') AS BedNo,
    ISNULL(b.BedName, N'') AS BedName,
    LTRIM(RTRIM(ISNULL(b.BedNo, N'') + CASE WHEN ISNULL(b.BedName, N'') <> N'' THEN N' - ' + b.BedName ELSE N'' END)) AS BedDisplayName,
    ISNULL(b.BedClassID, ISNULL(ei.BedClass, 0)) AS BedClassID,
    ISNULL(bc.BedClassName, N'') AS BedClassName,
    ISNULL(b.BedStatus, 0) AS BedStatus,
    CASE ISNULL(b.BedStatus, 0)
        WHEN 0 THEN N'آزاد'
        WHEN 1 THEN N'اشغال'
        WHEN 2 THEN N'رزرو'
        WHEN 3 THEN N'غیرفعال'
        WHEN 4 THEN N'تعمیرات'
        WHEN 5 THEN N'پاکسازی/بلوکه'
        ELSE N''
    END AS BedStatusName,
    ISNULL(ei.AdmissionType, 0) AS AdmissionType,
    ISNULL(at.Name, N'') AS AdmissionTypeName,
    ISNULL(ei.AdmissionSource, 0) AS AdmissionSource,
    ISNULL(src.Name, N'') AS AdmissionSourceName,
    ISNULL(ei.AdmissionDiagnosis, N'') AS AdmissionDiagnosis,
    ISNULL(ei.InitialDiagnosis, N'') AS InitialDiagnosis,
    ISNULL(ei.ICD10Code, N'') AS ICD10Code,
    ISNULL(ei.IsolationRequired, 0) AS IsolationRequired,
    ISNULL(ei.FallRisk, 0) AS FallRisk,
    ISNULL(ei.PressureUlcerRisk, 0) AS PressureUlcerRisk,
    ISNULL(ei.InfectionRisk, 0) AS InfectionRisk,
    ISNULL(ei.CompanionFullName, N'') AS CompanionFullName,
    ISNULL(ei.CompanionMobile, N'') AS CompanionMobile,
    ISNULL(ei.EmergencyContactName, N'') AS EmergencyContactName,
    ISNULL(ei.EmergencyContactMobile, N'') AS EmergencyContactMobile,
    ISNULL(ei.DepositAmount, 0) AS DepositAmount,
    ISNULL(CASE WHEN ISNULL(e.StartDate, N'') <> N'' THEN DATEDIFF(DAY, TRY_CONVERT(date, LEFT(e.StartDate, 10)), GETDATE()) ELSE 0 END, 0) AS StayDays
FROM dbo.EncInpatient ei
LEFT JOIN dbo.Enc e ON e.EncID = ei.EncID
LEFT JOIN dbo.Patient p ON p.PatientID = e.PatientID
LEFT JOIN dbo.EncContact ec ON ec.EncID = ei.EncID
LEFT JOIN dbo.InpBed b ON b.BedID = ei.BedID
LEFT JOIN dbo.InpRoom r ON r.RoomID = ISNULL(NULLIF(ei.RoomID, 0), b.RoomID)
LEFT JOIN dbo.InpWard w ON w.WardID = ISNULL(NULLIF(ei.WardID, 0), ISNULL(r.WardID, b.WardID))
LEFT JOIN dbo.InpBedClass bc ON bc.BedClassID = ISNULL(b.BedClassID, ei.BedClass)
LEFT JOIN dbo.vADR g ON g.ADName = N'Gender' AND g.ID = p.Gender
LEFT JOIN dbo.vADR es ON es.ADName = N'EncStatus' AND es.ID = e.EncStatus
LEFT JOIN dbo.vADR at ON at.ADName = N'InpatientAdmissionType' AND at.ID = ei.AdmissionType
LEFT JOIN dbo.vADR src ON src.ADName = N'InpatientAdmissionSource' AND src.ID = ei.AdmissionSource
WHERE ISNULL(e.IsCancel, 0) = 0
  AND ISNULL(e.EncStatus, 0) <> 5
  -- ملاک اصلی صفحه بخش بستری، وجود رکورد EncInpatient است.
  -- EncType برای تفکیک استاندارد است، اما برای داده‌های قبلی که EncType هنوز اصلاح نشده، بیمار نباید از بخش بستری حذف شود.
  AND (@WardID = 0 OR ISNULL(w.WardID, 0) = @WardID)
  AND (@DepID = 0 OR ISNULL(w.DepID, 0) = @DepID)
  AND (
        @SearchText = N''
        OR p.NationalCode LIKE N'%' + @SearchText + N'%'
        OR p.FirstName LIKE N'%' + @SearchText + N'%'
        OR p.LastName LIKE N'%' + @SearchText + N'%'
        OR CONVERT(NVARCHAR(20), e.EncID) LIKE N'%' + @SearchText + N'%'
      )
ORDER BY w.SortID, w.WardName, r.SortID, r.RoomNo, b.SortID, b.BedNo, e.EncID DESC";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _convert.ConvertDataTable<InpatientWardPatient>(dt);
    }

    public List<InpatientWardSummary> GetSummary(int depID = 0)
    {
        var com = new SqlCommand();
        AddParam(com, "@DepID", depID);

        const string tsql = @"
;WITH BedAgg AS
(
    SELECT
        w.WardID,
        COUNT(DISTINCT r.RoomID) AS RoomCount,
        COUNT(DISTINCT b.BedID) AS BedCount,
        ISNULL(SUM(CASE WHEN b.IsActive = 1 AND b.BedStatus = 0 THEN 1 ELSE 0 END), 0) AS FreeBedCount,
        ISNULL(SUM(CASE WHEN b.IsActive = 1 AND b.BedStatus = 1 THEN 1 ELSE 0 END), 0) AS OccupiedBedCount,
        ISNULL(SUM(CASE WHEN b.IsActive = 1 AND b.BedStatus = 2 THEN 1 ELSE 0 END), 0) AS ReservedBedCount,
        ISNULL(SUM(CASE WHEN b.IsActive = 0 OR b.BedStatus IN (3,4,5) THEN 1 ELSE 0 END), 0) AS BlockedBedCount
    FROM dbo.InpWard w
    LEFT JOIN dbo.InpRoom r ON r.WardID = w.WardID
    LEFT JOIN dbo.InpBed b ON b.RoomID = r.RoomID
    WHERE w.IsActive = 1
      AND (@DepID = 0 OR w.DepID = @DepID)
    GROUP BY w.WardID
), PatientAgg AS
(
    SELECT
        EffectiveWardID = ISNULL(NULLIF(ei.WardID, 0), ISNULL(r.WardID, b.WardID)),
        COUNT(DISTINCT e.EncID) AS PatientCount,
        ISNULL(SUM(CASE WHEN ISNULL(ei.IsolationRequired,0)=1 THEN 1 ELSE 0 END), 0) AS IsolationCount,
        ISNULL(SUM(CASE WHEN ISNULL(ei.FallRisk,0)=1 THEN 1 ELSE 0 END), 0) AS FallRiskCount,
        ISNULL(SUM(CASE WHEN ISNULL(ei.InfectionRisk,0)=1 THEN 1 ELSE 0 END), 0) AS InfectionRiskCount
    FROM dbo.EncInpatient ei
    INNER JOIN dbo.Enc e ON e.EncID = ei.EncID
    LEFT JOIN dbo.InpBed b ON b.BedID = ei.BedID
    LEFT JOIN dbo.InpRoom r ON r.RoomID = ISNULL(NULLIF(ei.RoomID, 0), b.RoomID)
    WHERE ISNULL(e.IsCancel,0)=0
      AND ISNULL(e.EncStatus,0) <> 5
    GROUP BY ISNULL(NULLIF(ei.WardID, 0), ISNULL(r.WardID, b.WardID))
)
SELECT
    w.WardID,
    ISNULL(w.WardName, N'') AS WardName,
    ISNULL(w.DepID, 0) AS DepID,
    ISNULL(ba.RoomCount, 0) AS RoomCount,
    ISNULL(ba.BedCount, 0) AS BedCount,
    ISNULL(ba.FreeBedCount, 0) AS FreeBedCount,
    ISNULL(ba.OccupiedBedCount, 0) AS OccupiedBedCount,
    ISNULL(ba.ReservedBedCount, 0) AS ReservedBedCount,
    ISNULL(ba.BlockedBedCount, 0) AS BlockedBedCount,
    ISNULL(pa.PatientCount, 0) AS PatientCount,
    ISNULL(pa.IsolationCount, 0) AS IsolationCount,
    ISNULL(pa.FallRiskCount, 0) AS FallRiskCount,
    ISNULL(pa.InfectionRiskCount, 0) AS InfectionRiskCount,
    CAST(CASE WHEN ISNULL(ba.BedCount, 0) = 0 THEN 0 ELSE (100.0 * ISNULL(ba.OccupiedBedCount, 0) / ba.BedCount) END AS DECIMAL(6,2)) AS OccupancyPercent
FROM dbo.InpWard w
LEFT JOIN BedAgg ba ON ba.WardID = w.WardID
LEFT JOIN PatientAgg pa ON pa.EffectiveWardID = w.WardID
WHERE w.IsActive = 1
  AND (@DepID = 0 OR w.DepID = @DepID)
ORDER BY w.SortID, w.WardName";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _convert.ConvertDataTable<InpatientWardSummary>(dt);
    }

    private static void AddParam(SqlCommand com, string name, object? value)
    {
        // مهم: SearchText خالی باید همان رشته خالی بماند، نه DBNull.
        // چون در کوئری شرط داریم: @SearchText = N'' OR ...
        // اگر DBNull شود، شرط false/unknown می‌شود و هیچ بیماری برنمی‌گردد.
        com.Parameters.AddWithValue(name, value ?? DBNull.Value);
    }
}
