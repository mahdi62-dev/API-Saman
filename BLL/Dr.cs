using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class Dr
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();
    private readonly DataService _dalDataService = new();

    public List<Models.Dr> GetDrList(string strWehere)
    {
        var dt = _dalDataService.LoadData(CSet.cnStringHIS, "*", "vDr", strWehere, null);
        var EncDrList = new List<Models.Dr>();
        EncDrList = _appConvertDtToList.ConvertDataTable<Models.Dr>(dt);
        return EncDrList;
    }

    public List<Models.Dr> GetDrListPortal(string strWehere)
    {
        var dt = _dalDataService.LoadData(CSet.cnStringPortal, "*", "vDr", strWehere, null);
        var EncDrList = new List<Models.Dr>();
        EncDrList = _appConvertDtToList.ConvertDataTable<Models.Dr>(dt);
        return EncDrList;
    }


    //public int EncTotalPayAmount(int EncID)
    //{
    //    

    //    SqlCommand com = new SqlCommand();
    //    com.Parameters.AddWithValue("@EncID", EncID);

    //    var dalData = new DataService();
    //    var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);

    //    return Convert.ToInt32(dt.Rows[0]["TotalPayAmount"]);
    //}

    public List<Models.Dr> GetDrListPortal(SqlCommand com)
    {
        var tsql = @"SELECT *
                    FROM vDR
                    --WHERE MasterID = @MasterID
                    WHERE FullNameEn LIKE @MasterName AND IsDisable = 0";

        var dt = _dalDataService.GetDataTableByText(CSet.cnStringPortal, com, tsql);
        return _appConvertDtToList.ConvertDataTable<Models.Dr>(dt);
    }

    public Models.Dr GetDrPortal(SqlCommand com)
    {
        var tsql = @"SELECT *
                    FROM vDR
                   
                    WHERE FullNameEn = @MasterName AND IsDisable = 0";

        var dt = _dalDataService.GetDataTableByText(CSet.cnStringPortal, com, tsql);


        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Dr>(dRow);
    }
}