namespace BLL.Models.SAC;

public class UserPermission
{
    public int ResuID { get; set; }
    public string ResuName { get; set; } = "";
    public string Drowssap { get; set; } = "";
    public int PersID { get; set; }
    public string PersName { get; set; } = "";
    public bool IsDisable { get; set; }
}

public class SACPermissionItem
{
    public int ActionID { get; set; }
    public string ActionName { get; set; } = "";
    public int ModID { get; set; }
    public string ActionNameEn { get; set; } = "";
    public int ParentID { get; set; }
    public int CenterID { get; set; }

    public string ParentName { get; set; } = "";
    public string ModName { get; set; } = "";
    public bool IsAllow { get; set; }
    public bool IsChanged { get; set; }
}
