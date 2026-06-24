using System.Collections.Concurrent;
using System.Data;
using System.Reflection;

namespace APP;

/// <summary>
/// تبدیل DataRow به Model — بهینه‌شده با PropertyInfo Cache
/// مشکل قبلی: هر بار GetProperty/GetProperties فراخوانی می‌شد (Reflection سنگین)
/// راه‌حل: PropertyInfo ها یک‌بار cache می‌شوند
/// </summary>
public class ConvertDRowToModel
{
    // Cache: به ازای هر Type، PropertyInfo ها ذخیره می‌شوند
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _propCache = new();

    public T CreateItemFromRow<T>(DataRow? row) where T : new()
    {
        var item = new T();
        if (row != null) SetItemFromRow(item, row);
        return item;
    }

    public void SetItemFromRow<T>(T item, DataRow row) where T : new()
    {
        var props = GetCachedProps(typeof(T));
        var colNames = new HashSet<string>(
            row.Table.Columns.Cast<DataColumn>().Select(c => c.ColumnName),
            StringComparer.OrdinalIgnoreCase);

        foreach (var p in props)
        {
            if (!colNames.Contains(p.Name)) continue;
            var val = row[p.Name];
            if (val != DBNull.Value)
                p.SetValue(item, val, null);
        }
    }

    private static PropertyInfo[] GetCachedProps(Type type)
        => _propCache.GetOrAdd(type, t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance));
}

/// <summary>
/// تبدیل DataTable به List — بهینه‌شده
/// </summary>
public class ConvertDtToList
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _propCache = new();

    public List<T> ConvertDataTable<T>(DataTable dt) where T : new()
    {
        var result = new List<T>(dt.Rows.Count);
        if (dt.Rows.Count == 0) return result;

        var props = GetCachedProps(typeof(T));

        // ستون‌های موجود در DataTable را یک‌بار شناسایی کن
        var colSet = new HashSet<string>(
            dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName),
            StringComparer.OrdinalIgnoreCase);

        // فقط propertyهایی که ستون متناظر دارند
        var matchedProps = props
            .Where(p => colSet.Contains(p.Name))
            .ToArray();

        foreach (DataRow row in dt.Rows)
        {
            var obj = new T();
            foreach (var p in matchedProps)
            {
                var val = row[p.Name];
                if (val != DBNull.Value)
                    p.SetValue(obj, val, null);
            }
            result.Add(obj);
        }

        return result;
    }

    public T GetItem<T>(DataRow dr) where T : new()
    {
        var obj = new T();
        var props = GetCachedProps(typeof(T));
        var colSet = new HashSet<string>(
            dr.Table.Columns.Cast<DataColumn>().Select(c => c.ColumnName),
            StringComparer.OrdinalIgnoreCase);

        foreach (var p in props)
        {
            if (!colSet.Contains(p.Name)) continue;
            var val = dr[p.Name];
            if (val != DBNull.Value)
                p.SetValue(obj, val, null);
        }
        return obj;
    }

    private static PropertyInfo[] GetCachedProps(Type type)
        => _propCache.GetOrAdd(type, t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance));
}

/// <summary>
/// تبدیل List به DataTable
/// </summary>
public class ConvertListToDt
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _propCache = new();

    public DataTable ToDataTable<T>(List<T> items)
    {
        var dt = new DataTable(typeof(T).Name);
        var props = _propCache.GetOrAdd(typeof(T),
            t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance));

        foreach (var p in props)
        {
            var type = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
            dt.Columns.Add(p.Name, type);
        }

        foreach (var item in items)
        {
            var values = new object[props.Length];
            for (var i = 0; i < props.Length; i++)
                values[i] = props[i].GetValue(item, null) ?? DBNull.Value;
            dt.Rows.Add(values);
        }

        return dt;
    }
}
