namespace BLL.Models;

public class DrDesk
{
    public Guid WProfileID { get; set; } // uniqueidentifier, not null
    public int DrDeskID { get; set; } // int, not null
    public int EncID { get; set; } // int, not null
    public int PatientID { get; set; } // int, not null
    public int FuncType { get; set; } // int, not null
    public int SFIDType { get; set; } // int, not null
}

public class DrDeskEncHistory
{
    public int EncID { get; set; } // int, not null
    public string StartDate { get; set; } // int, not null

    public string ChiefComplaintName { get; set; } // int, not null
    public string ServiceRegName { get; set; } // int, not null
}

public class DrDeskEncDocuments
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Name2 { get; set; }
    public int ReportCount { get; set; }
    public int AttachCount { get; set; }
    public int IsService { get; set; }
}

public class DrDeskEncServiceHistory
{
    public int IsForm { get; set; }
    public int TypeID { get; set; }
    public int ID { get; set; }
    public string Date { get; set; } // int, not null
    public string Name { get; set; } // int, not null
    public string Name2 { get; set; }
    public int AttID { get; set; }
    public int ReportID { get; set; }
}

public class DrDeskEncStatus
{
    public int EncID { get; set; }
    public int IsSFHeartMD { get; set; }
    public int IsDrVisit { get; set; }
    public int IsDrPrescriptionDrug { get; set; }
    public int IsDrPrescriptionLab { get; set; }
    public int IsDrPrescriptionHistory { get; set; }
}