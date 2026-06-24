using System.Data;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class CompareLabResults
{
    public DataTable CompareLabResultsCRUD(int FuncType, int PatientID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@FuncType", FuncType);
        com.Parameters.AddWithValue("@PatientID", PatientID);

        var dalData = new DataService();
        return dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spPatientResult");
    }
}