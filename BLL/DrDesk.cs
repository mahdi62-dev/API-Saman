using System.Data;
using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class DrDesk
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();

    public List<DrDeskEncHistory> DrDeskEncHistoryCRUD(Models.DrDesk DrDesk)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@DrDeskID", DrDesk.DrDeskID);
        com.Parameters.AddWithValue("@EncID", DrDesk.EncID);
        com.Parameters.AddWithValue("@PatientID", DrDesk.PatientID);
        com.Parameters.AddWithValue("@FuncType", DrDesk.FuncType);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDrDesk");
        return _appConvertDtToList.ConvertDataTable<DrDeskEncHistory>(dt);
    }

    public List<DrDeskEncDocuments> DrDeskEncDocumentsCRUD(Models.DrDesk DrDesk)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@DrDeskID", DrDesk.DrDeskID);
        com.Parameters.AddWithValue("@EncID", DrDesk.EncID);
        com.Parameters.AddWithValue("@PatientID", DrDesk.PatientID);
        com.Parameters.AddWithValue("@FuncType", DrDesk.FuncType);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDrDesk");
        return _appConvertDtToList.ConvertDataTable<DrDeskEncDocuments>(dt);
    }

    public List<DrDeskEncServiceHistory> DrDeskEncServiceHistoryCRUD(Models.DrDesk DrDesk)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@DrDeskID", DrDesk.DrDeskID);
        com.Parameters.AddWithValue("@EncID", DrDesk.EncID);
        com.Parameters.AddWithValue("@PatientID", DrDesk.PatientID);
        com.Parameters.AddWithValue("@WProfileID", DrDesk.WProfileID);
        com.Parameters.AddWithValue("@FuncType", DrDesk.FuncType);
        com.Parameters.AddWithValue("@SFID", DrDesk.SFIDType);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDrDesk");
        return _appConvertDtToList.ConvertDataTable<DrDeskEncServiceHistory>(dt);
    }

    public DrDeskEncStatus DrDeskEncStatusCRUD(Models.DrDesk DrDesk)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@DrDeskID", DrDesk.DrDeskID);
        com.Parameters.AddWithValue("@EncID", DrDesk.EncID);
        com.Parameters.AddWithValue("@FuncType", DrDesk.FuncType);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDrDesk");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<DrDeskEncStatus>(dRow);
    }
}