using System.Data;
using API.BLL.SMS;

namespace API.APP;

public class Sms
{
    public SMSPortal _bllSMS = new();
    public string _curDateTime;
    public DataTable _dtSMS;
    public string _Mobile;

    public int _SmsID, _TemplateID;
    public string _SmsParam;
    public int _SmsSetID;

    public void SendSms(string smssetid, string va1)
    {
        //_curDateTime = APP.SDate.ShamsiDate();

        _dtSMS = _bllSMS.SmsLoad(smssetid, va1);

        if (_dtSMS.Rows.Count == 0)
            return;

        for (var i = 0; i < _dtSMS.Rows.Count; i++)
        {
            _SmsID = Convert.ToInt32(_dtSMS.Rows[i]["SMSID"]);
            _SmsSetID = Convert.ToInt32(_dtSMS.Rows[i]["SmsSetID"]);
            _TemplateID = Convert.ToInt32(_dtSMS.Rows[i]["TemplateID"]);
            _SmsParam = _dtSMS.Rows[i]["SmsParam"].ToString();
            _Mobile = _dtSMS.Rows[i]["Mobile"].ToString();


            _bllSMS.SendSmsWithParamAsync(_SmsSetID, _SmsID, _TemplateID, _Mobile, _SmsParam);
        }
    }
}