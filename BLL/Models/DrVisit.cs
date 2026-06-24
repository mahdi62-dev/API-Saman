using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("DrVisit")]
public class DrVisit
{
    public DrVisit()
    {
        CRUD = 0;
        EncID = 0;
        DepID = 0;

        FollowupPeriod = 0;
        UserPersID = 0;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CRUD { get; set; } // int, not null

    public int DrVisitID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public int DepID { get; set; } // int, not null
    [MaxLength(16)] public string Date { get; set; } // char(16), null
    [MaxLength] public string VisitItem { get; set; } // nvarchar(max), null
    [MaxLength] public string Diagnosis { get; set; } // nvarchar(max), null
    [MaxLength] public string Note { get; set; } // nvarchar(max), null
    [MaxLength] public string Conclusion { get; set; } // nvarchar(max), null
    public int FollowupPeriod { get; set; } // int, not null
    public int DiagnosisID { get; set; } // int, not null
    public int UserPersID { get; set; } // int, not null
    [MaxLength] public string F1 { get; set; } // nvarchar(max), null
}

public record VisitItem
{
    public bool IschemicHeartDisease { get; set; } // int, not null
    public bool HypertensiveHD { get; set; } // int, not null
    public bool PostChemotherapyDCM { get; set; } // int, not null
    public bool MuscularDystrophy { get; set; } // int, not null
    public bool IdiopathicCardiomyopathy { get; set; } // int, not null
    public bool ValvularHD { get; set; } // int, not null
    public bool PPCM { get; set; } // int, not null
    public bool Myocarditis { get; set; } // int, not null
    public bool Others { get; set; } // int, not null
    public bool Unknown { get; set; } // int, not null
    public bool CABG { get; set; } // int, not null
    public bool PCI { get; set; } // int, not null
    public bool ValveSurgery { get; set; } // int, not null
    public bool ICDCRT { get; set; } // int, not null
    public bool JVPVisible { get; set; } // int, not null
    public bool JVPNormal { get; set; } // int, not null
    public bool AscitesYes { get; set; } // int, not null
    public bool AscitesNO { get; set; } // int, not null
    public bool FineCracklesYes { get; set; } // int, not null
    public bool FineCracklesNO { get; set; } // int, not null
    public bool EdemaYes { get; set; } // int, not null
    public bool EdemaNO { get; set; } // int, not null
    public bool IfYesPitting { get; set; } // int, not null
    public bool IfYesNonPitting { get; set; } // int, not null
    public bool I { get; set; } // int, not null
    public bool II { get; set; } // int, not null
    public bool III { get; set; } // int, not null
    public bool IV { get; set; } // int, not null
}