using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.Web;

public class WebEnc
{
    private readonly ConvertDtToList _appConvertDtToList = new();
    private ConvertDRowToModel _appConvertDRowToModel = new();

    public List<Models.Web.WebEnc> WebEncCRUD(Models.Web.WebEnc webenc)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", webenc.CRUD);
        com.Parameters.AddWithValue("@FuncType", webenc.FuncType);
        com.Parameters.AddWithValue("@WEncID", webenc.WEncID);
        com.Parameters.AddWithValue("@NationalCode", webenc.NationalCode);

        com.Parameters.AddWithValue("@CenterID", webenc.CenterID);
        com.Parameters.AddWithValue("@MasterID", webenc.MasterID);
        com.Parameters.AddWithValue("@WProfileID", webenc.WProfileID);
        com.Parameters.AddWithValue("@WEncServiceID", webenc.WEncServiceID);

        com.Parameters.AddWithValue("@StartDate", webenc.StartDate);
        com.Parameters.AddWithValue("@StartDateRange1", webenc.StartDateRange1);
        com.Parameters.AddWithValue("@StartDateRange2", webenc.StartDateRange2);

        com.Parameters.AddWithValue("@Explain", webenc.Explain);
        com.Parameters.AddWithValue("@EncStatus", webenc.EncStatus);
        com.Parameters.AddWithValue("@PayAmount", webenc.PayAmount);
        com.Parameters.AddWithValue("@TransactionID", webenc.TransactionID);

        com.Parameters.AddWithValue("@Recommender", webenc.Recommender);
        com.Parameters.AddWithValue("@Insurance", webenc.Insurance);
        com.Parameters.AddWithValue("@DrugDescription", webenc.DrugDescription);
        com.Parameters.AddWithValue("@HistoryDrug", webenc.HistoryDrug);
        com.Parameters.AddWithValue("@FamilyHistoryDisease", webenc.FamilyHistoryDisease);
        com.Parameters.AddWithValue("@NewTreatment", webenc.NewTreatment);
        com.Parameters.AddWithValue("@ContinueTreatment", webenc.ContinueTreatment);
        com.Parameters.AddWithValue("@EncUnderlyingDisease", webenc.EncUnderlyingDisease);
        com.Parameters.AddWithValue("@HistorySurgery", webenc.HistorySurgery);
        com.Parameters.AddWithValue("@ChiefComplaint", webenc.ChiefComplaint);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringPortal, com, "spWebEnc");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDtToList.ConvertDataTable<Models.Web.WebEnc>(dt);
    }
}