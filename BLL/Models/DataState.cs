namespace BLL.Models;

public class DS
{
    public Dep DepCur = new();

    public int DepID = 1000;
    public int MasterID { get; set; }
    public int CentID { get; set; }
    public int ModID { get; set; }
}

public class EncState
{
    public Sch Sch;
    public bool EncEditMode { get; set; } = false;
    public bool PatientEditMode { get; set; } = false;
}

public class DrState
{
    public int DrReportID { get; set; }
    public int SRID { get; set; }
}

public class PageState
{
    public int PageID { get; set; }
}