//namespace BLL.Report
//{
//    public class Report
//    {
//        public DataTable RepListAllLoad()
//        {
//            string tsql = @"
//                        SELECT *
//                        FROM SamanReport.dbo.vReport
//                        WHERE 1=1
//                        AND IsRep=1
//                        AND RepID>0
//                        ";

//            SqlCommand com = new SqlCommand();
//            //com.Parameters.AddWithValue("@RepID", RepID);

//            DataService dalData = new DataService();
//            return dalData.GetDataTableByText(CSet.cnStringReport, com, tsql);
//        }

//        public DataTable RepLoad(int RepID)
//        {
//            string tsql = @"
//                        SELECT *
//                        FROM SamanReport.dbo.vReport
//                        WHERE 1=1
//                        AND IsRep=1
//                        AND RepID=@RepID
//                        ";

//            SqlCommand com = new SqlCommand();
//            com.Parameters.AddWithValue("@RepID", RepID);

//            DataService dalData = new DataService();
//            return dalData.GetDataTableByText(CSet.cnStringReport, com, tsql);
//        }

//        public DataTable RepRun(object TSQL)
//        {
//            SqlCommand com = new SqlCommand();
//            com.Parameters.AddWithValue("@TSQL", TSQL);

//            DataService dalData = new DataService();
//            return dalData.GetDataTableBySP(CSet.cnStringReport, com, "spRunTSQL");
//        }

//        public DataTable RepFilterLoad(int RepID)
//        {
//            string tsql = @"
//                        SELECT *
//                        FROM SamanReport.dbo.vReportFilter
//                        WHERE 1=1
//                        --AND IsRep=1
//                        AND RepID=@RepID
//                        ";

//            SqlCommand com = new SqlCommand();
//            com.Parameters.AddWithValue("@RepID", RepID);

//            DataService dalData = new DataService();
//            return dalData.GetDataTableByText(CSet.cnStringReport, com, tsql);
//        }

//        public void RepRptFileSave(int RepID, string FileName, byte[] file, int UserPersID)
//        {
//            string tsql = @"
//                        DECLARE @SCurdatetime nchar(16)
//                        SELECT @SCurdatetime=SamanHIS.dbo.SCurdatetime()

//                        UPDATE dbo.ReportFile
//                          SET FileName=@FileName,
//                              RptFile=@RptFile,
//                              UserPersID=@UserPersID
//							  ActionDate=@SCurdatetime
//                          WHERE RepID=@RepID
//                        ";

//            SqlCommand com = new SqlCommand();
//            com.Parameters.AddWithValue("@RepID", RepID);
//            com.Parameters.AddWithValue("@FileName", FileName);
//            com.Parameters.AddWithValue("@RptFile", file);
//            com.Parameters.AddWithValue("@UserPersID", UserPersID);

//            DataService dalData = new DataService();
//            dalData.GetDataTableByText(CSet.cnStringReport, com, tsql);
//        }

//        public StiReport RepRptFileLoad(int RepID)
//        {
//            string TSQL = @"
//                        SELECT * 
//                        FROM dbo.ReportFile
//                        WHERE RepID=@RepID";

//            SqlCommand com = new SqlCommand();
//            com.Parameters.AddWithValue("@RepID", RepID);


//            DataService dalData = new DataService();
//            DataTable dt = new DataTable();
//            dt = dalData.GetDataTableByText(CSet.cnStringReport, com, TSQL);

//            StiReport report = new StiReport();

//            report.Load((byte[])dt.Rows[0]["RptFile"]);


//            return report;
//        }

//        public DataTable RepRptFileLoadDB(int RepID1)
//        {
//            string TSQL = @"
//                        SELECT * 
//                        FROM dbo.vReport
//                        WHERE RepID=@RepID
//                        AND RepType=2 ";

//            SqlCommand com = new SqlCommand();
//            com.Parameters.AddWithValue("@RepID", RepID1);

//            DataService dalData = new DataService();
//            return dalData.GetDataTableByText(CSet.cnStringReport, com, TSQL);
//        }
//    }
//}

