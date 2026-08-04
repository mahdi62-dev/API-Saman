using System.Data;
using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class ERPSettings
{
    private readonly ConvertDtToList _convert = new();
    private readonly DataService _dal = new();

    public List<ErpCenterSetting> CenterCRUD(ErpCenterSetting m)
    {
        var com = BaseCommand(1, m.CRUD);
        AddParam(com, "@CenterID", m.CenterID);
        AddParam(com, "@MasterID", m.MasterID);
        AddParam(com, "@Name", m.Name);
        AddParam(com, "@Explain", m.Explain);
        AddParam(com, "@CenterType", m.CenterType);
        AddParam(com, "@IPServer", m.IPServer);
        AddParam(com, "@Tel", m.Tel);
        AddParam(com, "@WebAddress", m.WebAddress);
        AddParam(com, "@InstagramAddress", m.InstagramAddress);
        AddVarBinaryParam(com, "@Logo", m.Logo);
        AddParam(com, "@Sign", m.Sign);
        AddParam(com, "@TelText", m.TelText);
        AddParam(com, "@Address", m.Address);
        return Exec<ErpCenterSetting>(com);
    }

    public List<ErpSetting> SettingCRUD(ErpSetting m)
    {
        var com = BaseCommand(2, m.CRUD);
        AddParam(com, "@ID", m.ID);
        AddParam(com, "@CenterName", m.CenterName);
        AddParam(com, "@CenterType", m.CenterType);
        AddParam(com, "@SettingCenterID", m.CenterID);
        AddParam(com, "@CompanyTel", m.CompanyTel);
        AddParam(com, "@TimexApp", m.TimexApp);
        return Exec<ErpSetting>(com);
    }

    public List<ErpSettingConfig> SettingConfigCRUD(ErpSettingConfig m)
    {
        var com = BaseCommand(3, m.CRUD);
        AddParam(com, "@ID", m.ID);
        AddParam(com, "@Val1", m.Val1);
        return Exec<ErpSettingConfig>(com);
    }

    public List<ErpSettingApp> SettingAppCRUD(ErpSettingApp m)
    {
        var com = BaseCommand(4, m.CRUD);
        AddParam(com, "@SAID", m.SAID);
        AddParam(com, "@UserID", m.UserID);
        AddParam(com, "@ModID", m.ModID);
        AddParam(com, "@DepID", m.DepID);
        AddParam(com, "@SetID", m.SetID);
        AddParam(com, "@Val", m.Val);
        return Exec<ErpSettingApp>(com);
    }

    public List<ErpConfig> ConfigCRUD(ErpConfig m)
    {
        var com = BaseCommand(5, m.CRUD);
        AddParam(com, "@ModID", m.ModID);
        AddParam(com, "@DepID", m.DepID);
        AddParam(com, "@ConfigID", m.ConfigID);
        AddParam(com, "@Val", m.Val);
        AddParam(com, "@CenterID", m.CenterID);
        AddParam(com, "@Explain", m.Explain);
        return Exec<ErpConfig>(com);
    }

    private SqlCommand BaseCommand(int tableID, int crud)
    {
        var com = new SqlCommand();
        AddParam(com, "@TableID", tableID);
        AddParam(com, "@CRUD", crud);
        return com;
    }

    private List<T> Exec<T>(SqlCommand com) where T : new()
    {
        var dt = _dal.GetDataTableBySP(CSet.cnStringERP, com, "spERPSettingsCRUD");
        return _convert.ConvertDataTable<T>(dt);
    }

    private static void AddParam(SqlCommand com, string name, object? value)
    {
        if (value is string str && string.IsNullOrWhiteSpace(str)) value = DBNull.Value;
        com.Parameters.AddWithValue(name, value ?? DBNull.Value);
    }

    private static void AddVarBinaryParam(SqlCommand com, string name, byte[]? value)
    {
        var p = com.Parameters.Add(name, SqlDbType.VarBinary, -1);
        p.Value = value is not null ? value : DBNull.Value;
    }
}
