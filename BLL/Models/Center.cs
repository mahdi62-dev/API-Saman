using System.ComponentModel.DataAnnotations;

namespace BLL.Models;

public class Center
{
    public int CenterID { get; set; } = 0;
    public int MasterID { get; set; } = 0;
    public string Name { get; set; } = "";
    public string Explain { get; set; } = "";
    public string IPServer { get; set; } = "";
    public string SQLInstance { get; set; } = "";
    public string Tel { get; set; } = "";
    public string WebAddress { get; set; } = "";
    public string InstagramAddress { get; set; } = "";
    [MaxLength] public byte[] Logo { get; set; }
}