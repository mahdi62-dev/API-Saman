namespace BLL.Models;

public class PatientDebt
{
    public int EncID { get; set; }
    public int PatientID { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public int EncType { get; set; }
    public string EncTypeName { get; set; } = string.Empty;
    public int EncStatus { get; set; }
    public string EncStatusName { get; set; } = string.Empty;
    public int PageCount { get; set; }
    public long TotalAmount { get; set; }
    public long PatientAmount { get; set; }
    public long PayAmount { get; set; }
    public long DiscountAmount { get; set; }
    public long RemainAmount { get; set; }
}
