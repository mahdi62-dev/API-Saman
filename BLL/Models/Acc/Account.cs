using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Acc;

public class Account
{
    public int CRUD { get; set; } // int, not null
    public int FuncType { get; set; } // int, not null

    public int CenterID { get; set; } // int, not null

    public int AccountID { get; set; }

    [Required] [MaxLength(20)] public string AccountCode { get; set; }

    [Required] [MaxLength(100)] public string AccountName { get; set; }

    public string AccountName2 { get; set; }

    [Range(1, 4)] public int AccountLevel { get; set; }

    public int? ParentID { get; set; }
    public string AccountCodeName { get; set; }

    public bool IsDisable { get; set; }

    public int AccountType { get; set; }
}