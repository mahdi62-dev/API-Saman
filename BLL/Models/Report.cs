namespace BLL.Models;

public class ReportQuery
{
    public int CRUD { get; set; }
    public int FuncType { get; set; }
    public int RepType { get; set; }
    public int RepID { get; set; }
    public string Name { get; set; }
    public string FileName { get; set; }
    public string TableName { get; set; }
    public string TSQL { get; set; }
    public byte[] RptFile { get; set; }
    public int ParentID { get; set; }
}

public class List
{
    public string string1 { get; set; }
    public string string2 { get; set; }
}

public class ReportRun
{
    public int CRUD { get; set; }
    public int FuncType { get; set; }
    public int RepID { get; set; }
    public string RepCode { get; set; }
    public bool IsRep { get; set; }
    public int RepType { get; set; }
    public string CenterName { get; set; }
    public string Name { get; set; }
    public string FullName { get; set; }
    public string TSQL { get; set; }
    public string PaperSize { get; set; }
    public bool IsLandscape { get; set; }
    public int ParentID { get; set; }
    public string FileName { get; set; }
    public string RptFile { get; set; }
    public string FilterCaption { get; set; } = "";

    public int UserPersID { get; set; }
}

public class ReportFilter
{
    public int CRUD { get; set; }
    public int FuncType { get; set; }
    public int RepID { get; set; }
    public int RepFilterType { get; set; }
    public int FilterOrder { get; set; }
    public string RepFilter { get; set; }
    public int ControlType { get; set; }
    public string FilterName { get; set; }
    public int FilterID { get; set; }
    public string ControlName { get; set; }
    public int UserPersID { get; set; }
}