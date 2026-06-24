using System.ComponentModel.DataAnnotations;

namespace BLL.Models;

public class HFFormFollowup
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
    public string Note { get; set; } = "";
    public int UserPersID { get; set; } = 0;
    public string FormName { get; set; } = "";
    public string FormName2 { get; set; } = "";
    public int IsOutOfCenter { get; set; } = 0;
    public int ReportID { get; set; } = 0;


    [MaxLength] public string Note1 { get; set; } // nvarchar(max), null
    [MaxLength] public string Note2 { get; set; } // nvarchar(max), null
    [MaxLength] public string Note3 { get; set; } // nvarchar(max), null
    [MaxLength] public string Note4 { get; set; } // nvarchar(max), null
    [MaxLength] public string Note5 { get; set; } // nvarchar(max), null
    [MaxLength] public string Note6 { get; set; } // nvarchar(max), null
    [MaxLength] public string Note7 { get; set; } // nvarchar(max), null
    [MaxLength] public string Note8 { get; set; } // nvarchar(max), null
    public int Result1 { get; set; } // int, not null
    public int Result2 { get; set; } // int, not null
    public int Result3 { get; set; } // int, not null
    public int Result4 { get; set; } // int, not null
    public int Result5 { get; set; } // int, not null
    public int Result6 { get; set; } // int, not null
    public int Result7 { get; set; } // int, not null
    public int Result8 { get; set; } // int, not null
}