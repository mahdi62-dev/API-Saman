namespace BLL.Models;

public class EncInfo
{
    public int CRUD { get; set; } // int, not null
    public int FuncType { get; set; } // int, not null
    public long RecNO { get; set; } // int, not null
    public int EncInfoID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public string FullName { get; set; } // nvarchar(301), null
    public int InfoStatus { get; set; } // int, not null
    public string InfoStatusName { get; set; } // nvarchar(100), null
    public string StartDate { get; set; } // nchar(16), not null
    public string EndDate { get; set; } // nchar(16), null
    public bool IsDisable { get; set; } // bit, not null
    public int DepID { get; set; } // smallint, not null
    public string DepName { get; set; } // nvarchar(200), null
    public int DrID { get; set; } // smallint, not null
    public string DrName { get; set; } // nvarchar(201), null
    public int UserPersID { get; set; } // smallint, not null
    public bool WardDrug { get; set; } // bit, not null
    public bool WardService { get; set; } // bit, not null
    public bool Opr { get; set; } // bit, not null
    public bool OprDrug { get; set; } // bit, not null
    public string EncStartDate { get; set; } // bit, not null
    public bool IsDisplayMonitor { get; set; } // bit, not null
    public string WeekDayName { get; set; } // bit, not null
    public string ServiceName { get; set; } // bit, not null
    public string Note { get; set; } = string.Empty;
    public int SortID { get; set; }
}

public class TvSubtitle
{
    public int CRUD { get; set; } // int, not null
    public int FuncType { get; set; } // int, not null
    public int ID { get; set; } // int, not null
    public string Tvtitle { get; set; } // bit, not null
}