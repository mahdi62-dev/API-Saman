using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("Page")]
public class Page
{
    public Page()
    {
        CRUD = 1;
        FuncType = 0;

        PageID = 0;
        EncID = 0;
        PageCode = 0;
        ModID = 0;
        DepID = 0;
        PageService = 1;
        WardID = 0;
        Date = null;
        IsEmerg = false;
        TotalAmount = 0;
        InsuranceAmount = 0;
        FranchiseAmount = 0;
        OICAmount = 0;
        PatientAmount = 0;
        PayAmount = 0;
        DiscountAmount = 0;
        ResultAmount = 0;
        RemainAmount = 0;
        UserPersID = 0;
        StorageID = 0;
        StoragePeriodID = 0;
        InvOutputApplyStatus = 0;
        IsReadOnly = false;
        InvPageID = 0;
        InsuranceAmount2 = 0;
        DrTechAssist = 0;
        RefDrID = 0;
    }

    public int CRUD { get; set; } // int, not null
    public int FuncType { get; set; } // int, not null


    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PageID { get; set; } // int, not null

    public int EncID { get; set; } // int, not null

    [Description("کد برگه")] public int PageCode { get; set; } // int, not null
    public int ModID { get; set; } // smallint, not null
    public int DepID { get; set; } // smallint, not null
    public int PageService { get; set; } // smallint, not null

    [Description("بخش پذیرش بیمار")] public short WardID { get; set; } // smallint, not null

    [MaxLength(16)]
    [Description("تاریخ برگه")]
    public string Date { get; set; } // nchar(16), null

    [Description("تاریخ نسخه یا درخواست")] public string Date2 { get; set; } // nchar(16), null


    [Description("تاریخ جواب دهی")] public string Date3 { get; set; } // nchar(16), null

    [Description("برگه اورژانسی")] public bool IsEmerg { get; set; } // bit, not null
    [Description("جمع مبلغ")] public long TotalAmount { get; set; } // bigint, not null
    [Description("سهم سازمان")] public long InsuranceAmount { get; set; } // bigint, not null
    [Description("فرانشیز")] public long FranchiseAmount { get; set; } // bigint, not null

    [Description("مبلغ خارج از پوشش بیمه")]
    public long OICAmount { get; set; } // bigint, not null

    [Description("سهم بیمار")] public long PatientAmount { get; set; } // bigint, not null
    [Description("پرداخت شده")] public long PayAmount { get; set; } // bigint, not null
    [Description("تخفیف")] public long DiscountAmount { get; set; } // bigint, not null
    [Description("قابل پرداخت بیمار")] public long ResultAmount { get; set; } // bigint, not null
    [Description("مانده")] public long RemainAmount { get; set; } // bigint, not null
    [Description("کاربر")] public int UserPersID { get; set; } // int, not null
    [Description("کد انبار")] public int StorageID { get; set; } // int, not null

    [Description("شناسه دوره انبار گردانی")]
    public int StoragePeriodID { get; set; } // int, not null

    [Description("وضعیت رسیدگی در حواله خروج")]
    public byte InvOutputApplyStatus { get; set; } // tinyint, not null

    [Description("برگه بسته شده")] public bool IsReadOnly { get; set; } // bit, not null
    [Description("برگه توسط کاربر مجاز برای ویرایش باز شده")] public bool UnlockForEdit { get; set; } = false;
    [Description("شناسه حواله خروج")] public int InvPageID { get; set; } // int, not null
    [Description("مبلغ بیمه تکمیلی")] public int InsuranceAmount2 { get; set; } // int, not null
    [Description("مسئول فنی")] public int DrTechAssist { get; set; } // int, not null

    [Description("پزشک درخواست کننده و ارجاع دهنده")]
    public int RefDrID { get; set; } // int, not null
}