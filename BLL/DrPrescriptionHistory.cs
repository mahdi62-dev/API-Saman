using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class DrPrescriptionHistory
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();

    public Models.DrPrescriptionHistory DrPrescriptionHistoryCRUD(
        Models.DrPrescriptionHistory DrPrescriptionHistory, int EncID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", DrPrescriptionHistory.CRUD);
        com.Parameters.AddWithValue("@RecNO", DrPrescriptionHistory.RecNO);
        com.Parameters.AddWithValue("@ID", DrPrescriptionHistory.ID);
        com.Parameters.AddWithValue("@EncID", EncID);
        com.Parameters.AddWithValue("@PrescType", DrPrescriptionHistory.PrescType);
        com.Parameters.AddWithValue("@ItemID", DrPrescriptionHistory.ItemID);
        com.Parameters.AddWithValue("@Date2", DrPrescriptionHistory.Date2);
        com.Parameters.AddWithValue("@Num", DrPrescriptionHistory.Num);
        com.Parameters.AddWithValue("@UseTime", DrPrescriptionHistory.UseTime);
        com.Parameters.AddWithValue("@UseDose", DrPrescriptionHistory.UseDose);
        com.Parameters.AddWithValue("@Note", DrPrescriptionHistory.Note);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDrPrescriptionHistory");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.DrPrescriptionHistory>(dRow);
    }

    public List<Models.DrPrescriptionHistory> DrPrescriptionHistoryItemLoad(int CRUD, int EncID, int PrescType)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@EncID", EncID);
        com.Parameters.AddWithValue("@PrescType", PrescType);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDrPrescriptionHistory");
        return _appConvertDtToList.ConvertDataTable<Models.DrPrescriptionHistory>(dt);
    }
}