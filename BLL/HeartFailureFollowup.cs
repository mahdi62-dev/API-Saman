using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class HeartFailureFollowup
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();


    public List<HeartFailureFollowupHistoryItem> DrPrescriptionItemListLoadByEncID(int CRUD, int FuncType, int EncID,
        string date)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@FuncType", FuncType);
        com.Parameters.AddWithValue("@EncID", EncID);
        com.Parameters.AddWithValue("@Date", date);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spHeartFailureFollowUp");
        return _appConvertDtToList.ConvertDataTable<HeartFailureFollowupHistoryItem>(dt);
    }
}