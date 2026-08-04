using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class AppUserSessionBLL
{
    private readonly ConvertDtToList _convert = new();

    public string CreateSession(int operID, int operPersID, string? route = null, int modID = 0, int depID = 0, int encID = 0, int expireHours = 12)
    {
        var sessionID = Guid.NewGuid().ToString("N");

        const string tsql = @"
            SET NOCOUNT ON;
            DECLARE @Now NCHAR(16);
            SELECT @Now = SamanERP.dbo.SCurdatetime();

            INSERT INTO SamanERP.dbo.AppUserSession
                (SessionID, OperID, OperPersID, LastRoute, ModID, DepID, EncID, ExpireAt, IsActive, CreateDate, LastAccessDate)
            VALUES
                (@SessionID, @OperID, @OperPersID, @LastRoute, @ModID, @DepID, @EncID, DATEADD(HOUR, @ExpireHours, SYSDATETIME()), 1, @Now, @Now);";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@SessionID", sessionID);
        com.Parameters.AddWithValue("@OperID", operID);
        com.Parameters.AddWithValue("@OperPersID", operPersID);
        com.Parameters.AddWithValue("@LastRoute", (object?)route ?? DBNull.Value);
        com.Parameters.AddWithValue("@ModID", modID);
        com.Parameters.AddWithValue("@DepID", depID);
        com.Parameters.AddWithValue("@EncID", encID);
        com.Parameters.AddWithValue("@ExpireHours", expireHours <= 0 ? 12 : expireHours);

        var dal = new DataService();
        dal.ExecuteNonQueryByText(CSet.cnStringERP, com, tsql);

        return sessionID;
    }

    public AppUserSession ValidateSession(string? sessionID, int extendHours = 12)
    {
        if (string.IsNullOrWhiteSpace(sessionID)) return new AppUserSession();

        const string tsql = @"
            SET NOCOUNT ON;
            DECLARE @Now NCHAR(16);
            SELECT @Now = SamanERP.dbo.SCurdatetime();

            UPDATE SamanERP.dbo.AppUserSession
               SET LastAccessDate = @Now,
                   ExpireAt = DATEADD(HOUR, @ExtendHours, SYSDATETIME())
             WHERE SessionID = @SessionID
               AND IsActive = 1
               AND ExpireAt > SYSDATETIME();

            SELECT TOP 1 SessionID, OperID, OperPersID, LastRoute, ModID, DepID, EncID, ExpireAt, IsActive, CreateDate, LastAccessDate
            FROM SamanERP.dbo.AppUserSession
            WHERE SessionID = @SessionID
              AND IsActive = 1
              AND ExpireAt > SYSDATETIME();";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@SessionID", sessionID);
        com.Parameters.AddWithValue("@ExtendHours", extendHours <= 0 ? 12 : extendHours);

        var dal = new DataService();
        var dt = dal.GetDataTableByText(CSet.cnStringERP, com, tsql);
        return _convert.ConvertDataTable<AppUserSession>(dt).FirstOrDefault() ?? new AppUserSession();
    }

    public void UpdateRoute(string? sessionID, string? route, int modID = 0, int depID = 0, int encID = 0)
    {
        if (string.IsNullOrWhiteSpace(sessionID)) return;

        const string tsql = @"
            SET NOCOUNT ON;
            DECLARE @Now NCHAR(16);
            SELECT @Now = SamanERP.dbo.SCurdatetime();

            UPDATE SamanERP.dbo.AppUserSession
               SET LastRoute = @LastRoute,
                   ModID = CASE WHEN @ModID > 0 THEN @ModID ELSE ModID END,
                   DepID = CASE WHEN @DepID > 0 THEN @DepID ELSE DepID END,
                   EncID = CASE WHEN @EncID > 0 THEN @EncID ELSE EncID END,
                   LastAccessDate = @Now
             WHERE SessionID = @SessionID
               AND IsActive = 1;";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@SessionID", sessionID);
        com.Parameters.AddWithValue("@LastRoute", (object?)route ?? DBNull.Value);
        com.Parameters.AddWithValue("@ModID", modID);
        com.Parameters.AddWithValue("@DepID", depID);
        com.Parameters.AddWithValue("@EncID", encID);

        var dal = new DataService();
        dal.ExecuteNonQueryByText(CSet.cnStringERP, com, tsql);
    }

    public void Logout(string? sessionID)
    {
        if (string.IsNullOrWhiteSpace(sessionID)) return;

        const string tsql = @"
            SET NOCOUNT ON;
            UPDATE SamanERP.dbo.AppUserSession
               SET IsActive = 0
             WHERE SessionID = @SessionID;";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@SessionID", sessionID);

        var dal = new DataService();
        dal.ExecuteNonQueryByText(CSet.cnStringERP, com, tsql);
    }
}
