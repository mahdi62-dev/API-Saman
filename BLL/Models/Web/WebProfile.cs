using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Web;

public class WebProfile
{
    [Key] public Guid WProfileID { get; set; } // uniqueidentifier, not null

    public int CRUD { get; set; } // nvarchar(201), null
    public int FuncType { get; set; } // nvarchar(201), null
    public int CentID { get; set; } // nvarchar(201), null
    public int PatientID { get; set; } // nvarchar(201), null
    public string Mobile { get; set; } = ""; // nvarchar(201), null
    public string OTPCode { get; set; } = ""; // nvarchar(10), null
    public string NationalCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{" "}{FirstName} {LastName}";
    public string FatherName { get; set; }
    public string BirthDate { get; set; }
    public int Gender { get; set; } = 0;
    public string GenderName { get; set; }
    public string Drowssap { get; set; }
    public int City { get; set; } = 0;
    public string Street { get; set; }
    public string Email { get; set; }
}