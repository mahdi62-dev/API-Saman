namespace DAL;

public class CSet
{
    public static int AppID;

    public static string cnStringDC;
    public static string cnStringHIS;
    public static string cnStringERP;
    public static string cnStringReport;
    public static string cnStringLog;
    public static string cnStringPortal;


    public static void SetCon(string serverName, string appID, string serverportalName)
    {
        AppID = Convert.ToInt32(appID);
        string drowssap = null;

        switch (appID)
        {
            case "1":
                drowssap = "Alfa@2020#";
                break;

            case "2":
                drowssap = "Zahra@2020#";
                break;

            case "3":
                drowssap = "Besharati@2020#";
                break;

            case "4":
                drowssap = "Petct@2020";
                break;
        }

        cnStringDC = "Data source=" + serverName +
                     "; Database=SamanDC; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
                     drowssap + "; Connect Timeout=180;Encrypt=False;";

        cnStringHIS = "Data source=" + serverName +
                      "; Database=SamanHIS; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
                      drowssap + "; Connect Timeout=180;Encrypt=False;";

        cnStringERP = "Data source=" + serverName +
                      "; Database=SamanERP; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
                      drowssap + "; Connect Timeout=180;Encrypt=False;";

        cnStringReport = "Data source=" + serverName +
                         "; Database=SamanReport; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
                         drowssap + "; Connect Timeout=180;Encrypt=False;";

        cnStringLog = "Data source=" + serverName +
                      "; Database=SamanLog; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
                      drowssap + "; Connect Timeout=180;Encrypt=False;";

        //cnStringPortal = "Data source=" + serverName +
        //                 "; Database=SamanPortal; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
        //                 drowssap + "; Connect Timeout=180;Encrypt=False;";

        cnStringPortal = "Data source=" + serverportalName +
                         "; Database=SamanPortal; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
                         drowssap + "; Connect Timeout=180;Encrypt=False;";
    }

    public static void SetConPortal(string serverName, string appID)
    {
        AppID = Convert.ToInt32(appID);
        string drowssap = null;

        switch (appID)
        {
            case "1":
                drowssap = "Alfa@2020#";
                break;

            case "2":
                drowssap = "Zahra@2020#";
                break;

            case "3":
                drowssap = "Besharati@2020#";
                break;

            case "4":
                drowssap = "Petct@2020";
                break;
        }

        cnStringDC = "Data source=" + serverName +
                     "; Database=SamanDC; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
                     drowssap + "; Connect Timeout=180;Encrypt=False;";

        cnStringHIS = "Data source=" + serverName +
                      "; Database=SamanHIS; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
                      drowssap + "; Connect Timeout=180;Encrypt=False;";

        cnStringERP = "Data source=" + serverName +
                      "; Database=SamanERP; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
                      drowssap + "; Connect Timeout=180;Encrypt=False;";

        cnStringReport = "Data source=" + serverName +
                         "; Database=SamanReport; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
                         drowssap + "; Connect Timeout=180;Encrypt=False;";

        cnStringLog = "Data source=" + serverName +
                      "; Database=SamanLog; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
                      drowssap + "; Connect Timeout=180;Encrypt=False;";
    }
}