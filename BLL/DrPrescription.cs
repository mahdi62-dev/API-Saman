using System.Data;
using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class DrPrescription
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();

    public Models.DrPrescription DrPrescriptionCRUD(int CRUD, int FuncType,
        Models.DrPrescription DrPrescription, int EncID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@FuncType", FuncType);
        com.Parameters.AddWithValue("@RecNO", DrPrescription.RecNO);
        com.Parameters.AddWithValue("@DrPrescID", DrPrescription.DrPrescID);
        com.Parameters.AddWithValue("@EncID", EncID);
        com.Parameters.AddWithValue("@PrescType", DrPrescription.PrescType);
        com.Parameters.AddWithValue("@Date", DrPrescription.Date);
        com.Parameters.AddWithValue("@Date2", DrPrescription.Date2);
        com.Parameters.AddWithValue("@UserPersID", DrPrescription.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDrPrescription");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.DrPrescription>(dRow);
    }

    public Models.DrPrescription DrPrescriptionPre(int CRUD, int FuncType, int EncID, int PrescType)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@FuncType", FuncType);
        com.Parameters.AddWithValue("@EncID", EncID);
        com.Parameters.AddWithValue("@PrescType", PrescType);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDrPrescription");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.DrPrescription>(dRow);
    }

    public void DrPrescriptionItemCRUD(int CRUD, int DrPrescItemID, int DrPrescID, int ItemId, object Num,
        int UseTime, int UseDose, string Note)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@DrPrescItemID", DrPrescItemID);
        com.Parameters.AddWithValue("@DrPrescID", DrPrescID);
        com.Parameters.AddWithValue("@ItemId", ItemId);
        com.Parameters.AddWithValue("@Num", Num);
        com.Parameters.AddWithValue("@UseTime", UseTime);
        com.Parameters.AddWithValue("@UseDose", UseDose);
        com.Parameters.AddWithValue("@Note", Note);


        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringHIS, com, "spDrPrescriptionItem");
    }

    public DataTable DrPrescriptionItemLoad(int CRUD, int FuncType, int DrPrescID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@FuncType", FuncType);
        com.Parameters.AddWithValue("@DrPrescID", DrPrescID);


        var dalData = new DataService();
        return dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDrPrescriptionItem");
    }

    public List<DrPrescriptionItem> DrPrescriptionItemListLoadByEncID(int CRUD, int FuncType, int EncID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@FuncType", FuncType);
        com.Parameters.AddWithValue("@EncID", EncID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDrPrescriptionItem");
        return _appConvertDtToList.ConvertDataTable<DrPrescriptionItem>(dt);
    }

    public List<DrPrescriptionItem> DrPrescriptionItemList(int CRUD, int FuncType, int DrPrescID)
    {
        List<DrPrescriptionItem> dpList = new();

        var dt = DrPrescriptionItemLoad(CRUD, FuncType, DrPrescID);
        dpList = _appConvertDtToList.ConvertDataTable<DrPrescriptionItem>(dt);

        return dpList;
    }

    public List<DrPrescriptionItem> DrPrescriptionItemListPre(int CRUD, int FuncType, int EncID,
        int PrescType)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@FuncType", FuncType);
        com.Parameters.AddWithValue("@EncID", EncID);
        com.Parameters.AddWithValue("@PrescType", PrescType);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDrPrescription");

        var nl = _appConvertDtToList.ConvertDataTable<DrPrescriptionItem>(dt);
        return nl;
    }
}