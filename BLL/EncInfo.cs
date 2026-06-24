using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class EncInfo
{
    private readonly ConvertDtToList _appConvertDtToList = new();

    public List<Models.EncInfo> EncInfoCRUD(Models.EncInfo encinfo)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", encinfo.CRUD);
        com.Parameters.AddWithValue("@EncID", encinfo.EncID);
        com.Parameters.AddWithValue("@DepID", encinfo.DepID);
        com.Parameters.AddWithValue("@InfoStatus", encinfo.InfoStatus);
        com.Parameters.AddWithValue("@UserPersID", encinfo.UserPersID);
        com.Parameters.AddWithValue("@StartDate", encinfo.StartDate);
        //com.Parameters.AddWithValue("@EndDate", encinfo.EndDate);

        //com.Parameters.AddWithValue("@EncInfoID", encinfo.EncInfoID);
        //com.Parameters.AddWithValue("@EncID", encinfo.EncID);
        //com.Parameters.AddWithValue("@StartDate", encinfo.StartDate);
        //com.Parameters.AddWithValue("@EndDate", encinfo.EndDate);
        //com.Parameters.AddWithValue("@IsDisable", encinfo.IsDisable);
        //com.Parameters.AddWithValue("@DepID", encinfo.DepID);
        //com.Parameters.AddWithValue("@DrID", encinfo.DrID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spEncInfo");
        return _appConvertDtToList.ConvertDataTable<Models.EncInfo>(dt);
    }

    public List<Models.EncInfo> EncInfoCRUDMonitor(Models.EncInfo encinfo)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", encinfo.CRUD);
        //com.Parameters.AddWithValue("@FuncType", encinfo.FuncType);

        //com.Parameters.AddWithValue("@EncInfoID", encinfo.EncInfoID);
        //com.Parameters.AddWithValue("@EncID", encinfo.EncID);
        //com.Parameters.AddWithValue("@StartDate", encinfo.StartDate);
        //com.Parameters.AddWithValue("@EndDate", encinfo.EndDate);
        //com.Parameters.AddWithValue("@IsDisable", encinfo.IsDisable);
        //com.Parameters.AddWithValue("@DepID", encinfo.DepID);
        //com.Parameters.AddWithValue("@DrID", encinfo.DrID);
        //com.Parameters.AddWithValue("@UserPersID", encinfo.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spEncInfo");
        return _appConvertDtToList.ConvertDataTable<Models.EncInfo>(dt);
    }

    public List<TvSubtitle> TvSubtitleCRUD(TvSubtitle tvSubtitle)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", tvSubtitle.CRUD);
        //com.Parameters.AddWithValue("@FuncType", tvSubtitle.FuncType);

        //com.Parameters.AddWithValue("@EncInfoID", encinfo.EncInfoID);
        //com.Parameters.AddWithValue("@EncID", encinfo.EncID);
        //com.Parameters.AddWithValue("@StartDate", encinfo.StartDate);
        //com.Parameters.AddWithValue("@EndDate", encinfo.EndDate);
        //com.Parameters.AddWithValue("@IsDisable", encinfo.IsDisable);
        //com.Parameters.AddWithValue("@DepID", encinfo.DepID);
        //com.Parameters.AddWithValue("@DrID", encinfo.DrID);
        //com.Parameters.AddWithValue("@UserPersID", encinfo.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spEncInfo");
        return _appConvertDtToList.ConvertDataTable<TvSubtitle>(dt);
    }
}