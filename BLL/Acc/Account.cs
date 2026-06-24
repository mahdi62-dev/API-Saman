using APP;
using DAL;
using Microsoft.Data.SqlClient;

//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.Acc;

public class Account
{
    private readonly ConvertDtToList _appConvertDtToList = new();
    private ConvertDRowToModel _appConvertDRowToModel = new();
    private DataService _dalDataService = new();

    public List<Models.Acc.Account> AccCRUD(Models.Acc.Account Acc)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", Acc.CRUD);
        com.Parameters.AddWithValue("@FuncType", Acc.FuncType);
        //com.Parameters.AddWithValue("@AccountID", Acc.AccountID);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringERP, com, "spAccAccount");
        return _appConvertDtToList.ConvertDataTable<Models.Acc.Account>(dt);
    }
}