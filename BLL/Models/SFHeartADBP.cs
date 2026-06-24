using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("SFHeartADBP")]
public class SFHeartADBP
{
    public SFHeartADBP()
    {
        CRUD = 0;
        EncID = 0;
        PageID = 0;
        ServiceCode = 0;
        Date = null;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CRUD { get; set; } // int, not null

    public int SFHeartADBPID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public int PageID { get; set; } // int, not null
    public int ServiceCode { get; set; } // int, not null
    public string Date { get; set; }
    public int? LTSystolic { get; set; } // int, null
    public int? LTDiastolic { get; set; } // int, null
    public int? RTSystolic { get; set; } // int, null
    public int? RTDiastolic { get; set; } // int, null
    public int? HR { get; set; } // int, null
    public int UserPersID { get; set; } // int, not null
}