using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models.Web;

[Table("WebEnc")]
public class WebEnc
{
    public WebEnc()
    {
        CenterID = 0;
        WEncServiceID = 0;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid WProfileID { get; set; } // uniqueidentifier, not null

    public int EncID { get; set; } // int, not null
    public int CRUD { get; set; } // int, not null
    public int FuncType { get; set; } // int, not null
    public Guid WEncID { get; set; } // int, not null
    public int CenterID { get; set; } // int, not null
    public int MasterID { get; set; } // int, not null

    public int WEncServiceID { get; set; } // int, not null

    public string StartDate { get; set; }

    public int Age { get; set; } // int, not null

    public string StartDateRange1 { get; set; }
    public string StartDateRange2 { get; set; }

    [MaxLength] public string Explain { get; set; } // nvarchar(max), null

    [MaxLength(16)] public int Recommender { get; set; } = 0;

    public int Insurance { get; set; } = 0;
    public string DrugDescription { get; set; }
    public string HistoryDrug { get; set; }
    public string FamilyHistoryDisease { get; set; }
    public string NewTreatment { get; set; }
    public string ContinueTreatment { get; set; }
    public string EncUnderlyingDisease { get; set; }
    public string HistorySurgery { get; set; }
    public string ChiefComplaint { get; set; }
    public int EncStatus { get; set; } // int, not null
    public long PayAmount { get; set; } // int, not null
    public string PayDate { get; set; }
    public string TransactionID { get; set; } // int, not null
    public string ActionDate { get; set; } // char(16), not null

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{" "}{FirstName} {LastName}";
    public string GenderName { get; set; }

    public string WEncServiceName { get; set; }


    public string NationalCode { get; set; }
    public string Mobile { get; set; }
}