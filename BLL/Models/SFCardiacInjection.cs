using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BLL.Models;

[Table("SFCardiacInjection")]
public class SFCardiacInjection
{
    public SFCardiacInjection()
    {
        CRUD = 1;
    }

    [JsonIgnore] public int CRUD { get; set; }

    [JsonIgnore] public int FuncType { get; set; } = 0;

    [JsonIgnore] public int EncID { get; set; } = 0;

    [JsonIgnore] public int PageID { get; set; } = 0;

    [JsonIgnore] public int CentID { get; set; } = 0;

    [JsonIgnore] public int FormID { get; set; } = 0;

    [JsonIgnore] public int UserPersID { get; set; } = 0;

    public string DrugID { get; set; }
    public string DrugDose { get; set; }
    public string DrugNote { get; set; } = "";
    public string Time { get; set; } // float, null
    public string BPSystolic { get; set; } // float, null
    public string BPDiastolic { get; set; } // float, null
    public string HeartRate { get; set; } // int, null
    public int SpO2 { get; set; } // int, not null
    public string Note { get; set; } = "";
}