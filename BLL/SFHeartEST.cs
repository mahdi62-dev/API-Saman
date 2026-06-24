using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class SFHeartEST
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.SFHeartEST SFHeartESTCUD(Models.SFHeartEST SFHeartEST)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", SFHeartEST.CRUD);
        com.Parameters.AddWithValue("@SFHeartESTID", SFHeartEST.SFHeartESTID);
        com.Parameters.AddWithValue("@EncID", SFHeartEST.EncID);
        com.Parameters.AddWithValue("@PageID", SFHeartEST.PageID);
        com.Parameters.AddWithValue("@ServiceCode", SFHeartEST.ServiceCode);
        com.Parameters.AddWithValue("@Result", SFHeartEST.Result);
        com.Parameters.AddWithValue("@Note", SFHeartEST.Note);
        com.Parameters.AddWithValue("@UserPersID", SFHeartEST.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSFHeartEST");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.SFHeartEST>(dRow);
    }
}