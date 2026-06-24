using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("Cash")]
public class Cash
{
    public Cash()
    {
        CRUD = 0;
        ModID = 2; // 2-Cash
        IsEdited = false;
        CashType = 0; //1-sapaie 2-vadie 3-tarkhis 4-motefareghe
        PayType = 1; //1-cart 2-naghdi 3-fish 4-check 5-bardasht gheyr naghdi
        PageID = 0;
        PayGroup = 0; //1-clinic 2-drjarah 3-drbihoshi 4-drjarahclinick
        TransType = 0; //1-daryaft 2-odat
        DrID = 0;
        Bank = 0;
        IsClosed = false;
        About = 0;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CRUD { get; set; } // int, not null

    public int FuncType { get; set; } // int, not null

    public int ModID { get; set; } // int, not null
    public int CashID { get; set; } // int, not null
    public bool IsEdited { get; set; } // bit, not null
    [Description("نوع قبض")] public int CashType { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public int SchID { get; set; } // int, not null

    public int PageID { get; set; } // int, not null
    [MaxLength(16)] public string CashDate { get; set; } // nchar(16), not null
    [Description("نحوه پرداخت")] public int PayType { get; set; } // int, not null
    public int PayGroup { get; set; } // int, not null
    public int TransType { get; set; } // tinyint, not null
    public long PayAmount { get; set; } // bigint, not null
    public int? Bank { get; set; } // int, null
    [MaxLength(1000)] public string BankNumber { get; set; } // nvarchar(1000), null
    [MaxLength(16)] public string BankDate { get; set; } // nchar(16), null
    public int DepID { get; set; } // int, not null
    [MaxLength(1000)] public string Note { get; set; } // nvarchar(1000), null
    public int DrID { get; set; } // int, not null
    [MaxLength(1000)] public string Receiver { get; set; } // nvarchar(1000), null
    public bool IsClosed { get; set; } // bit, not null
    public int? About { get; set; } // int, null
    public int UserPersID { get; set; } // int, not null


    //----vcash----

    public long? RecNo { get; set; } // bigint, null
    public string CashTypeName { get; set; } // string, not null
    public string PayGroupName { get; set; } // string, not null
    public string PayTypeName { get; set; } // string, not null
    public string PersName { get; set; } // string, not null
    public string BankName { get; set; } // nvarchar(100), null
    public string DrName { get; set; } // nvarchar(201), null
    public string AboutName { get; set; } // nvarchar(100), null


    //----VerifyOnlineWeb----
    public string OGRefID { get; set; } // string, not null
    public long OGPayAmount { get; set; } // int, not null
    public Guid WEncID { get; set; } // int, not null
    public Guid WProfileID { get; set; } // int, not null
}