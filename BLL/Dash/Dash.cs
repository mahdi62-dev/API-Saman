using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.Dash;

public class Dash
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();
    private DataService _dalDataService = new();

    public Models.Dash GetMartDash(Models.Dash dash)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", dash.CRUD);
        com.Parameters.AddWithValue("@CenterID", dash.CenterID);
        com.Parameters.AddWithValue("@QID", dash.QID);
        com.Parameters.AddWithValue("@Year", dash.Year);
        com.Parameters.AddWithValue("@Mon", dash.Mon);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringDC, com, "spMartDash");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Dash>(dRow);
    }

    public List<Models.Dash> GetMartDashList(Models.Dash dash)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", dash.CRUD);
        com.Parameters.AddWithValue("@CenterID", dash.CenterID);
        com.Parameters.AddWithValue("@QID", dash.QID);
        com.Parameters.AddWithValue("@Year", dash.Year);
        com.Parameters.AddWithValue("@Mon", dash.Mon);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringDC, com, "spMartDash");


        return _appConvertDtToList.ConvertDataTable<Models.Dash>(dt);
    }
}