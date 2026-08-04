namespace BLL.Models;

public class InpWard
{
    public int CRUD { get; set; } = 1;
    public int WardID { get; set; }
    public int DepID { get; set; }
    public string WardCode { get; set; } = "";
    public string WardName { get; set; } = "";
    public int WardType { get; set; }
    public int GenderLimit { get; set; }
    public bool IsICU { get; set; }
    public bool IsSurgery { get; set; }
    public bool IsActive { get; set; } = true;
    public int SortID { get; set; }
    public string Explain { get; set; } = "";
    public int CenterID { get; set; } = 1;
    public int UserPersID { get; set; }
    public string ActionDate { get; set; } = "";
}

public class InpRoom
{
    public int CRUD { get; set; } = 1;
    public int RoomID { get; set; }
    public int WardID { get; set; }
    public string WardName { get; set; } = "";
    public string RoomNo { get; set; } = "";
    public string RoomName { get; set; } = "";
    public string RoomDisplayName => string.IsNullOrWhiteSpace(RoomName) ? RoomNo : $"{RoomNo} - {RoomName}";
    public int RoomClass { get; set; }
    public int FloorNo { get; set; }
    public int Capacity { get; set; } = 1;
    public int GenderLimit { get; set; }
    public bool IsIsolation { get; set; }
    public bool IsActive { get; set; } = true;
    public int SortID { get; set; }
    public string Explain { get; set; } = "";
    public int CenterID { get; set; } = 1;
    public int UserPersID { get; set; }
    public string ActionDate { get; set; } = "";
}

public class InpBedClass
{
    public int CRUD { get; set; } = 1;
    public int BedClassID { get; set; }
    public string BedClassCode { get; set; } = "";
    public string BedClassName { get; set; } = "";
    public int BedClassType { get; set; }
    public string BedClassTypeName { get; set; } = "";
    public int ServiceID { get; set; }
    public int ServiceCategory { get; set; }
    public string ServiceCategoryName { get; set; } = "";
    public int ServiceCode { get; set; }
    public string ServiceName { get; set; } = "";
    public long DepositAmount { get; set; }
    public bool DepositIsRequired { get; set; }
    public bool IsActive { get; set; } = true;
    public int SortID { get; set; }
    public string Explain { get; set; } = "";
    public int CenterID { get; set; } = 1;
    public int UserPersID { get; set; }
    public string ActionDate { get; set; } = "";
}

public class InpBed
{
    public int CRUD { get; set; } = 1;
    public int BedID { get; set; }
    public int WardID { get; set; }
    public string WardName { get; set; } = "";
    public int RoomID { get; set; }
    public string RoomName { get; set; } = "";
    public int BedClassID { get; set; }
    public string BedClassName { get; set; } = "";
    public string BedNo { get; set; } = "";
    public string BedName { get; set; } = "";
    public string BedDisplayName => string.IsNullOrWhiteSpace(BedName) ? BedNo : $"{BedNo} - {BedName}";
    public int ServiceID { get; set; }
    public int ServiceCategory { get; set; }
    public string ServiceCategoryName { get; set; } = "";
    public int ServiceCode { get; set; }
    public string ServiceName { get; set; } = "";
    public long DepositAmountOverride { get; set; }
    public bool UseDepositOverride { get; set; }
    public int BedStatus { get; set; } // ADR: InpatientBedStatus؛ 0 آزاد، 1 اشغال، 2 رزرو، 3 غیرفعال، 4 تعمیرات، 5 پاکسازی
    public bool IsActive { get; set; } = true;
    public int SortID { get; set; }
    public string Explain { get; set; } = "";
    public int CenterID { get; set; } = 1;
    public int UserPersID { get; set; }
    public string ActionDate { get; set; } = "";
}
