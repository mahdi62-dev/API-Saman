using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.BLL.Models.Web;

[Table("Enc")]
public class Enc
{
    public Enc()
    {
        CenterID = 0;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int CRUD { get; set; } // int, not null

    public int FuncType { get; set; } // int, not null
    public int CenterID { get; set; } // int, not null
    public string CenterName { get; set; }
    public string DrName { get; set; }
    public int PatientID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public Guid WProfileID { get; set; } // uniqueidentifier, not null
    public string StartDate { get; set; }
    public string DrNationalCode { get; set; }
    public int DrID { get; set; } // int, not null
    public string DrExplain { get; set; } // int, not null
}