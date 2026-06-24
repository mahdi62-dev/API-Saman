using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("InvPageItem")]
public class InvPageItem
{
    public InvPageItem()
    {
        InvPageID = 0;
        Num2 = 0;
        Unit2 = 0;
        UnitKNum = 1;
        Unit = 0;
        Num = 0;
        BuyFeeAmount2 = 0;
        BuyAmount2 = 0;
        SellPer = 0;
        BuyFeeAmount = 0;
        SellFeeAmount = 0;
        SellFeeAmount2 = 0;
        BuyAmount = 0;
        DiscountAmount = 0;
        TaxAmount = 0;
        BuyAmountLast = 0;
        SellAmount = 0;
        SellAmountLast = 0;
        IsBonus = false;
        SellAmount2 = 0;
        StockNum = 0;
        StockNumAll = 0;
        ResultAmount = 0;
        SRID = 0;
        CenterID = 1;
    }

    public long? RecNO { get; set; } // bigint, null
    public int? ServiceCode { get; set; } // int, null
    public string ServiceName { get; set; } // nvarchar(1000), null
    public double Num { get; set; } // float, not null
    public double Num2 { get; set; } // float, not null
    public double UnitKNum { get; set; } // float, not null
    public string Unit2Name { get; set; } // int, not null
    public int Unit2 { get; set; } // int, not null
    public string UnitName { get; set; } // int, not null
    public int Unit { get; set; } // int, not null
    public double StockNum { get; set; } // float, not null
    public string ExpirationDate { get; set; } // nchar(16), null

    [Description("فی خرید فاکتور")] public long BuyFeeAmount2 { get; set; } // bigint, not null

    public long BuyAmount2 { get; set; } // bigint, not null
    public double SellPer { get; set; } // float, not null
    public long SellFeeAmount { get; set; } // bigint, not null
    public long SellFeeAmount2 { get; set; } // bigint, not null
    public double BuyFeeAmount { get; set; } // float, not null
    public long BuyAmount { get; set; } // bigint, not null
    public long DiscountAmount { get; set; } // bigint, not null
    public long TaxAmount { get; set; } // bigint, not null
    public long BuyAmountLast { get; set; } // bigint, not null
    public long SellAmount { get; set; } // bigint, not null
    public long SellAmountLast { get; set; } // bigint, not null
    public long ResultAmount { get; set; } // bigint, not null


    //---------Out of Grid---
    public int CRUD { get; set; } // int, not null
    public int InvType { get; set; } // int, not null
    public int InvCategoryType { get; set; } // int, not null
    public int StorageID { get; set; } // int, not null
    public int StoragePeriodID { get; set; } // int, not null
    public int InvDID { get; set; } // int, not null
    public int InvPageID { get; set; } // int, not null
    public int ServiceID { get; set; } // int, not null
    public bool IsBonus { get; set; } // bit, not null
    public long SellAmount2 { get; set; } // bigint, not null
    public double StockNumAll { get; set; } // float, not null
    public int SRID { get; set; } // int, not null
    public int CenterID { get; set; } // int, not null
}