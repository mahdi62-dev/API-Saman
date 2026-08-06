namespace BLL.Models;

public class EPrescriptionProviderSetting
{
    public int ProviderID { get; set; }
    public string ProviderCode { get; set; } = string.Empty;
    public string ProviderName { get; set; } = string.Empty;
    public string BaseUrlTest { get; set; } = string.Empty;
    public string BaseUrlProd { get; set; } = string.Empty;
    public bool IsTestMode { get; set; } = true;
    public bool IsActive { get; set; } = true;
    public string ClientID { get; set; } = string.Empty;
    public string RedirectUri { get; set; } = string.Empty;
    public string ParID { get; set; } = string.Empty;
    public string SiamID { get; set; } = string.Empty;
    public int TimeoutSeconds { get; set; } = 60;
}

public class EPrescriptionServiceMap
{
    public int MapID { get; set; }
    public string ProviderCode { get; set; } = string.Empty;
    public int LocalItemID { get; set; }
    public int LocalServiceID { get; set; }
    public int LocalServiceCode { get; set; }
    public int LocalServiceCategory { get; set; }
    public string LocalName { get; set; } = string.Empty;
    public string ProviderSrvCode { get; set; } = string.Empty;
    public string ProviderSrvType { get; set; } = string.Empty;
    public string ProviderTerminology { get; set; } = string.Empty;
    public string ProviderParTarefGrp { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}

public class EPrescriptionLog
{
    public long LogID { get; set; }
    public string ProviderCode { get; set; } = string.Empty;
    public int EncID { get; set; }
    public int DrPrescID { get; set; }
    public int PatientID { get; set; }
    public int PrescType { get; set; }
    public string RequestJson { get; set; } = string.Empty;
    public string ResponseJson { get; set; } = string.Empty;
    public string TrackingCode { get; set; } = string.Empty;
    public string RegisterID { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public string StatusMessage { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
    public int UserPersID { get; set; }
    public string ActionDate { get; set; } = string.Empty;
}

public class EPrescriptionBuildResult
{
    public bool IsValid { get; set; }
    public string ProviderCode { get; set; } = "TAMIN";
    public string RequestJson { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();
    public List<string> Warnings { get; set; } = new();
}


public class EPrescriptionBaseCatalog
{
    public long CatalogID { get; set; }
    public string ProviderCode { get; set; } = string.Empty;
    public string CatalogType { get; set; } = string.Empty;
    public string ItemCode { get; set; } = string.Empty;
    public string ItemName { get; set; } = string.Empty;
    public string ItemType { get; set; } = string.Empty;
    public string RawJson { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public int UserPersID { get; set; }
    public string ActionDate { get; set; } = string.Empty;
}


public class EPrescriptionTokenResult
{
    public bool IsSuccess { get; set; }
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public int ExpiresIn { get; set; }
    public string RawJson { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
}
