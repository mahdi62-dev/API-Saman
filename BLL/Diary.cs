using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class Diary
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();
    private readonly DataService _dalDataService = new();

    public List<Models.Diary> DiaryCRUD(Models.Diary diary)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@DFuncType", diary.DFuncType);
        com.Parameters.AddWithValue("@CenterID", diary.CenterID);
        com.Parameters.AddWithValue("@CRUD", diary.CRUD);
        com.Parameters.AddWithValue("@FuncType", diary.FuncType);
        com.Parameters.AddWithValue("@ID", diary.ID);
        com.Parameters.AddWithValue("@Date", diary.Date);
        com.Parameters.AddWithValue("@DType", diary.DType);
        com.Parameters.AddWithValue("@Val1", diary.Val1);
        com.Parameters.AddWithValue("@ValStr1", diary.ValStr1);
        com.Parameters.AddWithValue("@Explain", diary.Explain);
        com.Parameters.AddWithValue("@ActionType", diary.ActionType);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringERP, com, "spDiary");
        return _appConvertDtToList.ConvertDataTable<Models.Diary>(dt);
    }
}