using System.Data;
using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class Sch
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();

    public List<SchDef> SchDefLoad(SchDef SchDef, string StartDate, string EndDate)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", SchDef.CRUD);
        com.Parameters.AddWithValue("@FuncType", SchDef.FuncType);
        com.Parameters.AddWithValue("@DepID", SchDef.DepID);
        com.Parameters.AddWithValue("@DrID", SchDef.DrID);
        com.Parameters.AddWithValue("@StartDate", StartDate);
        com.Parameters.AddWithValue("@EndDate", EndDate);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSchDef");
        return _appConvertDtToList.ConvertDataTable<SchDef>(dt);
    }

    public List<Models.Sch> SchLoad(object CRUD, object SchDefID)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@SchDefID", SchDefID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSch");
        return _appConvertDtToList.ConvertDataTable<Models.Sch>(dt);
    }

    public void SchListSave(Models.Sch Sch)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", Sch.CRUD);
        com.Parameters.AddWithValue("@SchID", Sch.SchID);
        com.Parameters.AddWithValue("@SchDefID", Sch.SchDefID);
        com.Parameters.AddWithValue("@RecNo", Sch.RecNo);
        com.Parameters.AddWithValue("@EncID", Sch.EncID);
        com.Parameters.AddWithValue("@IsConfirm", Sch.IsConfirm);
        com.Parameters.AddWithValue("@FirstName", Sch.FirstName);
        com.Parameters.AddWithValue("@LastName", Sch.LastName);
        com.Parameters.AddWithValue("@FatherName", Sch.FatherName);
        com.Parameters.AddWithValue("@NationalCode", Sch.NationalCode);
        com.Parameters.AddWithValue("@Gender", Sch.Gender);
        com.Parameters.AddWithValue("@Mobile", Sch.Mobile);
        com.Parameters.AddWithValue("@Tel", Sch.Tel);
        com.Parameters.AddWithValue("@BirthDate", Sch.BirthDate);
        com.Parameters.AddWithValue("@Age", Sch.Age);
        com.Parameters.AddWithValue("@Country", Sch.Country);
        com.Parameters.AddWithValue("@City", Sch.City);
        com.Parameters.AddWithValue("@Insurance", Sch.Insurance);
        com.Parameters.AddWithValue("@ChiefComplaint", Sch.ChiefComplaint);
        com.Parameters.AddWithValue("@Height", Sch.Height);
        com.Parameters.AddWithValue("@Weight", Sch.Weight);
        com.Parameters.AddWithValue("@UnderlyingDisease", Sch.UnderlyingDisease);
        com.Parameters.AddWithValue("@Anes", Sch.Anes);
        com.Parameters.AddWithValue("@Description", Sch.Description);
        com.Parameters.AddWithValue("@F1", Sch.F1);
        com.Parameters.AddWithValue("@F2", Sch.F2);
        com.Parameters.AddWithValue("@F3", Sch.F3);
        com.Parameters.AddWithValue("@F4", Sch.F4);
        com.Parameters.AddWithValue("@F5", Sch.F5);
        com.Parameters.AddWithValue("@F6", Sch.F6);
        com.Parameters.AddWithValue("@F7", Sch.F7);
        com.Parameters.AddWithValue("@F8", Sch.F8);
        com.Parameters.AddWithValue("@F9", Sch.F9);
        com.Parameters.AddWithValue("@F10", Sch.F10);
        com.Parameters.AddWithValue("@F11", Sch.F11);
        com.Parameters.AddWithValue("@F12", Sch.F12);
        com.Parameters.AddWithValue("@F13", Sch.F13);
        com.Parameters.AddWithValue("@F14", Sch.F14);
        com.Parameters.AddWithValue("@F15", Sch.F15);
        com.Parameters.AddWithValue("@F16", Sch.F16);
        com.Parameters.AddWithValue("@F17", Sch.F17);
        com.Parameters.AddWithValue("@F18", Sch.F18);
        com.Parameters.AddWithValue("@F19", Sch.F19);
        com.Parameters.AddWithValue("@F20", Sch.F20);
        com.Parameters.AddWithValue("@IsCancel", Sch.IsCancel);
        com.Parameters.AddWithValue("@UserPersID", Sch.UserPersID);
        com.Parameters.AddWithValue("@RefDrID", Sch.RefDrID);
        com.Parameters.AddWithValue("@EncService", Sch.EncService);
        com.Parameters.AddWithValue("@SchTime", Sch.SchTime);

        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringHIS, com, "spSch");
    }


    public void SchConfirm(int CRUD, Models.Sch Sch, int FuncType)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@FuncType", FuncType);
        com.Parameters.AddWithValue("@SchDefID", Sch.SchDefID);
        com.Parameters.AddWithValue("@SchID", Sch.SchID);
        com.Parameters.AddWithValue("@IsConfirm", Sch.IsConfirm);

        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringHIS, com, "spSch");
    }


    public void SchCancel(int CRUD, Models.Sch Sch)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@SchID", Sch.SchID);
        com.Parameters.AddWithValue("@IsCancel", Sch.IsCancel);

        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringHIS, com, "spSch");
    }

    public void SchRecPaste(object CRUD, Models.Sch Sch, int SchDefID, object RecNo, bool IsCut, bool IsCopy)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);

        com.Parameters.AddWithValue("@IsPaste", 1);
        com.Parameters.AddWithValue("@IsCut", IsCut);
        com.Parameters.AddWithValue("@IsCopy", IsCopy);

        com.Parameters.AddWithValue("@SchDefID", SchDefID);
        com.Parameters.AddWithValue("@SchID", Sch.SchID);
        com.Parameters.AddWithValue("@RecNo", RecNo);


        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringHIS, com, "spSch");
    }

    public List<Models.Sch> SchSearch(object CRUD, string StartDate, string EndDate, int drId, int depId,
        object NationalCode, object Mobile, object FirstName, object LastName)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@StartDate", StartDate);
        com.Parameters.AddWithValue("@EndDate", EndDate);
        com.Parameters.AddWithValue("@DepID", drId);
        com.Parameters.AddWithValue("@DrID", depId);

        com.Parameters.AddWithValue("@NationalCode", NationalCode);
        com.Parameters.AddWithValue("@FirstName", FirstName);
        com.Parameters.AddWithValue("@LastName", LastName);
        com.Parameters.AddWithValue("@Mobile", Mobile);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSch");
        return _appConvertDtToList.ConvertDataTable<Models.Sch>(dt);
    }

    public void SchSave(Models.Sch Sch, int UserPersID)

    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", Sch.CRUD);
        com.Parameters.AddWithValue("@SchDefID", Sch.SchDefID);
        com.Parameters.AddWithValue("@SchID", Sch.SchID);
        com.Parameters.AddWithValue("@RecNo", Sch.RecNo);
        com.Parameters.AddWithValue("@NationalCode", Sch.NationalCode);
        com.Parameters.AddWithValue("@FirstName", Sch.FirstName);
        com.Parameters.AddWithValue("@LastName", Sch.LastName);
        com.Parameters.AddWithValue("@FatherName", Sch.FatherName);
        com.Parameters.AddWithValue("@Country", Sch.Country);
        com.Parameters.AddWithValue("@Gender", Sch.Gender);
        com.Parameters.AddWithValue("@BirthDate", Sch.BirthDate);
        com.Parameters.AddWithValue("@Age", Sch.Age);
        com.Parameters.AddWithValue("@Mobile", Sch.Mobile);
        com.Parameters.AddWithValue("@Tel", Sch.Tel);


        com.Parameters.AddWithValue("@City", Sch.City);
        com.Parameters.AddWithValue("@Description", Sch.Description);
        com.Parameters.AddWithValue("@ChiefComplaint", Sch.ChiefComplaint);
        com.Parameters.AddWithValue("@EncService", Sch.EncService);
        com.Parameters.AddWithValue("@RefDrID", Sch.RefDrID);
        com.Parameters.AddWithValue("@Insurance", Sch.Insurance);
        com.Parameters.AddWithValue("@Height", Sch.Height);
        com.Parameters.AddWithValue("@Weight", Sch.Weight);
        com.Parameters.AddWithValue("@UnderlyingDisease", Sch.UnderlyingDisease);
        com.Parameters.AddWithValue("@Anes", Sch.Anes);
        com.Parameters.AddWithValue("@F1", Sch.F1);
        com.Parameters.AddWithValue("@SchTime", Sch.SchTime);
        com.Parameters.AddWithValue("@IsConfirm", Sch.IsConfirm);

        com.Parameters.AddWithValue("@UserPersID", UserPersID);

        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringHIS, com, "spSch");
    }


    public Models.Sch SchRecLoad(object CRUD, object SchID)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@SchID", SchID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSch");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Sch>(dRow);
    }

    public void SchEncNew(int CRUD, int EncID, int SchID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@EncID", EncID);
        com.Parameters.AddWithValue("@SchID", SchID);

        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringHIS, com, "spSch");
    }

    public List<SchDef> SchDefLoadPortal(SchDef SchDef)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", SchDef.CRUD);
        com.Parameters.AddWithValue("@FuncType", SchDef.FuncType);
        com.Parameters.AddWithValue("@CentID", SchDef.CentID);
        com.Parameters.AddWithValue("@DrNationalCode", SchDef.DrNationalCode);
        com.Parameters.AddWithValue("@DepID", SchDef.DepID);
        com.Parameters.AddWithValue("@DrID", SchDef.DrID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSchDef");
        return _appConvertDtToList.ConvertDataTable<SchDef>(dt);
    }

    public Models.Sch SchLoadPortal(Models.Sch sch)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", sch.CRUD);
        com.Parameters.AddWithValue("@CentID", sch.CentID);
        com.Parameters.AddWithValue("@FuncType", sch.FuncType);
        com.Parameters.AddWithValue("@SchDefID", sch.SchDefID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSch");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Sch>(dRow);
    }

    public void SchSavePortal(Models.Sch Sch, int UserPersID)

    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", Sch.CRUD);
        com.Parameters.AddWithValue("@CentID", Sch.CentID);
        com.Parameters.AddWithValue("@SchDefID", Sch.SchDefID);
        com.Parameters.AddWithValue("@SchID", Sch.SchID);
        com.Parameters.AddWithValue("@RecNo", Sch.RecNo);
        com.Parameters.AddWithValue("@NationalCode", Sch.NationalCode);
        com.Parameters.AddWithValue("@FirstName", Sch.FirstName);
        com.Parameters.AddWithValue("@LastName", Sch.LastName);
        com.Parameters.AddWithValue("@FatherName", Sch.FatherName);
        com.Parameters.AddWithValue("@Country", Sch.Country);
        com.Parameters.AddWithValue("@Gender", Sch.Gender);
        com.Parameters.AddWithValue("@BirthDate", Sch.BirthDate);
        com.Parameters.AddWithValue("@Age", Sch.Age);
        com.Parameters.AddWithValue("@Mobile", Sch.Mobile);
        com.Parameters.AddWithValue("@Tel", Sch.Tel);


        com.Parameters.AddWithValue("@City", Sch.City);
        com.Parameters.AddWithValue("@Description", Sch.Description);
        com.Parameters.AddWithValue("@ChiefComplaint", Sch.ChiefComplaint);
        com.Parameters.AddWithValue("@EncService", Sch.EncService);
        com.Parameters.AddWithValue("@RefDrID", Sch.RefDrID);
        com.Parameters.AddWithValue("@Insurance", Sch.Insurance);
        com.Parameters.AddWithValue("@Height", Sch.Height);
        com.Parameters.AddWithValue("@Weight", Sch.Weight);
        com.Parameters.AddWithValue("@UnderlyingDisease", Sch.UnderlyingDisease);
        com.Parameters.AddWithValue("@Anes", Sch.Anes);
        com.Parameters.AddWithValue("@F1", Sch.F1);
        com.Parameters.AddWithValue("@SchTime", Sch.SchTime);

        com.Parameters.AddWithValue("@UserPersID", UserPersID);

        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringHIS, com, "spSch");
    }

    public List<Models.Sch> SchLoadPortal(object CRUD, int centid, int functype, object SchDefID)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@CentID", centid);
        com.Parameters.AddWithValue("@FuncType", functype);
        com.Parameters.AddWithValue("@SchDefID", SchDefID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSch");
        return _appConvertDtToList.ConvertDataTable<Models.Sch>(dt);
    }

    public void SchConfirmPortal(int CRUD, Models.Sch Sch, int FuncType)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@CentID", Sch.CentID);
        com.Parameters.AddWithValue("@FuncType", FuncType);
        com.Parameters.AddWithValue("@SchDefID", Sch.SchDefID);
        com.Parameters.AddWithValue("@SchID", Sch.SchID);
        com.Parameters.AddWithValue("@IsConfirm", true);

        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringHIS, com, "spSch");
    }
}