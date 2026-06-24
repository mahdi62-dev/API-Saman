using System.ComponentModel.DataAnnotations;

namespace BLL.Models;

public class DocReport
{
    [Key] public int PageID { get; set; } // int, not null
    [MaxLength] public byte[] Doc { get; set; } // varbinary(max), null
    [MaxLength] public string Rtf { get; set; } // nvarchar(max), null
    [MaxLength] public string Txt { get; set; } // nvarchar(max), null
    [MaxLength] public string Htm { get; set; } // nvarchar(max), null
    [MaxLength] public byte[] PDF { get; set; } // varbinary(max), null
}