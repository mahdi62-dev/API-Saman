using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class AppVersionHistoryBLL
{
    private readonly ConvertDtToList _convert = new();

    public List<AppVersionHistory> LoadHistory(int top = 200)
    {
        const string tsql = @"
            SELECT TOP (@Top)
                   ChangeID,
                   VersionNo,
                   ReleaseDate,
                   Title,
                   ChangeText,
                   ChangeType,
                   IsActive,
                   SortID,
                   UserPersID,
                   ActionDate
            FROM SamanERP.dbo.AppVersionHistory
            WHERE ISNULL(IsActive, 1) = 1
            ORDER BY SortID DESC, ChangeID DESC";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@Top", top <= 0 ? 200 : top);

        var dal = new DataService();
        var dt = dal.GetDataTableByText(CSet.cnStringERP, com, tsql);
        return _convert.ConvertDataTable<AppVersionHistory>(dt);
    }

    public AppVersionHistory Latest()
    {
        return LoadHistory(1).FirstOrDefault() ?? new AppVersionHistory();
    }
}
