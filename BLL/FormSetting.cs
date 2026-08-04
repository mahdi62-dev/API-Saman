using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class FormSetting
{
    private readonly ConvertDtToList _appConvertDtToList = new();

    /// <summary>
    /// لیست فرم‌هایی که در تنظیمات UI رکورد دارند.
    /// از خود spFormSetting با CRUD=10 خوانده می‌شود.
    /// </summary>
    public List<Models.Form> GetFormList()
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", 10);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringERP, com, "spFormSetting");
        return _appConvertDtToList.ConvertDataTable<Models.Form>(dt);
    }

    /// <summary>
    /// خواندن تنظیمات یک فرم برای مصرف کدهای قدیمی‌تر.
    /// </summary>
    public DataTable FormSettingLoad(int FormID)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", 1);
        com.Parameters.AddWithValue("@FormID", FormID);

        var dalData = new DataService();
        return dalData.GetDataTableBySP(CSet.cnStringERP, com, "spFormSetting");
    }

    /// <summary>
    /// CRUD کامل تنظیمات فرم بر اساس Stored Procedure:
    /// 0=Insert, 1=Select, 2=Update, 4=Delete
    /// </summary>
    public List<Models.FormSetting> FormSettingCRUD(Models.FormSetting formSetting)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", formSetting.CRUD);
        com.Parameters.AddWithValue("@FuncType", formSetting.FuncType);
        com.Parameters.AddWithValue("@ID", formSetting.ID);
        com.Parameters.AddWithValue("@FormID", formSetting.FormID);
        com.Parameters.AddWithValue("@ModID", formSetting.ModID);
        com.Parameters.AddWithValue("@DepID", formSetting.DepID);
        com.Parameters.AddWithValue("@UserPersID", formSetting.UserPersID);
        com.Parameters.AddWithValue("@IsUI", formSetting.IsUI);
        com.Parameters.AddWithValue("@FormSubID", formSetting.FormSubID);
        com.Parameters.AddWithValue("@FormUiID", formSetting.FormUiID);
        com.Parameters.AddWithValue("@IsRequired", formSetting.IsRequired);
        com.Parameters.AddWithValue("@UiCaption", NullIfEmpty(formSetting.UiCaption));
        com.Parameters.AddWithValue("@RecNo", formSetting.RecNo);
        com.Parameters.AddWithValue("@Visible", formSetting.Visible);
        com.Parameters.AddWithValue("@Enabled", formSetting.Enabled);
        com.Parameters.AddWithValue("@ReadOnly", formSetting.ReadOnly);
        com.Parameters.AddWithValue("@TabStop", formSetting.TabStop);
        com.Parameters.AddWithValue("@IsDisable", formSetting.IsDisable);
        com.Parameters.AddWithValue("@Val1", formSetting.Val1);
        com.Parameters.AddWithValue("@ValStr1", NullIfEmpty(formSetting.ValStr1));
        com.Parameters.AddWithValue("@DefaultValue", NullIfEmpty(formSetting.DefaultValue));
        com.Parameters.AddWithValue("@Explain", NullIfEmpty(formSetting.Explain));
        com.Parameters.AddWithValue("@CenterID", formSetting.CenterID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringERP, com, "spFormSetting");
        return _appConvertDtToList.ConvertDataTable<Models.FormSetting>(dt);
    }

    private static object NullIfEmpty(string? value)
        => string.IsNullOrWhiteSpace(value) ? DBNull.Value : value;

    public int GetVal1(DataTable dtFormSetting, string UiName)
    {
        var val = 0;

        string filter;
        filter = "UiName='" + UiName + "'";

        if (dtFormSetting.Select(filter).Length > 0)
        {
            DataTable dt;
            dt = dtFormSetting.Select(filter).CopyToDataTable();

            if (dt.Rows.Count > 0) val = Convert.ToInt32(dt.Rows[0]["Val1"]);
        }

        return val;
    }

    public string GetName(DataTable dtFormSetting, string UiName)
    {
        string val = null;

        string filter;
        filter = "UiName='" + UiName + "'";

        if (dtFormSetting.Select(filter).Length > 0)
        {
            DataTable dt;
            dt = dtFormSetting.Select(filter).CopyToDataTable();

            if (dt.Rows.Count > 0) val = dt.Rows[0]["UiCaption"].ToString();
        }

        return val;
    }

    public bool UiIsRequied(DataTable dtFormSetting, string UiName)
    {
        var val = false;

        string filter;
        filter = "UiName='" + UiName + "'";

        if (dtFormSetting.Select(filter).Length > 0)
        {
            DataTable dt;
            dt = dtFormSetting.Select(filter).CopyToDataTable();

            if (dt.Rows.Count > 0) val = Convert.ToBoolean(dt.Rows[0]["IsRequired"]);
        }

        return val;
    }

    public bool UiIsReadOnly(DataTable dtFormSetting, string UiName)
    {
        var val = false;

        string filter;
        filter = "UiName='" + UiName + "'";

        if (dtFormSetting.Select(filter).Length > 0)
        {
            DataTable dt;
            dt = dtFormSetting.Select(filter).CopyToDataTable();

            if (dt.Rows.Count > 0)
            {
                if (dt.Columns.Contains("IsReadOnly"))
                    val = Convert.ToBoolean(dt.Rows[0]["IsReadOnly"]);
                else if (dt.Columns.Contains("ReadOnly"))
                    val = Convert.ToBoolean(dt.Rows[0]["ReadOnly"]);
            }
        }

        return val;
    }

    public int UiDefaultValueInt(DataTable dtFormSetting, string UiName)
    {
        string val = null;

        string filter;
        filter = "UiName='" + UiName + "'";

        if (dtFormSetting.Select(filter).Length > 0)
        {
            DataTable dt;
            dt = dtFormSetting.Select(filter).CopyToDataTable();

            if (dt.Rows.Count > 0) val = dt.Rows[0]["DefaultValue"].ToString();
        }

        if (string.IsNullOrEmpty(val)) val = "0";

        return Convert.ToInt32(val);
    }

    public bool UiDefaultValueBoolean(DataTable dtFormSetting, string UiName)
    {
        string val = null;

        string filter;
        filter = "UiName='" + UiName + "'";

        if (dtFormSetting.Select(filter).Length > 0)
        {
            DataTable dt;
            dt = dtFormSetting.Select(filter).CopyToDataTable();

            if (dt.Rows.Count > 0) val = dt.Rows[0]["DefaultValue"].ToString();
        }

        if (string.IsNullOrEmpty(val)) val = "0";

        return Convert.ToBoolean(val);
    }

    public string UiDefaultValueString(DataTable dtFormSetting, string UiName)
    {
        string val = null;

        string filter;
        filter = "UiName='" + UiName + "'";

        if (dtFormSetting.Select(filter).Length > 0)
        {
            DataTable dt;
            dt = dtFormSetting.Select(filter).CopyToDataTable();

            if (dt.Rows.Count > 0) val = dt.Rows[0]["DefaultValue"].ToString();
        }

        return val;
    }
}
