using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("InvStorage")]
public class InvStorage
{
    public InvStorage()
    {
        StorageID = 0;
        StoragePeriodID = 0;
        ISCheckStockNum = false;
        StorageType = 0;
        CenterID = 1;
    }

    [Key] public int StorageID { get; set; } // int, not null

    public int StoragePeriodID { get; set; } // int, not nul

    [MaxLength(200)] public string Name { get; set; } // nvarchar(200), null

    public bool ISCheckStockNum { get; set; } // bit, not null
    public int StorageType { get; set; } // int, not null
    public int CenterID { get; set; } // int, not null
}