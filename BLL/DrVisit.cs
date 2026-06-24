using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class DrVisit
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.DrVisit DrVisitCRUD(Models.DrVisit DrVisit)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", DrVisit.CRUD);
        com.Parameters.AddWithValue("@DrVisitID", DrVisit.DrVisitID);
        com.Parameters.AddWithValue("@EncID", DrVisit.EncID);
        com.Parameters.AddWithValue("@DepID", DrVisit.DepID);
        com.Parameters.AddWithValue("@VisitItem", DrVisit.VisitItem);
        com.Parameters.AddWithValue("@DiagnosisID", DrVisit.DiagnosisID);
        com.Parameters.AddWithValue("@Diagnosis", DrVisit.Diagnosis);
        com.Parameters.AddWithValue("@Note", DrVisit.Note);
        com.Parameters.AddWithValue("@Conclusion", DrVisit.Conclusion);
        com.Parameters.AddWithValue("@FollowupPeriod", DrVisit.FollowupPeriod);
        com.Parameters.AddWithValue("@F1", DrVisit.F1);

        com.Parameters.AddWithValue("@UserPersID", DrVisit.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spDrVisit");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.DrVisit>(dRow);
    }
}