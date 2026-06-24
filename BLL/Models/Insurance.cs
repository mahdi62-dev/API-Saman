using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("Insurance")]
public class Insurance
{
    public Insurance()
    {
        IsDisable = false;
        EncType = 0;
        InsuranceType = 0;
        IsCoverOIC = false;
        IsMandatoryPageNumber = false;
        IsMandatorySerialNumber = false;
        IsMandatoryEndDate = false;
        ParentID = 0;
        OPExportID = 0;
    }

    [Key] public int InsuranceID { get; set; } // int, not null
    [MaxLength(50)] public string Name { get; set; } // nvarchar(50), null
    public double InPer { get; set; } // float, not null
    public double OutPer { get; set; } // float, not null
    public byte GroupCode { get; set; } // tinyint, not null
    public bool IsDisable { get; set; } // bit, not null
    [MaxLength(16)] public string StartDate { get; set; } // nvarchar(16), null
    [MaxLength(16)] public string EndDate { get; set; } // nvarchar(16), null
    public byte EncType { get; set; } // tinyint, not null
    public byte InsuranceType { get; set; } // tinyint, not null
    [Description("پوشش آزادها در بیمه")] public bool IsCoverOIC { get; set; } // bit, not null
    public bool IsMandatoryPageNumber { get; set; } // bit, not null
    public bool IsMandatorySerialNumber { get; set; } // bit, not null
    public bool IsMandatoryEndDate { get; set; } // bit, not null
    public int ParentID { get; set; } // int, not null
    public int OPExportID { get; set; } // int, not null
}