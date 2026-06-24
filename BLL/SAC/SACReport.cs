using System.Data;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.SAC;

public class SACReport
{
    public void SACReportSave(object RepID, object PersID, bool? Permission, object UserPersID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@RepID", RepID);
        com.Parameters.AddWithValue("@PersID", PersID);
        com.Parameters.AddWithValue("@Permission", Permission);

        com.Parameters.AddWithValue("@UserPersID", UserPersID);

        var dalData = new DataService();
        dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSACUserPermissionReport");
    }

    public DataTable SACReportLoad(int PersID)
    {
        var TSQL = @"SELECT RepID 
                            FROM SamanHIS.dbo.SACUserPermissionReport
                            WHERE PersID = @PersID";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@PersID", PersID);

        var dalData = new DataService();
        return dalData.GetDataTableByText(CSet.cnStringHIS, com, TSQL);
    }
}