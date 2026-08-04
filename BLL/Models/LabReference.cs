namespace BLL.Models;

public class LabReference
{
    public int CRUD { get; set; } = 1;
    public int LabRefID { get; set; }
    public int ServiceID { get; set; }
    public int ServiceCode { get; set; }
    public int ServiceType { get; set; } = 3;
    public int ServiceCategory { get; set; } = 150;
    public string TestCode { get; set; } = "";
    public string TestNameFa { get; set; } = "";
    public string TestNameEn { get; set; } = "";
    public string CategoryName { get; set; } = "";
    public byte Gender { get; set; }
    public int AgeFromDay { get; set; }
    public int AgeToDay { get; set; } = 36500;
    public string Unit { get; set; } = "";
    public double? NormalLow { get; set; }
    public double? NormalHigh { get; set; }
    public double? CriticalLow { get; set; }
    public double? CriticalHigh { get; set; }
    public string TextRange { get; set; } = "";
    public bool UseDefaultResult { get; set; }
    public string DefaultResult { get; set; } = "";
    // 1=Text, 2=Decimal, 3=Combo(ADR)
    public byte AnswerType { get; set; } = 1;
    public string AnswerListADName { get; set; } = "";
    public double? ResultMin { get; set; }
    public double? ResultMax { get; set; }
    public string RefRangeText { get; set; } = "";
    public string MethodName { get; set; } = "";
    public string AnalyzerName { get; set; } = "";
    public string KitName { get; set; } = "";
    public string SourceTitle { get; set; } = "";
    public string StartDate { get; set; } = "";
    public string EndDate { get; set; } = "";
    public bool IsDefault { get; set; } = true;
    public bool IsApproved { get; set; }
    public bool IsDisable { get; set; }
    public int CenterID { get; set; } = 1;
    public int UserPersID { get; set; }
    public string ActionDate { get; set; } = "";
}
