using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("SFHeartMD")]
public class SFHeartMD
{
    public SFHeartMD()
    {
        CRUD = 0;
        FuncType = 0;
        ChiefComplaint = null;
        V1 = false;
        V2 = false;
        V3 = false;
        V4 = false;
        V5 = false;
        V6 = false;
        V7 = false;
        V8 = false;
        V9 = false;
        V10 = false;
        V11 = false;
        V12 = false;
        V13 = false;
        V14 = false;
        V15 = false;
        V16 = false;
        V17 = false;
        V18 = false;
        V19 = false;
        V20 = false;
        V21 = false;
        V22 = false;
        V23 = false;
        V24 = false;
        V25 = false;
        V26 = false;
        V27 = false;
        V28 = false;
        UserPersID = 0;
    }

    public int CRUD { get; set; } // int, not null
    public int FuncType { get; set; } // int, not null

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SFHeartMDID { get; set; } // int, not null

    public int EncID { get; set; } // int, not null
    public int PatientID { get; set; } // int, not null

    public string Note { get; set; } // nvarchar(max), null
    public string PMHNote { get; set; } // nvarchar(max), null

    public string ChiefComplaint { get; set; } // int, not null
    [MaxLength] public string ChiefComplaintNote { get; set; } // nvarchar(max), null
    public string HeartRate { get; set; } // int, null
    [MaxLength] public string HeartRateNote { get; set; } // nvarchar(max), null
    public string RightBPSystolic { get; set; } // float, null
    public string RightBPDiastolic { get; set; } // float, null
    [MaxLength] public string RightBPNote { get; set; } // nvarchar(max), null

    public string LeftBPSystolic { get; set; } // float, null
    public string LeftBPDiastolic { get; set; } // float, null
    [MaxLength] public string LeftBPNote { get; set; } // nvarchar(max), null

    public bool V1 { get; set; } // bit, not null
    public bool V2 { get; set; } // bit, not null
    public bool V3 { get; set; } // bit, not null
    public bool V4 { get; set; } // bit, not null
    public bool V5 { get; set; } // bit, not null
    public bool V6 { get; set; } // bit, not null
    public bool V7 { get; set; } // bit, not null
    public bool V8 { get; set; } // bit, not null
    public bool V9 { get; set; } // bit, not null
    public bool V10 { get; set; } // bit, not null
    public bool V11 { get; set; } // bit, not null
    public bool V12 { get; set; } // bit, not null
    public bool V13 { get; set; } // bit, not null
    public bool V14 { get; set; } // bit, not null
    public bool V15 { get; set; } // bit, not null
    public bool V16 { get; set; } // bit, not null
    public bool V17 { get; set; } // bit, not null
    public bool V18 { get; set; } // bit, not null
    public bool V19 { get; set; } // bit, not null
    public bool V20 { get; set; } // bit, not null
    public bool V21 { get; set; } // bit, not null
    public bool V22 { get; set; } // bit, not null
    public bool V23 { get; set; } // bit, not null
    public bool V24 { get; set; } // bit, not null
    public bool V25 { get; set; } // bit, not null
    public bool V26 { get; set; } // bit, not null
    public bool V27 { get; set; } // bit, not null
    public bool V28 { get; set; } // bit, not null
    public bool V29 { get; set; } // bit, not null

    public string MDHistoryText { get; set; } // nvarchar(max), null
    public string ChiefComplaintText { get; set; } // nvarchar(max), null
    public string PrescHistoryTxtDrg { get; set; } // nvarchar(max), null
    public string PrescHistoryTxtLab { get; set; } // nvarchar(max), null
    public string PrescHistoryTxtLabDate { get; set; } // nvarchar(max), null
    public int Height { get; set; } // int, not null
    public int Weight { get; set; } // int, not null
    public double BMI { get; set; } // int, not null
    public string BMIText { get; set; } // nvarchar(max), null
    public int SpO2 { get; set; } // int, not null

    public int UserPersID { get; set; } // int, not null
}