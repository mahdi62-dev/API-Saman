namespace API.APP.HTML;

public class HTML
{
    public string ClassVisible(string CssClass, bool visible)
    {
        if (!string.IsNullOrEmpty(CssClass))
            CssClass = CssClass.Replace("d-none", "");

        if (!visible)
            CssClass += " d-none";

        return CssClass;
    }

    public string ClassChange(string CssClass, string Class, bool HasExist)
    {
        if (!string.IsNullOrEmpty(CssClass))
            CssClass = CssClass.Replace(Class, "");

        if (HasExist)
            CssClass += " " + Class;

        return CssClass;
    }
}