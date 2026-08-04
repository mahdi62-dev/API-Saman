namespace BLL.Models;

public class InpatientDepositPolicy
{
    public bool RequireDeposit { get; set; }
    public bool AllowFinalWithoutDeposit { get; set; }
    public bool NeedFinancialConfirm { get; set; }
    public long DepositAmount { get; set; }
    public int InitialEncStatus { get; set; } = 23;
    public int InitialBedStatus { get; set; } = 1;
    public int FinalEncStatus { get; set; } = 23;
    public int ReservationExpireMinutes { get; set; } = 120;
}

public class EncInpatient
{
    public int CRUD { get; set; } = 1;
    public int EncID { get; set; }
    public int AdmissionType { get; set; }
    public int AdmissionSource { get; set; }
    public int WardID { get; set; }
    public int RoomID { get; set; }
    public int BedID { get; set; }
    public int BedClass { get; set; }
    public string AdmissionDiagnosis { get; set; } = "";
    public string InitialDiagnosis { get; set; } = "";
    public string ICD10Code { get; set; } = "";
    public string IntroduceLetterNo { get; set; } = "";
    public string IntroduceLetterDate { get; set; } = "";
    public string IntroduceLetterExpireDate { get; set; } = "";
    public long DepositAmount { get; set; }
    public bool DepositRequired { get; set; }
    public long DepositPaidAmount { get; set; }
    public int DepositCashID { get; set; }
    public bool FinancialConfirm { get; set; }
    public string FinancialConfirmDate { get; set; } = "";
    public int FinancialConfirmUserPersID { get; set; }
    public string BedReservationDate { get; set; } = "";
    public string BedReservationExpireDate { get; set; } = "";
    public string FinalAdmissionDate { get; set; } = "";
    public int FinalAdmissionUserPersID { get; set; }
    public int PreAdmissionStatus { get; set; }
    public string CompanionFullName { get; set; } = "";
    public string CompanionRelation { get; set; } = "";
    public string CompanionNationalCode { get; set; } = "";
    public string CompanionMobile { get; set; } = "";
    public string EmergencyContactName { get; set; } = "";
    public string EmergencyContactRelation { get; set; } = "";
    public string EmergencyContactMobile { get; set; } = "";
    public bool IsolationRequired { get; set; }
    public int IsolationType { get; set; }
    public bool FallRisk { get; set; }
    public bool PressureUlcerRisk { get; set; }
    public bool InfectionRisk { get; set; }
    public bool PatientIdentificationBand { get; set; }
    public bool AllergyBand { get; set; }
    public bool HasBelongings { get; set; }
    public string BelongingsDescription { get; set; } = "";
    public int UserPersID { get; set; }
    public string ActionDate { get; set; } = "";
    public int CenterID { get; set; } = 1;
}
