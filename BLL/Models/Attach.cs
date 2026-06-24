using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("AttFile")]
public class Att
{
    public Att()
    {
        CentID = 0;
        CRUD = 0;
        FuncType = 0;
        EncID = 0;
        DepID = 0;
        EAID = 0;
        AttTag = 0;
        AttFileType = 0;
        UserPersID = 0;
        AttSelect = false;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CentID { get; set; }

    public int CRUD { get; set; }
    public int FuncType { get; set; }
    public int EAID { get; set; } // int, not null
    [MaxLength(10)] public string NationalCode { get; set; } // nvarchar(10), null
    public int PatientID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public Guid WEncID { get; set; } // uniqueidentifier, not null
    public int PageID { get; set; } // int, not null
    public int DepID { get; set; } // int, not null
    [MaxLength(200)] public string FileName { get; set; } // nvarchar(200), null
    public string AttFileNameFull { get; set; } // nvarchar(max), null
    public double AttFileSize { get; set; }
    public int AttFileType { get; set; } // int, not null
    public string AttFileTypeName { get; set; } // int, not null
    public string AttFileContentType { get; set; } // int, not null
    public int AttTag { get; set; } // int, not null
    public string AttTagName { get; set; }
    public string AttTagName2 { get; set; }

    public int AttTagCount { get; set; } // int, not null
    public byte[] AttFile { get; set; } // varbinary(max), not null
    public string AttFile1 { get; set; } // varbinary(max), not null
    public byte[] AttFileThumbnail { get; set; } // varbinary(max), not null
    public string AttFileThumbnail1 { get; set; } // varbinary(max), not null
    public int UserPersID { get; set; } // int, not null
    [MaxLength(16)] public string ActionDate { get; set; } // nchar(16), null
    public int ActionType { get; set; } // int, not null
    public bool AttSelect { get; set; } // bit, not null
    public bool IsSelected { get; set; } = false; // bit, not null
    public string Date { get; set; }
    public string Note { get; set; } // nvarchar(max), null
    public bool OutOfCenter { get; set; } = false;
    public string UserIP { get; set; } // nvarchar(max), null
    public string UserDeviceName { get; set; } // nvarchar(max), null
}