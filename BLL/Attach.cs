using System.Data;
using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class Attach
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private readonly ConvertDtToList _appConvertDtToList = new();


    public Att AttFileCRUD(Att att)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", att.CRUD);
        com.Parameters.AddWithValue("@FuncType", att.FuncType);
        com.Parameters.AddWithValue("@EAID", att.EAID);
        com.Parameters.AddWithValue("@NationalCode", att.NationalCode);
        com.Parameters.AddWithValue("@EncID", att.EncID);
        com.Parameters.AddWithValue("@WEncID", att.WEncID);
        com.Parameters.AddWithValue("@PageID", att.PageID);
        com.Parameters.AddWithValue("@DepID", att.DepID);
        com.Parameters.AddWithValue("@FileName", att.FileName);
        com.Parameters.AddWithValue("@AttFileSize", att.AttFileSize);
        com.Parameters.AddWithValue("@AttFileType", att.AttFileType);
        com.Parameters.AddWithValue("@AttFileContentType", att.AttFileContentType);
        com.Parameters.AddWithValue("@AttTag", att.AttTag);
        com.Parameters.AddWithValue("@Date", att.Date);
        com.Parameters.AddWithValue("@Note", att.Note);
        com.Parameters.AddWithValue("@OutOfCenter", att.OutOfCenter);
        com.Parameters.AddWithValue("@AttFile", att.AttFile);
        com.Parameters.AddWithValue("@AttFileThumbnail", att.AttFileThumbnail);
        com.Parameters.AddWithValue("@ActionType", att.ActionType);
        com.Parameters.AddWithValue("@UserIP", att.UserIP);
        com.Parameters.AddWithValue("@UserDeviceName", att.UserDeviceName);
        com.Parameters.AddWithValue("@UserPersID", att.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringERP, com, "spAttFile");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Att>(dRow);
    }

    public List<Att> AttListCRUD(Att att)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", att.CRUD);
        com.Parameters.AddWithValue("@FuncType", att.FuncType);
        com.Parameters.AddWithValue("@EAID", att.EAID);
        com.Parameters.AddWithValue("@NationalCode", att.NationalCode);
        com.Parameters.AddWithValue("@PatientID", att.PatientID);
        com.Parameters.AddWithValue("@EncID", att.EncID);
        com.Parameters.AddWithValue("@WEncID", att.WEncID);
        com.Parameters.AddWithValue("@PageID", att.PageID);
        com.Parameters.AddWithValue("@DepID", att.DepID);
        com.Parameters.AddWithValue("@FileName", att.FileName);
        com.Parameters.AddWithValue("@AttFileSize", att.AttFileSize);
        com.Parameters.AddWithValue("@AttFileType", att.AttFileType);
        com.Parameters.AddWithValue("@AttFileContentType", att.AttFileContentType);
        com.Parameters.AddWithValue("@AttTag", att.AttTag);
        com.Parameters.AddWithValue("@Date", att.Date);
        com.Parameters.AddWithValue("@Note", att.Note);
        com.Parameters.AddWithValue("@OutOfCenter", att.OutOfCenter);
        com.Parameters.AddWithValue("@AttFile", att.AttFile);
        com.Parameters.AddWithValue("@AttFileThumbnail", att.AttFileThumbnail);
        com.Parameters.AddWithValue("@ActionType", att.ActionType);
        com.Parameters.AddWithValue("@UserIP", att.UserIP);
        com.Parameters.AddWithValue("@UserDeviceName", att.UserDeviceName);
        com.Parameters.AddWithValue("@UserPersID", att.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringERP, com, "spAttFile");
        return _appConvertDtToList.ConvertDataTable<Att>(dt);
    }

    public List<Att> AttFilePortal(Att att)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", att.CRUD);
        com.Parameters.AddWithValue("@FuncType", att.FuncType);
        com.Parameters.AddWithValue("@EAID", att.EAID);
        com.Parameters.AddWithValue("@NationalCode", att.NationalCode);
        com.Parameters.AddWithValue("@EncID", att.EncID);
        com.Parameters.AddWithValue("@WEncID", att.WEncID);
        com.Parameters.AddWithValue("@PageID", att.PageID);
        com.Parameters.AddWithValue("@DepID", att.DepID);
        com.Parameters.AddWithValue("@FileName", att.FileName);
        com.Parameters.AddWithValue("@AttFileSize", att.AttFileSize);
        com.Parameters.AddWithValue("@AttFileType", att.AttFileType);
        com.Parameters.AddWithValue("@AttFileContentType", att.AttFileContentType);
        com.Parameters.AddWithValue("@AttTag", att.AttTag);
        com.Parameters.AddWithValue("@Date", att.Date);
        com.Parameters.AddWithValue("@Note", att.Note);
        com.Parameters.AddWithValue("@AttFile", att.AttFile);
        com.Parameters.AddWithValue("@AttFileThumbnail", att.AttFileThumbnail);
        com.Parameters.AddWithValue("@UserPersID", att.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringPortal, com, "spAttFile");
        return _appConvertDtToList.ConvertDataTable<Att>(dt);
    }
}