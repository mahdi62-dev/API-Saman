using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("SFHeartEcho")]
public class SFHeartEcho
{
    public SFHeartEcho()
    {
        CRUD = 0;
        EncID = 0;
        PageID = 0;
        ServiceCode = 0;
        Date = null;
        ArtiumIntact = false;
        ArtiumASD = false;
        ArtiumPFO = false;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CRUD { get; set; } // int, not null

    public int SFHeartEchoID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public int PageID { get; set; } // int, not null
    public int ServiceCode { get; set; } // int, not null
    public string Date { get; set; }

    public int? AtriumLASize { get; set; } // int, not null
    public double? AtriumLADiameter { get; set; } // float, null
    public double? AtriumLAArea { get; set; } // float, null
    public int? AtriumAorticRootSize { get; set; } // int, not null
    public double? AtriumAorticRootDiameter { get; set; } // float, null
    public int? AtriumRASize { get; set; } // int, not null
    public double? AtriumRADiameter { get; set; } // float, null
    public double? AtriumRAArea { get; set; } // float, null
    public string ArtiumIAS { get; set; } // tinyint, null
    public bool? ArtiumIntact { get; set; } // bit, null
    public bool? ArtiumASD { get; set; } // bit, null
    public bool? ArtiumPFO { get; set; } // bit, null
    [MaxLength] public string ArtiumNote { get; set; } // nvarchar(max), null
    public int? LVSize { get; set; } // int, not null
    public int? LVFunction { get; set; } // int, not null
    public int? LVThickness { get; set; } // int, not null
    public int? LVDiastolicFunction { get; set; } // int, not null
    public double? LVEDD { get; set; } // int, null
    public double? LVESD { get; set; } // int, null
    public double? LVDIVS { get; set; } // int, null
    public double? LVDPW { get; set; } // int, null
    public double? LvSimpsons { get; set; } // float, null
    public string LVIVS { get; set; } // int, null
    public bool? LVIntact { get; set; } // bit, null
    public bool? LVDefect { get; set; } // bit, null
    public string LVEF { get; set; } // float, null
    [MaxLength] public string LVNote { get; set; } // nvarchar(max), null
    public bool? MitralThick { get; set; } // bit, null
    public bool? MitralCalcified { get; set; } // bit, null
    public bool? MitralDomeShape { get; set; } // bit, null
    public bool? MitralMyxomatous { get; set; } // bit, null
    public bool? MitralBioProsthetic { get; set; } // bit, null
    public bool? Mitralprolaptic { get; set; } // bit, null
    public bool? MitralMechanicalProsthetic { get; set; } // bit, null
    public bool? MitralMAC { get; set; } // bit, null
    [MaxLength(500)] public string MitralprolapticNote { get; set; } // nvarchar(500), null
    public int? MitralRegurgitation { get; set; } // int, not null
    public int? MitralRegurgitationSeverity { get; set; } // int, not null
    public int? MitralStenosis { get; set; } // int, not null
    public int? MitralStenosisType { get; set; } // int, not null
    public double? MitralPeak { get; set; } // int, null
    public double? MitralMean { get; set; } // int, null
    public double? MitralPlanimetery { get; set; } // int, null
    public double? MitralPHT { get; set; } // int, null
    [MaxLength(500)] public string MitralNote { get; set; } // nvarchar(500), null
    public bool? WMAnteriorHypokinesia { get; set; } // bit, null
    public bool? WMAnteriorAkinesia { get; set; } // bit, null
    public bool? WMAnteriorDyskinesia { get; set; } // bit, null
    public bool? WMAnteriorAneurysm { get; set; } // bit, null
    public bool? WMAnteriorBasal { get; set; } // bit, null
    public bool? WMAnteriorMid { get; set; } // bit, null
    public bool? WMAnteriorApical { get; set; } // bit, null
    public bool? WMSeptalHypokinesia { get; set; } // bit, null
    public bool? WMSeptalAkinesia { get; set; } // bit, null
    public bool? WMSeptalDyskinesia { get; set; } // bit, null
    public bool? WMSeptalAneurysm { get; set; } // bit, null
    public bool? WMSeptalBasal { get; set; } // bit, null
    public bool? WMSeptalMid { get; set; } // bit, null
    public bool? WMSeptalApical { get; set; } // bit, null
    public bool? WMLeteralHypokinesia { get; set; } // bit, null
    public bool? WMLeteralAkinesia { get; set; } // bit, null
    public bool? WMLeteralDyskinesia { get; set; } // bit, null
    public bool? WMLeteralAneurysm { get; set; } // bit, null
    public bool? WMLeteralBasal { get; set; } // bit, null
    public bool? WMLeteralMid { get; set; } // bit, null
    public bool? WMLeteralApical { get; set; } // bit, null
    public bool? WMInferiorHypokinesia { get; set; } // bit, null
    public bool? WMInferiorAkinesia { get; set; } // bit, null
    public bool? WMInferiorDyskinesia { get; set; } // bit, null
    public bool? WMInferiorAneurysm { get; set; } // bit, null
    public bool? WMInferiorBasal { get; set; } // bit, null
    public bool? WMInferiorMid { get; set; } // bit, null
    public bool? WMInferiorApical { get; set; } // bit, null
    public bool? WMPosteriorHypokinesia { get; set; } // bit, null
    public bool? WMPosteriorAkinesia { get; set; } // bit, null
    public bool? WMPosteriorDyskinesia { get; set; } // bit, null
    public bool? WMPosteriorAneurysm { get; set; } // bit, null
    public bool? WMPosteriorBasal { get; set; } // bit, null
    public bool? WMPosteriorMid { get; set; } // bit, null
    public bool? WMPosteriorApical { get; set; } // bit, null
    public bool? WMApicalHypokinesia { get; set; } // bit, null
    public bool? WMApicalAkinesia { get; set; } // bit, null
    public bool? WMApicalDyskinesia { get; set; } // bit, null
    public bool? WMApicalAneurysm { get; set; } // bit, null
    public int? RVSize { get; set; } // int, not null
    public int? RVFunction { get; set; } // int, not null
    public double? RVTapse { get; set; } // int, null
    public double? RVDD { get; set; } // int, null
    public double? RVTickness { get; set; } // int, null
    public double? RVSM { get; set; } // int, null
    public double? RVOTDiameter { get; set; } // int, null
    [MaxLength(500)] public string RVNote { get; set; } // nvarchar(500), null
    [MaxLength(10)] public string Dt { get; set; } // nvarchar(10), null
    [MaxLength(10)] public string IVRT { get; set; } // nvarchar(10), null
    [MaxLength(10)] public string EARatio { get; set; } // nvarchar(10), null
    [MaxLength(10)] public string Asep { get; set; } // nvarchar(10), null
    [MaxLength(10)] public string EFSlope { get; set; } // nvarchar(10), null
    [MaxLength(10)] public string EPSS { get; set; } // nvarchar(10), null
    [MaxLength(10)] public string ESep { get; set; } // nvarchar(10), null
    [MaxLength(10)] public string ELat { get; set; } // nvarchar(10), null
    [MaxLength(10)] public string EE { get; set; } // nvarchar(10), null
    [MaxLength(10)] public string MVA { get; set; } // nvarchar(10), null
    public bool? AortThick { get; set; } // bit, null
    public bool? AortCalcified { get; set; } // bit, null
    public bool? AortDomeShape { get; set; } // bit, null
    public bool? AortMyxomatous { get; set; } // bit, null
    public bool? AortBioProsthetic { get; set; } // bit, null
    public bool? AortMechanicalProsthetic { get; set; } // bit, null
    public bool? Aortprolaptic { get; set; } // bit, null
    [MaxLength(500)] public string AortprolapticNote { get; set; } // nvarchar(500), null
    public int? AortRegurgitation { get; set; } // int, not null
    public int? AortRegurgitationSeverity { get; set; } // int, not null
    public int? AortStenosis { get; set; } // int, not null
    public int? AortStenosisType { get; set; } // int, not null
    [MaxLength(50)] public string AortAera { get; set; } // varchar(50), null
    public double? AortPHT { get; set; } // int, null
    public double? AortAVVTI { get; set; } // int, null
    public double? AortAVA { get; set; } // int, null
    public double? AortPeak { get; set; } // int, null
    public double? AortMean { get; set; } // int, null
    public double? AortLVOTDiameter { get; set; } // int, null
    public double? AortLVOTPG { get; set; } // int, null
    public double? AortLVOTMG { get; set; } // int, null
    public double? AortLVOTVTI { get; set; } // int, null
    public int? AortThoracicAort { get; set; } // int, not null
    public double? AortThoracicAortDiameter { get; set; } // int, null
    [MaxLength(500)] public string AortNote { get; set; } // nvarchar(500), null
    public int? TricRegurgitation { get; set; } // int, not null
    public int? TricRegurgitationSeverity { get; set; } // int, not null
    public int? TricStenosis { get; set; } // int, not null
    public int? TricStenosisType { get; set; } // int, not null
    public double? TricAera { get; set; } // int, null
    public double? TricPHT { get; set; } // int, null
    public double? TricTRPvel { get; set; } // int, null
    public double? TricSPAP { get; set; } // int, not null
    public int? TricSPAPSeverity { get; set; } // int, not null
    public double? TricPlanimetery { get; set; } // int, null
    public double? TricPeak { get; set; } // int, null
    public double? TricMean { get; set; } // int, null
    [MaxLength(500)] public string TricNote { get; set; } // nvarchar(500), null
    public int? PlumRegurgitation { get; set; } // int, not null
    public int? PlumRegurgitationSeverity { get; set; } // int, not null
    public int? PlumStenosis { get; set; } // int, not null
    public int? PlumStenosisType { get; set; } // int, not null
    public double? PlumPHT { get; set; } // int, null
    public double? PlumACT { get; set; } // int, null
    public double? PlumPeak { get; set; } // int, null
    public double? PlumMean { get; set; } // int, null
    [MaxLength(500)] public string PlumNote { get; set; } // nvarchar(500), null

    public int? Pericardium { get; set; } // int, not null
    public int? PericardiumAnteriorChamber { get; set; } // int, not null
    public int? PericardiumInferiorChamber { get; set; } // int, not null
    public int? PericardiumPosteriorChamber { get; set; } // int, not null
    public int? PericardiumLeteralChamber { get; set; } // int, not null
    public double? PericardiumAnteriorDiameter { get; set; } // int, null
    public double? PericardiumInferiorDiameter { get; set; } // int, null
    public double? PericardiumPosteriorDiameter { get; set; } // int, null
    public double? PericardiumLeteralDiameter { get; set; } // int, null
    public int? PericardiumAnteriorDiameter2 { get; set; } // int, null
    public int? PericardiumInferiorDiameter2 { get; set; } // int, null
    public int? PericardiumPosteriorDiameter2 { get; set; } // int, null
    public int? PericardiumLeteralDiameter2 { get; set; } // int, null
    public int? PEGrade { get; set; } // int, not null
    public int? IVCStatus { get; set; } // int, not null
    public double? IVCSize { get; set; } // int, not null
    public int? IVCRespiratoryCollapse { get; set; } // int, not null

    [MaxLength(500)] public string PericardiumNote { get; set; } // nvarchar(500), null
    public string Recomendation { get; set; } // nvarchar(500), null
    public string RecomendationNote { get; set; } // nvarchar(500), null
    public string Conclusion { get; set; } = "";
    public int UserPersID { get; set; } // int, not null
}