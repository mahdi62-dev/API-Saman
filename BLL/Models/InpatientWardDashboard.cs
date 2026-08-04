namespace BLL.Models;

public class InpatientWardPatient
{
    public int EncID { get; set; }
    public int PatientID { get; set; }
    public string NationalCode { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string FatherName { get; set; } = "";
    public string FullName { get; set; } = "";
    public int Age { get; set; }
    public int Gender { get; set; }
    public string GenderName { get; set; } = "";
    public string Mobile { get; set; } = "";
    public string StartDate { get; set; } = "";
    public int EncType { get; set; }
    public int EncStatus { get; set; }
    public string EncStatusName { get; set; } = "";
    public int ModID { get; set; }
    public int EncDepID { get; set; }
    public int WardID { get; set; }
    public string WardName { get; set; } = "";
    public int WardDepID { get; set; }
    public int RoomID { get; set; }
    public string RoomName { get; set; } = "";
    public int BedID { get; set; }
    public string BedNo { get; set; } = "";
    public string BedName { get; set; } = "";
    public string BedDisplayName { get; set; } = "";
    public int BedClassID { get; set; }
    public string BedClassName { get; set; } = "";
    public int BedStatus { get; set; }
    public string BedStatusName { get; set; } = "";
    public int AdmissionType { get; set; }
    public string AdmissionTypeName { get; set; } = "";
    public int AdmissionSource { get; set; }
    public string AdmissionSourceName { get; set; } = "";
    public string AdmissionDiagnosis { get; set; } = "";
    public string InitialDiagnosis { get; set; } = "";
    public string ICD10Code { get; set; } = "";
    public bool IsolationRequired { get; set; }
    public bool FallRisk { get; set; }
    public bool PressureUlcerRisk { get; set; }
    public bool InfectionRisk { get; set; }
    public string CompanionFullName { get; set; } = "";
    public string CompanionMobile { get; set; } = "";
    public string EmergencyContactName { get; set; } = "";
    public string EmergencyContactMobile { get; set; } = "";
    public long DepositAmount { get; set; }
    public int StayDays { get; set; }
}

public class InpatientWardSummary
{
    public int WardID { get; set; }
    public string WardName { get; set; } = "";
    public int DepID { get; set; }
    public int RoomCount { get; set; }
    public int BedCount { get; set; }
    public int FreeBedCount { get; set; }
    public int OccupiedBedCount { get; set; }
    public int ReservedBedCount { get; set; }
    public int BlockedBedCount { get; set; }
    public int PatientCount { get; set; }
    public int IsolationCount { get; set; }
    public int FallRiskCount { get; set; }
    public int InfectionRiskCount { get; set; }
    public decimal OccupancyPercent { get; set; }
}
