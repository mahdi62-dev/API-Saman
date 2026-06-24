using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("DrPrescription")]
public class DrPrescription
{
    public DrPrescription()
    {
        EncID = 0;
        PrescType = 0;
        Date = null;
        Date2 = null;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CRUD { get; set; } // int, not null

    public int RecNO { get; set; } // int, not null

    public int DrPrescID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public int PrescType { get; set; } // int, not null
    [MaxLength(16)] public string Date { get; set; } // nchar(16), null
    [MaxLength(10)] public string Date2 { get; set; } // nchar(10), null
    public int UserPersID { get; set; } // int, not null
}