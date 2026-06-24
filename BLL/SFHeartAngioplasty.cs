using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class SFHeartAngioplasty
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.SFHeartAngioplasty SFHeartAngioplastyCUD(Models.SFHeartAngioplasty SFHeartAngioplasty)
    {
        var com = new SqlCommand()
            ;
        com.Parameters.AddWithValue("@CRUD", SFHeartAngioplasty.CRUD);
        com.Parameters.AddWithValue("@SFAngioplastyID", SFHeartAngioplasty.SFAngioplastyID);
        com.Parameters.AddWithValue("@EncID", SFHeartAngioplasty.EncID);
        com.Parameters.AddWithValue("@PageID", SFHeartAngioplasty.PageID);
        com.Parameters.AddWithValue("@ServiceCode", SFHeartAngioplasty.ServiceCode);
        com.Parameters.AddWithValue("@LMBrand", SFHeartAngioplasty.LMBrand);
        com.Parameters.AddWithValue("@LMDiameter", SFHeartAngioplasty.LMDiameter);
        com.Parameters.AddWithValue("@LMLength", SFHeartAngioplasty.LMLength);
        com.Parameters.AddWithValue("@LMNote", SFHeartAngioplasty.LMNote);
        com.Parameters.AddWithValue("@LADProxBrand", SFHeartAngioplasty.LADProxBrand);
        com.Parameters.AddWithValue("@LADProxDiameter", SFHeartAngioplasty.LADProxDiameter);
        com.Parameters.AddWithValue("@LADProxLength", SFHeartAngioplasty.LADProxLength);
        com.Parameters.AddWithValue("@LADProxNote", SFHeartAngioplasty.LADProxNote);
        com.Parameters.AddWithValue("@LADMidBrand", SFHeartAngioplasty.LADMidBrand);
        com.Parameters.AddWithValue("@LADMidDiameter", SFHeartAngioplasty.LADMidDiameter);
        com.Parameters.AddWithValue("@LADMidLength", SFHeartAngioplasty.LADMidLength);
        com.Parameters.AddWithValue("@LADMidNote", SFHeartAngioplasty.LADMidNote);
        com.Parameters.AddWithValue("@LADDistalBrand", SFHeartAngioplasty.LADDistalBrand);
        com.Parameters.AddWithValue("@LADDistalDiameter", SFHeartAngioplasty.LADDistalDiameter);
        com.Parameters.AddWithValue("@LADDistalLength", SFHeartAngioplasty.LADDistalLength);
        com.Parameters.AddWithValue("@LADDistalNote", SFHeartAngioplasty.LADDistalNote);
        com.Parameters.AddWithValue("@D1Brand", SFHeartAngioplasty.D1Brand);
        com.Parameters.AddWithValue("@D1Diameter", SFHeartAngioplasty.D1Diameter);
        com.Parameters.AddWithValue("@D1Length", SFHeartAngioplasty.D1Length);
        com.Parameters.AddWithValue("@D1Note", SFHeartAngioplasty.D1Note);
        com.Parameters.AddWithValue("@D2Brand", SFHeartAngioplasty.D2Brand);
        com.Parameters.AddWithValue("@D2Diameter", SFHeartAngioplasty.D2Diameter);
        com.Parameters.AddWithValue("@D2Length", SFHeartAngioplasty.D2Length);
        com.Parameters.AddWithValue("@D2Note", SFHeartAngioplasty.D2Note);
        com.Parameters.AddWithValue("@LCXProxBrand", SFHeartAngioplasty.LCXProxBrand);
        com.Parameters.AddWithValue("@LCXProxDiameter", SFHeartAngioplasty.LCXProxDiameter);
        com.Parameters.AddWithValue("@LCXProxLength", SFHeartAngioplasty.LCXProxLength);
        com.Parameters.AddWithValue("@LCXProxNote", SFHeartAngioplasty.LCXProxNote);
        com.Parameters.AddWithValue("@LCXDistalBrand", SFHeartAngioplasty.LCXDistalBrand);
        com.Parameters.AddWithValue("@LCXDistalDiameter", SFHeartAngioplasty.LCXDistalDiameter);
        com.Parameters.AddWithValue("@LCXDistalLength", SFHeartAngioplasty.LCXDistalLength);
        com.Parameters.AddWithValue("@LCXDistalNote", SFHeartAngioplasty.LCXDistalNote);
        com.Parameters.AddWithValue("@OM1Brand", SFHeartAngioplasty.OM1Brand);
        com.Parameters.AddWithValue("@OM1Diameter", SFHeartAngioplasty.OM1Diameter);
        com.Parameters.AddWithValue("@OM1Length", SFHeartAngioplasty.OM1Length);
        com.Parameters.AddWithValue("@OM1Note", SFHeartAngioplasty.OM1Note);
        com.Parameters.AddWithValue("@OM2Brand", SFHeartAngioplasty.OM2Brand);
        com.Parameters.AddWithValue("@OM2Diameter", SFHeartAngioplasty.OM2Diameter);
        com.Parameters.AddWithValue("@OM2Length", SFHeartAngioplasty.OM2Length);
        com.Parameters.AddWithValue("@OM2Note", SFHeartAngioplasty.OM2Note);
        com.Parameters.AddWithValue("@OM3Brand", SFHeartAngioplasty.OM3Brand);
        com.Parameters.AddWithValue("@OM3Diameter", SFHeartAngioplasty.OM3Diameter);
        com.Parameters.AddWithValue("@OM3Length", SFHeartAngioplasty.OM3Length);
        com.Parameters.AddWithValue("@OM3Note", SFHeartAngioplasty.OM3Note);
        com.Parameters.AddWithValue("@RCAProxBrand", SFHeartAngioplasty.RCAProxBrand);
        com.Parameters.AddWithValue("@RCAProxDiameter", SFHeartAngioplasty.RCAProxDiameter);
        com.Parameters.AddWithValue("@RCAProxLength", SFHeartAngioplasty.RCAProxLength);
        com.Parameters.AddWithValue("@RCAProxNote", SFHeartAngioplasty.RCAProxNote);
        com.Parameters.AddWithValue("@RCAMidBrand", SFHeartAngioplasty.RCAMidBrand);
        com.Parameters.AddWithValue("@RCAMidDiameter", SFHeartAngioplasty.RCAMidDiameter);
        com.Parameters.AddWithValue("@RCAMidLength", SFHeartAngioplasty.RCAMidLength);
        com.Parameters.AddWithValue("@RCAMidNote", SFHeartAngioplasty.RCAMidNote);
        com.Parameters.AddWithValue("@RCADistalBrand", SFHeartAngioplasty.RCADistalBrand);
        com.Parameters.AddWithValue("@RCADistalDiameter", SFHeartAngioplasty.RCADistalDiameter);
        com.Parameters.AddWithValue("@RCADistalLength", SFHeartAngioplasty.RCADistalLength);
        com.Parameters.AddWithValue("@RCADistalNote", SFHeartAngioplasty.RCADistalNote);
        com.Parameters.AddWithValue("@PDABrand", SFHeartAngioplasty.PDABrand);
        com.Parameters.AddWithValue("@PDADiameter", SFHeartAngioplasty.PDADiameter);
        com.Parameters.AddWithValue("@PDALength", SFHeartAngioplasty.PDALength);
        com.Parameters.AddWithValue("@PDANote", SFHeartAngioplasty.PDANote);
        com.Parameters.AddWithValue("@PLVBrand", SFHeartAngioplasty.PLVBrand);
        com.Parameters.AddWithValue("@PLVDiameter", SFHeartAngioplasty.PLVDiameter);
        com.Parameters.AddWithValue("@PLVLength", SFHeartAngioplasty.PLVLength);
        com.Parameters.AddWithValue("@PLVNote", SFHeartAngioplasty.PLVNote);
        com.Parameters.AddWithValue("@Result1", SFHeartAngioplasty.Result1);
        com.Parameters.AddWithValue("@Plan1", SFHeartAngioplasty.Plan1);
        com.Parameters.AddWithValue("@LIMAonLADBrand", SFHeartAngioplasty.LIMAonLADBrand);
        com.Parameters.AddWithValue("@LIMAonLADDiameter", SFHeartAngioplasty.LIMAonLADDiameter);
        com.Parameters.AddWithValue("@LIMAonLADLength", SFHeartAngioplasty.LIMAonLADLength);
        com.Parameters.AddWithValue("@LIMAonLADNote", SFHeartAngioplasty.LIMAonLADNote);
        com.Parameters.AddWithValue("@SVGD1Brand", SFHeartAngioplasty.SVGD1Brand);
        com.Parameters.AddWithValue("@SVGD1Diameter", SFHeartAngioplasty.SVGD1Diameter);
        com.Parameters.AddWithValue("@SVGD1Length", SFHeartAngioplasty.SVGD1Length);
        com.Parameters.AddWithValue("@SVGD1Note", SFHeartAngioplasty.SVGD1Note);
        com.Parameters.AddWithValue("@SVGD2Brand", SFHeartAngioplasty.SVGD2Brand);
        com.Parameters.AddWithValue("@SVGD2Diameter", SFHeartAngioplasty.SVGD2Diameter);
        com.Parameters.AddWithValue("@SVGD2Length", SFHeartAngioplasty.SVGD2Length);
        com.Parameters.AddWithValue("@SVGD2Note", SFHeartAngioplasty.SVGD2Note);
        com.Parameters.AddWithValue("@SVGOM1Brand", SFHeartAngioplasty.SVGOM1Brand);
        com.Parameters.AddWithValue("@SVGOM1Diameter", SFHeartAngioplasty.SVGOM1Diameter);
        com.Parameters.AddWithValue("@SVGOM1Length", SFHeartAngioplasty.SVGOM1Length);
        com.Parameters.AddWithValue("@SVGOM1Note", SFHeartAngioplasty.SVGOM1Note);
        com.Parameters.AddWithValue("@SVGOM2Brand", SFHeartAngioplasty.SVGOM2Brand);
        com.Parameters.AddWithValue("@SVGOM2Diameter", SFHeartAngioplasty.SVGOM2Diameter);
        com.Parameters.AddWithValue("@SVGOM2Length", SFHeartAngioplasty.SVGOM2Length);
        com.Parameters.AddWithValue("@SVGOM2Note", SFHeartAngioplasty.SVGOM2Note);
        com.Parameters.AddWithValue("@SVGOM3Brand", SFHeartAngioplasty.SVGOM3Brand);
        com.Parameters.AddWithValue("@SVGOM3Diameter", SFHeartAngioplasty.SVGOM3Diameter);
        com.Parameters.AddWithValue("@SVGOM3Length", SFHeartAngioplasty.SVGOM3Length);
        com.Parameters.AddWithValue("@SVGOM3Note", SFHeartAngioplasty.SVGOM3Note);
        com.Parameters.AddWithValue("@SVGPDABrand", SFHeartAngioplasty.SVGPDABrand);
        com.Parameters.AddWithValue("@SVGPDADiameter", SFHeartAngioplasty.SVGPDADiameter);
        com.Parameters.AddWithValue("@SVGPDALength", SFHeartAngioplasty.SVGPDALength);
        com.Parameters.AddWithValue("@SVGPDANote", SFHeartAngioplasty.SVGPDANote);
        com.Parameters.AddWithValue("@SVGRCABrand", SFHeartAngioplasty.SVGRCABrand);
        com.Parameters.AddWithValue("@SVGRCADiameter", SFHeartAngioplasty.SVGRCADiameter);
        com.Parameters.AddWithValue("@SVGRCALength", SFHeartAngioplasty.SVGRCALength);
        com.Parameters.AddWithValue("@SVGRCANote", SFHeartAngioplasty.SVGRCANote);
        com.Parameters.AddWithValue("@SVGPLVBrand", SFHeartAngioplasty.SVGPLVBrand);
        com.Parameters.AddWithValue("@SVGPLVDiameter", SFHeartAngioplasty.SVGPLVDiameter);
        com.Parameters.AddWithValue("@SVGPLVLength", SFHeartAngioplasty.SVGPLVLength);
        com.Parameters.AddWithValue("@SVGPLVNote", SFHeartAngioplasty.SVGPLVNote);
        com.Parameters.AddWithValue("@SVGRamosBrand", SFHeartAngioplasty.SVGRamosBrand);
        com.Parameters.AddWithValue("@SVGRamosDiameter", SFHeartAngioplasty.SVGRamosDiameter);
        com.Parameters.AddWithValue("@SVGRamosLength", SFHeartAngioplasty.SVGRamosLength);
        com.Parameters.AddWithValue("@SVGRamosNote", SFHeartAngioplasty.SVGRamosNote);
        com.Parameters.AddWithValue("@RadialOnBrand", SFHeartAngioplasty.RadialOnBrand);
        com.Parameters.AddWithValue("@RadialOnDiameter", SFHeartAngioplasty.RadialOnDiameter);
        com.Parameters.AddWithValue("@RadialOnLength", SFHeartAngioplasty.RadialOnLength);
        com.Parameters.AddWithValue("@RadialOnNote", SFHeartAngioplasty.RadialOnNote);
        com.Parameters.AddWithValue("@LVEFBrand", SFHeartAngioplasty.LVEFBrand);
        com.Parameters.AddWithValue("@LVEFDiameter", SFHeartAngioplasty.LVEFDiameter);
        com.Parameters.AddWithValue("@LVEFLength", SFHeartAngioplasty.LVEFLength);
        com.Parameters.AddWithValue("@LVEFNote", SFHeartAngioplasty.LVEFNote);
        com.Parameters.AddWithValue("@MRBrand", SFHeartAngioplasty.MRBrand);
        com.Parameters.AddWithValue("@MRDiameter", SFHeartAngioplasty.MRDiameter);
        com.Parameters.AddWithValue("@MRLength", SFHeartAngioplasty.MRLength);
        com.Parameters.AddWithValue("@MRNote", SFHeartAngioplasty.MRNote);
        com.Parameters.AddWithValue("@Result2", SFHeartAngioplasty.Result2);
        com.Parameters.AddWithValue("@Plan2", SFHeartAngioplasty.Plan2);

        com.Parameters.AddWithValue("@MTX", SFHeartAngioplasty.MTX);
        com.Parameters.AddWithValue("@PCION", SFHeartAngioplasty.PCION);
        com.Parameters.AddWithValue("@CABG", SFHeartAngioplasty.CABG);
        com.Parameters.AddWithValue("@StagePCION", SFHeartAngioplasty.StagePCION);

        com.Parameters.AddWithValue("@UserPersID", SFHeartAngioplasty.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSFHeartAngioplasty");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.SFHeartAngioplasty>(dRow);
    }
}