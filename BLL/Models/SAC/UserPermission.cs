namespace BLL.Models.SAC;

// این فایل عمداً فقط مدل Seed را نگه می‌دارد تا با مدل‌های موجود پروژه مثل UserPermission و SACPermissionItem تداخل نداشته باشد.
public class SACPermissionSeedItem
{
    public int ActionID { get; set; }
    public string ActionName { get; set; } = "";
    public int ModID { get; set; }
    public string ActionNameEn { get; set; } = "";
    public int ParentID { get; set; }
    public int CenterID { get; set; } = 1;
}
