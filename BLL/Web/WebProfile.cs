using System.Data;
using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.Web;

public class WebProfile
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();

    public Models.Web.WebProfile GetCodeFromMobile(Models.Web.WebProfile pro)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", pro.CRUD);
        com.Parameters.AddWithValue("@Mobile", pro.Mobile);
        com.Parameters.AddWithValue("@OTPCode", pro.OTPCode);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringPortal, com, "spOTP");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Web.WebProfile>(dRow);
    }

    public Models.Web.WebProfile ProfileCRUD(Models.Web.WebProfile profile)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", profile.CRUD);
        com.Parameters.AddWithValue("@FuncType", profile.FuncType);
        com.Parameters.AddWithValue("@CentID", profile.CentID);
        com.Parameters.AddWithValue("@PatientID", profile.PatientID);
        com.Parameters.AddWithValue("@WProfileID", profile.WProfileID);
        com.Parameters.AddWithValue("@NationalCode", profile.NationalCode);
        com.Parameters.AddWithValue("@FirstName", profile.FirstName);
        com.Parameters.AddWithValue("@LastName", profile.LastName);
        com.Parameters.AddWithValue("@FatherName", profile.FatherName);
        com.Parameters.AddWithValue("@Gender", profile.Gender);
        com.Parameters.AddWithValue("@BirthDate", profile.BirthDate);
        com.Parameters.AddWithValue("@Mobile", profile.Mobile);
        com.Parameters.AddWithValue("@City", profile.City);
        com.Parameters.AddWithValue("@Street", profile.Street);
        com.Parameters.AddWithValue("@Email", profile.Email);
        com.Parameters.AddWithValue("@Drowssap", profile.Drowssap);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringPortal, com, "spWebProfile");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Web.WebProfile>(dRow);
    }

    public List<Att> GetEncDocList(int crud, int funcType, API.BLL.Models.Web.Enc enc)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", crud);
        com.Parameters.AddWithValue("@FuncType", funcType);
        com.Parameters.AddWithValue("@CentID", enc.CenterID);
        com.Parameters.AddWithValue("@DrID", enc.DrID);
        com.Parameters.AddWithValue("@EncID", enc.EncID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringPortal, com, "spWebProfileFunc");

        return _appConvertDtToList.ConvertDataTable<Att>(dt);
    }

    public List<Models.SFForm> GetEncFormList(int crud, int funcType, API.BLL.Models.Web.Enc enc)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", crud);
        com.Parameters.AddWithValue("@FuncType", funcType);
        com.Parameters.AddWithValue("@CentID", enc.CenterID);
        com.Parameters.AddWithValue("@DrID", enc.DrID);
        com.Parameters.AddWithValue("@EncID", enc.EncID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringPortal, com, "spWebProfileFunc");

        return _appConvertDtToList.ConvertDataTable<Models.SFForm>(dt);
    }

    public List<API.BLL.Models.Web.Enc> GetEncHistoryList(int crud, int funcType, Guid wProfileID, int centid,
        string nationalcode)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", crud);
        com.Parameters.AddWithValue("@FuncType", funcType);
        com.Parameters.AddWithValue("@WProfileID", wProfileID);
        com.Parameters.AddWithValue("@CentID", centid);
        com.Parameters.AddWithValue("@NationalCode", nationalcode);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringPortal, com, "spWebProfileFunc");
        return _appConvertDtToList.ConvertDataTable<API.BLL.Models.Web.Enc>(dt);
    }
}