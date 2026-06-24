using System.Data;
using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class DrReport
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public DocReport DocReportLoad(object CRUD, object PageID)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@PageID", PageID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDocReport");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<DocReport>(dRow);
    }
}