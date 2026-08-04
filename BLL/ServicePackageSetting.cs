using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class ServicePackageSetting
{
    private readonly ConvertDtToList _convert = new();

    public List<BLL.Models.ServicePackageSetting> PackageList(int packageType = 0, int depID = 0, int wardID = 0, bool showDisabled = true)
    {
        var com = new SqlCommand();
        AddParam(com, "@PackageType", packageType);
        AddParam(com, "@DepID", depID);
        AddParam(com, "@WardID", wardID);
        AddParam(com, "@ShowDisabled", showDisabled);

        const string tsql = @"
SELECT
    p.PackageID,
    p.DepID,
    ISNULL(d.Name, N'') AS DepName,
    ISNULL(p.WardID, 0) AS WardID,
    ISNULL(w.WardName, N'') AS WardName,
    ISNULL(p.PackageType, 1) AS PackageType,
    p.PackageCode,
    ISNULL(p.PackageName, N'') AS PackageName,
    ISNULL(p.StartDate, N'') AS StartDate,
    ISNULL(p.EndDate, N'') AS EndDate,
    ISNULL(p.IsDisable, 0) AS IsDisable,
    ISNULL(p.SortID, 0) AS SortID,
    ISNULL(p.Explain, N'') AS Explain,
    ISNULL(p.CenterID, 1) AS CenterID,
    ISNULL(p.UserPersID, 0) AS UserPersID,
    ISNULL(p.ActionDate, N'') AS ActionDate,
    ISNULL(i.ItemCount, 0) AS ItemCount
FROM dbo.ServicePackage p
LEFT JOIN dbo.Dep d ON d.DepID = p.DepID
LEFT JOIN dbo.InpWard w ON w.WardID = ISNULL(p.WardID, 0)
OUTER APPLY (SELECT COUNT(*) AS ItemCount FROM dbo.ServicePackageItem spi WHERE spi.ServicePakageID = p.PackageID AND ISNULL(spi.IsDisable, 0) = 0) i
WHERE (@PackageType = 0 OR ISNULL(p.PackageType, 1) = @PackageType)
  AND (@DepID = 0 OR p.DepID = @DepID)
  AND (@WardID = 0 OR ISNULL(p.WardID, 0) = @WardID)
  AND (@ShowDisabled = 1 OR ISNULL(p.IsDisable, 0) = 0)
ORDER BY ISNULL(p.SortID, 0), p.PackageCode, p.PackageName";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _convert.ConvertDataTable<BLL.Models.ServicePackageSetting>(dt);
    }

    public BLL.Models.ServicePackageSetting SavePackage(BLL.Models.ServicePackageSetting p)
    {
        var com = new SqlCommand();
        AddParam(com, "@PackageID", p.PackageID);
        AddParam(com, "@DepID", p.DepID);
        AddParam(com, "@WardID", p.WardID);
        AddParam(com, "@PackageType", p.PackageType <= 0 ? 1 : p.PackageType);
        AddParam(com, "@PackageCode", p.PackageCode);
        AddParam(com, "@PackageName", p.PackageName);
        AddParam(com, "@StartDate", p.StartDate);
        AddParam(com, "@EndDate", p.EndDate);
        AddParam(com, "@IsDisable", p.IsDisable);
        AddParam(com, "@SortID", p.SortID);
        AddParam(com, "@Explain", p.Explain);
        AddParam(com, "@CenterID", p.CenterID <= 0 ? 1 : p.CenterID);
        AddParam(com, "@UserPersID", p.UserPersID);

        const string tsql = @"
DECLARE @Now NCHAR(16) = dbo.SCurdatetime();

IF ISNULL(@PackageCode, 0) = 0
BEGIN
    SELECT @PackageCode = ISNULL(MAX(PackageCode), 0) + 1
    FROM dbo.ServicePackage
    WHERE DepID = @DepID;
END

IF ISNULL(@PackageID, 0) = 0
BEGIN
    INSERT INTO dbo.ServicePackage
    (DepID, PackageCode, PackageName, IsDisable, PackageType, WardID, StartDate, EndDate, SortID, Explain, CenterID, UserPersID, ActionDate)
    VALUES
    (@DepID, @PackageCode, @PackageName, @IsDisable, @PackageType, @WardID, @StartDate, @EndDate, @SortID, @Explain, @CenterID, @UserPersID, @Now);

    SET @PackageID = SCOPE_IDENTITY();
END
ELSE
BEGIN
    UPDATE dbo.ServicePackage
    SET DepID=@DepID,
        PackageCode=@PackageCode,
        PackageName=@PackageName,
        IsDisable=@IsDisable,
        PackageType=@PackageType,
        WardID=@WardID,
        StartDate=@StartDate,
        EndDate=@EndDate,
        SortID=@SortID,
        Explain=@Explain,
        CenterID=@CenterID,
        UserPersID=@UserPersID,
        ActionDate=@Now
    WHERE PackageID=@PackageID;
END

SELECT TOP 1
    p.PackageID,
    p.DepID,
    ISNULL(d.Name, N'') AS DepName,
    ISNULL(p.WardID, 0) AS WardID,
    ISNULL(w.WardName, N'') AS WardName,
    ISNULL(p.PackageType, 1) AS PackageType,
    p.PackageCode,
    ISNULL(p.PackageName, N'') AS PackageName,
    ISNULL(p.StartDate, N'') AS StartDate,
    ISNULL(p.EndDate, N'') AS EndDate,
    ISNULL(p.IsDisable, 0) AS IsDisable,
    ISNULL(p.SortID, 0) AS SortID,
    ISNULL(p.Explain, N'') AS Explain,
    ISNULL(p.CenterID, 1) AS CenterID,
    ISNULL(p.UserPersID, 0) AS UserPersID,
    ISNULL(p.ActionDate, N'') AS ActionDate,
    0 AS ItemCount
FROM dbo.ServicePackage p
LEFT JOIN dbo.Dep d ON d.DepID = p.DepID
LEFT JOIN dbo.InpWard w ON w.WardID = ISNULL(p.WardID, 0)
WHERE p.PackageID = @PackageID";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _convert.ConvertDataTable<BLL.Models.ServicePackageSetting>(dt).FirstOrDefault() ?? p;
    }

    public void DeletePackage(int packageID, int userPersID)
    {
        var com = new SqlCommand();
        AddParam(com, "@PackageID", packageID);
        AddParam(com, "@UserPersID", userPersID);

        const string tsql = @"
DECLARE @Now NCHAR(16) = dbo.SCurdatetime();
UPDATE dbo.ServicePackage SET IsDisable = 1, UserPersID = @UserPersID, ActionDate = @Now WHERE PackageID = @PackageID;";
        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }

    public List<ServicePackageItemSetting> ItemList(int packageID, bool showDisabled = true)
    {
        var com = new SqlCommand();
        AddParam(com, "@PackageID", packageID);
        AddParam(com, "@ShowDisabled", showDisabled);

        const string tsql = @"
SELECT
    i.ID,
    i.ServicePakageID,
    ISNULL(i.DepID, 0) AS DepID,
    ISNULL(i.ServiceID, 0) AS ServiceID,
    ISNULL(i.ServiceCategory, ISNULL(s.ServiceCategory, 0)) AS ServiceCategory,
    ISNULL(cat.Name, N'') AS ServiceCategoryName,
    ISNULL(i.ServiceCode, ISNULL(s.ServiceCode, 0)) AS ServiceCode,
    ISNULL(s.Name, N'') AS ServiceName,
    ISNULL(i.ServiceAdrID, 0) AS ServiceAdrID,
    ISNULL(i.ServiceNum, 1) AS ServiceNum,
    ISNULL(i.IsDisable, 0) AS IsDisable,
    ISNULL(i.SortID, 0) AS SortID,
    ISNULL(i.Explain, N'') AS Explain,
    ISNULL(i.CenterID, 1) AS CenterID,
    ISNULL(i.UserPersID, 0) AS UserPersID,
    ISNULL(i.ActionDate, N'') AS ActionDate
FROM dbo.ServicePackageItem i
LEFT JOIN dbo.Service s ON s.ServiceID = i.ServiceID
LEFT JOIN dbo.vADR cat ON cat.ADName = N'ServiceCategory' AND cat.ID = ISNULL(i.ServiceCategory, ISNULL(s.ServiceCategory, 0))
WHERE i.ServicePakageID = @PackageID
  AND (@ShowDisabled = 1 OR ISNULL(i.IsDisable, 0) = 0)
ORDER BY ISNULL(i.SortID, 0), i.ID";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _convert.ConvertDataTable<ServicePackageItemSetting>(dt);
    }

    public ServicePackageItemSetting SaveItem(ServicePackageItemSetting item)
    {
        var com = new SqlCommand();
        AddParam(com, "@ID", item.ID);
        AddParam(com, "@ServicePakageID", item.ServicePakageID);
        AddParam(com, "@DepID", item.DepID);
        AddParam(com, "@ServiceID", item.ServiceID);
        AddParam(com, "@ServiceCategory", item.ServiceCategory);
        AddParam(com, "@ServiceCode", item.ServiceCode);
        AddParam(com, "@ServiceAdrID", item.ServiceAdrID);
        AddParam(com, "@ServiceNum", item.ServiceNum <= 0 ? 1 : item.ServiceNum);
        AddParam(com, "@IsDisable", item.IsDisable);
        AddParam(com, "@SortID", item.SortID);
        AddParam(com, "@Explain", item.Explain);
        AddParam(com, "@CenterID", item.CenterID <= 0 ? 1 : item.CenterID);
        AddParam(com, "@UserPersID", item.UserPersID);

        const string tsql = @"
DECLARE @Now NCHAR(16) = dbo.SCurdatetime();

IF ISNULL(@ServiceID, 0) = 0 AND ISNULL(@ServiceCategory, 0) > 0 AND ISNULL(@ServiceCode, 0) > 0
BEGIN
    SELECT TOP 1 @ServiceID = ServiceID
    FROM dbo.Service
    WHERE ServiceCategory = @ServiceCategory
      AND ServiceCode = @ServiceCode
      AND ISNULL(IsDisable, 0) = 0
      AND (EndDate IS NULL OR LTRIM(RTRIM(EndDate)) = N'')
    ORDER BY ServiceID DESC;
END

IF ISNULL(@DepID, 0) = 0
    SELECT @DepID = DepID FROM dbo.ServicePackage WHERE PackageID = @ServicePakageID;

IF ISNULL(@ID, 0) = 0
BEGIN
    INSERT INTO dbo.ServicePackageItem
    (ServicePakageID, DepID, ServiceID, ServiceAdrID, ServiceCategory, ServiceCode, ServiceNum, IsDisable, SortID, Explain, CenterID, UserPersID, ActionDate)
    VALUES
    (@ServicePakageID, @DepID, @ServiceID, @ServiceAdrID, @ServiceCategory, @ServiceCode, @ServiceNum, @IsDisable, @SortID, @Explain, @CenterID, @UserPersID, @Now);

    SET @ID = SCOPE_IDENTITY();
END
ELSE
BEGIN
    UPDATE dbo.ServicePackageItem
    SET ServicePakageID=@ServicePakageID,
        DepID=@DepID,
        ServiceID=@ServiceID,
        ServiceAdrID=@ServiceAdrID,
        ServiceCategory=@ServiceCategory,
        ServiceCode=@ServiceCode,
        ServiceNum=@ServiceNum,
        IsDisable=@IsDisable,
        SortID=@SortID,
        Explain=@Explain,
        CenterID=@CenterID,
        UserPersID=@UserPersID,
        ActionDate=@Now
    WHERE ID=@ID;
END

SELECT TOP 1
    i.ID,
    i.ServicePakageID,
    ISNULL(i.DepID, 0) AS DepID,
    ISNULL(i.ServiceID, 0) AS ServiceID,
    ISNULL(i.ServiceCategory, ISNULL(s.ServiceCategory, 0)) AS ServiceCategory,
    ISNULL(cat.Name, N'') AS ServiceCategoryName,
    ISNULL(i.ServiceCode, ISNULL(s.ServiceCode, 0)) AS ServiceCode,
    ISNULL(s.Name, N'') AS ServiceName,
    ISNULL(i.ServiceAdrID, 0) AS ServiceAdrID,
    ISNULL(i.ServiceNum, 1) AS ServiceNum,
    ISNULL(i.IsDisable, 0) AS IsDisable,
    ISNULL(i.SortID, 0) AS SortID,
    ISNULL(i.Explain, N'') AS Explain,
    ISNULL(i.CenterID, 1) AS CenterID,
    ISNULL(i.UserPersID, 0) AS UserPersID,
    ISNULL(i.ActionDate, N'') AS ActionDate
FROM dbo.ServicePackageItem i
LEFT JOIN dbo.Service s ON s.ServiceID = i.ServiceID
LEFT JOIN dbo.vADR cat ON cat.ADName = N'ServiceCategory' AND cat.ID = ISNULL(i.ServiceCategory, ISNULL(s.ServiceCategory, 0))
WHERE i.ID=@ID";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _convert.ConvertDataTable<ServicePackageItemSetting>(dt).FirstOrDefault() ?? item;
    }

    public void DeleteItem(int itemID, int userPersID)
    {
        var com = new SqlCommand();
        AddParam(com, "@ID", itemID);
        AddParam(com, "@UserPersID", userPersID);

        const string tsql = @"
DECLARE @Now NCHAR(16) = dbo.SCurdatetime();
UPDATE dbo.ServicePackageItem SET IsDisable = 1, UserPersID = @UserPersID, ActionDate = @Now WHERE ID = @ID;";
        new DataService().ExecuteNonQueryByText(CSet.cnStringHIS, com, tsql);
    }

    public List<BLL.Models.Service> GetActiveServiceList(int serviceCategory = 0, string? searchText = null)
    {
        var com = new SqlCommand();
        AddParam(com, "@ServiceCategory", serviceCategory);
        AddParam(com, "@SearchText", searchText ?? "");

        const string tsql = @"
SELECT TOP 300
    s.ServiceID,
    s.ServiceType,
    s.ServiceCategory,
    s.ServiceCode,
    s.Name,
    s.Namelong,
    s.Price,
    ISNULL(cat.Name, N'') AS ServiceCategoryName
FROM dbo.Service s
LEFT JOIN dbo.vADR cat ON cat.ADName = N'ServiceCategory' AND cat.ID = s.ServiceCategory
WHERE ISNULL(s.IsDisable, 0) = 0
  AND (s.EndDate IS NULL OR LTRIM(RTRIM(s.EndDate)) = N'')
  AND (@ServiceCategory = 0 OR s.ServiceCategory = @ServiceCategory)
  AND (@SearchText = N'' OR s.Name LIKE N'%' + @SearchText + N'%' OR CONVERT(NVARCHAR(50), s.ServiceCode) LIKE N'%' + @SearchText + N'%')
ORDER BY s.ServiceCategory, s.ServiceCode, s.Name";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _convert.ConvertDataTable<BLL.Models.Service>(dt);
    }

    private static void AddParam(SqlCommand com, string name, object? value)
    {
        if (value is string s && string.IsNullOrWhiteSpace(s)) value = DBNull.Value;
        com.Parameters.AddWithValue(name, value ?? DBNull.Value);
    }
}
