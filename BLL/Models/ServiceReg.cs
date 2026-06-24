using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("ServiceReg")]
public class ServiceReg
{
    public ServiceReg()
    {
        PageID = 0;
        ServiceID = 0;
        Num = 1;
        ServiceCategory = 0;
        DrID = 0;
        PersID = 0;
        PersID2 = 0;
        IsOIC = false;
        IsManualPrice = false;

        TotalPrice = 0;
        TotalAmount = 0;
        ProAmount = 0;
        TechAmount = 0;
        OICAmount = 0;
        InsuranceAmount = 0;
        PatientAmount = 0;
        FranchiseAmount = 0;
        DiscountAmount = 0;
        ResultAmount = 0;
        InvOutputApplyStatus = 0;
        InsuranceAmount2 = 0;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Description("شناسه ثبت سرویس")]
    public int SRID { get; set; } // int, not null

    [Description("شناسه برگه")] public int PageID { get; set; } // int, not null
    [Description("شناسه سرویس")] public int ServiceID { get; set; } // int, not null
    public string ServiceName { get; set; } // nvarchar(100), null
    public double Num { get; set; } // float, not null
    [Description("سرفصل سرویس")] public int ServiceCategory { get; set; } // int, not null
    [Description("پزشک انجام دهنده")] public int DrID { get; set; } // int, not null
    [Description("تکنسین")] public int PersID { get; set; } // int, not null
    [Description("پرستار")] public int PersID2 { get; set; } // int, not null
    [Description("فی سرویس")] public long TotalPrice { get; set; } // int, not null

    [Description("جمع مبلغ-تعداد ضربدر فی")]
    public long TotalAmount { get; set; } // int, not null

    [Description("مبلغ حرفه ای")] public long ProAmount { get; set; } // int, not null
    [Description("مبلغ فنی")] public long TechAmount { get; set; } // int, not null
    [Description("خارج از پوشش بیمه")] public long OICAmount { get; set; } // int, not null
    [Description("سهم سازمان")] public long InsuranceAmount { get; set; } // int, not null
    [Description("سهم بیمار")] public long PatientAmount { get; set; } // int, not null
    [Description("مبلغ فرانشیز")] public long FranchiseAmount { get; set; } // int, not null
    [Description("تخفیف")] public long DiscountAmount { get; set; } // int, not null
    [Description("مبلغ قابل پرداخت")] public long ResultAmount { get; set; } // int, not null

    [Description("وضعیت اعمال حواله خروج")]
    public byte InvOutputApplyStatus { get; set; } // tinyint, not null

    [Description("سهم بیمه تکمیلی")] public long InsuranceAmount2 { get; set; } // int, not null

    public long TotalAmountManual { get; set; } // int, not null

    public int ServiceCode { get; set; } // int, not null
    public bool IsOIC { get; set; } // int, not null

    public bool IsManualPrice { get; set; } // int, not null

    public long RecNO { get; set; } // int, not null
    public int CRUD { get; set; } // int, not null
    public string DrName { get; set; } // nvarchar(100), null
    public string PersName { get; set; } // nvarchar(100), null        
    public int StorageId { get; set; } // int, not null

    public string ServiceUnitName { get; set; } // nvarchar(100), null

    public int Report { get; set; } // int, not null
}