namespace BLL.Models;

public class Personnel
{
    public int CRUD { get; set; } // int, not null
    public int CenterID { get; set; } // int, not null
    public int PersID { get; set; } // int, not null
    public int SortID { get; set; } // int, not null
    public string NationalCode { get; set; } // nvarchar(10), null
    public string FullName { get; set; } // nvarchar(201), null
    public string FirstName { get; set; } // nvarchar(100), null
    public string LastName { get; set; } // nvarchar(100), null
    public string FatherName { get; set; } // nvarchar(100), null
    public int Dep { get; set; } // int, not null
    public string DepName { get; set; } // nvarchar(200), null
    public string Name { get; set; } // nvarchar(200), null
    public int PersType { get; set; } // int, not null
    public int ContractType { get; set; } // int, not null
    public string ContractTypeName { get; set; } // nvarchar(100), null
    public string PersTypeName { get; set; } // nvarchar(100), null
    public int Gender { get; set; } // int, not null
    public string GenderName { get; set; } // nvarchar(100), null
    public bool IsDisable { get; set; } // bit, not null
    public string IDCardNumber { get; set; } // nvarchar(30), null
    public string BirthDate { get; set; } // nchar(10), null
    public int MaritalStatus { get; set; } // tinyint, not null
    public string Mobile { get; set; } // nvarchar(14), null
    public string Tel { get; set; } // nvarchar(14), null
    public int Province { get; set; } // int, not null
    public int City { get; set; } // int, not null
    public string Street { get; set; } // nvarchar(max), null
    public string AddressDetail { get; set; } // nvarchar(max), null
    public int Bank { get; set; } // int, not null
    public string BankAccountNumber { get; set; } // nvarchar(50), null
    public byte[] Photo { get; set; } // varbinary(max), null
    public byte[] Sign { get; set; } // image, null
    public int DrRoleType { get; set; } // int, not null
    public bool IsSalary { get; set; } // bit, not null
    public bool IsInsurance { get; set; } // bit, not null
    public string PersTypeGroup { get; set; } // nvarchar(1000), null
    public bool IsPercase { get; set; } // bit, not null
    public int ShareCount { get; set; } // int, not null
    public int RegNumber { get; set; } // int, not null
    public int AcademicLevel { get; set; } // bit, not null
    public bool IsFullTime { get; set; } // bit, not null
    public int? Speciality { get; set; } // int, null
    public int DrExpert { get; set; } // smallint, not null
    public int DrExpertise { get; set; } // smallint, not null
    public int DrLevel { get; set; } // int, not null
    public int DrUiType { get; set; } // smallint, not null
    public string Email { get; set; } // nchar(16), null
    public string Description { get; set; } // nchar(16), null
    public string ResuName { get; set; } // nchar(16), null
    public string Drowssap { get; set; } // nchar(16), null
    public bool Share { get; set; } // bit, not null

    public string FullNameEn { get; set; } // nvarchar(1000), null
    public string SignTextEn { get; set; } // nvarchar(1000), null
    public string SignTextFa { get; set; } // nvarchar(1000), null
    public bool DrIsPortal { get; set; } // nvarchar(1000), null
    public string Explain { get; set; } // nvarchar(1000), null

    public string ActionDate { get; set; } // nchar(16), null
    public int UserPersID { get; set; } // int, not null
}