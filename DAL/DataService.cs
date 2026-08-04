using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL;

/// <summary>
/// لایه دسترسی داده — بهینه‌شده
/// تغییرات: استفاده از using برای SqlConnection و SqlDataReader
/// تا اتصال‌ها حتی در صورت Exception بسته شوند
/// </summary>
public class DataService
{
    // ───── SP ─────

    public DataTable GetDataTableBySP(string cnString, SqlCommand com, string comText)
    {
        using var con = new SqlConnection(cnString);
        com.Connection = con;
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = comText;

        var dt = new DataTable();
        con.Open();
        using (var sdr = com.ExecuteReader())
            dt.Load(sdr);

        return dt;
    }

    public void ExecuteNonQueryBySp(string cnString, SqlCommand com, string comText)
    {
        using var con = new SqlConnection(cnString);
        com.Connection = con;
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = comText;

        con.Open();
        com.ExecuteNonQuery();
    }

    public void ExecuteNonQueryByText(string cnString, SqlCommand com, string comText)
    {
        using var con = new SqlConnection(cnString);
        com.Connection = con;
        com.CommandType = CommandType.Text;
        com.CommandText = comText;

        con.Open();
        com.ExecuteNonQuery();
    }

    // ───── Text SQL ─────

    public DataTable GetDataTableByText(string cnString, SqlCommand com, string comText)
    {
        using var con = new SqlConnection(cnString);
        com.Connection = con;
        com.CommandType = CommandType.Text;
        com.CommandText = comText;

        var dt = new DataTable();
        con.Open();
        using (var sdr = com.ExecuteReader())
            dt.Load(sdr);

        return dt;
    }

    public DataTable GetDataTableByText(string cnString, string comText)
    {
        using var con = new SqlConnection(cnString);
        using var com = new SqlCommand(comText, con);
        com.CommandType = CommandType.Text;

        var dt = new DataTable();
        con.Open();
        using (var sdr = com.ExecuteReader())
            dt.Load(sdr);

        return dt;
    }

    // ───── Helper عمومی ─────

    public DataTable LoadData(string conString, string fields, string from, string where, string? orderBy)
    {
        var tsql = $"SELECT {fields} FROM {from}";
        if (!string.IsNullOrEmpty(where))   tsql += $" WHERE {where}";
        if (!string.IsNullOrEmpty(orderBy)) tsql += $" ORDER BY {orderBy}";

        return GetDataTableByText(conString, tsql);
    }
}
