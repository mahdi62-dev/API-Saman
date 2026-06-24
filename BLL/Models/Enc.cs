namespace BLL.Models;

public class Enc
{
    public Enc()
    {
        CRUD = 1;
        FuncType = 0;
        EncID = 0;
        PatientID = 0;
        LastEncID = 0;
        Insurance = 1;
        Insurance2 = 1;
    }

    public int CRUD { get; set; }
    public int FuncType { get; set; }
    public int EncID { get; set; }
    public string EncPhoto { get; set; }
    public int PatientID { get; set; }

    public int LastEncID { get; set; }
    public int OutEncCount { get; set; } = 0;
    public int InEncCount { get; set; } = 0;

    public string NationalCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FatherName { get; set; }
    public string BirthDate { get; set; }
    public int Age { get; set; } = 0;
    public string IDCardNumber { get; set; }
    public string PassportID { get; set; }
    public string Mobile { get; set; }
    public string Tel { get; set; }
    public string CompanionAddress { get; set; }
    public string CompanionTel { get; set; }
    public int Recommender { get; set; } = 0;
    public string CompanionFullName { get; set; }
    public string Street { get; set; }
    public string Email { get; set; }
    public int Gender { get; set; } = 0;
    public string GenderName { get; set; }
    public int Country { get; set; } = 0;
    public string CountryName { get; set; }
    public int BirthArea { get; set; } = 0;
    public string BirthAreaName { get; set; }

    public int EducationLevel { get; set; } = 0;
    public string EducationLevelName { get; set; }
    public int Religion { get; set; } = 0;
    public int Job { get; set; } = 0;
    public string JobName { get; set; }

    public int City { get; set; } = 0;
    public string AddressFull { get; set; }
    public int MaritalStatus { get; set; } = 0;
    public string MaritalStatusName { get; set; }
    public int RefDrID { get; set; } = 0;
    public string ReferDrText { get; set; }

    public string InsuranceNumber { get; set; }

    // public string EncDescription { get; set; }
    public int InsurancePageNumber { get; set; }
    public string InsuranceExpireDate { get; set; }
    public string PresDate { get; set; }
    public string InsuranceNumber2 { get; set; }

    public int ModID { get; set; } = 0;
    public int DepID { get; set; } = 0;
    public string DepName { get; set; }
    public int Insurance { get; set; }
    public string InsuranceName { get; set; }
    public string InsuranceSerial { get; set; }
    public bool InsuranceExpireValid { get; set; } = false;
    public int Insurance2 { get; set; }
    public string InsuranceName2 { get; set; }

    public int EncService { get; set; } = 0;
    public string EncServiceName { get; set; }
    public double DiscountPercent { get; set; } = 0;
    public int DrID { get; set; } = 0;
    public string DrName { get; set; }
    public int ChiefComplaint { get; set; } = 0;
    public string ChiefComplaintName { get; set; }
    public int UnderlyingDisease { get; set; } = 0;
    public string UnderlyingDiseaseName { get; set; }
    public int EncType { get; set; } = 0;
    public string EncTypeName { get; set; }
    public int EncStatus { get; set; } = 0;
    public string EncStatusName { get; set; }
    public string StartDate { get; set; }
    public string StartDate1 { get; set; }

    public string StartDateRange { get; set; }
    public string EndDate { get; set; }
    public string EndDate1 { get; set; }

    public string EndDateRange { get; set; }
    public bool IsEmerg { get; set; } = false;
    public string Description { get; set; }
    public long SDrFixAmount { get; set; } = 0;
    public bool IsSDrAcceptAmount { get; set; } = false;
    public string OprReserveDate { get; set; }
    public int Height { get; set; } = 0;
    public int Weight { get; set; } = 0;
    public int RefPrID { get; set; } = 0;

    public string EncCurInfo => $"{"/ "}{FirstName} {LastName} {Age + " ساله"}";

    public Enc Clone()
    {
        return (Enc)MemberwiseClone();
    }
}

public class EncError
{
    public EncError()
    {
        ErrorCode = 0;
        ErrorMessage = null;
    }

    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
}