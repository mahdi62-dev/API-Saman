using System.Data;
using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class SFForm
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.SFForm SFFormCRUD(Models.SFForm SFForm)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", SFForm.CRUD);
        com.Parameters.AddWithValue("@FuncType", SFForm.FuncType);
        com.Parameters.AddWithValue("@CentID", SFForm.CentID);
        com.Parameters.AddWithValue("@ID", SFForm.ID);
        com.Parameters.AddWithValue("@FormID", SFForm.FormID);
        com.Parameters.AddWithValue("@EncID", SFForm.EncID);
        com.Parameters.AddWithValue("@PageID", SFForm.PageID);
        com.Parameters.AddWithValue("@Date", SFForm.Date);
        com.Parameters.AddWithValue("@ServiceCode", SFForm.ServiceCode);
        com.Parameters.AddWithValue("@F1", SFForm.F1);
        com.Parameters.AddWithValue("@F2", SFForm.F2);
        com.Parameters.AddWithValue("@Note", SFForm.Note);
        com.Parameters.AddWithValue("@UserPersID", SFForm.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSFForm");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.SFForm>(dRow);
    }

    public OkProc SFProcOkCRUD(OkProc procok)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", procok.CRUD);
        com.Parameters.AddWithValue("@FuncType", procok.FuncType);
        com.Parameters.AddWithValue("@EncID", procok.EncID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSFForm");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<OkProc>(dRow);
    }
}