using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class SFHeartCABG
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.SFHeartCABG SFHeartCABGCUD(Models.SFHeartCABG SFHeartCABG)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", SFHeartCABG.CRUD);
        com.Parameters.AddWithValue("@SFHeartCABGID", SFHeartCABG.SFHeartCABGID);
        com.Parameters.AddWithValue("@EncID", SFHeartCABG.EncID);
        com.Parameters.AddWithValue("@PageID", SFHeartCABG.PageID);
        com.Parameters.AddWithValue("@ServiceCode", SFHeartCABG.ServiceCode);
        com.Parameters.AddWithValue("@LIMAOnLAD", SFHeartCABG.LIMAOnLAD);
        com.Parameters.AddWithValue("@SVGOnLAD", SFHeartCABG.SVGOnLAD);
        com.Parameters.AddWithValue("@SVGD1", SFHeartCABG.SVGD1);
        com.Parameters.AddWithValue("@SVGD2", SFHeartCABG.SVGD2);
        com.Parameters.AddWithValue("@SVGD3", SFHeartCABG.SVGD3);
        com.Parameters.AddWithValue("@SVGOM1", SFHeartCABG.SVGOM1);
        com.Parameters.AddWithValue("@SVGOM2", SFHeartCABG.SVGOM2);
        com.Parameters.AddWithValue("@SVGOM3", SFHeartCABG.SVGOM3);
        com.Parameters.AddWithValue("@SVGRCA", SFHeartCABG.SVGRCA);
        com.Parameters.AddWithValue("@SVGPDA", SFHeartCABG.SVGPDA);
        com.Parameters.AddWithValue("@SVGPLV", SFHeartCABG.SVGPLV);
        com.Parameters.AddWithValue("@SVGRamus", SFHeartCABG.SVGRamus);
        com.Parameters.AddWithValue("@RadialOn", SFHeartCABG.RadialOn);
        com.Parameters.AddWithValue("@Note", SFHeartCABG.Note);
        com.Parameters.AddWithValue("@UserPersID", SFHeartCABG.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSFHeartCABG");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.SFHeartCABG>(dRow);
    }
}