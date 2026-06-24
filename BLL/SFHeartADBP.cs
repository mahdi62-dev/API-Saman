using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class SFHeartADBP
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.SFHeartADBP SFHeartADBPCUD(Models.SFHeartADBP SFHeartADBP)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", SFHeartADBP.CRUD);
        com.Parameters.AddWithValue("@SFHeartADBPID", SFHeartADBP.SFHeartADBPID);
        com.Parameters.AddWithValue("@EncID", SFHeartADBP.EncID);
        com.Parameters.AddWithValue("@PageID", SFHeartADBP.PageID);
        com.Parameters.AddWithValue("@ServiceCode", SFHeartADBP.ServiceCode);
        com.Parameters.AddWithValue("@LTSystolic", SFHeartADBP.LTSystolic);
        com.Parameters.AddWithValue("@LTDiastolic", SFHeartADBP.LTDiastolic);
        com.Parameters.AddWithValue("@RTSystolic", SFHeartADBP.RTSystolic);
        com.Parameters.AddWithValue("@RTDiastolic", SFHeartADBP.RTDiastolic);
        com.Parameters.AddWithValue("@HR", SFHeartADBP.HR);
        com.Parameters.AddWithValue("@UserPersID", SFHeartADBP.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSFHeartADBP");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.SFHeartADBP>(dRow);
    }
}