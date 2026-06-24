namespace BLL.Models;

public class PortalService
{
    public int PortalServiceID { get; set; } // int, not null
    public string PortalServiceName { get; set; } // nvarchar(201), null
    public string PortalServicePrice { get; set; } // nvarchar(10), null
}