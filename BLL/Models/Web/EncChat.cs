using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models.Web;

[Table("EncChat")]
public class EncChat
{
    public EncChat()
    {
        CenterID = 0;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int CRUD { get; set; } // int, not null

    public int FuncType { get; set; } // int, not null
    public long ChatID { get; set; } // int, not null
    public int MasterID { get; set; } // int, not null
    public int CenterID { get; set; } // int, not null
    public Guid WProfileID { get; set; } // uniqueidentifier, not null
    public Guid WEncID { get; set; } // uniqueidentifier, not null
    public string NationalCode { get; set; } // nvarchar(201), null
    public int ChatSide { get; set; } // int, not null
    public string ChatText { get; set; }
    public int ChatStatus { get; set; } // int, not null
    public string ChatStatusDate { get; set; }
    public string ActionDate { get; set; }


    public int AttFileType { get; set; } // int, not null
    public byte[] AttFile { get; set; } // varbinary(max), not null
    public string AttFile1 { get; set; } // varbinary(max), not null
}