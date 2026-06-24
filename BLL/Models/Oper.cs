namespace BLL.Models;

public class Oper
{
    public int OperID { get; set; } = 0;
    public int OperPersID { get; set; } = 0;

    public string OperName { get; set; } = "";
    public string OperPersName { get; set; } = "";

    public bool OperIsDisable { get; set; } = false;
    public string UserIP { get; set; }
    public string UserDeviceName { get; set; }
}