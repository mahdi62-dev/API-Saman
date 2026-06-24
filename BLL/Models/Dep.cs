using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("Dep")]
[Description("بخشها")]
public class Dep
{
    public Dep()
    {
        CRUD = 1;
        MapID = 0;
        ModID = 0;
        CenterIDA = 0;
    }

    public int CRUD { get; set; } // int, not null

    [Key] [Description("کد بخش")] public int DepID { get; set; } // int, not null

    [MaxLength(200)]
    [Description("نام بخش")]
    public string Name { get; set; } // nvarchar(200), null

    [Description("کد معادل")] public int MapID { get; set; } // int, not null
    [Description("نوع ماژول")] public int ModID { get; set; } // int, not null
    [Description("مرکز")] public int CenterIDA { get; set; } // int, not null

    public int StorageID { get; set; } // int, not null
    public int StoragePeriodID { get; set; } // int, not null
}