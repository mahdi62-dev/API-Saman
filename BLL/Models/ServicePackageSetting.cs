namespace BLL.Models;

public class ServicePackageSetting
{
    public int CRUD { get; set; } = 1;
    public int PackageID { get; set; }
    public int DepID { get; set; }
    public string DepName { get; set; } = "";
    public int WardID { get; set; }
    public string WardName { get; set; } = "";
    public int PackageType { get; set; } = 1; // 1 سرپایی، 2 بستری
    public int PackageCode { get; set; }
    public string PackageName { get; set; } = "";
    public string StartDate { get; set; } = "";
    public string EndDate { get; set; } = "";
    public bool IsDisable { get; set; }
    public int SortID { get; set; }
    public string Explain { get; set; } = "";
    public int CenterID { get; set; } = 1;
    public int UserPersID { get; set; }
    public string ActionDate { get; set; } = "";
    public int ItemCount { get; set; }
}

public class ServicePackageItemSetting
{
    public int CRUD { get; set; } = 1;
    public int ID { get; set; }
    public int ServicePakageID { get; set; }
    public int DepID { get; set; }
    public int ServiceID { get; set; }
    public int ServiceCategory { get; set; }
    public string ServiceCategoryName { get; set; } = "";
    public int ServiceCode { get; set; }
    public string ServiceName { get; set; } = "";
    public int ServiceAdrID { get; set; }
    public double ServiceNum { get; set; } = 1;
    public bool IsDisable { get; set; }
    public int SortID { get; set; }
    public string Explain { get; set; } = "";
    public int CenterID { get; set; } = 1;
    public int UserPersID { get; set; }
    public string ActionDate { get; set; } = "";
}
