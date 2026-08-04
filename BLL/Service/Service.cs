using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.Service;

public class Service
{
    private readonly ConvertDtToList _appConvertDtToList = new();

    public List<Models.Service> ServiceCRUD(Models.Service s)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", s.CRUD);
        com.Parameters.AddWithValue("@FuncType", s.FuncType);
        com.Parameters.AddWithValue("@DepID", s.DepID);

        com.Parameters.AddWithValue("@CentID", s.CenterID);
        com.Parameters.AddWithValue("@ServiceID", s.ServiceID);
        com.Parameters.AddWithValue("@ServiceType", s.ServiceType);
        com.Parameters.AddWithValue("@ServiceCategory", s.ServiceCategory);
        com.Parameters.AddWithValue("@ServiceCode", s.ServiceCode);
        AddParam(com, "@ServiceCode2", s.ServiceCode2);
        AddParam(com, "@Name", s.Name);
        AddParam(com, "@Namelong", s.Namelong);
        com.Parameters.AddWithValue("@Price", s.Price);
        AddParam(com, "@PriceB", s.PriceB);
        AddParam(com, "@PriceC", s.PriceC);
        AddParam(com, "@PriceD", s.PriceD);
        AddParam(com, "@PricePro", s.PricePro);
        AddParam(com, "@PriceTech", s.PriceTech);
        AddParam(com, "@MapIDA", s.MapIDA);
        AddParam(com, "@MapIDB", s.MapIDB);
        AddParam(com, "@StartDate", s.StartDate);
        AddParam(com, "@EndDate", s.EndDate);
        com.Parameters.AddWithValue("@IsTech", s.IsTech);
        com.Parameters.AddWithValue("@IsManualPrice", s.IsManualPrice);
        com.Parameters.AddWithValue("@ServicePriceType", s.ServicePriceType);
        com.Parameters.AddWithValue("@ServiceUnit", s.ServiceUnit);
        com.Parameters.AddWithValue("@ServiceUnit2", s.ServiceUnit2);
        com.Parameters.AddWithValue("@ServiceStatus", s.ServiceStatus);
        com.Parameters.AddWithValue("@IsDisable", s.IsDisable);
        com.Parameters.AddWithValue("@IsOIC", s.IsOIC);
        com.Parameters.AddWithValue("@UserPersID", s.UserPersID);

        var dalData = new DataService();

        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spService");
        return _appConvertDtToList.ConvertDataTable<Models.Service>(dt);
    }



    public int GetNextServiceCode(int serviceType, int serviceCategory)
    {
        const string tsql = @"
SELECT ISNULL(MAX(ServiceCode), 0) + 1 AS NextServiceCode
FROM dbo.Service
WHERE ServiceType = @ServiceType
  AND ServiceCategory = @ServiceCategory";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@ServiceType", serviceType);
        com.Parameters.AddWithValue("@ServiceCategory", serviceCategory);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);

        if (dt.Rows.Count == 0 || dt.Rows[0]["NextServiceCode"] == DBNull.Value)
            return 1;

        return Convert.ToInt32(dt.Rows[0]["NextServiceCode"]);
    }

    public Models.Service GetServiceByID(int serviceID)
    {
        const string tsql = @"
SELECT
    s.ServiceID,
    s.CenterID,
    s.ServiceType,
    s.ServiceCategory,
    s.ServiceCode,
    s.ServiceCode2,
    s.Name,
    s.Namelong,
    s.Price,
    s.PriceB,
    s.PriceC,
    s.PriceD,
    s.PricePro,
    s.PriceTech,
    s.MapIDA,
    s.MapIDB,
    s.StartDate,
    s.EndDate,
    s.IsTech,
    s.IsManualPrice,
    s.ServicePriceType,
    s.ServiceUnit,
    s.ServiceUnit2,
    s.ServiceStatus,
    s.IsDisable,
    s.IsOIC,
    ISNULL(sk.TotalK, 0) AS TotalK,
    ISNULL(sk.ProK, 0) AS ProK,
    ISNULL(sk.TechK, 0) AS TechK,
    ISNULL(sk.AnesK, 0) AS AnesK
FROM dbo.Service s
LEFT JOIN dbo.ServiceK sk ON sk.ServiceID = s.ServiceID
WHERE s.ServiceID = @ServiceID";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@ServiceID", serviceID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _appConvertDtToList.ConvertDataTable<Models.Service>(dt).FirstOrDefault() ?? new Models.Service();
    }

    public List<Models.Service> ServiceCreateNewVersion(Models.Service s)
    {
        s.CRUD = 6;
        return ServiceCRUD(s);
    }

    private static void AddParam(SqlCommand com, string name, object? value)
    {
        if (value is string str && string.IsNullOrWhiteSpace(str))
            value = DBNull.Value;

        com.Parameters.AddWithValue(name, value ?? DBNull.Value);
    }

    public List<Models.Service> ServicePakageItem(int ServicePackageID)
    {
        var tsql = @"
SELECT
    CAST(spi.ServicePakageID AS INT) AS PackageID,
    CAST(ISNULL(spi.ServiceID, s.ServiceID) AS INT) AS ServiceID,
    CAST(ISNULL(spi.ServiceCategory, s.ServiceCategory) AS SMALLINT) AS ServiceCategory,
    CAST(ISNULL(spi.ServiceCode, s.ServiceCode) AS INT) AS ServiceCode,
    CAST(ISNULL(spi.ServiceNum, 1) AS INT) AS ServiceNum,
    ISNULL(s.Name, N'') AS Name,
    ISNULL(unitAdr.Name, N'') AS ServiceUnitName,
    CAST(ISNULL(s.IsManualPrice, 0) AS BIT) AS IsManualPrice,
    CAST(ISNULL(s.ServiceType, 0) AS INT) AS ServiceType
FROM dbo.ServicePackageItem spi
OUTER APPLY
(
    SELECT TOP 1 sv.*
    FROM dbo.vService sv
    WHERE (ISNULL(spi.ServiceID, 0) > 0 AND sv.ServiceID = spi.ServiceID)
       OR (ISNULL(spi.ServiceID, 0) = 0 AND sv.ServiceCategory = spi.ServiceCategory AND sv.ServiceCode = spi.ServiceCode)
    ORDER BY CASE WHEN sv.ServiceID = spi.ServiceID THEN 0 ELSE 1 END, sv.ServiceID DESC
) s
LEFT JOIN dbo.vADR unitAdr ON unitAdr.ADName = N'ServiceUnit' AND unitAdr.ID = ISNULL(s.ServiceUnit, 0)
WHERE spi.ServicePakageID = @PackageID
  AND ISNULL(spi.IsDisable, 0) = 0
ORDER BY ISNULL(spi.SortID, 0), spi.ID";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@PackageID", ServicePackageID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);

        return _appConvertDtToList.ConvertDataTable<Models.Service>(dt);
    }


    public List<Models.Service> ServiceCRUDPortal(Models.Service s)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", s.CRUD);
        com.Parameters.AddWithValue("@FuncType", s.FuncType);
        com.Parameters.AddWithValue("@MasterID", s.MasterID);
        com.Parameters.AddWithValue("@DepID", s.DepID);

        com.Parameters.AddWithValue("@CentID", s.CenterID);
        com.Parameters.AddWithValue("@ServiceID", s.ServiceID);
        com.Parameters.AddWithValue("@ServiceType", s.ServiceType);
        com.Parameters.AddWithValue("@ServiceCategory", s.ServiceCategory);
        com.Parameters.AddWithValue("@ServiceCode", s.ServiceCode);
        com.Parameters.AddWithValue("@ServiceCode2", s.ServiceCode2);
        com.Parameters.AddWithValue("@Name", s.Name);
        com.Parameters.AddWithValue("@Namelong", s.Namelong);
        com.Parameters.AddWithValue("@Price", s.Price);
        com.Parameters.AddWithValue("@PriceB", s.PriceB);
        com.Parameters.AddWithValue("@PriceC", s.PriceC);
        com.Parameters.AddWithValue("@PriceD", s.PriceD);
        com.Parameters.AddWithValue("@PricePro", s.PricePro);
        com.Parameters.AddWithValue("@PriceTech", s.PriceTech);
        com.Parameters.AddWithValue("@MapIDA", s.MapIDA);
        com.Parameters.AddWithValue("@MapIDB", s.MapIDB);
        com.Parameters.AddWithValue("@StartDate", s.StartDate);
        com.Parameters.AddWithValue("@EndDate", s.EndDate);
        com.Parameters.AddWithValue("@IsTech", s.IsTech);
        com.Parameters.AddWithValue("@IsManualPrice", s.IsManualPrice);
        com.Parameters.AddWithValue("@ServicePriceType", s.ServicePriceType);
        com.Parameters.AddWithValue("@ServiceUnit", s.ServiceUnit);
        com.Parameters.AddWithValue("@ServiceUnit2", s.ServiceUnit2);
        com.Parameters.AddWithValue("@ServiceStatus", s.ServiceStatus);
        com.Parameters.AddWithValue("@IsDisable", s.IsDisable);
        com.Parameters.AddWithValue("@IsOIC", s.IsOIC);
        com.Parameters.AddWithValue("@UserPersID", s.UserPersID);

        var dalData = new DataService();

        var dt = dalData.GetDataTableBySP(CSet.cnStringPortal, com, "spService");
        return _appConvertDtToList.ConvertDataTable<Models.Service>(dt);
    }
}