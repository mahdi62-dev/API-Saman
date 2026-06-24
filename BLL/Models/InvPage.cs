using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("InvPage")]
public class InvPage
{
    public InvPage()
    {
        InvType = 0;
        InvCategoryType = 0;
        InvPageCode = 0;
        InvPageCode2 = "0";
        StorageID = 0;
        StoragePeriodID = 0;
        SellerID = 0;
        TransfereeID = 0;
        DeliverPersID = 0;
        OrderDepID = 0;
        DestDepID = 0;
        TotalAmount = 0;
        BuyAmount = 0;
        SellAmount = 0;
        IsSign = false;
        SignPersID = 0;
        IsLocked = false;
        PrintCount = 0;
        BonusAmount = 0;
        OtherAmount = 0;
        DiscountAmount = 0;
        DiscountAmount2 = 0;
        TotalDiscountAmount = 0;
        TaxAmount = 0;
        TaxAmount2 = 0;
        TotalTaxAmount = 0;
        ResultAmount = 0;
        UserPersID = 0;
        IsApplyInvStock = false;
        IsApplyServicePrice = false;
        OrderCode = 0;
        IsAuto = false;
        CenterID = 1;
    }

    public int CRUD { get; set; } // int, not null
    public int FuncType { get; set; } // int, not null

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InvPageID { get; set; } // int, not null

    [Description("نوع برگه")] public byte InvType { get; set; } // tinyint, not null

    [Description("نوع گروه بندی رسید ورود و خروج")]
    public int InvCategoryType { get; set; } // int, not null

    [Description("کد رسید یا حواله")] public int InvPageCode { get; set; } // int, not null

    [MaxLength(20)]
    [Description("شماره فاکتور فروشنده")]
    public string InvPageCode2 { get; set; } // nvarchar(20), not null

    [Description("کد انبار")] public int StorageID { get; set; } // int, not null

    [Description("کد دوره انبارگردانی")] public int StoragePeriodID { get; set; } // int, not null

    [MaxLength(16)] public string Date { get; set; } // nchar(16), null

    [MaxLength(16)]
    [Description("تاریخ فاکتور")]
    public string Date2 { get; set; } // nchar(16), null

    [Description("فروشنده")] public int SellerID { get; set; } // int, not null

    [Description("تحویل گیرنده")] public int TransfereeID { get; set; } // int, not null

    [Description("تحویل دهنده")] public int DeliverPersID { get; set; } // int, not null

    [Description("بخش درخواست دهنده")] public int OrderDepID { get; set; } // int, not null

    [Description("بخش مقصد در خواله خروج")]
    public int DestDepID { get; set; } // int, not null

    [Description("جمع مبلغ")] public long TotalAmount { get; set; } // bigint, not null

    [Description("قیمت خرید")] public long BuyAmount { get; set; } // bigint, not null

    [Description("قیمت فروش")] public long SellAmount { get; set; } // bigint, not null

    [MaxLength(1000)]
    [Description("توضیحات")]
    public string Description { get; set; } // nvarchar(1000), null

    [Description("امضا شده")] public bool IsSign { get; set; } // bit, not null

    [Description("امضا کننده")] public int SignPersID { get; set; } // int, not null

    [MaxLength(16)]
    [Description("تاریخ امضا")]
    public string SignDate { get; set; } // nchar(16), null

    [Description("قفل شده")] public bool IsLocked { get; set; } // bit, not null

    [MaxLength(16)]
    [Description("تاریخ قفل شدن")]
    public string LockDate { get; set; } // nchar(16), null

    [MaxLength(16)]
    [Description("تاریخ پرینت")]
    public string PrintDate { get; set; } // nchar(16), null

    [Description("دفعات پرینت")] public short PrintCount { get; set; } // smallint, not null

    [Description("مبلغ جایزه")] public long BonusAmount { get; set; } // bigint, not null

    [Description("سایر هزینه ها، مثل پیک و ارسال و ...")]
    public long OtherAmount { get; set; } // bigint, not null

    [Description("کل تخفیف فاکتور")] public long DiscountAmount { get; set; } // bigint, not null

    public long DiscountAmount2 { get; set; } // bigint, not null
    public long TotalDiscountAmount { get; set; } // bigint, not null
    public long TaxAmount { get; set; } // bigint, not null
    public long TaxAmount2 { get; set; } // bigint, not null
    public long TotalTaxAmount { get; set; } // bigint, not null
    public long ResultAmount { get; set; } // bigint, not null
    public int UserPersID { get; set; } // int, not null
    public bool IsApplyInvStock { get; set; } // bit, not null
    public bool IsApplyServicePrice { get; set; } // bit, not null
    public int OrderCode { get; set; } // int, not null
    public bool IsAuto { get; set; } // bit, not null
    public int CenterID { get; set; } // int, not null


    //-----------------------------------//

    public int StockNum { get; set; }

    public long BuyAmountLast { get; set; }

    public long SellAmountLast { get; set; }

    public long Price { get; set; } // bigint, not null
}