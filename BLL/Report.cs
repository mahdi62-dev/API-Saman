using System.Data;
using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;
using Stimulsoft.Report;

//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL;

public class Report
{
    private readonly ConvertDtToList _appConvertDtToList = new();
    private ConvertDRowToModel _appConvertDRowToModel = new();
    private DataService _dalDataService = new();

    public List<ReportQuery> ReportQueryCRUD(ReportQuery reportQuery)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", reportQuery.CRUD);
        com.Parameters.AddWithValue("@FuncType", reportQuery.FuncType);
        com.Parameters.AddWithValue("@RepID", reportQuery.RepID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringReport, com, "spReport");
        return _appConvertDtToList.ConvertDataTable<ReportQuery>(dt);
    }

    public List<ReportRun> ReportTreeLoad(ReportRun reportRun)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", reportRun.CRUD);
        com.Parameters.AddWithValue("@FuncType", reportRun.FuncType);
        com.Parameters.AddWithValue("@PersID", reportRun.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringReport, com, "spReport");
        return _appConvertDtToList.ConvertDataTable<ReportRun>(dt);
    }

    public List<ReportFilter> RepFilterLoad(ReportFilter reportfilter)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", reportfilter.CRUD);
        com.Parameters.AddWithValue("@FuncType", reportfilter.FuncType);
        com.Parameters.AddWithValue("@RepID", reportfilter.RepID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringReport, com, "spReport");
        return _appConvertDtToList.ConvertDataTable<ReportFilter>(dt);
    }

    public DataTable RepRun(int RepType, string Date1, string Date2, int Year, int Mon, object TSQL)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@RepType", RepType);
        com.Parameters.AddWithValue("@Date1", Date1);
        com.Parameters.AddWithValue("@Date2", Date2);
        com.Parameters.AddWithValue("@Year", Year);
        com.Parameters.AddWithValue("@Mon", Mon);
        com.Parameters.AddWithValue("@TSQL", TSQL);

        var dalData = new DataService();
        return dalData.GetDataTableBySP(CSet.cnStringReport, com, "spRunTSQL");
    }


    public StiReport RepRptStmFileLoad(string RepID)
    {
        var TSQL = @"
                        SELECT * 
                        FROM dbo.ReportFile
                        WHERE RepID=@RepID";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@RepID", RepID);


        var dalData = new DataService();
        var dt = new DataTable();
        dt = dalData.GetDataTableByText(CSet.cnStringReport, com, TSQL);

        var report = new StiReport();

        report.Load((byte[])dt.Rows[0]["RptFile"]);
        //report.LoadPackedDocument((byte[])dt.Rows[0]["RptFile"]);

        // report.Load(new MemoryStream((byte[]) dt.Rows[0]["RptFile"]));

        return report;
    }

    public void RepRptFileSave(int RepID, string FileName, byte[] file, int UserPersID)
    {
        var tsql = @"
                        DECLARE @SCurdatetime nchar(16)
                        SELECT @SCurdatetime=SamanHIS.dbo.SCurdatetime()

                        UPDATE dbo.ReportFile
                          SET FileName=@FileName,
                              RptFile=@RptFile,
                              UserPersID=@UserPersID,
							  ActionDate=@SCurdatetime
                          WHERE RepID=@RepID
                        ";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@RepID", RepID);
        com.Parameters.AddWithValue("@FileName", FileName);
        com.Parameters.AddWithValue("@RptFile", file);
        com.Parameters.AddWithValue("@UserPersID", UserPersID);

        var dalData = new DataService();
        dalData.GetDataTableByText(CSet.cnStringReport, com, tsql);
    }


    public List<ReportQuery> GetReportList(ReportQuery rep)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", rep.CRUD);
        com.Parameters.AddWithValue("@FuncType", rep.FuncType);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringReport, com, "spReport");
        return _appConvertDtToList.ConvertDataTable<ReportQuery>(dt);
    }

    public List<ReportQuery> GetReportAppList(ReportQuery rep)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", rep.CRUD);
        com.Parameters.AddWithValue("@FuncType", rep.FuncType);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringReport, com, "spReport");
        return _appConvertDtToList.ConvertDataTable<ReportQuery>(dt);
    }
}