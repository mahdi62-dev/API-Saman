using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.Lab;

public class LabReference
{
    private readonly ConvertDtToList _convert = new();

    public List<Models.LabReference> GetCurrent(int serviceCode = 0, int serviceType = 3, int serviceCategory = 150)
    {
        var tsql = @"
SELECT *
FROM dbo.vLabTestReferenceCurrent
WHERE (@ServiceCode = 0 OR ServiceCode = @ServiceCode)
  AND ServiceType = @ServiceType
  AND ServiceCategory = @ServiceCategory
ORDER BY CategoryName, TestNameFa, ServiceCode";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@ServiceCode", serviceCode);
        com.Parameters.AddWithValue("@ServiceType", serviceType);
        com.Parameters.AddWithValue("@ServiceCategory", serviceCategory);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _convert.ConvertDataTable<Models.LabReference>(dt);
    }

    public List<Models.LabReference> LabReferenceCRUD(Models.LabReference r)
    {
        var com = new SqlCommand();
        AddParam(com, "@CRUD", r.CRUD);
        AddParam(com, "@LabRefID", r.LabRefID);
        AddParam(com, "@ServiceID", r.ServiceID);
        AddParam(com, "@ServiceCode", r.ServiceCode);
        AddParam(com, "@ServiceType", r.ServiceType);
        AddParam(com, "@ServiceCategory", r.ServiceCategory);
        AddParam(com, "@TestCode", r.TestCode);
        AddParam(com, "@TestNameFa", r.TestNameFa);
        AddParam(com, "@TestNameEn", r.TestNameEn);
        AddParam(com, "@CategoryName", r.CategoryName);
        AddParam(com, "@Gender", r.Gender);
        AddParam(com, "@AgeFromDay", r.AgeFromDay);
        AddParam(com, "@AgeToDay", r.AgeToDay);
        AddParam(com, "@Unit", r.Unit);
        AddParam(com, "@NormalLow", r.NormalLow);
        AddParam(com, "@NormalHigh", r.NormalHigh);
        AddParam(com, "@CriticalLow", r.CriticalLow);
        AddParam(com, "@CriticalHigh", r.CriticalHigh);
        AddParam(com, "@TextRange", r.TextRange);
        AddParam(com, "@UseDefaultResult", r.UseDefaultResult);
        AddParam(com, "@DefaultResult", r.DefaultResult);
        AddParam(com, "@AnswerType", r.AnswerType);
        AddParam(com, "@AnswerListADName", r.AnswerListADName);
        AddParam(com, "@ResultMin", r.ResultMin);
        AddParam(com, "@ResultMax", r.ResultMax);
        AddParam(com, "@MethodName", r.MethodName);
        AddParam(com, "@AnalyzerName", r.AnalyzerName);
        AddParam(com, "@KitName", r.KitName);
        AddParam(com, "@SourceTitle", r.SourceTitle);
        AddParam(com, "@StartDate", r.StartDate);
        AddParam(com, "@EndDate", r.EndDate);
        AddParam(com, "@IsDefault", r.IsDefault);
        AddParam(com, "@IsApproved", r.IsApproved);
        AddParam(com, "@IsDisable", r.IsDisable);
        AddParam(com, "@CenterID", r.CenterID);
        AddParam(com, "@UserPersID", r.UserPersID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spLabReferenceSetting");
        return _convert.ConvertDataTable<Models.LabReference>(dt);
    }

    private static void AddParam(SqlCommand com, string name, object? value)
    {
        if (value is string str && string.IsNullOrWhiteSpace(str))
            value = DBNull.Value;

        com.Parameters.AddWithValue(name, value ?? DBNull.Value);
    }
}
