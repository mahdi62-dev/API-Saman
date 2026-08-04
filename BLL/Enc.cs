using System.Data;
using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class Enc
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();

    public List<Models.Enc> PatientList(Models.Enc enc)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", enc.CRUD);
        com.Parameters.AddWithValue("@NationalCode", enc.NationalCode);
        com.Parameters.AddWithValue("@FirstName", enc.FirstName);
        com.Parameters.AddWithValue("@LastName", enc.LastName);
        com.Parameters.AddWithValue("@FatherName", enc.FatherName);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spPatient");
        return _appConvertDtToList.ConvertDataTable<Models.Enc>(dt);
    }

    public Models.Enc PatientCRUD(Models.Enc enc, int UserPersID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", enc.CRUD);
        com.Parameters.AddWithValue("@PatientID", enc.PatientID);
        com.Parameters.AddWithValue("@NationalCode", enc.NationalCode);
        com.Parameters.AddWithValue("@FirstName", enc.FirstName);
        com.Parameters.AddWithValue("@LastName", enc.LastName);
        com.Parameters.AddWithValue("@FatherName", enc.FatherName);

        com.Parameters.AddWithValue("@Gender", SafeNonNegative(enc.Gender));
        com.Parameters.AddWithValue("@BirthDate", enc.BirthDate);
        com.Parameters.AddWithValue("@MaritalStatus", SafeNonNegative(enc.MaritalStatus));
        com.Parameters.AddWithValue("@Country", SafeNonNegative(enc.Country));

        com.Parameters.AddWithValue("@IDCardNumber", enc.IDCardNumber);
        com.Parameters.AddWithValue("@BirthArea", SafeNonNegative(enc.BirthArea));
        com.Parameters.AddWithValue("@Religion", SafeNonNegative(enc.Religion));
        com.Parameters.AddWithValue("@Job", SafeNonNegative(enc.Job));
        com.Parameters.AddWithValue("@PassportID", enc.PassportID);
        com.Parameters.AddWithValue("@EducationLevel", SafeNonNegative(enc.EducationLevel));

        com.Parameters.AddWithValue("@UserPersID", UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spPatient");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];


        return _appConvertDRowToModel.CreateItemFromRow<Models.Enc>(dRow);
    }

    public Models.Enc EncCRUD(Models.Enc enc, int UserPersID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", enc.CRUD);
        com.Parameters.AddWithValue("@FuncType", enc.FuncType);

        com.Parameters.AddWithValue("@NationalCode", enc.NationalCode);
        com.Parameters.AddWithValue("@FirstName", enc.FirstName);
        com.Parameters.AddWithValue("@LastName", enc.LastName);
        com.Parameters.AddWithValue("@FatherName", enc.FatherName);
        com.Parameters.AddWithValue("@EncID", enc.EncID);
        com.Parameters.AddWithValue("@PatientID", enc.PatientID);
        com.Parameters.AddWithValue("@StartDate", enc.StartDate);
        com.Parameters.AddWithValue("@EncType", enc.EncType);
        com.Parameters.AddWithValue("@IsEmerg", enc.IsEmerg);
        com.Parameters.AddWithValue("@ModID", enc.ModID);
        com.Parameters.AddWithValue("@DepID", enc.DepID);
        com.Parameters.AddWithValue("@DrID", enc.DrID);
        com.Parameters.AddWithValue("@RefDrID", enc.RefDrID);
        com.Parameters.AddWithValue("@ReferDrText", enc.ReferDrText);
        com.Parameters.AddWithValue("@RefPrID", enc.RefPrID);
        com.Parameters.AddWithValue("@PresDate", enc.PresDate == null ? DBNull.Value : enc.PresDate);
        com.Parameters.AddWithValue("@EncService", enc.EncService);
        com.Parameters.AddWithValue("@DiscountPercent", enc.DiscountPercent);
        com.Parameters.AddWithValue("@ChiefComplaint", enc.ChiefComplaint);
        com.Parameters.AddWithValue("@UnderlyingDisease", enc.UnderlyingDisease);
        com.Parameters.AddWithValue("@Description", enc.Description);
        com.Parameters.AddWithValue("@Insurance", enc.Insurance);
        com.Parameters.AddWithValue("@InsuranceNumber", enc.InsuranceNumber);
        com.Parameters.AddWithValue("@InsuranceSerial", enc.InsuranceSerial);
        com.Parameters.AddWithValue("@InsurancePagenumber", enc.InsurancePageNumber);
        com.Parameters.AddWithValue("@InsuranceExpireDate", enc.InsuranceExpireDate);
        com.Parameters.AddWithValue("@InsuranceExpireValid", enc.InsuranceExpireValid);
        com.Parameters.AddWithValue("@SDrFixAmount", enc.SDrFixAmount);
        com.Parameters.AddWithValue("@IsSDrAcceptAmount", enc.IsSDrAcceptAmount);
        com.Parameters.AddWithValue("@OprReserveDate",
            enc.OprReserveDate == null ? DBNull.Value : enc.OprReserveDate);
        com.Parameters.AddWithValue("@Height", enc.Height);
        com.Parameters.AddWithValue("@Weight", enc.Weight);

        com.Parameters.AddWithValue("@Mobile", enc.Mobile);
        com.Parameters.AddWithValue("@City", enc.City);
        com.Parameters.AddWithValue("@Street", enc.Street);
        com.Parameters.AddWithValue("@Email", enc.Email);
        com.Parameters.AddWithValue("@Tel", enc.Tel);

        com.Parameters.AddWithValue("@CompanionFullName", enc.CompanionFullName);
        com.Parameters.AddWithValue("@CompanionTel", enc.CompanionTel);
        com.Parameters.AddWithValue("@Recommender", enc.Recommender);
        com.Parameters.AddWithValue("@CompanionAddress", enc.CompanionAddress);

        com.Parameters.AddWithValue("@Insurance2", enc.Insurance2);
        com.Parameters.AddWithValue("@InsuranceNumber2", enc.InsuranceNumber2);

        com.Parameters.AddWithValue("@UserPersID", UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spEnc");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Enc>(dRow);
    }

    public Models.Enc EncCRUD(Models.Enc enc)
    {
        return EncCRUD(enc, 0);
    }


    public Models.Enc EncLoadByID(int encID)
    {
        if (encID <= 0) return new Models.Enc();

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@EncID", encID);

        const string tsql = @"
SELECT TOP 1 *
FROM dbo.vEncFullName e
WHERE e.EncID = @EncID
  AND ISNULL(e.IsCancel, 0) = 0;";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Enc>(dRow);
    }

    public Models.Enc EncNavigateByType(int encID, int funcType, int encType)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@EncID", encID);
        com.Parameters.AddWithValue("@FuncType", funcType);
        com.Parameters.AddWithValue("@EncType", encType);

        const string tsql = @"
DECLARE @EncIDCur INT = ISNULL(@EncID, 0);

IF @FuncType = 100 -- Last
BEGIN
    SELECT @EncIDCur = ISNULL(MAX(EncID), 0)
    FROM dbo.Enc
    WHERE EncType = @EncType
      AND ISNULL(IsCancel, 0) = 0;
END
ELSE IF @FuncType = 101 -- Next
BEGIN
    SELECT TOP 1 @EncIDCur = EncID
    FROM dbo.Enc
    WHERE EncType = @EncType
      AND ISNULL(IsCancel, 0) = 0
      AND EncID > @EncID
    ORDER BY EncID;

    IF ISNULL(@EncIDCur, 0) = ISNULL(@EncID, 0)
        SELECT @EncIDCur = ISNULL(MAX(EncID), 0) FROM dbo.Enc WHERE EncType = @EncType AND ISNULL(IsCancel, 0) = 0;
END
ELSE IF @FuncType = 102 -- Previous
BEGIN
    SELECT TOP 1 @EncIDCur = EncID
    FROM dbo.Enc
    WHERE EncType = @EncType
      AND ISNULL(IsCancel, 0) = 0
      AND EncID < @EncID
    ORDER BY EncID DESC;

    IF ISNULL(@EncIDCur, 0) = ISNULL(@EncID, 0)
        SELECT @EncIDCur = ISNULL(MIN(EncID), 0) FROM dbo.Enc WHERE EncType = @EncType AND ISNULL(IsCancel, 0) = 0;
END

SELECT TOP 1 *
FROM dbo.vEncFullName e
WHERE e.EncID = @EncIDCur
  AND e.EncType = @EncType;
";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        var result = _appConvertDRowToModel.CreateItemFromRow<Models.Enc>(dRow);
        if (result.EncID == 0)
            result.EncType = encType;
        return result;
    }

    public DataTable ActiveInpatientByNationalCode(string nationalCode, int excludeEncID = 0)
        => ActiveInpatientByPatientOrNational(0, nationalCode, excludeEncID);

    public DataTable ActiveInpatientByPatientOrNational(int patientID, string nationalCode, int excludeEncID = 0)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@PatientID", patientID);
        com.Parameters.AddWithValue("@NationalCode", nationalCode ?? "");
        com.Parameters.AddWithValue("@ExcludeEncID", excludeEncID);

        const string tsql = @"
DECLARE @NC NCHAR(10) = NULLIF(LTRIM(RTRIM(@NationalCode)), N'');

SELECT TOP 1
    e.EncID,
    e.PatientID,
    p.FirstName,
    p.LastName,
    p.FatherName,
    p.NationalCode,
    e.StartDate,
    e.EncStatus,
    ISNULL(es.Name, N'') AS EncStatusName,
    ISNULL(ei.WardID, 0) AS WardID,
    ISNULL(w.WardName, N'') AS WardName,
    ISNULL(ei.RoomID, 0) AS RoomID,
    ISNULL(r.RoomName, r.RoomNo) AS RoomName,
    ISNULL(ei.BedID, 0) AS BedID,
    ISNULL(b.BedNo, N'') AS BedNo,
    ISNULL(b.BedName, N'') AS BedName
FROM dbo.EncInpatient ei
INNER JOIN dbo.Enc e ON e.EncID = ei.EncID
INNER JOIN dbo.Patient p ON p.PatientID = e.PatientID
LEFT JOIN dbo.InpBed b ON b.BedID = ei.BedID
LEFT JOIN dbo.InpRoom r ON r.RoomID = ISNULL(NULLIF(ei.RoomID, 0), b.RoomID)
LEFT JOIN dbo.InpWard w ON w.WardID = ISNULL(NULLIF(ei.WardID, 0), ISNULL(r.WardID, b.WardID))
LEFT JOIN dbo.vADR es ON es.ADName = N'EncStatus' AND es.ID = e.EncStatus
WHERE ISNULL(e.IsCancel, 0) = 0
  -- ملاک فعال بودن بستری، داشتن EncInpatient و ترخیص/کنسل نهایی نشدن است؛
  -- برای داده‌های قدیمی فقط به EncType تکیه نمی‌کنیم.
  AND ISNULL(e.EncStatus, 0) NOT IN (4, 5, 27, 28)
  AND e.EncID <> @ExcludeEncID
  AND (
        (@PatientID > 0 AND e.PatientID = @PatientID)
        OR (@NC IS NOT NULL AND LTRIM(RTRIM(p.NationalCode)) = @NC)
      )
ORDER BY e.EncID DESC";

        return new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
    }

    public DataTable EncInsuranceChange
        (int EncID, int InsuranceID, int UserPersID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@EncID", EncID);
        com.Parameters.AddWithValue("@InsuranceIDNew", InsuranceID);
        com.Parameters.AddWithValue("@UserPersID", UserPersID);

        var dalData = new DataService();
        return dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spEncInsuranceChange");
    }

    public int EncTotalPayAmount(int EncID)
    {
        var tsql = @" SELECT ISNULL(SUM(PayAmount),0) AS TotalPayAmount
                            FROM dbo.Page p
                            WHERE P.EncID=@EncID ";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@EncID", EncID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);

        return Convert.ToInt32(dt.Rows[0]["TotalPayAmount"]);
    }


    public int EncIdLast(int ModID)
    {
        var encIDLast = 0;

        var tsql = "SELECT ISNULL(MAX(EncID),0) AS EncID FROM Enc WHERE ModID=@ModID";
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@ModID", ModID);

        var dalData = new DataService();

        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);
        if (dt.Rows.Count > 0)
            encIDLast = Convert.ToInt32(dt.Rows[0]["EncID"]);

        return encIDLast;
    }

    public EncError EncError(Models.Enc enc, int FuncType)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", enc.CRUD);
        com.Parameters.AddWithValue("@FuncType", FuncType);
        com.Parameters.AddWithValue("@NationalCode", enc.NationalCode);
        com.Parameters.AddWithValue("@PatientID", enc.PatientID);
        com.Parameters.AddWithValue("@FirstName", enc.FirstName);
        com.Parameters.AddWithValue("@LastName", enc.LastName);
        com.Parameters.AddWithValue("@FatherName", enc.FatherName);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spPatient");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<EncError>(dRow);
    }

    public List<Models.Enc> EncList(Models.Enc enc)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", 1);
        com.Parameters.AddWithValue("@FuncType", enc.FuncType);

        com.Parameters.AddWithValue("@NationalCode", enc.NationalCode);
        com.Parameters.AddWithValue("@FirstName", enc.FirstName);
        com.Parameters.AddWithValue("@LastName", enc.LastName);
        com.Parameters.AddWithValue("@FatherName", enc.FatherName);
        com.Parameters.AddWithValue("@EncID", enc.EncID);
        com.Parameters.AddWithValue("@PatientID", enc.PatientID);
        com.Parameters.AddWithValue("@StartDate", enc.StartDate);
        com.Parameters.AddWithValue("@StartDate1", enc.StartDate1);
        com.Parameters.AddWithValue("@StartDateRange", enc.StartDateRange);
        com.Parameters.AddWithValue("@EndDate", enc.EndDate);
        com.Parameters.AddWithValue("@EndDate1", enc.EndDate1);
        com.Parameters.AddWithValue("@EndDateRange", enc.EndDateRange);
        com.Parameters.AddWithValue("@EncType", enc.EncType);
        com.Parameters.AddWithValue("@IsEmerg", enc.IsEmerg);
        com.Parameters.AddWithValue("@ModID", enc.ModID);
        com.Parameters.AddWithValue("@DepID", enc.DepID);
        com.Parameters.AddWithValue("@DrID", enc.DrID);
        com.Parameters.AddWithValue("@RefDrID", enc.RefDrID);
        com.Parameters.AddWithValue("@ReferDrText", enc.ReferDrText);
        com.Parameters.AddWithValue("@PresDate", enc.PresDate == null ? DBNull.Value : enc.PresDate);
        com.Parameters.AddWithValue("@EncService", enc.EncService);
        com.Parameters.AddWithValue("@DiscountPercent", enc.DiscountPercent);
        com.Parameters.AddWithValue("@ChiefComplaint", enc.ChiefComplaint);
        com.Parameters.AddWithValue("@UnderlyingDisease", enc.UnderlyingDisease);
        com.Parameters.AddWithValue("@Description", enc.Description);
        com.Parameters.AddWithValue("@Insurance", enc.Insurance);
        com.Parameters.AddWithValue("@InsuranceNumber", enc.InsuranceNumber);
        com.Parameters.AddWithValue("@InsuranceSerial", enc.InsuranceSerial);
        com.Parameters.AddWithValue("@InsurancePagenumber", enc.InsurancePageNumber);
        com.Parameters.AddWithValue("@InsuranceExpireDate", enc.InsuranceExpireDate);
        com.Parameters.AddWithValue("@InsuranceExpireValid", enc.InsuranceExpireValid);
        com.Parameters.AddWithValue("@SDrFixAmount", enc.SDrFixAmount);
        com.Parameters.AddWithValue("@IsSDrAcceptAmount", enc.IsSDrAcceptAmount);
        com.Parameters.AddWithValue("@OprReserveDate",
            enc.OprReserveDate == null ? DBNull.Value : enc.OprReserveDate);
        com.Parameters.AddWithValue("@Height", enc.Height);
        com.Parameters.AddWithValue("@Weight", enc.Weight);

        com.Parameters.AddWithValue("@Mobile", enc.Mobile);
        com.Parameters.AddWithValue("@City", enc.City);
        com.Parameters.AddWithValue("@Street", enc.Street);
        com.Parameters.AddWithValue("@Email", enc.Email);
        com.Parameters.AddWithValue("@Tel", enc.Tel);

        com.Parameters.AddWithValue("@CompanionFullName", enc.CompanionFullName);
        com.Parameters.AddWithValue("@CompanionTel", enc.CompanionTel);
        com.Parameters.AddWithValue("@Recommender", enc.Recommender);
        com.Parameters.AddWithValue("@CompanionAddress", enc.CompanionAddress);

        com.Parameters.AddWithValue("@Insurance2", enc.Insurance2);
        com.Parameters.AddWithValue("@InsuranceNumber2", enc.InsuranceNumber2);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spEnc");
        return _appConvertDtToList.ConvertDataTable<Models.Enc>(dt);
    }


    public DataTable GetEncFinancialData(int EncID)
    {
        var tsql = @"
                        SELECT ISNULL(SUM(PayAmount),0) AS TotalPayAmount, ISNULL(SUM(DiscountAmount),0) AS TotalDiscountAmount, 0 AS PageDrugCount
                        FROM dbo.Page p
                        WHERE EncID=@EncID

                        UNION ALL

                        SELECT PayAmount,DiscountAmount, 0 AS PageDrugCount
                        FROM EncBillsummary
                        WHERE EncID=@EncID


                        UNION

                        SELECT 0 AS PayAmount,0 AS DiscountAmount, COUNT(p.PageID) AS PageDrugCount
                        FROM dbo.Page p
                        INNER JOIN dbo.ServiceReg sr ON sr.PageID=p.PageID
                        INNER JOIN dbo.Service s ON s.ServiceID=sr.ServiceID

                        WHERE EncId=@EncID 
                        AND ( (p.ModID IN (5,28) AND p.TotalAmount>0) OR s.ServiceType=2)

                        ";
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@EncID", EncID);


        var dalData = new DataService();
        return dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);
    }

    public void EncCancelSave(bool IsCancel, int EncID, int PersID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@IsCancel", IsCancel);
        com.Parameters.AddWithValue("@EncID", EncID);
        com.Parameters.AddWithValue("@PersID", PersID);

        var dalData = new DataService();
        dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spEncCancel");
    }

    public Models.Enc EncSearch(Models.Enc enc, bool IsContactDisplay)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@EncID", enc.EncID);
        com.Parameters.AddWithValue("@IsContactDisplay", IsContactDisplay);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spEncSearch");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Enc>(dRow);
    }

    private static int SafeNonNegative(int value) => value < 0 ? 0 : value;

}