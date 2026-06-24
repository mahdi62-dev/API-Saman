using System.ComponentModel.DataAnnotations;

namespace BLL.Models;

public class Dr
{
    public int MasterID { get; set; } // int, not null
    public int CentID { get; set; } // int, not null
    public int DrID { get; set; } // int, not null
    [MaxLength] public byte[] Photo { get; set; } // varbinary(max), not null
    public string Name { get; set; } // nvarchar(201), null
    public string Title { get; set; } // nvarchar(201), null
    public string NationalCode { get; set; } // nvarchar(10), null
    public string FirstName { get; set; } // nvarchar(100), null
    public string LastName { get; set; } // nvarchar(100), null
    public int ShareCount { get; set; } // int, not null
    public int RegNumber { get; set; } // int, not null
    public int Gender { get; set; } // int, not null
    public string Mobile { get; set; } // nvarchar(14), null
    public bool IsDisable { get; set; } // bit, not null
    public int DrLevel { get; set; } // int, not null
    public int DrExpert { get; set; } // smallint, not null
    public int DrExpertise { get; set; } // smallint, not null
    public int DrUiType { get; set; } // smallint, not null
    public int DrRoleType { get; set; } // int, not null
    public int AcademicLevel { get; set; } // bit, not null
    public bool IsFullTime { get; set; } // bit, not null
    public int Speciality { get; set; } // int, null
    public string Explain { get; set; } // int, null
    public string CenterName { get; set; } // nvarchar(201), null

    public string Tel { get; set; } // nvarchar(201), null
    public string Tel1 { get; set; } // nvarchar(201), null
    public string Tel2 { get; set; } // nvarchar(201), null
    public string Address { get; set; } // nvarchar(201), null
    public string MapAddress { get; set; } // nvarchar(201), null
    public string InstagramAddress { get; set; } // nvarchar(201), null
    public string WhatsappAddress { get; set; } // nvarchar(201), null
    public string TelegramAddress { get; set; } // nvarchar(201), null
    public string About { get; set; } // nvarchar(201), null
    public string FullNameEn { get; set; } // nvarchar(201), null

    public string AccountNumber { get; set; } // nvarchar(201), null
}