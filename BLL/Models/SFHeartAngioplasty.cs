using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("SFHeartAngioplasty")]
public class SFHeartAngioplasty
{
    public SFHeartAngioplasty()
    {
        CRUD = 0;
        EncID = 0;
        PageID = 0;
        ServiceCode = 0;
        Date = null;
        LMBrand = 0;
        LMDiameter = 0;
        LADProxBrand = 0;
        LADProxDiameter = 0;
        LADMidBrand = 0;
        LADMidDiameter = 0;
        LADDistalBrand = 0;
        LADDistalDiameter = 0;
        D1Brand = 0;
        D1Diameter = 0;
        D2Brand = 0;
        D2Diameter = 0;
        LCXProxBrand = 0;
        LCXProxDiameter = 0;
        LCXDistalBrand = 0;
        LCXDistalDiameter = 0;
        OM1Brand = 0;
        OM1Diameter = 0;
        OM2Brand = 0;
        OM2Diameter = 0;
        RCAProxBrand = 0;
        RCAProxDiameter = 0;
        RCAMidBrand = 0;
        RCAMidDiameter = 0;
        RCADistalBrand = 0;
        RCADistalDiameter = 0;
        PDABrand = 0;
        PDADiameter = 0;
        PLVBrand = 0;
        PLVDiameter = 0;
        LIMAonLADBrand = 0;
        LIMAonLADDiameter = 0;
        SVGD1Brand = 0;
        SVGD1Diameter = 0;
        SVGD2Brand = 0;
        SVGD2Diameter = 0;
        SVGOM1Brand = 0;
        SVGOM1Diameter = 0;
        SVGOM2Brand = 0;
        SVGOM2Diameter = 0;
        SVGOM3Brand = 0;
        SVGOM3Diameter = 0;
        SVGPDABrand = 0;
        SVGPDADiameter = 0;
        SVGRCABrand = 0;
        SVGRCADiameter = 0;
        SVGPLVBrand = 0;
        SVGPLVDiameter = 0;
        SVGRamosBrand = 0;
        SVGRamosDiameter = 0;
        RadialOnBrand = 0;
        RadialOnDiameter = 0;
        LVEFBrand = 0;
        LVEFDiameter = 0;
        MRBrand = 0;
        MRDiameter = 0;
        MTX = false;
        CABG = false;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CRUD { get; set; } // int, not null

    public int SFAngioplastyID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public int PageID { get; set; } // int, not null
    public int ServiceCode { get; set; } // int, not null
    public string Date { get; set; }
    public int LMBrand { get; set; } // int, not null
    public int LMDiameter { get; set; } // int, not null
    public int? LMLength { get; set; } // int, null
    [MaxLength] public string LMNote { get; set; } // nvarchar(max), null
    public int LADProxBrand { get; set; } // int, not null
    public int LADProxDiameter { get; set; } // int, not null
    public int? LADProxLength { get; set; } // int, null
    [MaxLength] public string LADProxNote { get; set; } // nvarchar(max), null
    public int LADMidBrand { get; set; } // int, not null
    public int LADMidDiameter { get; set; } // int, not null
    public int? LADMidLength { get; set; } // int, null
    [MaxLength] public string LADMidNote { get; set; } // nvarchar(max), null
    public int LADDistalBrand { get; set; } // int, not null
    public int LADDistalDiameter { get; set; } // int, not null
    public int? LADDistalLength { get; set; } // int, null
    [MaxLength] public string LADDistalNote { get; set; } // nvarchar(max), null
    public int D1Brand { get; set; } // int, not null
    public int D1Diameter { get; set; } // int, not null
    public int? D1Length { get; set; } // int, null
    [MaxLength] public string D1Note { get; set; } // nvarchar(max), null
    public int D2Brand { get; set; } // int, not null
    public int D2Diameter { get; set; } // int, not null
    public int? D2Length { get; set; } // int, null
    [MaxLength] public string D2Note { get; set; } // nvarchar(max), null
    public int LCXProxBrand { get; set; } // int, not null
    public int LCXProxDiameter { get; set; } // int, not null
    public int? LCXProxLength { get; set; } // int, null
    [MaxLength] public string LCXProxNote { get; set; } // nvarchar(max), null
    public int LCXDistalBrand { get; set; } // int, not null
    public int LCXDistalDiameter { get; set; } // int, not null
    public int? LCXDistalLength { get; set; } // int, null
    [MaxLength] public string LCXDistalNote { get; set; } // nvarchar(max), null
    public int OM1Brand { get; set; } // int, not null
    public int OM1Diameter { get; set; } // int, not null
    public int? OM1Length { get; set; } // int, null
    [MaxLength] public string OM1Note { get; set; } // nvarchar(max), null
    public int OM2Brand { get; set; } // int, not null
    public int OM2Diameter { get; set; } // int, not null
    public int? OM2Length { get; set; } // int, null
    [MaxLength] public string OM2Note { get; set; } // nvarchar(max), null
    public int OM3Brand { get; set; } // int, not null
    public int OM3Diameter { get; set; } // int, not null
    public int? OM3Length { get; set; } // int, null
    [MaxLength] public string OM3Note { get; set; } // nvarchar(max), null
    public int RCAProxBrand { get; set; } // int, not null
    public int RCAProxDiameter { get; set; } // int, not null
    public int? RCAProxLength { get; set; } // int, null
    [MaxLength] public string RCAProxNote { get; set; } // nvarchar(max), null
    public int RCAMidBrand { get; set; } // int, not null
    public int RCAMidDiameter { get; set; } // int, not null
    public int? RCAMidLength { get; set; } // int, null
    [MaxLength] public string RCAMidNote { get; set; } // nvarchar(max), null
    public int RCADistalBrand { get; set; } // int, not null
    public int RCADistalDiameter { get; set; } // int, not null
    public int? RCADistalLength { get; set; } // int, null
    [MaxLength] public string RCADistalNote { get; set; } // nvarchar(max), null
    public int PDABrand { get; set; } // int, not null
    public int PDADiameter { get; set; } // int, not null
    public int? PDALength { get; set; } // int, null
    [MaxLength] public string PDANote { get; set; } // nvarchar(max), null
    public int PLVBrand { get; set; } // int, not null
    public int PLVDiameter { get; set; } // int, not null
    public int? PLVLength { get; set; } // int, null
    [MaxLength] public string PLVNote { get; set; } // nvarchar(max), null
    [MaxLength] public string Result1 { get; set; } // nvarchar(max), null
    [MaxLength] public string Plan1 { get; set; } // nvarchar(max), null
    public int LIMAonLADBrand { get; set; } // int, not null
    public int LIMAonLADDiameter { get; set; } // int, not null
    public int? LIMAonLADLength { get; set; } // int, null
    [MaxLength] public string LIMAonLADNote { get; set; } // nvarchar(max), null
    public int SVGD1Brand { get; set; } // int, not null
    public int SVGD1Diameter { get; set; } // int, not null
    public int? SVGD1Length { get; set; } // int, null
    [MaxLength] public string SVGD1Note { get; set; } // nvarchar(max), null
    public int SVGD2Brand { get; set; } // int, not null
    public int SVGD2Diameter { get; set; } // int, not null
    public int? SVGD2Length { get; set; } // int, null
    [MaxLength] public string SVGD2Note { get; set; } // nvarchar(max), null
    public int SVGOM1Brand { get; set; } // int, not null
    public int SVGOM1Diameter { get; set; } // int, not null
    public int? SVGOM1Length { get; set; } // int, null
    [MaxLength] public string SVGOM1Note { get; set; } // nvarchar(max), null
    public int SVGOM2Brand { get; set; } // int, not null
    public int SVGOM2Diameter { get; set; } // int, not null
    public int? SVGOM2Length { get; set; } // int, null
    [MaxLength] public string SVGOM2Note { get; set; } // nvarchar(max), null
    public int SVGOM3Brand { get; set; } // int, not null
    public int SVGOM3Diameter { get; set; } // int, not null
    public int? SVGOM3Length { get; set; } // int, null
    [MaxLength] public string SVGOM3Note { get; set; } // nvarchar(max), null
    public int SVGPDABrand { get; set; } // int, not null
    public int SVGPDADiameter { get; set; } // int, not null
    public int? SVGPDALength { get; set; } // int, null
    [MaxLength] public string SVGPDANote { get; set; } // nvarchar(max), null
    public int SVGRCABrand { get; set; } // int, not null
    public int SVGRCADiameter { get; set; } // int, not null
    public int? SVGRCALength { get; set; } // int, null
    [MaxLength] public string SVGRCANote { get; set; } // nvarchar(max), null
    public int SVGPLVBrand { get; set; } // int, not null
    public int SVGPLVDiameter { get; set; } // int, not null
    public int? SVGPLVLength { get; set; } // int, null
    [MaxLength] public string SVGPLVNote { get; set; } // nvarchar(max), null
    public int SVGRamosBrand { get; set; } // int, not null
    public int SVGRamosDiameter { get; set; } // int, not null
    public int? SVGRamosLength { get; set; } // int, null
    [MaxLength] public string SVGRamosNote { get; set; } // nvarchar(max), null
    public int RadialOnBrand { get; set; } // int, not null
    public int RadialOnDiameter { get; set; } // int, not null
    public int? RadialOnLength { get; set; } // int, null
    [MaxLength] public string RadialOnNote { get; set; } // nvarchar(max), null
    public int LVEFBrand { get; set; } // int, not null
    public int LVEFDiameter { get; set; } // int, not null
    public int? LVEFLength { get; set; } // int, null
    [MaxLength] public string LVEFNote { get; set; } // nvarchar(max), null
    public int MRBrand { get; set; } // int, not null
    public int MRDiameter { get; set; } // int, not null
    public int? MRLength { get; set; } // int, null
    [MaxLength] public string MRNote { get; set; } // nvarchar(max), null
    [MaxLength] public string Result2 { get; set; } // nvarchar(max), null
    [MaxLength] public string Plan2 { get; set; } // nvarchar(max), null

    public bool? MTX { get; set; } // bit, null
    public int PCION { get; set; } // int, not null
    public bool? CABG { get; set; } // bit, null
    public int StagePCION { get; set; } // int, not null
    public int UserPersID { get; set; } // int, not null
}