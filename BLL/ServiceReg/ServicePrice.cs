using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class ServicePrice
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.ServicePrice ServicePriceCRUD(Models.ServicePrice s)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", s.CRUD);

        com.Parameters.AddWithValue("@FuncType", s.FuncType);

        com.Parameters.AddWithValue("@RegDate", s.RegDate);
        com.Parameters.AddWithValue("@ServiceID", s.ServiceID);
        com.Parameters.AddWithValue("@EncID", s.EncID);
        com.Parameters.AddWithValue("@DrID", s.DrID);
        com.Parameters.AddWithValue("@IsOIC", s.IsOIC);
        com.Parameters.AddWithValue("@ManualPrice", s.ManualPrice);
        com.Parameters.AddWithValue("@IsOpr", s.IsOpr);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spServicePrice");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.ServicePrice>(dRow);
    }

    //public DataTable ServicePriceLoad(object RegDate, int ServiceID, int EncID, int DrID, bool IsOIC,
    //    long ManualPrice, bool IsOpr)
    //{
    //    string TSQL =
    //        @" SELECT * FROM dbo.fntServicePrice (@RegDate,@ServiceID,@EncID,@DrID,@IsOIC,@ManualPrice,@IsOpr) ";


    //    SqlCommand com = new SqlCommand();
    //    com.Parameters.AddWithValue("@RegDate", RegDate == null ? DBNull.Value : RegDate);
    //    com.Parameters.AddWithValue("@ServiceID", ServiceID);
    //    com.Parameters.AddWithValue("@EncID", EncID);
    //    com.Parameters.AddWithValue("@DrID", DrID);

    //    com.Parameters.AddWithValue("@IsOIC", IsOIC);
    //    com.Parameters.AddWithValue("@ManualPrice", ManualPrice);
    //    com.Parameters.AddWithValue("@IsOpr", IsOpr);

    //    DataService dalData = new DataService();

    //    return dalData.GetDataTableByText(CSet.cnStringHIS, com, TSQL);

    //}
}