using DAL;
using Microsoft.Data.SqlClient;

namespace BLL.SMS;

public class SMS
{
    public void SmsSave(int crud, int smssetid, string valstr1, string mobile)
    {
        var com = new SqlCommand();
        com.Parameters.AddWithValue("@CRUD", crud);
        com.Parameters.AddWithValue("@SmsSetID", smssetid);
        com.Parameters.AddWithValue("@ValStr1", valstr1);
        com.Parameters.AddWithValue("@Mobile", mobile);

        var dalData = new DataService();
        dalData.ExecuteNonQueryBySp(CSet.cnStringERP, com, "spSms");
    }
}