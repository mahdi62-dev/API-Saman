namespace BLL.Models;

public class ErpCenterSetting
{
    public int CRUD { get; set; } = 1;
    public int CenterID { get; set; }
    public int MasterID { get; set; }
    public string Name { get; set; } = "";
    public string Explain { get; set; } = "";
    public int CenterType { get; set; }
    public string IPServer { get; set; } = "";
    public string Tel { get; set; } = "";
    public string WebAddress { get; set; } = "";
    public string InstagramAddress { get; set; } = "";
    public byte[]? Logo { get; set; }
    public bool HasLogo => Logo is not null && Logo.Length > 0;
    public string Sign { get; set; } = "";
    public string TelText { get; set; } = "";
    public string Address { get; set; } = "";
}

public class ErpSetting
{
    public int CRUD { get; set; } = 1;
    public int ID { get; set; }
    public string CenterName { get; set; } = "";
    public int CenterType { get; set; }
    public string CenterID { get; set; } = "";
    public string CompanyTel { get; set; } = "";
    public string TimexApp { get; set; } = "";
}

public class ErpSettingConfig
{
    public int CRUD { get; set; } = 1;
    public int ID { get; set; }
    public int? Val1 { get; set; }
}

public class ErpSettingApp
{
    public int CRUD { get; set; } = 1;
    public int SAID { get; set; }
    public int UserID { get; set; }
    public int ModID { get; set; }
    public int DepID { get; set; }
    public int SetID { get; set; }
    public string Val { get; set; } = "";
}

public class ErpConfig
{
    public int CRUD { get; set; } = 1;
    public int ModID { get; set; }
    public int DepID { get; set; }
    public int ConfigID { get; set; }
    public string Val { get; set; } = "";
    public int CenterID { get; set; }
    public string Explain { get; set; } = "";
}
