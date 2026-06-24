using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("SFHeartAngiography")]
public class SFHeartAngiography
{
    public SFHeartAngiography()
    {
        CRUD = 0;
        EncID = 0;
        PageID = 0;
        ServiceCode = 0;
        Date = null;
        LM = 0;
        LADProx = 0;
        LADMid = 0;
        LADDistal = 0;
        D1 = 0;
        D2 = 0;
        LCXProx = 0;
        LCXDistal = 0;
        OM1 = 0;
        OM2 = 0;
        OM3 = 0;
        RCAProx = 0;
        RCAMid = 0;
        RCADistal = 0;
        PDA = 0;
        PLV = 0;
        LimaOnLAD = 0;
        SVGD1 = 0;
        SVGD2 = 0;
        SVGOM1 = 0;
        SVGOM2 = 0;
        SVGOM3 = 0;
        SVGPDA = 0;
        SVGRCA = 0;
        SVGPLV = 0;
        SVGRamos = 0;
        LVEF = 0;
        MR = 0;
        NECA = false;
        MildCAD = false;
        Ectasia = false;
        MuscleBridge = false;
        SVD = false;
        VD2 = false;
        VD3 = false;
        LMResult = false;
        MTX = false;
        CABG = false;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CRUD { get; set; } // int, not null

    public int SFAngiographyID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public int PageID { get; set; } // int, not null
    public int ServiceCode { get; set; } // int, not null
    public string Date { get; set; }
    public int LM { get; set; } // int, not null
    public int LADProx { get; set; } // int, not null
    public int LADMid { get; set; } // int, not null
    public int LADDistal { get; set; } // int, not null
    public int D1 { get; set; } // int, not null
    public int D2 { get; set; } // int, not null
    public int LCXProx { get; set; } // int, not null
    public int LCXDistal { get; set; } // int, not null
    public int OM1 { get; set; } // int, not null
    public int OM2 { get; set; } // int, not null
    public int OM3 { get; set; } // int, not null
    public int RCAProx { get; set; } // int, not null
    public int RCAMid { get; set; } // int, not null
    public int RCADistal { get; set; } // int, not null
    public int PDA { get; set; } // int, not null
    public int PLV { get; set; } // int, not null
    public int LimaOnLAD { get; set; } // int, not null
    public int SVGD1 { get; set; } // int, not null
    public int SVGD2 { get; set; } // int, not null
    public int SVGOM1 { get; set; } // int, not null
    public int SVGOM2 { get; set; } // int, not null
    public int SVGOM3 { get; set; } // int, not null
    public int SVGPDA { get; set; } // int, not null
    public int SVGRCA { get; set; } // int, not null
    public int SVGPLV { get; set; } // int, not null
    public int SVGRamos { get; set; } // int, not null
    public int LVEF { get; set; } // int, not null
    public int MR { get; set; } // int, not null
    [MaxLength] public string LMNote { get; set; } // nvarchar(max), null
    [MaxLength] public string LADProxNote { get; set; } // nvarchar(max), null
    [MaxLength] public string LADMidNote { get; set; } // nvarchar(max), null
    [MaxLength] public string LADDistalNote { get; set; } // nvarchar(max), null
    [MaxLength] public string D1Note { get; set; } // nvarchar(max), null
    [MaxLength] public string D2Note { get; set; } // nvarchar(max), null
    [MaxLength] public string LCXProxNote { get; set; } // nvarchar(max), null
    [MaxLength] public string LCXDistalNote { get; set; } // nvarchar(max), null
    [MaxLength] public string OM1Note { get; set; } // nvarchar(max), null
    [MaxLength] public string OM2Note { get; set; } // nvarchar(max), null
    [MaxLength] public string OM3Note { get; set; } // nvarchar(max), null
    [MaxLength] public string RCAProxNote { get; set; } // nvarchar(max), null
    [MaxLength] public string RCAMidNote { get; set; } // nvarchar(max), null
    [MaxLength] public string RCADistalNote { get; set; } // nvarchar(max), null
    [MaxLength] public string PDANote { get; set; } // nvarchar(max), null
    [MaxLength] public string PLVNote { get; set; } // nvarchar(max), null
    [MaxLength] public string LIMAonLADNote { get; set; } // nvarchar(max), null
    [MaxLength] public string SVGD1Note { get; set; } // nvarchar(max), null
    [MaxLength] public string SVGD2Note { get; set; } // nvarchar(max), null
    [MaxLength] public string SVGOM1Note { get; set; } // nvarchar(max), null
    [MaxLength] public string SVGOM2Note { get; set; } // nvarchar(max), null
    [MaxLength] public string SVGOM3Note { get; set; } // nvarchar(max), null
    [MaxLength] public string SVGPDANote { get; set; } // nvarchar(max), null
    [MaxLength] public string SVGRCANote { get; set; } // nvarchar(max), null
    [MaxLength] public string SVGPLVNote { get; set; } // nvarchar(max), null
    [MaxLength] public string SVGRamosNote { get; set; } // nvarchar(max), null
    [MaxLength] public string LVEFNote { get; set; } // nvarchar(max), null
    [MaxLength] public string MRNote { get; set; } // nvarchar(max), null
    [MaxLength] public string RadialOn { get; set; } // nvarchar(max), null
    [MaxLength] public string ResultText { get; set; } // nvarchar(max), null
    [MaxLength] public string PlanText { get; set; } // nvarchar(max), null
    [MaxLength] public string ResultText2 { get; set; } // nvarchar(max), null
    [MaxLength] public string PlanText2 { get; set; } // nvarchar(max), null

    public bool? NECA { get; set; } // int, not null
    public bool? MildCAD { get; set; } // int, not null
    public bool? Ectasia { get; set; } // int, not null
    public bool? MuscleBridge { get; set; } // int, not null
    public bool? SVD { get; set; } // int, not null
    public bool? VD2 { get; set; } // int, not null
    public bool? VD3 { get; set; } // int, not null
    public bool? LMResult { get; set; } // int, not null
    public bool? MTX { get; set; } // bit, null
    public int PCION { get; set; } // int, not null
    public bool? CABG { get; set; } // bit, null
    public int StagePCION { get; set; } // int, not null
    public int UserPersID { get; set; } // int, not null
}