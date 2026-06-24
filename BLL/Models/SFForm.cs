namespace BLL.Models;

public class SFForm
{
    public int CRUD { get; set; }
    public int FuncType { get; set; }
    public int CentID { get; set; } = 0;
    public int ModID { get; set; } = 0;
    public int ID { get; set; } = 0;
    public int FormID { get; set; } = 0;
    public int PatientID { get; set; } = 0;
    public int EncID { get; set; } = 0;
    public int DrID { get; set; } = 0;
    public int PageID { get; set; } = 0;
    public int ServiceCode { get; set; } //  int, not null
    public string Date { get; set; } = "";
    public string F1 { get; set; } = "";
    public string F2 { get; set; } = "";

    public string Note { get; set; } = "";
    public int UserPersID { get; set; } = 0;
    public string FormName { get; set; } = "";
    public string FormName2 { get; set; } = "";
    public int IsOutOfCenter { get; set; } = 0;
    public int ReportID { get; set; } = 0;
}