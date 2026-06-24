using System.Text.Json.Serialization;

namespace BLL.Models;

public class OkProc
{
    public OkProc()
    {
        CRUD = 1;
        ProcType = "";
    }

    [JsonIgnore] public int CRUD { get; set; }

    [JsonIgnore] public int FuncType { get; set; } = 0;

    [JsonIgnore] public int EncID { get; set; } = 0;

    [JsonIgnore] public int PageID { get; set; } = 0;

    [JsonIgnore] public int CentID { get; set; } = 0;

    [JsonIgnore] public int FormID { get; set; } = 0;

    [JsonIgnore] public int UserPersID { get; set; } = 0;

    public string ProcType { get; set; } = "";
    public string DrName { get; set; } = "";
    public bool HTN { get; set; }
    public bool DM { get; set; }
    public bool DLP { get; set; }
    public bool CS { get; set; }
    public bool FH { get; set; }
    public bool DMInsulin { get; set; }
    public bool CAD { get; set; }
    public bool Thyroid { get; set; }

    public bool CHF { get; set; }
    public bool Cr { get; set; }
    public string BP { get; set; } = "";
    public string HR { get; set; } = "";
    public bool PCI { get; set; }
    public bool CABG { get; set; }
    public bool Valvular { get; set; }
    public string DH { get; set; } = "";
    public string Echo { get; set; } = "";
    public string ECG { get; set; } = "";
    public string EST { get; set; } = "";
    public string CAG { get; set; } = "";
    public string MPI { get; set; } = "";
    public string CCTA { get; set; } = "";
    public string FC { get; set; } = "";
    public int RCRI { get; set; }
    public string DrugID { get; set; } = "";
    public string DrugPeriod { get; set; } = "";

    [JsonIgnore] public string DrugRecommendation { get; set; }

    public int ProcRisk { get; set; }
    public int ProcStatus { get; set; }
    public string Recommend { get; set; } = "";
    public string Note { get; set; } = "";
}