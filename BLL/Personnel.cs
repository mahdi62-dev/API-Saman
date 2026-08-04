using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class Personnel
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();
    private readonly DataService _dalDataService = new();


    public List<Models.Personnel> GetPersList(string strWhere, string orderby)
    {
        var dt = _dalDataService.LoadData(CSet.cnStringHIS, "PersID, Name", "vPersonnel", strWhere, orderby);
        var PersList = new List<Models.Personnel>();
        PersList = _appConvertDtToList.ConvertDataTable<Models.Personnel>(dt);
        return PersList;
    }

    public List<Models.Personnel> GetPersListAll(string strWhere, string orderby)
    {
        var dt = _dalDataService.LoadData(CSet.cnStringERP, "*", "vPersonnel", strWhere, orderby);
        var PersList = new List<Models.Personnel>();
        PersList = _appConvertDtToList.ConvertDataTable<Models.Personnel>(dt);
        return PersList;
    }


    public Models.Personnel GetPersByNationalCode(string nationalCode, int currentPersID = 0)
    {
        if (string.IsNullOrWhiteSpace(nationalCode))
            return new Models.Personnel();

        var strTSQL = @"
SELECT TOP 1 PersID
FROM dbo.Personnel
WHERE NationalCode = @NationalCode
  AND (@CurrentPersID = 0 OR PersID <> @CurrentPersID)
ORDER BY PersID";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@NationalCode", nationalCode);
        com.Parameters.AddWithValue("@CurrentPersID", currentPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringERP, com, strTSQL);

        if (dt.Rows.Count == 0)
            return new Models.Personnel();

        var pers = new Models.Personnel
        {
            CRUD = 1,
            PersID = Convert.ToInt32(dt.Rows[0]["PersID"])
        };

        return PersCRUD(pers);
    }

    public Models.Personnel PersCRUD(Models.Personnel pers)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", pers.CRUD);
        com.Parameters.AddWithValue("@PersID", pers.PersID);
        //com.Parameters.AddWithValue("@CenterID", pers.CenterID);
        com.Parameters.AddWithValue("@NationalCode", pers.NationalCode);
        com.Parameters.AddWithValue("@FirstName", pers.FirstName);
        com.Parameters.AddWithValue("@LastName", pers.LastName);
        com.Parameters.AddWithValue("@FatherName", pers.FatherName);
        com.Parameters.AddWithValue("@Dep", pers.Dep);
        com.Parameters.AddWithValue("@PersType", pers.PersType);
        com.Parameters.AddWithValue("@Gender", pers.Gender);
        com.Parameters.AddWithValue("@IsDisable", pers.IsDisable);
        com.Parameters.AddWithValue("@IDCardNumber", pers.IDCardNumber);
        com.Parameters.AddWithValue("@BirthDate", pers.BirthDate);
        com.Parameters.AddWithValue("@MaritalStatus", pers.MaritalStatus);
        com.Parameters.AddWithValue("@Mobile", pers.Mobile);
        com.Parameters.AddWithValue("@Tel", pers.Tel);
        com.Parameters.AddWithValue("@City", pers.City);
        com.Parameters.AddWithValue("@Street", pers.Street);
        com.Parameters.AddWithValue("@AddressDetail", pers.AddressDetail);
        com.Parameters.AddWithValue("@ContractType", pers.ContractType);


        com.Parameters.AddWithValue("@Bank", pers.Bank);
        com.Parameters.AddWithValue("@BankAccountNumber", pers.BankAccountNumber);
        com.Parameters.AddWithValue("@Photo", pers.Photo);
        com.Parameters.AddWithValue("@Sign", pers.Sign);
        com.Parameters.AddWithValue("@DrRoleType", pers.DrRoleType);
        com.Parameters.AddWithValue("@IsSalary", pers.IsSalary);
        com.Parameters.AddWithValue("@IsInsurance", pers.IsInsurance);
        com.Parameters.AddWithValue("@IsPercase", pers.IsPercase);
        com.Parameters.AddWithValue("@ShareCount", pers.ShareCount);
        com.Parameters.AddWithValue("@RegNumber", pers.RegNumber);
        com.Parameters.AddWithValue("@AcademicLevel", pers.AcademicLevel);
        com.Parameters.AddWithValue("@IsFullTime", pers.IsFullTime);
        com.Parameters.AddWithValue("@Speciality", pers.Speciality);
        com.Parameters.AddWithValue("@DrExpert", pers.DrExpert);
        com.Parameters.AddWithValue("@DrExpertise", pers.DrExpertise);
        com.Parameters.AddWithValue("@DrLevel", pers.DrLevel);
        com.Parameters.AddWithValue("@DrUiType", pers.DrUiType);
        com.Parameters.AddWithValue("@Email", pers.Email);
        com.Parameters.AddWithValue("@Description", pers.Description);
        com.Parameters.AddWithValue("@ResuName", pers.ResuName);
        com.Parameters.AddWithValue("@Drowssap", pers.Drowssap);
        com.Parameters.AddWithValue("@Share", pers.Share);

        com.Parameters.AddWithValue("@FullNameEn", pers.FullNameEn);
        com.Parameters.AddWithValue("@SignTextEn", pers.SignTextEn);
        com.Parameters.AddWithValue("@SignTextFa", pers.SignTextFa);
        com.Parameters.AddWithValue("@DrIsPortal", pers.DrIsPortal);
        com.Parameters.AddWithValue("@Explain", pers.Explain);

        com.Parameters.AddWithValue("@UserPersID", pers.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringERP, com, "spPersonnel");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Personnel>(dRow);
    }
}