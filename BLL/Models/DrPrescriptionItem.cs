using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("DrPrescriptionItem")]
public class DrPrescriptionItem
{
    public DrPrescriptionItem()
    {
        DrPrescID = 0;
        ItemID = 0;
        Num = 1;
        UseTime = 0;
        UseDose = 0;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int CRUD { get; set; } // int, not null

    public long RecNO { get; set; } // int, not null
    public string IsDrPresc { get; set; } // int, not null
    public int DrPrescItemID { get; set; } // int, not null
    public int DrPrescID { get; set; } // int, not null
    public int ItemID { get; set; } // int, not null
    public string ItemName { get; set; } // int, not null
    public double Num { get; set; } // float, not null
    public int UseTime { get; set; } // int, not null
    public string UseTimeName { get; set; }
    public int UseDose { get; set; } // int, not null
    public string UseDoseName { get; set; } // int, not null
    public string DrugNote { get; set; } // int, not null
    [MaxLength] public string Note { get; set; } // nvarchar(max), null
    [MaxLength(10)] public string FirstDrPresDate { get; set; } // nchar(16), null


    //-------FHFollowup------
    public bool IsConfirm { get; set; } // int, not null
}