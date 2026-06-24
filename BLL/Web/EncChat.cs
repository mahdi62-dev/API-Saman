using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.Web;

public class EncChat
{
    private readonly ConvertDtToList _appConvertDtToList = new();
    private ConvertDRowToModel _appConvertDRowToModel = new();

    public List<Models.Web.EncChat> EncChatCRUD(Models.Web.EncChat webenc)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", webenc.CRUD);
        com.Parameters.AddWithValue("@FuncType", webenc.FuncType);
        com.Parameters.AddWithValue("@WProfileID", webenc.WProfileID);
        com.Parameters.AddWithValue("@WEncID", webenc.WEncID);
        com.Parameters.AddWithValue("@NationalCode", webenc.NationalCode);
        com.Parameters.AddWithValue("@CenterID", webenc.CenterID);
        com.Parameters.AddWithValue("@MasterID", webenc.MasterID);
        com.Parameters.AddWithValue("@ChatSide", webenc.ChatSide);
        com.Parameters.AddWithValue("@ChatText", webenc.ChatText);
        com.Parameters.AddWithValue("@ChatStatus", webenc.ChatStatus);
        com.Parameters.AddWithValue("@ChatStatusDate", webenc.ChatStatusDate);
        com.Parameters.AddWithValue("@ActionDate", webenc.ActionDate);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringPortal, com, "spEncChat");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDtToList.ConvertDataTable<Models.Web.EncChat>(dt);
    }
}