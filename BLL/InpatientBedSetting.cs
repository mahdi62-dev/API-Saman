using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class InpatientBedSetting
{
    private readonly ConvertDtToList _convert = new();

    public List<InpWard> WardCRUD(InpWard m)
    {
        var com = BaseCommand(1, m.CRUD);
        AddParam(com, "@WardID", m.WardID);
        AddParam(com, "@DepID", m.DepID);
        AddParam(com, "@WardCode", m.WardCode);
        AddParam(com, "@WardName", m.WardName);
        AddParam(com, "@WardType", m.WardType);
        AddParam(com, "@GenderLimit", m.GenderLimit);
        AddParam(com, "@IsICU", m.IsICU);
        AddParam(com, "@IsSurgery", m.IsSurgery);
        AddParam(com, "@IsActive", m.IsActive);
        AddParam(com, "@SortID", m.SortID);
        AddParam(com, "@Explain", m.Explain);
        AddAudit(com, m.CenterID, m.UserPersID);
        return Exec<InpWard>(com);
    }

    public List<InpRoom> RoomCRUD(InpRoom m)
    {
        var com = BaseCommand(2, m.CRUD);
        AddParam(com, "@RoomID", m.RoomID);
        AddParam(com, "@WardID", m.WardID);
        AddParam(com, "@RoomNo", m.RoomNo);
        AddParam(com, "@RoomName", m.RoomName);
        AddParam(com, "@RoomClass", m.RoomClass);
        AddParam(com, "@FloorNo", m.FloorNo);
        AddParam(com, "@Capacity", m.Capacity);
        AddParam(com, "@GenderLimit", m.GenderLimit);
        AddParam(com, "@IsIsolation", m.IsIsolation);
        AddParam(com, "@IsActive", m.IsActive);
        AddParam(com, "@SortID", m.SortID);
        AddParam(com, "@Explain", m.Explain);
        AddAudit(com, m.CenterID, m.UserPersID);
        return Exec<InpRoom>(com);
    }

    public List<InpBedClass> BedClassCRUD(InpBedClass m)
    {
        var com = BaseCommand(3, m.CRUD);
        AddParam(com, "@BedClassID", m.BedClassID);
        AddParam(com, "@BedClassCode", m.BedClassCode);
        AddParam(com, "@BedClassName", m.BedClassName);
        AddParam(com, "@BedClassType", m.BedClassType);
        AddParam(com, "@ServiceID", m.ServiceID);
        AddParam(com, "@ServiceCategory", m.ServiceCategory);
        AddParam(com, "@ServiceCode", m.ServiceCode);
        AddParam(com, "@DepositAmount", m.DepositAmount);
        AddParam(com, "@DepositIsRequired", m.DepositIsRequired);
        AddParam(com, "@IsActive", m.IsActive);
        AddParam(com, "@SortID", m.SortID);
        AddParam(com, "@Explain", m.Explain);
        AddAudit(com, m.CenterID, m.UserPersID);
        return Exec<InpBedClass>(com);
    }

    public List<InpBed> BedCRUD(InpBed m)
    {
        var com = BaseCommand(4, m.CRUD);
        AddParam(com, "@BedID", m.BedID);
        AddParam(com, "@WardID", m.WardID);
        AddParam(com, "@RoomID", m.RoomID);
        AddParam(com, "@BedClassID", m.BedClassID);
        AddParam(com, "@BedNo", m.BedNo);
        AddParam(com, "@BedName", m.BedName);
        AddParam(com, "@ServiceID", m.ServiceID);
        AddParam(com, "@ServiceCategory", m.ServiceCategory);
        AddParam(com, "@ServiceCode", m.ServiceCode);
        AddParam(com, "@DepositAmountOverride", m.DepositAmountOverride);
        AddParam(com, "@UseDepositOverride", m.UseDepositOverride);
        AddParam(com, "@BedStatus", m.BedStatus);
        AddParam(com, "@IsActive", m.IsActive);
        AddParam(com, "@SortID", m.SortID);
        AddParam(com, "@Explain", m.Explain);
        AddAudit(com, m.CenterID, m.UserPersID);
        return Exec<InpBed>(com);
    }

    public List<Models.Service> GetActiveServiceList(int serviceCategory = 0)
    {
        var com = new SqlCommand();
        AddParam(com, "@ServiceCategory", serviceCategory);

        const string tsql = @"
SELECT
    s.ServiceID,
    s.ServiceCategory,
    s.ServiceCode,
    s.Name,
    ISNULL(cat.Name, N'') AS ServiceCategoryName,
    s.Price,
    s.StartDate,
    s.EndDate
FROM dbo.Service s
LEFT JOIN dbo.vADR cat ON cat.ADName = N'ServiceCategory' AND cat.ID = s.ServiceCategory
WHERE ISNULL(s.IsDisable, 0) = 0
  AND (@ServiceCategory = 0 OR s.ServiceCategory = @ServiceCategory)
  AND (s.EndDate IS NULL OR LTRIM(RTRIM(s.EndDate)) = '')
ORDER BY s.ServiceCategory, s.ServiceCode, s.Name";

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _convert.ConvertDataTable<Models.Service>(dt);
    }

    private static SqlCommand BaseCommand(int tableID, int crud)
    {
        var com = new SqlCommand();
        AddParam(com, "@TableID", tableID);
        AddParam(com, "@CRUD", crud);
        return com;
    }

    private static void AddAudit(SqlCommand com, int centerID, int userPersID)
    {
        AddParam(com, "@CenterID", centerID <= 0 ? 1 : centerID);
        AddParam(com, "@UserPersID", userPersID);
    }

    private List<T> Exec<T>(SqlCommand com) where T : new()
    {
        var dt = new DataService().GetDataTableBySP(CSet.cnStringHIS, com, "spInpatientBedSetting");
        return _convert.ConvertDataTable<T>(dt);
    }

    private static void AddParam(SqlCommand com, string name, object? value)
    {
        if (value is string str && string.IsNullOrWhiteSpace(str)) value = DBNull.Value;
        com.Parameters.AddWithValue(name, value ?? DBNull.Value);
    }
}
