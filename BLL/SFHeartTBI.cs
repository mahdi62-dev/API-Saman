using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class SFHeartTBI
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.SFHeartTBI SFHeartTBICUD(Models.SFHeartTBI SFHeartTBI)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", SFHeartTBI.CRUD);
        com.Parameters.AddWithValue("@SFHeartTBIID", SFHeartTBI.SFHeartTBIID);
        com.Parameters.AddWithValue("@EncID", SFHeartTBI.EncID);
        com.Parameters.AddWithValue("@PageID", SFHeartTBI.PageID);
        com.Parameters.AddWithValue("@ServiceCode", SFHeartTBI.ServiceCode);
        com.Parameters.AddWithValue("@LT", SFHeartTBI.LT);
        com.Parameters.AddWithValue("@RT", SFHeartTBI.RT);
        com.Parameters.AddWithValue("@UserPersID", SFHeartTBI.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSFHeartTBI");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.SFHeartTBI>(dRow);
    }
}