namespace BLL.Models.Web;

public class WebMaster
{
    public int CRUD { get; set; } // int, not null
    public int FuncType { get; set; } // int, not null

    public int MasterID { get; set; } // int, not null
    public string NationalCode { get; set; } // nvarchar(201), null
    public string Name { get; set; } // nvarchar(201), nul
    public string MasterName { get; set; } // nvarchar(201), null
    public string Page { get; set; } // nvarchar(201), null
    public string MasterNameFull => $"{" دکتر "} {MasterName}";
    public string Explain { get; set; } // int, null
    public string StartDate { get; set; } // int, null
    public string AccountNumber { get; set; } // int, null
    public string Tel { get; set; } // nvarchar(201), null
    public string Mobile { get; set; } // nvarchar(14), null
}