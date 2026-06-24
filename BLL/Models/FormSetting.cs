namespace BLL.Models;

public class FormSetting
{
    public int CRUD { get; set; }
    public int FuncType { get; set; }

    public int ID { get; set; }
    public int FormID { get; set; }
    public int ModID { get; set; }
    public int DepID { get; set; }
    public int UserPersID { get; set; }
    public bool IsUI { get; set; }
    public int FormSubID { get; set; }
    public int FormUiID { get; set; }
    public bool IsRequired { get; set; }
    public string UiCaption { get; set; }
    public int RecNo { get; set; }
    public bool Visible { get; set; }
    public bool Enabled { get; set; }
    public bool ReadOnly { get; set; }
    public bool TabStop { get; set; }
    public bool IsDisable { get; set; }
    public int Val1 { get; set; }
    public string ValStr1 { get; set; }
    public string DefaultValue { get; set; }
    public string Explain { get; set; }
    public int CenterID { get; set; }
}

public class Form
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string DName { get; set; }
}