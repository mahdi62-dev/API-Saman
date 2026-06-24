using System.ComponentModel.DataAnnotations;

namespace BLL.Models;

public class Diary
{
    public int DFuncType { get; set; } = 0;
    public int CenterID { get; set; } = 0;
    public int CRUD { get; set; } = 0;
    public int FuncType { get; set; } = 0;
    [Key] public Guid ID { get; set; } // uniqueidentifier, not null
    public string Date { get; set; } = "";
    public int DType { get; set; } = 0;
    public int Val1 { get; set; } = 0;
    public string ValStr1 { get; set; } = "";
    public string Explain { get; set; } = "";
    public int ActionType { get; set; } = 0;
}