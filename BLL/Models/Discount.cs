namespace BLL.Models;

public class Discount
{
    public int CRUD { get; set; } // int, not null
    public int ModID { get; set; } // int, not null
    public int DiscountID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public int PageID { get; set; } // int, not null
    public bool IsDisable { get; set; } // bit, not null
    public int DiscountEncType { get; set; } // int, not null
    public int DiscountReferType { get; set; } // int, not null
    public string DiscountReferTypeName { get; set; } // nvarchar(100), null
    public int DiscountActionTaken { get; set; } // int, not null
    public string DiscountActionTakenName { get; set; } // nvarchar(100), null
    public int DiscountType { get; set; } // int, not null
    public string DiscountTypeName { get; set; } // nvarchar(100), null
    public int DepID { get; set; } // int, not null
    public string Date { get; set; } // nchar(16), not null
    public long DiscountAmount { get; set; } // bigint, not null
    public string Note { get; set; } // nvarchar(1000), null
    public int UserPersID { get; set; } // int, not null
    public string ActionDate { get; set; } // nchar(16), not null
    public int PatientID { get; set; } // int, not null
    public string FullName { get; set; } // nvarchar(301), null
    public byte EncType { get; set; } // tinyint, not null
    public string EncTypeName { get; set; } // nvarchar(100), null
    public byte EncStatus { get; set; } // tinyint, not null
    public string EncStatusName { get; set; } // nvarchar(100), null
    public string StartDate { get; set; } // nchar(16), null
    public string EndDate { get; set; } // nchar(16), null
    public string DepName { get; set; } // nvarchar(200), null
    public string DrName { get; set; } // nvarchar(201), null
    public string PersName { get; set; } // nvarchar(201), null
}