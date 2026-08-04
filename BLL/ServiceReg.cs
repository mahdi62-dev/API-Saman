using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class ServiceReg
{
    private readonly ConvertDtToList _appConvertDtToList = new();

    public DataTable ServiceRegLoad(int CRUD, int pageID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@pageID", pageID);


        var dalData = new DataService();
        return dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spServiceReg");
    }


    public List<Models.ServiceReg> ServiceRegLoadList(int CRUD, int pageID)
    {
        var srList = new List<Models.ServiceReg>();

        var dt = ServiceRegLoad(CRUD, pageID);
        srList = _appConvertDtToList.ConvertDataTable<Models.ServiceReg>(dt);

        return srList;
    }

    public void ServiceRegSave(int CRUD, int PageID, object StorageID, object StoragePeriodID, object DrID,
        object PersID, object SRID,
        object ServiceID, object Num, object ServiceCategory, long TotalAmountManual)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", CRUD);
        com.Parameters.AddWithValue("@PageID", PageID);
        com.Parameters.AddWithValue("@StorageID", StorageID);
        com.Parameters.AddWithValue("@StoragePeriodID", StoragePeriodID);
        com.Parameters.AddWithValue("@DrID", DrID);
        com.Parameters.AddWithValue("@PersID", PersID);
        com.Parameters.AddWithValue("@SRID", SRID);
        com.Parameters.AddWithValue("@ServiceID", ServiceID);
        com.Parameters.AddWithValue("@Num", Num);
        com.Parameters.AddWithValue("@ServiceCategory", ServiceCategory);
        com.Parameters.AddWithValue("@TotalAmountManual", TotalAmountManual);


        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringHIS, com, "spServiceReg");
    }



    public void UpdateServiceRegStaff(int srid, int drID, int persID)
    {
        if (srid <= 0) return;
        const string tsql = @"
            UPDATE dbo.ServiceReg
               SET DrID = @DrID,
                   PersID = @PersID
             WHERE SRID = @SRID";
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@SRID", srid);
        com.Parameters.AddWithValue("@DrID", drID);
        com.Parameters.AddWithValue("@PersID", persID);
        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }

    public DataTable DrReportListSearch(int PageID)
    {
        var tsql =
            "SELECT sr.SRID,DrReportList.ID,DrReportList.Name,DrReportList.Name3 FROM [SamanHIS].[dbo].[ServiceReg] sr INNER JOIN dbo.Service s ON s.ServiceID = sr.ServiceID INNER JOIN dbo.DrReportServiceAssign drs ON drs.ServiceCode = s.ServiceCode AND drs.ServiceCategory = s.ServiceCategory INNER JOIN dbo.vADR DrReportList ON DrReportList.ID = drs.DrReportID WHERE DrReportList.ADName = 'DrReportList' AND PageID = @PageID";
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@PageID", PageID);

        var dalData = new DataService();
        return dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);
    }
}