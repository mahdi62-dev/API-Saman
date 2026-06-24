namespace BLL.Models;

public class HeartFailureFollowupHistoryItem
{
    public int ID { get; set; } // int, not null
    public int DrPrescItemID { get; set; } // int, not null
    public int ItemID { get; set; } // int, not null
    public string ItemName { get; set; } // int, not null
    public bool IsConfirm { get; set; } // int, not null
    public string Date { get; set; } // int, not null
}