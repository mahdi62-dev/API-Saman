using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("Service")]
public class ServicePrice
{
    public ServicePrice()
    {
        CRUD = 0;
        FuncType = 0;

        TotalPrice = 0;
        TotalProPrice = 0;
        TotalTechPrice = 0;
        InsPrice = 0;
        PatPrice = 0;
        ProInsPrice = 0;
        ProPatPrice = 0;
        TechInsPrice = 0;
        TechPatPrice = 0;

        RegDate = null;
        ServiceID = 0;
        EncID = 0;
        DrID = 0;
        IsOIC = false;
        ManualPrice = 0;
        IsOpr = false;
    }

    public int CRUD { get; set; }
    public int FuncType { get; set; }

    public long TotalPrice { get; set; }
    public long TotalProPrice { get; set; }
    public long TotalTechPrice { get; set; }
    public long InsPrice { get; set; }
    public long PatPrice { get; set; }
    public long ProInsPrice { get; set; }
    public long ProPatPrice { get; set; }
    public long TechInsPrice { get; set; }
    public long TechPatPrice { get; set; }

    public string RegDate { get; set; }
    public int ServiceID { get; set; }
    public int EncID { get; set; }
    public int DrID { get; set; }
    public bool IsOIC { get; set; }
    public long ManualPrice { get; set; }

    public bool IsOpr { get; set; }
}