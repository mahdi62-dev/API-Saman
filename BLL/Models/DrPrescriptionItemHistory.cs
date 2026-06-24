using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("DrPrescriptionHistory")]
public class DrPrescriptionHistory
{
    public DrPrescriptionHistory()
    {
        EncID = 0;
        PrescType = 0;
        Num = 1;
        UseTime = 0;
        UseDose = 0;
        Date = null;
        Date2 = null;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CRUD { get; set; } // int, not null

    public long RecNO { get; set; } // int, not null

    public int ID { get; set; } // int, not null
    [Key] [Column(Order = 1)] public int EncID { get; set; } // int, not null
    [Key] [Column(Order = 2)] public int PrescType { get; set; } // int, not null
    [Key] [Column(Order = 3)] public int ItemID { get; set; } // int, not null
    public string ItemName { get; set; } // int, not null

    public string Date { get; set; } // nchar(16), null
    [MaxLength(10)] public string Date2 { get; set; } // nchar(10), null
    public double? Num { get; set; } // float, null
    public string Explain { get; set; }

    public int? UseTime { get; set; } // int, not null
    public string UseTimeName { get; set; }

    public int? UseDose { get; set; } // int, not null

    public string UseDoseName { get; set; } // int, not null
    [MaxLength] public string Note { get; set; } // nvarchar(max), null
}