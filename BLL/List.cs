using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class List
{
    private readonly ConvertDtToList _appConvertDtToList = new();
    private readonly DataService _dalDataService = new();

    public List<Models.ADR> GetAdrList(string ADName, string strWhere)
    {
        if (strWhere != null)
            strWhere = " AND " + strWhere;

        var dt = _dalDataService.LoadData(CSet.cnStringERP, "*", "vADR", "ADName= '" + ADName + "'" + strWhere,
            "ID");

        var AdrList = new List<Models.ADR>();

        AdrList = _appConvertDtToList.ConvertDataTable<Models.ADR>(dt);
        return AdrList;
    }

    public List<Models.ADR> ListLoad(string DBName, string Fields, string From, string Where, string OrderBy,
        string Search)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@DBName", DBName);
        com.Parameters.AddWithValue("@Fields", Fields);
        com.Parameters.AddWithValue("@From", From);
        com.Parameters.AddWithValue("@Where", Where);
        com.Parameters.AddWithValue("@OrderBy", OrderBy);
        com.Parameters.AddWithValue("@Search", Search == null ? DBNull.Value : Search);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringERP, com, "spList");
        return _appConvertDtToList.ConvertDataTable<Models.ADR>(dt);
    }
}