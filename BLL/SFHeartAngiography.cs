using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class SFHeartAngiography
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.SFHeartAngiography SFHeartAngiographyCUD(Models.SFHeartAngiography SFHeartAngiography)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", SFHeartAngiography.CRUD);
        com.Parameters.AddWithValue("@SFAngiographyID", SFHeartAngiography.SFAngiographyID);
        com.Parameters.AddWithValue("@EncID", SFHeartAngiography.EncID);
        com.Parameters.AddWithValue("@PageID", SFHeartAngiography.PageID);
        com.Parameters.AddWithValue("@ServiceCode", SFHeartAngiography.ServiceCode);
        com.Parameters.AddWithValue("@LM", SFHeartAngiography.LM);
        com.Parameters.AddWithValue("@LADProx", SFHeartAngiography.LADProx);
        com.Parameters.AddWithValue("@LADMid", SFHeartAngiography.LADMid);
        com.Parameters.AddWithValue("@LADDistal", SFHeartAngiography.LADDistal);
        com.Parameters.AddWithValue("@D1", SFHeartAngiography.D1);
        com.Parameters.AddWithValue("@D2", SFHeartAngiography.D2);
        com.Parameters.AddWithValue("@LCXProx", SFHeartAngiography.LCXProx);
        com.Parameters.AddWithValue("@LCXDistal", SFHeartAngiography.LCXDistal);
        com.Parameters.AddWithValue("@OM1", SFHeartAngiography.OM1);
        com.Parameters.AddWithValue("@OM2", SFHeartAngiography.OM2);
        com.Parameters.AddWithValue("@OM3", SFHeartAngiography.OM3);
        com.Parameters.AddWithValue("@RCAProx", SFHeartAngiography.RCAProx);
        com.Parameters.AddWithValue("@RCAMid", SFHeartAngiography.RCAMid);
        com.Parameters.AddWithValue("@RCADistal", SFHeartAngiography.RCADistal);
        com.Parameters.AddWithValue("@PDA", SFHeartAngiography.PDA);
        com.Parameters.AddWithValue("@PLV", SFHeartAngiography.PLV);
        com.Parameters.AddWithValue("@LimaOnLAD", SFHeartAngiography.LimaOnLAD);
        com.Parameters.AddWithValue("@SVGD1", SFHeartAngiography.SVGD1);
        com.Parameters.AddWithValue("@SVGD2", SFHeartAngiography.SVGD2);
        com.Parameters.AddWithValue("@SVGOM1", SFHeartAngiography.SVGOM1);
        com.Parameters.AddWithValue("@SVGOM2", SFHeartAngiography.SVGOM2);
        com.Parameters.AddWithValue("@SVGOM3", SFHeartAngiography.SVGOM3);
        com.Parameters.AddWithValue("@SVGPDA", SFHeartAngiography.SVGPDA);
        com.Parameters.AddWithValue("@SVGRCA", SFHeartAngiography.SVGRCA);
        com.Parameters.AddWithValue("@SVGPLV", SFHeartAngiography.SVGPLV);
        com.Parameters.AddWithValue("@SVGRamos", SFHeartAngiography.SVGRamos);
        com.Parameters.AddWithValue("@LVEF", SFHeartAngiography.LVEF);
        com.Parameters.AddWithValue("@MR", SFHeartAngiography.MR);
        com.Parameters.AddWithValue("@LMNote", SFHeartAngiography.LMNote);
        com.Parameters.AddWithValue("@LADProxNote", SFHeartAngiography.LADProxNote);
        com.Parameters.AddWithValue("@LADMidNote", SFHeartAngiography.LADMidNote);
        com.Parameters.AddWithValue("@LADDistalNote", SFHeartAngiography.LADDistalNote);
        com.Parameters.AddWithValue("@D1Note", SFHeartAngiography.D1Note);
        com.Parameters.AddWithValue("@D2Note", SFHeartAngiography.D2Note);
        com.Parameters.AddWithValue("@LCXProxNote", SFHeartAngiography.LCXProxNote);
        com.Parameters.AddWithValue("@LCXDistalNote", SFHeartAngiography.LCXDistalNote);
        com.Parameters.AddWithValue("@OM1Note", SFHeartAngiography.OM1Note);
        com.Parameters.AddWithValue("@OM2Note", SFHeartAngiography.OM2Note);
        com.Parameters.AddWithValue("@OM3Note", SFHeartAngiography.OM3Note);
        com.Parameters.AddWithValue("@RCAProxNote", SFHeartAngiography.RCAProxNote);
        com.Parameters.AddWithValue("@RCAMidNote", SFHeartAngiography.RCAMidNote);
        com.Parameters.AddWithValue("@RCADistalNote", SFHeartAngiography.RCADistalNote);
        com.Parameters.AddWithValue("@PDANote", SFHeartAngiography.PDANote);
        com.Parameters.AddWithValue("@PLVNote", SFHeartAngiography.PLVNote);
        com.Parameters.AddWithValue("@LIMAonLADNote", SFHeartAngiography.LIMAonLADNote);
        com.Parameters.AddWithValue("@SVGD1Note", SFHeartAngiography.SVGD1Note);
        com.Parameters.AddWithValue("@SVGD2Note", SFHeartAngiography.SVGD2Note);
        com.Parameters.AddWithValue("@SVGOM1Note", SFHeartAngiography.SVGOM1Note);
        com.Parameters.AddWithValue("@SVGOM2Note", SFHeartAngiography.SVGOM2Note);
        com.Parameters.AddWithValue("@SVGOM3Note", SFHeartAngiography.SVGOM3Note);
        com.Parameters.AddWithValue("@SVGPDANote", SFHeartAngiography.SVGPDANote);
        com.Parameters.AddWithValue("@SVGRCANote", SFHeartAngiography.SVGRCANote);
        com.Parameters.AddWithValue("@SVGPLVNote", SFHeartAngiography.SVGPLVNote);
        com.Parameters.AddWithValue("@SVGRamosNote", SFHeartAngiography.SVGRamosNote);
        com.Parameters.AddWithValue("@LVEFNote", SFHeartAngiography.LVEFNote);
        com.Parameters.AddWithValue("@MRNote", SFHeartAngiography.MRNote);
        com.Parameters.AddWithValue("@RadialOn", SFHeartAngiography.RadialOn);
        com.Parameters.AddWithValue("@ResultText", SFHeartAngiography.ResultText);
        com.Parameters.AddWithValue("@PlanText", SFHeartAngiography.PlanText);
        com.Parameters.AddWithValue("@ResultText2", SFHeartAngiography.ResultText2);
        com.Parameters.AddWithValue("@PlanText2", SFHeartAngiography.PlanText2);

        com.Parameters.AddWithValue("@NECA", SFHeartAngiography.NECA);
        com.Parameters.AddWithValue("@MildCAD", SFHeartAngiography.MildCAD);
        com.Parameters.AddWithValue("@Ectasia", SFHeartAngiography.Ectasia);
        com.Parameters.AddWithValue("@MuscleBridge", SFHeartAngiography.MuscleBridge);
        com.Parameters.AddWithValue("@SVD", SFHeartAngiography.SVD);
        com.Parameters.AddWithValue("@2VD", SFHeartAngiography.VD2);
        com.Parameters.AddWithValue("@3VD", SFHeartAngiography.VD3);
        com.Parameters.AddWithValue("@LMResult", SFHeartAngiography.LMResult);
        com.Parameters.AddWithValue("@MTX", SFHeartAngiography.MTX);
        com.Parameters.AddWithValue("@PCION", SFHeartAngiography.PCION);
        com.Parameters.AddWithValue("@CABG", SFHeartAngiography.CABG);
        com.Parameters.AddWithValue("@StagePCION", SFHeartAngiography.StagePCION);
        com.Parameters.AddWithValue("@UserPersID", SFHeartAngiography.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSFHeartAngiography");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.SFHeartAngiography>(dRow);
    }
}