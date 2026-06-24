using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

[Table("SH")]
public class SchDef
{
    public int CRUD { get; set; } // int, not null
    public int FuncType { get; set; } // int, not null
    public int CentID { get; set; } // int, not null
    public string DrNationalCode { get; set; } // int, not null
    public int SchDefID { get; set; } // int, not null
    public int DepID { get; set; } // int, not null
    public string DepName { get; set; } // nvarchar(200), null
    public int DrID { get; set; } // int, not null
    public string DrName { get; set; } // nvarchar(201), null
    public string Date { get; set; } // char(16), not null
    public int WeekDay { get; set; } // int, not null
    public string WeekDayName { get; set; } // nvarchar(100), null
    public string StartTime { get; set; } // char(5), null
    public string EndTime { get; set; } // char(5), null
    public int? TotalCapacity { get; set; } // int, null
    public int Capacity { get; set; } // int, not null
    public int ExtraNum { get; set; } // int, not null
    public int SchTime { get; set; } // int, not null
    public int UserPersID { get; set; } // int, not null
    public string Name { get; set; } // nvarchar(201), null
    public bool IsCancel { get; set; } // bit, not null
    public short SchCount { get; set; } // smallint, not null
    public short ConfirmCount { get; set; } // smallint, not null
    public short EncCount { get; set; } // smallint, not null
}

public class Sch : ICloneable
{
    public Sch()
    {
        SchID = 0;
        Insurance = 1;
    }

    public int CRUD { get; set; } // int, not null
    public int FuncType { get; set; } // int, not null
    public int CentID { get; set; } // int, not null

    public int SchID { get; set; } // int, not null
    public int SchDefID { get; set; } // int, not null
    public int RecNo { get; set; } // int, not null
    public string SchTime { get; set; } // nchar(5), null
    public int EncID { get; set; } // int, not null
    public string EncIDString { get; set; } // nchar(5), null
    public bool IsConfirm { get; set; } // bit, not null
    public int DepID { get; set; } // int, not null
    public int DrID { get; set; } // int, not null
    public string FirstName { get; set; } // nvarchar(1000), null
    public string LastName { get; set; } // nvarchar(1000), null
    public string FullName { get; set; } // nvarchar(2002), null

    public string FatherName { get; set; } // nvarchar(1000), null
    public string NationalCode { get; set; } // nchar(10), null
    public string Mobile { get; set; } // nvarchar(20), null
    public string Tel { get; set; } // nvarchar(20), null
    public string BirthDate { get; set; }

    public int Age { get; set; } // int, not null
    public int Country { get; set; } // int, not null
    public string CountryName { get; set; } // nvarchar(100), null
    public int City { get; set; } // int, not null
    public string CityName { get; set; } // nvarchar(201), null
    public int RefDrID { get; set; } // int, not null
    public string RefDrName { get; set; } // nvarchar(100), null
    public int Insurance { get; set; } // int, not null
    public string InsuranceName { get; set; } // nvarchar(50), null
    public int ChiefComplaint { get; set; } // int, not null
    public string ChiefComplaintName { get; set; } // nvarchar(100), null
    public int EncService { get; set; } // int, not null
    public string EncServiceName { get; set; } // nvarchar(100), null
    public int Height { get; set; } // int, not null
    public int Weight { get; set; } // int, not null
    public int UnderlyingDisease { get; set; } // bit, not null
    public bool Anes { get; set; } // bit, not null
    public string Description { get; set; } // nvarchar(1000), null
    public string F1 { get; set; } // nvarchar(50), null
    public string F2 { get; set; } // nvarchar(50), null
    public string F3 { get; set; } // nvarchar(50), null
    public string F4 { get; set; } // nvarchar(50), null
    public string F5 { get; set; } // nvarchar(50), null
    public string F6 { get; set; } // nvarchar(50), null
    public string F7 { get; set; } // nvarchar(50), null
    public string F8 { get; set; } // nvarchar(50), null
    public string F9 { get; set; } // nvarchar(50), null
    public string F10 { get; set; } // nvarchar(50), null
    public string F11 { get; set; } // nvarchar(50), null
    public string F12 { get; set; } // nvarchar(50), null
    public string F13 { get; set; } // nvarchar(50), null
    public string F14 { get; set; } // nvarchar(50), null
    public string F15 { get; set; } // nvarchar(50), null
    public string F16 { get; set; } // nvarchar(50), null
    public string F17 { get; set; } // nvarchar(50), null
    public string F18 { get; set; } // nvarchar(50), null
    public string F19 { get; set; } // nvarchar(50), null

    public string F20 { get; set; } // nvarchar(50), null

    //public int IsConfirm { get; set; } // int, not null
    public int Gender { get; set; } // int, not null
    public string ActionDate { get; set; } // nchar(16), null
    public int UserPersID { get; set; } // int, not null
    public string UserPersName { get; set; } // nvarchar(201), null
    public bool IsCancel { get; set; } // bit, not null
    public string Date { get; set; } // char(16), not null
    public bool IsCancelEnc { get; set; } // bit, not null
    public string Explain { get; set; } // char(16), not null

    public bool IsSelected { get; set; } = false; // bit, not null


    public object Clone()
    {
        return MemberwiseClone();
    }
}