using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.Lab;

public class LabAnswer
{
    private readonly ConvertDtToList _convert = new();

    public List<Models.LabWorkListItem> WorkList(int encID = 0, string? date1 = null, string? date2 = null, string? searchText = null, int status = -1, int financialStatus = -1, int filterServiceCode = 0)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", 1);
        com.Parameters.AddWithValue("@FuncType", 10);
        com.Parameters.AddWithValue("@EncID", encID);
        AddParam(com, "@Date1", date1);
        AddParam(com, "@Date2", date2);
        AddParam(com, "@SearchText", searchText);
        com.Parameters.AddWithValue("@Status", status);
        com.Parameters.AddWithValue("@FinancialStatus", financialStatus);
        com.Parameters.AddWithValue("@FilterServiceCode", filterServiceCode);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spLabAnswer");
        return _convert.ConvertDataTable<Models.LabWorkListItem>(dt);
    }


    public List<Models.LabTestFilterItem> TestFilterList(string? date1 = null, string? date2 = null)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", 1);
        com.Parameters.AddWithValue("@FuncType", 13);
        AddParam(com, "@Date1", date1);
        AddParam(com, "@Date2", date2);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spLabAnswer");
        return _convert.ConvertDataTable<Models.LabTestFilterItem>(dt);
    }

    public List<Models.LabPatientHistory> PatientHistory(int patientID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", 1);
        com.Parameters.AddWithValue("@FuncType", 11);
        com.Parameters.AddWithValue("@PatientID", patientID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spLabAnswer");
        return _convert.ConvertDataTable<Models.LabPatientHistory>(dt);
    }

    public List<Models.LabAnswerHeader> HeaderCRUD(Models.LabAnswerHeader h)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", h.CRUD);
        com.Parameters.AddWithValue("@FuncType", h.FuncType);
        com.Parameters.AddWithValue("@LabResultID", h.LabResultID);
        com.Parameters.AddWithValue("@EncID", h.EncID);
        com.Parameters.AddWithValue("@PatientID", h.PatientID);
        com.Parameters.AddWithValue("@PageID", h.PageID);
        AddParam(com, "@ResultNo", h.ResultNo);
        AddParam(com, "@LabNo", h.LabNo);
        AddParam(com, "@ResultDate", h.ResultDate);
        AddParam(com, "@SampleDate", h.SampleDate);
        com.Parameters.AddWithValue("@ReportStatus", h.ReportStatus);
        AddParam(com, "@Note", h.Note);
        com.Parameters.AddWithValue("@UserPersID", h.UserPersID);
        com.Parameters.AddWithValue("@CenterID", h.CenterID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spLabAnswer");
        return _convert.ConvertDataTable<Models.LabAnswerHeader>(dt);
    }

    public List<Models.LabAnswerItem> ItemCRUD(Models.LabAnswerItem item)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", item.CRUD);
        com.Parameters.AddWithValue("@FuncType", 0);
        com.Parameters.AddWithValue("@LabResultID", item.LabResultID);
        com.Parameters.AddWithValue("@LabResultItemID", item.LabResultItemID);
        com.Parameters.AddWithValue("@SRID", item.SRID);
        com.Parameters.AddWithValue("@ServiceID", item.ServiceID);
        com.Parameters.AddWithValue("@ServiceCode", item.ServiceCode);
        com.Parameters.AddWithValue("@ItemID", item.ItemID);
        AddParam(com, "@ItemName", item.ItemName);
        AddParam(com, "@CategoryName", item.CategoryName);
        AddParam(com, "@ResultValue", item.ResultValue);
        AddParam(com, "@Unit", item.Unit);
        AddParam(com, "@NormalLow", item.NormalLow);
        AddParam(com, "@NormalHigh", item.NormalHigh);
        AddParam(com, "@CriticalLow", item.CriticalLow);
        AddParam(com, "@CriticalHigh", item.CriticalHigh);
        AddParam(com, "@TextRange", item.TextRange);
        AddParam(com, "@UseDefaultResult", item.UseDefaultResult);
        AddParam(com, "@DefaultResult", item.DefaultResult);
        AddParam(com, "@AnswerType", item.AnswerType);
        AddParam(com, "@AnswerListADName", item.AnswerListADName);
        AddParam(com, "@ResultMin", item.ResultMin);
        AddParam(com, "@ResultMax", item.ResultMax);
        AddParam(com, "@RefRange", item.RefRange);
        AddParam(com, "@Flag", item.Flag);
        com.Parameters.AddWithValue("@IsCritical", item.IsCritical);
        com.Parameters.AddWithValue("@SortID", item.SortID);
        AddParam(com, "@ItemNote", item.Note);
        com.Parameters.AddWithValue("@UserPersID", item.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spLabAnswer");
        return _convert.ConvertDataTable<Models.LabAnswerItem>(dt);
    }

    public List<Models.LabAnswerItem> LoadItems(int labResultID, int pageID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", 1);
        com.Parameters.AddWithValue("@FuncType", 20);
        com.Parameters.AddWithValue("@LabResultID", labResultID);
        com.Parameters.AddWithValue("@PageID", pageID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spLabAnswer");
        return _convert.ConvertDataTable<Models.LabAnswerItem>(dt);
    }


    public List<Models.LabTrendPoint> Trend(int patientID, int itemID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", 1);
        com.Parameters.AddWithValue("@FuncType", 12);
        com.Parameters.AddWithValue("@PatientID", patientID);
        com.Parameters.AddWithValue("@ItemID", itemID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spLabAnswer");
        return _convert.ConvertDataTable<Models.LabTrendPoint>(dt);
    }

    private static void AddParam(SqlCommand com, string name, object? value)
    {
        if (value is string str && string.IsNullOrWhiteSpace(str))
            value = DBNull.Value;

        com.Parameters.AddWithValue(name, value ?? DBNull.Value);
    }
}
