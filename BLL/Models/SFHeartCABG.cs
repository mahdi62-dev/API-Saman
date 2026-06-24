using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("SFHeartCABG")]
public class SFHeartCABG
{
    public SFHeartCABG()
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

    public int SFHeartCABGID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public int PageID { get; set; } // int, not null
    public int ServiceCode { get; set; } // int, not null
    public string Date { get; set; }
    public bool? LIMAOnLAD { get; set; } // bit, null
    public bool? SVGOnLAD { get; set; } // bit, null
    public bool? SVGD1 { get; set; } // bit, null
    public bool? SVGD2 { get; set; } // bit, null
    public bool? SVGD3 { get; set; } // bit, null
    public bool? SVGOM1 { get; set; } // bit, null
    public bool? SVGOM2 { get; set; } // bit, null
    public bool? SVGOM3 { get; set; } // bit, null
    public bool? SVGRCA { get; set; } // bit, null
    public bool? SVGPDA { get; set; } // bit, null
    public bool? SVGPLV { get; set; } // bit, null
    public bool? SVGRamus { get; set; } // bit, null
    public int RadialOn { get; set; } // bit, null
    [MaxLength(500)] public string Note { get; set; } // nvarchar(500), null
    public int UserPersID { get; set; } // int, not null
}