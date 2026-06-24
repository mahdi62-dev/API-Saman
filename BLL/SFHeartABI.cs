using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class SFHeartABI
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.SFHeartABI SFHeartABICUD(Models.SFHeartABI SFHeartABI)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", SFHeartABI.CRUD);
        com.Parameters.AddWithValue("@SFHeartABIID", SFHeartABI.SFHeartABIID);
        com.Parameters.AddWithValue("@EncID", SFHeartABI.EncID);
        com.Parameters.AddWithValue("@PageID", SFHeartABI.PageID);
        com.Parameters.AddWithValue("@ServiceCode", SFHeartABI.ServiceCode);
        com.Parameters.AddWithValue("@LT", SFHeartABI.LT);
        com.Parameters.AddWithValue("@RT", SFHeartABI.RT);
        com.Parameters.AddWithValue("@UserPersID", SFHeartABI.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSFHeartABI");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.SFHeartABI>(dRow);
    }
}