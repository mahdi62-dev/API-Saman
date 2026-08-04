namespace BLL.Models;

public class AppUserSession
{
    public string SessionID { get; set; } = string.Empty;
    public int OperID { get; set; }
    public int OperPersID { get; set; }
    public string LastRoute { get; set; } = string.Empty;
    public int ModID { get; set; }
    public int DepID { get; set; }
    public int EncID { get; set; }
    public DateTime ExpireAt { get; set; }
    public bool IsActive { get; set; }
    public string CreateDate { get; set; } = string.Empty;
    public string LastAccessDate { get; set; } = string.Empty;
}
