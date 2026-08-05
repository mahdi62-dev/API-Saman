using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.SAC;

public class Permission
{
    private readonly ConvertDtToList _appConvertDtToList = new();

    public List<Models.SAC.UserPermission> GetUserList(bool showDisabled = false)
    {
        var strTSQL = @"
SELECT ResuID, ResuName, Drowssap, PersID, PersName, IsDisable
FROM dbo.vSACResuInfo
WHERE (@ShowDisabled = 1 OR IsDisable = 0)
ORDER BY PersID, PersName, ResuName";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@ShowDisabled", showDisabled);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, strTSQL);
        return _appConvertDtToList.ConvertDataTable<Models.SAC.UserPermission>(dt);
    }

    public List<Models.SAC.SACPermissionItem> GetPermissionList(int resuID)
    {
        var strTSQL = @"
SELECT
    p.ActionID,
    ISNULL(p.ActionName, N'') AS ActionName,
    p.ModID,
    ISNULL(p.ActionNameEn, N'') AS ActionNameEn,
    p.ParentID,
    ISNULL(p.CenterID, 1) AS CenterID,
    ISNULL(parent.ActionName, N'') AS ParentName,
    ISNULL(modList.Name, N'') AS ModName,
    CAST(CASE WHEN up.ActionID IS NULL THEN 0 ELSE 1 END AS bit) AS IsAllow,
    CAST(0 AS bit) AS IsChanged
FROM dbo.SACPermission p
LEFT JOIN dbo.SACPermission parent ON parent.ActionID = p.ParentID
LEFT JOIN dbo.vMod modList ON modList.ID = p.ModID
LEFT JOIN dbo.SACUserPermission up ON up.ActionID = p.ActionID AND up.UserID = @ResuID
ORDER BY p.ModID, p.ParentID, p.ActionID";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@ResuID", resuID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, strTSQL);
        return _appConvertDtToList.ConvertDataTable<Models.SAC.SACPermissionItem>(dt);
    }

    public void SyncPermissionCatalog(IEnumerable<Models.SAC.SACPermissionSeedItem> permissionList)
    {
        const string tsql = @"
IF EXISTS (SELECT 1 FROM dbo.SACPermission WHERE ActionID = @ActionID OR ActionNameEn = @ActionNameEn)
BEGIN
    UPDATE dbo.SACPermission
    SET ActionName = @ActionName,
        ModID = @ModID,
        ActionNameEn = @ActionNameEn,
        ParentID = @ParentID,
        CenterID = @CenterID
    WHERE ActionID = @ActionID OR ActionNameEn = @ActionNameEn;
END
ELSE
BEGIN
    INSERT INTO dbo.SACPermission (ActionID, ActionName, ModID, ActionNameEn, ParentID, CenterID)
    VALUES (@ActionID, @ActionName, @ModID, @ActionNameEn, @ParentID, @CenterID);
END";

        var dalData = new DataService();

        foreach (var item in permissionList.OrderBy(p => p.ActionID))
        {
            var com = new SqlCommand();
            com.Parameters.AddWithValue("@ActionID", item.ActionID);
            com.Parameters.AddWithValue("@ActionName", item.ActionName ?? "");
            com.Parameters.AddWithValue("@ModID", item.ModID);
            com.Parameters.AddWithValue("@ActionNameEn", item.ActionNameEn ?? "");
            com.Parameters.AddWithValue("@ParentID", item.ParentID);
            com.Parameters.AddWithValue("@CenterID", item.CenterID == 0 ? 1 : item.CenterID);

            dalData.ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
        }
    }

    public void SyncDepPermissionCatalog()
    {
        const string tsql = @"
IF NOT EXISTS (SELECT 1 FROM dbo.SACPermission WHERE ActionID = 600000 OR ActionNameEn = N'DepAccess')
    INSERT INTO dbo.SACPermission(ActionID, ActionName, ModID, ActionNameEn, ParentID, CenterID)
    VALUES(600000, N'دسترسی بخش‌ها', 26, N'DepAccess', 0, 1);
ELSE
    UPDATE dbo.SACPermission SET ActionName=N'دسترسی بخش‌ها', ModID=26, ActionNameEn=N'DepAccess', ParentID=0, CenterID=1 WHERE ActionID=600000;

IF NOT EXISTS (SELECT 1 FROM dbo.SACPermission WHERE ActionID = 600100 OR ActionNameEn = N'DepAccess.Page')
    INSERT INTO dbo.SACPermission(ActionID, ActionName, ModID, ActionNameEn, ParentID, CenterID)
    VALUES(600100, N'بخش‌های مجاز در ثبت خدمات', 26, N'DepAccess.Page', 600000, 1);
ELSE
    UPDATE dbo.SACPermission SET ActionName=N'بخش‌های مجاز در ثبت خدمات', ModID=26, ActionNameEn=N'DepAccess.Page', ParentID=600000, CenterID=1 WHERE ActionID=600100;

IF NOT EXISTS (SELECT 1 FROM dbo.SACPermission WHERE ActionID = 600200 OR ActionNameEn = N'DepAccess.Enc')
    INSERT INTO dbo.SACPermission(ActionID, ActionName, ModID, ActionNameEn, ParentID, CenterID)
    VALUES(600200, N'بخش‌های مجاز در پذیرش', 26, N'DepAccess.Enc', 600000, 1);
ELSE
    UPDATE dbo.SACPermission SET ActionName=N'بخش‌های مجاز در پذیرش', ModID=26, ActionNameEn=N'DepAccess.Enc', ParentID=600000, CenterID=1 WHERE ActionID=600200;

;WITH D AS
(
    SELECT DepID, ISNULL(Name, N'') AS DepName
    FROM dbo.vDep
    WHERE DepID > 0
)
MERGE dbo.SACPermission AS T
USING
(
    SELECT 610000 + DepID AS ActionID,
           N'ثبت خدمات: ' + DepName AS ActionName,
           26 AS ModID,
           N'DepAccess.Page.' + CONVERT(NVARCHAR(20), DepID) AS ActionNameEn,
           600100 AS ParentID,
           1 AS CenterID
    FROM D
    UNION ALL
    SELECT 620000 + DepID AS ActionID,
           N'پذیرش: ' + DepName AS ActionName,
           26 AS ModID,
           N'DepAccess.Enc.' + CONVERT(NVARCHAR(20), DepID) AS ActionNameEn,
           600200 AS ParentID,
           1 AS CenterID
    FROM D
) AS S
ON T.ActionID = S.ActionID OR T.ActionNameEn = S.ActionNameEn
WHEN MATCHED THEN
    UPDATE SET ActionName=S.ActionName, ModID=S.ModID, ActionNameEn=S.ActionNameEn, ParentID=S.ParentID, CenterID=S.CenterID
WHEN NOT MATCHED THEN
    INSERT(ActionID, ActionName, ModID, ActionNameEn, ParentID, CenterID)
    VALUES(S.ActionID, S.ActionName, S.ModID, S.ActionNameEn, S.ParentID, S.CenterID);";

        var dalData = new DataService();
        dalData.ExecuteNonQueryByText(CSet.cnStringHIS, new SqlCommand(), tsql);
    }

    public Models.SAC.UserPermission SaveUserAccount(Models.SAC.UserPermission user, int userPersID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", 2);
        com.Parameters.AddWithValue("@ResuID", user.ResuID);
        com.Parameters.AddWithValue("@ResuName", string.IsNullOrWhiteSpace(user.ResuName) ? (object)DBNull.Value : user.ResuName);
        com.Parameters.AddWithValue("@Drowssap", string.IsNullOrWhiteSpace(user.Drowssap) ? (object)DBNull.Value : user.Drowssap);
        com.Parameters.AddWithValue("@PersID", user.PersID);
        com.Parameters.AddWithValue("@IsDisable", user.IsDisable);
        com.Parameters.AddWithValue("@UserPersID", userPersID);

        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringHIS, com, "spSACResuInfo");

        return GetUserList(true).FirstOrDefault(x => x.PersID == user.PersID && x.ResuName == user.ResuName) ?? user;
    }

    public void CopyUserPermission(int sourceResuID, int targetResuID, int userPersID)
    {
        const string tsql = @"
DECLARE @SCurdatetime NCHAR(16);
SELECT @SCurdatetime = dbo.SCurdatetime();

BEGIN TRAN;

DELETE FROM dbo.SACUserPermission
WHERE UserID = @TargetResuID;

INSERT INTO dbo.SACUserPermission (UserID, ModID, ActionID, UserPersID, ActionDate, CenterID)
SELECT @TargetResuID, ModID, ActionID, @UserPersID, @SCurdatetime, CenterID
FROM dbo.SACUserPermission
WHERE UserID = @SourceResuID;

COMMIT TRAN;";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@SourceResuID", sourceResuID);
        com.Parameters.AddWithValue("@TargetResuID", targetResuID);
        com.Parameters.AddWithValue("@UserPersID", userPersID);

        var dalData = new DataService();
        dalData.ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }



    public HashSet<int> GetAllowedDepIDs(int resuID, string accessType)
    {
        var result = new HashSet<int>();
        if (resuID <= 0 || string.IsNullOrWhiteSpace(accessType)) return result;

        var prefix = accessType.Equals("Enc", StringComparison.OrdinalIgnoreCase)
            ? "DepAccess.Enc."
            : "DepAccess.Page.";

        const string tsql = @"
SELECT p.ActionNameEn
FROM dbo.SACUserPermission up
INNER JOIN dbo.SACPermission p ON p.ActionID = up.ActionID
WHERE up.UserID = @ResuID
  AND p.ActionNameEn LIKE @Prefix + N'%'";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@ResuID", resuID);
        com.Parameters.AddWithValue("@Prefix", prefix);

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        foreach (DataRow row in dt.Rows)
        {
            var key = row["ActionNameEn"]?.ToString() ?? string.Empty;
            var idx = key.LastIndexOf('.');
            if (idx >= 0 && int.TryParse(key[(idx + 1)..], out var depID) && depID > 0)
                result.Add(depID);
        }

        return result;
    }

    public void SavePermission(int actionID, int resuID, int modID, bool permission, int userPersID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@ActionID", actionID);
        com.Parameters.AddWithValue("@ResuID", resuID);
        com.Parameters.AddWithValue("@ModID", modID);
        com.Parameters.AddWithValue("@Permission", permission);
        com.Parameters.AddWithValue("@UserPersID", userPersID);

        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringHIS, com, "spSACUserPermission");
    }

    public void SavePermissionList(IEnumerable<Models.SAC.SACPermissionItem> permissionList, int resuID, int userPersID)
    {
        foreach (var item in permissionList)
            SavePermission(item.ActionID, resuID, item.ModID, item.IsAllow, userPersID);
    }
}
