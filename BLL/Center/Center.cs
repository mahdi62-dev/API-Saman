using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.Center;

public class Center
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.Center GetCenterInfo()
    {
        var tsql = @"
                            SELECT *
                            FROM dbo.Center";

        var com = new SqlCommand();

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringERP, com, tsql);

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Center>(dRow);
    }

    public Models.Center GetCenterPortal(int centerID)
    {
        var tsql = @"
                    SELECT *
                    FROM dbo.Center
                    WHERE CenterID = @CenterID";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CenterID", centerID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringPortal, com, tsql);

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Center>(dRow);
    }
}