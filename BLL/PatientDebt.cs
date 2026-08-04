using APP;
using BLL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class PatientDebtBLL
{
    private readonly ConvertDtToList _convert = new();

    public List<PatientDebt> LoadByPatient(int patientID)
    {
        if (patientID <= 0) return new List<PatientDebt>();

        const string tsql = @"
            SELECT *
            FROM dbo.fnPatientEncDebt(@PatientID)
            WHERE RemainAmount > 0
            ORDER BY EncID DESC";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@PatientID", patientID);

        var dt = new DataService().GetDataTableByText(CSet.cnStringHIS, com, tsql);
        return _convert.ConvertDataTable<PatientDebt>(dt);
    }

    public long TotalDebtByPatient(int patientID)
        => LoadByPatient(patientID).Sum(x => x.RemainAmount);
}
