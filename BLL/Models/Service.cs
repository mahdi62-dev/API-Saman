using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("Service")]
public class Service
{
    public Service()
    {
        CRUD = 1;
        FuncType = 0;
        DepID = 0;

        CenterID = 1;
        ServiceCategory = 0;
        IsTech = false;
        IsManualPrice = false;
        ServicePriceType = 0;
        ServiceUnit = 0;
        ServiceUnit2 = 0;
        ServiceStatus = 0;
        IsDisable = false;
        IsOIC = false;
    }

    public int CRUD { get; set; }
    public int FuncType { get; set; }
    public int MasterID { get; set; }

    public int DepID { get; set; }
    public int CenterID { get; set; }

    [Description("شناسه یکتای سرویس")] public int ServiceID { get; set; }

    [Description("نوع سرویس")] public int ServiceType { get; set; }

    [Description("سرفصل سرویس")] public short ServiceCategory { get; set; }

    [MaxLength(100)]
    [Description("کد سرویس")]
    public int ServiceCode { get; set; }

    [MaxLength(100)]
    [Description("کد دوم سرویس")]
    public string ServiceCode2 { get; set; }

    [MaxLength(1000)]
    [Description("شرح سرویس")]
    public string Name { get; set; }

    [MaxLength(1000)]
    [Description("شرح کامل سرویس")]
    public string Namelong { get; set; }

    [Description("فی")] public int Price { get; set; }
    [Description("فی دوم")] public int? PriceB { get; set; }
    [Description("فی سوم")] public int? PriceC { get; set; }
    [Description("فی چهارم")] public int? PriceD { get; set; }
    public int? PricePro { get; set; }
    public int? PriceTech { get; set; }

    [MaxLength(100)]
    [Description("کد سازمان بیمه")]
    public string MapIDA { get; set; }

    [MaxLength(100)] public string MapIDB { get; set; }
    [MaxLength(16)] public string StartDate { get; set; }
    [MaxLength(16)] public string EndDate { get; set; }
    public bool IsTech { get; set; }
    public bool IsManualPrice { get; set; }
    public byte ServicePriceType { get; set; }
    public int ServiceUnit { get; set; }
    public int ServiceUnit2 { get; set; }
    public short ServiceStatus { get; set; }
    public bool IsEmergency { get; set; }
    public bool IsDisable { get; set; }
    public bool IsOIC { get; set; }
    public int UserPersID { get; set; }


    //-----Drug
    public string ServiceUnitName { get; set; } // nvarchar(100), null
    //public string BrandOrType { get; set; } // nvarchar(255), null
    //public string FormOrKind { get; set; } // nvarchar(255), null
    //public string DoseOrSize { get; set; } // nvarchar(255), null
    //public string Company { get; set; } // nvarchar(255), null
    //public int? MinOrder { get; set; } // int, null
    //public int? MaxOrder { get; set; } // int, null
    //public bool HasExpDateControl { get; set; } // bit, not null
    //public bool IsStrategic { get; set; } // bit, not null


    //------Pakage
    public int PackageID { get; set; } // int, not null
    public int ServiceNum { get; set; } // int, not null


    //------
    public string ServiceTypeName { get; set; }
    public string ServiceCategoryName { get; set; }
    public double TotalK { get; set; }
    public double ProK { get; set; }
    public double TechK { get; set; }
    public double AnesK { get; set; }

    //------Web

    public int PriceOG { get; set; }
}