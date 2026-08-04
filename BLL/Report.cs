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
        com.CommandTimeout = 120;
        com.Parameters.AddWithValue("@RepType", RepType);
        com.Parameters.AddWithValue("@Date1", (object?)Date1 ?? DBNull.Value);
        com.Parameters.AddWithValue("@Date2", (object?)Date2 ?? DBNull.Value);
        com.Parameters.AddWithValue("@Year", Year);
        com.Parameters.AddWithValue("@Mon", Mon);
        com.Parameters.AddWithValue("@TSQL", TSQL ?? DBNull.Value);

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

    public List<ReportRun> ReportEditorList()
    {
        const string tsql = @"
            SELECT RepID, RepCode, IsRep, RepType, CenterName, Name, FullName, TSQL, PaperSize, IsLandscape, ParentID, FileName
            FROM SamanReport.dbo.vReport
            WHERE RepID >= 0
            ORDER BY ParentID, IsRep, RepID";

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringReport, new SqlCommand(), tsql);
        return _appConvertDtToList.ConvertDataTable<ReportRun>(dt);
    }

    public ReportRun ReportEditorLoad(int repID)
    {
        const string tsql = @"
            SELECT RepID, RepCode, IsRep, RepType, CenterName, Name, FullName, TSQL, PaperSize, IsLandscape, ParentID, FileName
            FROM SamanReport.dbo.vReport
            WHERE RepID = @RepID";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@RepID", repID);
        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringReport, com, tsql);
        if (dt.Rows.Count == 0) return new ReportRun();
        return _appConvertDRowToModel.CreateItemFromRow<ReportRun>(dt.Rows[0]);
    }

    public int ReportEditorNextRepID()
    {
        const string tsql = @"SELECT ISNULL(MAX(RepID), 0) + 1 AS RepID FROM SamanReport.dbo.Report WHERE RepType = 1";
        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringReport, new SqlCommand(), tsql);
        return dt.Rows.Count == 0 ? 1 : Convert.ToInt32(dt.Rows[0]["RepID"]);
    }

    public void ReportEditorSave(ReportRun rep)
    {
        const string tsql = @"
            IF EXISTS (SELECT 1 FROM SamanReport.dbo.Report WHERE RepID = @RepID)
            BEGIN
                UPDATE SamanReport.dbo.Report
                   SET RepType     = @RepType,
                       Name        = @Name,
                       TSQL        = @TSQL,
                       PaperSize   = @PaperSize,
                       IsLandscape = @IsLandscape,
                       ParentID    = @ParentID,
                       RepCode     = @RepCode,
                       IsRep       = @IsRep
                 WHERE RepID = @RepID;
            END
            ELSE
            BEGIN
                INSERT INTO SamanReport.dbo.Report
                    (RepID, RepType, Name, TSQL, PaperSize, IsLandscape, ParentID, RepCode, IsRep)
                VALUES
                    (@RepID, @RepType, @Name, @TSQL, @PaperSize, @IsLandscape, @ParentID, @RepCode, @IsRep);
            END";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@RepID", rep.RepID);
        com.Parameters.AddWithValue("@RepType", rep.RepType);
        com.Parameters.AddWithValue("@Name", (object?)rep.Name ?? DBNull.Value);
        com.Parameters.AddWithValue("@TSQL", (object?)rep.TSQL ?? DBNull.Value);
        com.Parameters.AddWithValue("@PaperSize", (object?)rep.PaperSize ?? DBNull.Value);
        com.Parameters.AddWithValue("@IsLandscape", rep.IsLandscape);
        com.Parameters.AddWithValue("@ParentID", rep.ParentID);
        com.Parameters.AddWithValue("@RepCode", (object?)rep.RepCode ?? DBNull.Value);
        com.Parameters.AddWithValue("@IsRep", rep.IsRep);

        var dalData = new DataService();
        dalData.ExecuteNonQueryByText(CSet.cnStringReport, com, tsql);
    }

}