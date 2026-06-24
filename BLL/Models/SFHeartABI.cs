using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("SFHeartABI")]
public class SFHeartABI
{
    public SFHeartABI()
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

    public int SFHeartABIID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public int PageID { get; set; } // int, not null
    public int ServiceCode { get; set; } // int, not null
    public string Date { get; set; }
    public double? LT { get; set; } // float, null
    public double? RT { get; set; } // float, null
    public int UserPersID { get; set; } // int, not null
}