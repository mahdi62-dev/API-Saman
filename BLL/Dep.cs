using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class Dep
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();
    private readonly DataService _dalDataService = new();


    public List<Models.Dep> GetDepList(string strWhere)
    {
        var dt = _dalDataService.LoadData(CSet.cnStringHIS, "DepID,Name", "vDep", strWhere, null);
        var EncDepList = new List<Models.Dep>();
        EncDepList = _appConvertDtToList.ConvertDataTable<Models.Dep>(dt);
        return EncDepList;
    }

    public Models.Dep DepCRUD(Models.Dep dep)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", dep.CRUD);
        com.Parameters.AddWithValue("@DepID", dep.DepID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDep");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.Dep>(dRow);
    }


    public List<Models.Dep> GetDepList()
    {
        var dt = _dalDataService.LoadData(CSet.cnStringHIS, "DepID,Name", "vDep", null, null);
        var EncDepList = new List<Models.Dep>();
        EncDepList = _appConvertDtToList.ConvertDataTable<Models.Dep>(dt);
        return EncDepList;
    }
}