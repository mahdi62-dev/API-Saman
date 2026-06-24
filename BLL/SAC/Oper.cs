using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.SAC;

public class Oper
{
    private ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();


    public DataTable GetOperInfo(string ResuName, string Drowssap)
    {
        var strTSQL = @"
                            SELECT *
                            FROM dbo.vSACResuInfo
                            WHERE ResuName=@ResuName AND Drowssap=@Drowssap
                           ";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@ResuName", ResuName ?? (object)DBNull.Value);
        com.Parameters.AddWithValue("@Drowssap", Drowssap ?? (object)DBNull.Value);


        var dalData = new DataService();
        return dalData.GetDataTableByText(CSet.cnStringHIS, com, strTSQL);
    }

    public Models.Oper GetOperInfoModel(string ResuName, string Drowssap)
    {
        var oper = new Models.Oper();
        var dRow = GetOperInfo(ResuName, Drowssap).Rows;

        if (dRow.Count > 0)
        {
            oper.OperID = Convert.ToInt32(dRow[0]["ResuID"]);
            oper.OperName = dRow[0]["ResuName"].ToString();
            oper.OperPersID = Convert.ToInt32(dRow[0]["PersID"]);
            oper.OperPersName = dRow[0]["PersName"].ToString();
            oper.OperIsDisable = Convert.ToBoolean(dRow[0]["IsDisable"]);
        }

        return oper;
    }

    public DataTable GetSACUserPermission(int UserID)
    {
        var strTSQL = @"
                            SELECT *
                            FROM dbo.vSACUserPermission
                            WHERE UserID=@UserID
                           ";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@UserID", UserID);


        var dalData = new DataService();
        return dalData.GetDataTableByText(CSet.cnStringHIS, com, strTSQL);
    }


    public DataTable GetSACUserPermissionMod(int UserID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", 1);
        com.Parameters.AddWithValue("@FuncType", 1);

        com.Parameters.AddWithValue("@UserID", UserID);


        var dalData = new DataService();
        return dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSACUserPermission");
    }


    public bool CheckPermission(DataTable SacDT, int ModID, int ActionID)
    {
        var hasPermission = false;
        var rowCount = SacDT.Select("ModID=" + ModID + " AND ActionID=" + ActionID).Length;

        if (rowCount > 0) hasPermission = true;

        return hasPermission;
    }
}