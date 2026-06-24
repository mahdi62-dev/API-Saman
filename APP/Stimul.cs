using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Dictionary;

namespace APP;

public class Stimul
{
    public StiReport PrintReport(string cnString, StiReport report, string ColumnName, string FilterString)
    {
        var sti = new StiSqlDatabase("SamanServer", cnString);
        report.Dictionary.Databases[0] = sti;

        var band = report.GetComponentByName("DataMain") as StiDataBand;

        var filter = new StiFilter
        {
            Column = ColumnName,
            Condition = StiFilterCondition.EqualTo,
            DataType = StiFilterDataType.String,
            Item = StiFilterItem.Value,
            Value1 = FilterString
        };


        band.Filters.Add(filter);

        report.ScriptUpdate();
        report.Compile();
        //report.Render();

        return report;
        //report.Render();

        //report.Show();

        //report.Print(false);
    }
}