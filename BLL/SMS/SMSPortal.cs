using System.Data;
using DAL;
using IPE.SmsIrClient;
using IPE.SmsIrClient.Models.Requests;
using Microsoft.Data.SqlClient;

namespace API.BLL.SMS;

public class SMSPortal
{
    public DataTable SmsLoad(string smssetid, string va1)
    {
        var tsql = @"

                    SELECT *
                    FROM SamanPortal.dbo.vSMS
                    WHERE 1=1
                    AND smssetid=@smssetid 
                    AND va1=@va1
                    AND IsSend=0 
                    --AND ActionDate <= @SCurDatetime
                    ORDER BY ActionDate

                        ";

        var com = new SqlCommand();
        com.Parameters.AddWithValue("@smssetid", smssetid);
        com.Parameters.AddWithValue("@va1", va1);

        var dalData = new DataService();
        return dalData.GetDataTableByText(CSet.cnStringPortal, com, tsql);
    }


    public async Task SendSmsWithParamAsync(int SmsSetID, int SmsID, int TemplateID, string Mobile, string SmsParam)
    {
        var dtSmsSetting = SmsParamLoad(SmsID);

        var paramCount = dtSmsSetting.Rows.Count;
        var dtSmsConfig = SmsConfigLoad();
        var smsIr = new SmsIr(dtSmsConfig.Rows[0]["Val1"].ToString());

        var ParameterArray = new VerifySendParameter[paramCount];

        for (var i = 0; i < paramCount; i++)
        {
            var name = dtSmsSetting.Rows[i]["ParamName"].ToString();
            var value = dtSmsSetting.Rows[i]["ParamVal"].ToString();

            var paramItem = new VerifySendParameter(name, value);

            ParameterArray[i] = paramItem;
        }

        var verificationSendResult = smsIr.VerifySendAsync(Mobile, TemplateID, ParameterArray);

        SmsSendSave(SmsID);
    }

    public DataTable SmsParamLoad(int SmsID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@SmsID", SmsID);

        var dalData = new DataService();
        return dalData.GetDataTableBySP(CSet.cnStringPortal, com, "spSmsParamLoad");
    }

    public DataTable SmsConfigLoad()
    {
        var TSQL = @"SELECT TOP(1) * FROM SmsConfig";
        var com = new SqlCommand();

        var dalData = new DataService();
        return dalData.GetDataTableByText(CSet.cnStringPortal, com, TSQL);
    }

    private void SmsSendSave(int SmsID)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@SmsID", SmsID);
        com.Parameters.AddWithValue("@IsSend", true);

        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringPortal, com, "spSms");
    }
}