using System.Data;
using APP;
using DAL;
using Microsoft.Data.SqlClient;

namespace BLL;

public class SFHeartMD
{
    private readonly ConvertDRowToModel _appConvertDRowToModel = new();
    private ConvertDtToList _appConvertDtToList = new();

    public Models.SFHeartMD SFHeartMDCUD(Models.SFHeartMD SFHeartMD)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", SFHeartMD.CRUD);
        com.Parameters.AddWithValue("@FuncType", SFHeartMD.FuncType);
        com.Parameters.AddWithValue("@SFHeartMDID", SFHeartMD.SFHeartMDID);
        com.Parameters.AddWithValue("@EncID", SFHeartMD.EncID);
        com.Parameters.AddWithValue("@PatientID", SFHeartMD.PatientID);
        com.Parameters.AddWithValue("@Note", SFHeartMD.Note);
        com.Parameters.AddWithValue("@PMHNote", SFHeartMD.PMHNote);
        com.Parameters.AddWithValue("@ChiefComplaint", SFHeartMD.ChiefComplaint);
        com.Parameters.AddWithValue("@ChiefComplaintNote", SFHeartMD.ChiefComplaintNote);
        com.Parameters.AddWithValue("@HeartRate", SFHeartMD.HeartRate);
        com.Parameters.AddWithValue("@HeartRateNote", SFHeartMD.HeartRateNote);
        com.Parameters.AddWithValue("@LeftBPSystolic", SFHeartMD.LeftBPSystolic);
        com.Parameters.AddWithValue("@LeftBPDiastolic", SFHeartMD.LeftBPDiastolic);
        com.Parameters.AddWithValue("@LeftBPNote", SFHeartMD.LeftBPNote);
        com.Parameters.AddWithValue("@RightBPSystolic", SFHeartMD.RightBPSystolic);
        com.Parameters.AddWithValue("@RightBPDiastolic", SFHeartMD.RightBPDiastolic);
        com.Parameters.AddWithValue("@RightBPNote", SFHeartMD.RightBPNote);
        com.Parameters.AddWithValue("@V1", SFHeartMD.V1);
        com.Parameters.AddWithValue("@V2", SFHeartMD.V2);
        com.Parameters.AddWithValue("@V3", SFHeartMD.V3);
        com.Parameters.AddWithValue("@V4", SFHeartMD.V4);
        com.Parameters.AddWithValue("@V5", SFHeartMD.V5);
        com.Parameters.AddWithValue("@V6", SFHeartMD.V6);
        com.Parameters.AddWithValue("@V7", SFHeartMD.V7);
        com.Parameters.AddWithValue("@V8", SFHeartMD.V8);
        com.Parameters.AddWithValue("@V9", SFHeartMD.V9);
        com.Parameters.AddWithValue("@V10", SFHeartMD.V10);
        com.Parameters.AddWithValue("@V11", SFHeartMD.V11);
        com.Parameters.AddWithValue("@V12", SFHeartMD.V12);
        com.Parameters.AddWithValue("@V13", SFHeartMD.V13);
        com.Parameters.AddWithValue("@V14", SFHeartMD.V14);
        com.Parameters.AddWithValue("@V15", SFHeartMD.V15);
        com.Parameters.AddWithValue("@V16", SFHeartMD.V16);
        com.Parameters.AddWithValue("@V17", SFHeartMD.V17);
        com.Parameters.AddWithValue("@V18", SFHeartMD.V18);
        com.Parameters.AddWithValue("@V19", SFHeartMD.V19);
        com.Parameters.AddWithValue("@V20", SFHeartMD.V20);
        com.Parameters.AddWithValue("@V21", SFHeartMD.V21);
        com.Parameters.AddWithValue("@V22", SFHeartMD.V22);
        com.Parameters.AddWithValue("@V23", SFHeartMD.V23);
        com.Parameters.AddWithValue("@V24", SFHeartMD.V24);
        com.Parameters.AddWithValue("@V25", SFHeartMD.V25);
        com.Parameters.AddWithValue("@V26", SFHeartMD.V26);
        com.Parameters.AddWithValue("@V27", SFHeartMD.V27);
        com.Parameters.AddWithValue("@V28", SFHeartMD.V28);
        com.Parameters.AddWithValue("@V29", SFHeartMD.V29);

        com.Parameters.AddWithValue("@Height", SFHeartMD.Height);
        com.Parameters.AddWithValue("@Weight", SFHeartMD.Weight);
        com.Parameters.AddWithValue("@BMI", SFHeartMD.BMI);
        com.Parameters.AddWithValue("@BMIText", SFHeartMD.BMIText);
        com.Parameters.AddWithValue("@SpO2", SFHeartMD.SpO2);


        com.Parameters.AddWithValue("@UserPersID", SFHeartMD.UserPersID);


        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringHIS, com, "spSFMD");

        DataRow dRow = null;
        if (dt.Rows.Count > 0)
            dRow = dt.Rows[0];

        return _appConvertDRowToModel.CreateItemFromRow<Models.SFHeartMD>(dRow);
    }
}