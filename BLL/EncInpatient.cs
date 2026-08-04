using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class EncInpatient
{
    private readonly ConvertDtToList _convert = new();

    public Models.EncInpatient Load(int encID)
    {
        var com = new SqlCommand();
        AddParam(com, "@CRUD", 1);
        AddParam(com, "@EncID", encID);
        var dt = new DataService().GetDataTableBySP(CSet.cnStringHIS, com, "spEncInpatient");
        return _convert.ConvertDataTable<Models.EncInpatient>(dt).FirstOrDefault() ?? new Models.EncInpatient { EncID = encID };
    }

    public Models.EncInpatient Save(Models.EncInpatient item)
    {
        var com = new SqlCommand();
        AddParam(com, "@CRUD", item.CRUD == 0 ? 0 : 2);
        AddParams(com, item);
        var dt = new DataService().GetDataTableBySP(CSet.cnStringHIS, com, "spEncInpatient");
        return _convert.ConvertDataTable<Models.EncInpatient>(dt).FirstOrDefault() ?? item;
    }

    public void UpdateBedStatus(int bedID, int bedStatus, int userPersID)
    {
        if (bedID <= 0) return;

        var com = new SqlCommand();
        AddParam(com, "@BedID", bedID);
        AddParam(com, "@BedStatus", bedStatus);
        AddParam(com, "@UserPersID", userPersID);

        const string tsql = @"
DECLARE @Now NCHAR(16) = dbo.SCurdatetime();

UPDATE dbo.InpBed
SET BedStatus = @BedStatus,
    UserPersID = @UserPersID,
    ActionDate = @Now
WHERE BedID = @BedID";

        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }

    public System.Data.DataTable ActiveAdmissionByBed(int bedID, int excludeEncID = 0)
    {
        var com = new SqlCommand();
        AddParam(com, "@BedID", bedID);
        AddParam(com, "@ExcludeEncID", excludeEncID);

        const string tsql = @"
SELECT TOP 1
    b.BedID,
    b.BedNo,
    b.BedName,
    ISNULL(b.BedStatus, 0) AS BedStatus,
    CASE ISNULL(b.BedStatus, 0)
        WHEN 0 THEN N'آزاد'
        WHEN 1 THEN N'اشغال'
        WHEN 2 THEN N'رزرو'
        WHEN 3 THEN N'غیرفعال'
        WHEN 4 THEN N'تعمیرات'
        WHEN 5 THEN N'پاکسازی/بلوکه'
        ELSE N'نامشخص'
    END AS BedStatusName,
    ISNULL(w.WardName, N'') AS WardName,
    ISNULL(r.RoomName, r.RoomNo) AS RoomName,
    e.EncID,
    e.PatientID,
    p.FirstName,
    p.LastName,
    p.NationalCode,
    e.EncStatus,
    ISNULL(es.Name, N'') AS EncStatusName
FROM dbo.InpBed b
LEFT JOIN dbo.InpRoom r ON r.RoomID = b.RoomID
LEFT JOIN dbo.InpWard w ON w.WardID = b.WardID
OUTER APPLY
(
    SELECT TOP 1 ei.EncID
    FROM dbo.EncInpatient ei
    INNER JOIN dbo.Enc e2 ON e2.EncID = ei.EncID
    WHERE ei.BedID = b.BedID
      AND ei.EncID <> @ExcludeEncID
      AND ISNULL(e2.IsCancel, 0) = 0
      AND ISNULL(e2.EncStatus, 0) NOT IN (4, 5, 27, 28)
    ORDER BY ei.EncID DESC
) activeEi
LEFT JOIN dbo.Enc e ON e.EncID = activeEi.EncID
LEFT JOIN dbo.Patient p ON p.PatientID = e.PatientID
LEFT JOIN dbo.vADR es ON es.ADName = N'EncStatus' AND es.ID = e.EncStatus
WHERE b.BedID = @BedID
  AND
  (
       ISNULL(b.IsActive, 0) = 0
    OR ISNULL(b.BedStatus, 0) <> 0
    OR activeEi.EncID IS NOT NULL
  )";

        return new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
    }

    public void SetEncStatus(int encID, int encStatus, int userPersID)
    {
        if (encID <= 0 || encStatus <= 0) return;

        var com = new SqlCommand();
        AddParam(com, "@EncID", encID);
        AddParam(com, "@EncStatus", encStatus);
        AddParam(com, "@UserPersID", userPersID);

        const string tsql = @"
UPDATE dbo.Enc
SET EncStatus = @EncStatus,
    PersID = CASE WHEN ISNULL(PersID, 0) = 0 THEN @UserPersID ELSE PersID END
WHERE EncID = @EncID";

        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }

    public InpatientDepositPolicy GetDepositPolicy(int bedID, int bedClassID)
    {
        var com = new SqlCommand();
        AddParam(com, "@BedID", bedID);
        AddParam(com, "@BedClassID", bedClassID);

        const string tsql = @"
DECLARE @RequireDeposit BIT = 0,
        @AllowFinalWithoutDeposit BIT = 1,
        @NeedFinancialConfirm BIT = 0,
        @DefaultDepositAmount BIGINT = 0,
        @ReservationExpireMinutes INT = 120;

IF OBJECT_ID(N'dbo.InpatientAdmissionSetting', N'U') IS NOT NULL
BEGIN
    SELECT TOP 1
        @RequireDeposit = ISNULL(RequireDeposit, 0),
        @AllowFinalWithoutDeposit = ISNULL(AllowFinalWithoutDeposit, 1),
        @NeedFinancialConfirm = ISNULL(NeedFinancialConfirm, 0),
        @DefaultDepositAmount = ISNULL(DefaultDepositAmount, 0),
        @ReservationExpireMinutes = ISNULL(ReservationExpireMinutes, 120)
    FROM dbo.InpatientAdmissionSetting
    WHERE CenterID = 1;
END

DECLARE @BedClassDeposit BIGINT = 0,
        @BedClassRequired BIT = 0,
        @BedDeposit BIGINT = 0,
        @UseBedDeposit BIT = 0;

IF OBJECT_ID(N'dbo.InpBedClass', N'U') IS NOT NULL
BEGIN
    SELECT TOP 1
        @BedClassDeposit = ISNULL(DepositAmount, 0),
        @BedClassRequired = ISNULL(DepositIsRequired, 0)
    FROM dbo.InpBedClass
    WHERE BedClassID = @BedClassID;
END

IF OBJECT_ID(N'dbo.InpBed', N'U') IS NOT NULL
BEGIN
    SELECT TOP 1
        @BedDeposit = ISNULL(DepositAmountOverride, 0),
        @UseBedDeposit = ISNULL(UseDepositOverride, 0),
        @BedClassID = CASE WHEN ISNULL(@BedClassID, 0) = 0 THEN ISNULL(BedClassID, 0) ELSE @BedClassID END
    FROM dbo.InpBed
    WHERE BedID = @BedID;

    IF @BedClassDeposit = 0 AND @BedClassID > 0
        SELECT TOP 1
            @BedClassDeposit = ISNULL(DepositAmount, 0),
            @BedClassRequired = ISNULL(DepositIsRequired, 0)
        FROM dbo.InpBedClass
        WHERE BedClassID = @BedClassID;
END

DECLARE @DepositAmount BIGINT =
    CASE
        WHEN @UseBedDeposit = 1 AND @BedDeposit > 0 THEN @BedDeposit
        WHEN @BedClassDeposit > 0 THEN @BedClassDeposit
        ELSE @DefaultDepositAmount
    END;

DECLARE @FinalRequireDeposit BIT = CASE WHEN @RequireDeposit = 1 OR @BedClassRequired = 1 THEN 1 ELSE 0 END;

SELECT
    CAST(@FinalRequireDeposit AS bit) AS RequireDeposit,
    CAST(@AllowFinalWithoutDeposit AS bit) AS AllowFinalWithoutDeposit,
    CAST(@NeedFinancialConfirm AS bit) AS NeedFinancialConfirm,
    CAST(@DepositAmount AS bigint) AS DepositAmount,
    CAST(CASE WHEN @FinalRequireDeposit = 1 THEN 21 ELSE 23 END AS int) AS InitialEncStatus,
    CAST(CASE WHEN @FinalRequireDeposit = 1 THEN 2 ELSE 1 END AS int) AS InitialBedStatus,
    CAST(23 AS int) AS FinalEncStatus,
    CAST(@ReservationExpireMinutes AS int) AS ReservationExpireMinutes;";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _convert.ConvertDataTable<InpatientDepositPolicy>(dt).FirstOrDefault() ?? new InpatientDepositPolicy();
    }

    public string RegisterDepositPayment(int encID, long paidAmount, int cashID, int userPersID)
    {
        if (encID <= 0) return "کد پذیرش نامعتبر است.";
        if (paidAmount <= 0) return "مبلغ ودیعه نامعتبر است.";

        var com = new SqlCommand();
        AddParam(com, "@EncID", encID);
        AddParam(com, "@PaidAmount", paidAmount);
        AddParam(com, "@CashID", cashID);
        AddParam(com, "@UserPersID", userPersID);

        const string tsql = @"
DECLARE @Now NCHAR(16) = dbo.SCurdatetime();

UPDATE dbo.EncInpatient
SET DepositPaidAmount = ISNULL(DepositPaidAmount, 0) + @PaidAmount,
    DepositCashID = CASE WHEN @CashID > 0 THEN @CashID ELSE DepositCashID END,
    FinancialConfirm = 1,
    FinancialConfirmDate = @Now,
    FinancialConfirmUserPersID = @UserPersID,
    PreAdmissionStatus = CASE WHEN ISNULL(PreAdmissionStatus, 0) IN (20,21) THEN 22 ELSE PreAdmissionStatus END,
    UserPersID = @UserPersID,
    ActionDate = @Now
WHERE EncID = @EncID;

UPDATE dbo.Enc
SET EncStatus = CASE WHEN EncStatus IN (20,21) THEN 22 ELSE EncStatus END
WHERE EncID = @EncID;

SELECT N'ودیعه بیمار ثبت/تایید شد.' AS Result;";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return dt.Rows.Count > 0 ? dt.Rows[0]["Result"].ToString() ?? "ودیعه ثبت شد." : "ودیعه ثبت شد.";
    }

    public string FinalizeAdmission(int encID, int userPersID)
    {
        if (encID <= 0) return "کد پذیرش نامعتبر است.";

        var com = new SqlCommand();
        AddParam(com, "@EncID", encID);
        AddParam(com, "@UserPersID", userPersID);

        const string tsql = @"
DECLARE @Now NCHAR(16) = dbo.SCurdatetime();
DECLARE @BedID INT = 0,
        @DepositRequired BIT = 0,
        @DepositAmount BIGINT = 0,
        @DepositPaidAmount BIGINT = 0,
        @DepositCashID INT = 0,
        @FinancialConfirm BIT = 0;

SELECT TOP 1
    @BedID = ISNULL(BedID, 0),
    @DepositRequired = ISNULL(DepositRequired, 0),
    @DepositAmount = ISNULL(DepositAmount, 0),
    @DepositPaidAmount = ISNULL(DepositPaidAmount, 0),
    @DepositCashID = ISNULL(DepositCashID, 0),
    @FinancialConfirm = ISNULL(FinancialConfirm, 0)
FROM dbo.EncInpatient
WHERE EncID = @EncID;

IF @@ROWCOUNT = 0
BEGIN
    SELECT CAST(0 AS bit) AS IsSuccess, N'اطلاعات بستری برای این پذیرش پیدا نشد.' AS Result;
    RETURN;
END

IF @DepositRequired = 1
   AND @DepositAmount > 0
   AND @DepositPaidAmount < @DepositAmount
   AND @DepositCashID = 0
BEGIN
    SELECT CAST(0 AS bit) AS IsSuccess,
           N'ودیعه بیمار هنوز دریافت نشده است. پذیرش نهایی بستری امکان‌پذیر نیست.' AS Result;
    RETURN;
END

UPDATE dbo.EncInpatient
SET FinalAdmissionDate = @Now,
    FinalAdmissionUserPersID = @UserPersID,
    PreAdmissionStatus = 23,
    UserPersID = @UserPersID,
    ActionDate = @Now
WHERE EncID = @EncID;

UPDATE dbo.Enc
SET EncStatus = 23,
    PersID = CASE WHEN ISNULL(PersID, 0) = 0 THEN @UserPersID ELSE PersID END
WHERE EncID = @EncID;

IF @BedID > 0
BEGIN
    UPDATE dbo.InpBed
    SET BedStatus = 1,
        UserPersID = @UserPersID,
        ActionDate = @Now
    WHERE BedID = @BedID;
END

SELECT CAST(1 AS bit) AS IsSuccess, N'پذیرش نهایی بستری با موفقیت انجام شد.' AS Result;";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        if (dt.Rows.Count == 0) return "عملیات انجام شد.";

        var result = dt.Rows[0]["Result"].ToString() ?? "";
        var isSuccess = dt.Columns.Contains("IsSuccess") && Convert.ToBoolean(dt.Rows[0]["IsSuccess"]);
        if (!isSuccess)
            throw new InvalidOperationException(result);

        return result;
    }

    private static void AddParams(SqlCommand com, Models.EncInpatient item)
    {
        AddParam(com, "@EncID", item.EncID);
        AddParam(com, "@AdmissionType", item.AdmissionType);
        AddParam(com, "@AdmissionSource", item.AdmissionSource);
        AddParam(com, "@WardID", item.WardID);
        AddParam(com, "@RoomID", item.RoomID);
        AddParam(com, "@BedID", item.BedID);
        AddParam(com, "@BedClass", item.BedClass);
        AddParam(com, "@AdmissionDiagnosis", item.AdmissionDiagnosis);
        AddParam(com, "@InitialDiagnosis", item.InitialDiagnosis);
        AddParam(com, "@ICD10Code", item.ICD10Code);
        AddParam(com, "@IntroduceLetterNo", item.IntroduceLetterNo);
        AddParam(com, "@IntroduceLetterDate", item.IntroduceLetterDate);
        AddParam(com, "@IntroduceLetterExpireDate", item.IntroduceLetterExpireDate);
        AddParam(com, "@DepositAmount", item.DepositAmount);
        AddParam(com, "@DepositRequired", item.DepositRequired);
        AddParam(com, "@DepositPaidAmount", item.DepositPaidAmount);
        AddParam(com, "@DepositCashID", item.DepositCashID);
        AddParam(com, "@FinancialConfirm", item.FinancialConfirm);
        AddParam(com, "@FinancialConfirmDate", item.FinancialConfirmDate);
        AddParam(com, "@FinancialConfirmUserPersID", item.FinancialConfirmUserPersID);
        AddParam(com, "@BedReservationDate", item.BedReservationDate);
        AddParam(com, "@BedReservationExpireDate", item.BedReservationExpireDate);
        AddParam(com, "@FinalAdmissionDate", item.FinalAdmissionDate);
        AddParam(com, "@FinalAdmissionUserPersID", item.FinalAdmissionUserPersID);
        AddParam(com, "@PreAdmissionStatus", item.PreAdmissionStatus);
        AddParam(com, "@CompanionFullName", item.CompanionFullName);
        AddParam(com, "@CompanionRelation", item.CompanionRelation);
        AddParam(com, "@CompanionNationalCode", item.CompanionNationalCode);
        AddParam(com, "@CompanionMobile", item.CompanionMobile);
        AddParam(com, "@EmergencyContactName", item.EmergencyContactName);
        AddParam(com, "@EmergencyContactRelation", item.EmergencyContactRelation);
        AddParam(com, "@EmergencyContactMobile", item.EmergencyContactMobile);
        AddParam(com, "@IsolationRequired", item.IsolationRequired);
        AddParam(com, "@IsolationType", item.IsolationType);
        AddParam(com, "@FallRisk", item.FallRisk);
        AddParam(com, "@PressureUlcerRisk", item.PressureUlcerRisk);
        AddParam(com, "@InfectionRisk", item.InfectionRisk);
        AddParam(com, "@PatientIdentificationBand", item.PatientIdentificationBand);
        AddParam(com, "@AllergyBand", item.AllergyBand);
        AddParam(com, "@HasBelongings", item.HasBelongings);
        AddParam(com, "@BelongingsDescription", item.BelongingsDescription);
        AddParam(com, "@UserPersID", item.UserPersID);
        AddParam(com, "@CenterID", item.CenterID);
    }

    private static void AddParam(SqlCommand com, string name, object? value)
    {
        if (value is string str && string.IsNullOrWhiteSpace(str)) value = DBNull.Value;
        com.Parameters.AddWithValue(name, value ?? DBNull.Value);
    }
}
