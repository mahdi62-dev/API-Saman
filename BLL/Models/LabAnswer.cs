namespace BLL.Models;

public class LabWorkListItem
{
    public int EncID { get; set; }
    public int PatientID { get; set; }
    public int PageID { get; set; }
    public int PageCode { get; set; }
    public string PageDate { get; set; } = "";
    public string PatientFullName { get; set; } = "";
    public string NationalCode { get; set; } = "";
    public string DrName { get; set; } = "";
    public string DepName { get; set; } = "";
    public long RemainAmount { get; set; }
    public int TestCount { get; set; }
    public int LabResultID { get; set; }
    public byte ReportStatus { get; set; }
    public string StatusName { get; set; } = "ثبت نشده";
    public bool HasResult { get; set; }
    public bool IsFinancialClear => RemainAmount <= 0;
}

public class LabPatientHistory
{
    public int EncID { get; set; }
    public int PatientID { get; set; }
    public int PageID { get; set; }
    public int PageCode { get; set; }
    public string PageDate { get; set; } = "";
    public int TestCount { get; set; }
    public int LabResultID { get; set; }
    public byte ReportStatus { get; set; }
    public string StatusName { get; set; } = "ثبت نشده";
    public long RemainAmount { get; set; }
}


public class LabTestFilterItem
{
    public int ServiceCode { get; set; }
    public int ServiceID { get; set; }
    public string TestCode { get; set; } = "";
    public string TestName { get; set; } = "";
    public string DisplayName => ServiceCode > 0 ? $"{ServiceCode} - {TestName}" : TestName;
}

public class LabAnswerHeader
{
    public int CRUD { get; set; } = 1;
    public int FuncType { get; set; }
    public int LabResultID { get; set; }
    public int EncID { get; set; }
    public int PatientID { get; set; }
    public int PageID { get; set; }
    public string ResultNo { get; set; } = "";
    public string LabNo { get; set; } = "";
    public string ResultDate { get; set; } = "";
    public string SampleDate { get; set; } = "";
    public byte ReportStatus { get; set; }
    public long RemainAmount { get; set; }
    public string Note { get; set; } = "";
    public int UserPersID { get; set; }
    public int CenterID { get; set; } = 1;

    public string PatientFullName { get; set; } = "";
    public string NationalCode { get; set; } = "";
    public string DrName { get; set; } = "";
    public string DepName { get; set; } = "";
    public string StatusName { get; set; } = "";
}

public class LabAnswerItem
{
    public int CRUD { get; set; }
    public int LabResultItemID { get; set; }
    public int LabResultID { get; set; }
    public int SRID { get; set; }
    public int ServiceID { get; set; }
    public int ServiceCode { get; set; }
    public int ItemID { get; set; }
    public string ItemName { get; set; } = "";
    public string CategoryName { get; set; } = "";
    public string ResultValue { get; set; } = "";
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
    public string RefRange { get; set; } = "";
    public string Flag { get; set; } = "";
    public bool IsCritical { get; set; }
    public int SortID { get; set; }
    public string Note { get; set; } = "";
    public int UserPersID { get; set; }
    public string ActionDate { get; set; } = "";
}


public class LabTrendPoint
{
    public int PatientID { get; set; }
    public int ItemID { get; set; }
    public string ItemName { get; set; } = "";
    public string ResultDate { get; set; } = "";
    public string ResultValue { get; set; } = "";
    public double ResultNumber { get; set; }
    public string Unit { get; set; } = "";
    public double? NormalLow { get; set; }
    public double? NormalHigh { get; set; }
    public double? CriticalLow { get; set; }
    public double? CriticalHigh { get; set; }
    public string TextRange { get; set; } = "";
    public string RefRange { get; set; } = "";
}
