using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class EncToolbarAccessBLL
{
    private readonly ConvertDtToList _convert = new();

    public List<EncToolbarAccess> Load(int modID, int depID = 0)
    {
        var com = new SqlCommand();
        AddParam(com, "@CRUD", 1);
        AddParam(com, "@ModID", modID);
        AddParam(com, "@DepID", depID);
        var dt = new DataService().GetDataTableBySP(CSet.cnStringHIS, com, "spEncToolbarAccess");
        return _convert.ConvertDataTable<EncToolbarAccess>(dt);
    }

    public List<EncToolbarAccess> Save(EncToolbarAccess item)
    {
        var com = new SqlCommand();
        AddParam(com, "@CRUD", item.EncToolbarAccessID > 0 ? 2 : 0);
        AddParams(com, item);
        var dt = new DataService().GetDataTableBySP(CSet.cnStringHIS, com, "spEncToolbarAccess");
        return _convert.ConvertDataTable<EncToolbarAccess>(dt);
    }

    public List<EncToolbarAccess> Delete(EncToolbarAccess item)
    {
        var com = new SqlCommand();
        AddParam(com, "@CRUD", 4);
        AddParams(com, item);
        var dt = new DataService().GetDataTableBySP(CSet.cnStringHIS, com, "spEncToolbarAccess");
        return _convert.ConvertDataTable<EncToolbarAccess>(dt);
    }

    public bool IsAllowed(int modID, int depID, string actionNameEn)
    {
        // خواندن مستقیم یک آیتم تولبار از دیتابیس، بدون اتکا به کش یا لیست تبدیل‌شده.
        // اولویت: تنظیم دقیق DepID، سپس تنظیم عمومی DepID=0.
        // اگر برای آیتم خاص رکوردی وجود نداشته باشد، روال قبلی حفظ می‌شود و true برمی‌گردد.
        var com = new SqlCommand();
        AddParam(com, "@ModID", modID);
        AddParam(com, "@DepID", depID);
        AddParam(com, "@ActionNameEn", actionNameEn);

        const string tsql = @"
SELECT TOP 1
    CAST(CASE WHEN ISNULL(IsDisable, 0) = 0 AND ISNULL(IsVisible, 1) = 1 THEN 1 ELSE 0 END AS bit) AS IsAllowed
FROM dbo.EncToolbarAccess
WHERE ModID = @ModID
  AND ActionNameEn = @ActionNameEn
  AND (DepID = @DepID OR DepID = 0)
ORDER BY CASE WHEN DepID = @DepID THEN 0 ELSE 1 END";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        if (dt.Rows.Count == 0) return true;

        return Convert.ToBoolean(dt.Rows[0]["IsAllowed"]);
    }


    private static void AddParams(SqlCommand com, EncToolbarAccess item)
    {
        AddParam(com, "@EncToolbarAccessID", item.EncToolbarAccessID);
        AddParam(com, "@ModID", item.ModID);
        AddParam(com, "@DepID", item.DepID);
        AddParam(com, "@ActionNameEn", item.ActionNameEn);
        AddParam(com, "@Caption", item.Caption);
        AddParam(com, "@IsVisible", item.IsVisible);
        AddParam(com, "@IsDisable", item.IsDisable);
        AddParam(com, "@CenterID", item.CenterID);
        AddParam(com, "@UserPersID", item.UserPersID);
    }

    private static void AddParam(SqlCommand com, string name, object? value)
    {
        if (value is string str && string.IsNullOrWhiteSpace(str)) value = DBNull.Value;
        com.Parameters.AddWithValue(name, value ?? DBNull.Value);
    }
}
