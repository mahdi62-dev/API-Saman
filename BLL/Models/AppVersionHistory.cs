namespace BLL.Models;

public class AppVersionHistory
{
    public int ChangeID { get; set; }
    public string VersionNo { get; set; } = string.Empty;
    public string ReleaseDate { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string ChangeText { get; set; } = string.Empty;
    public string ChangeType { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public int SortID { get; set; }
    public int UserPersID { get; set; }
    public string ActionDate { get; set; } = string.Empty;
}
