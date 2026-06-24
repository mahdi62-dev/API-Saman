using System.Globalization;

namespace API.APP;

public class SDate
{
    public DateTimeOffset S2MOffsetDate(string sDate)
    {
        return new DateTimeOffset(S2M(sDate), DateTimeOffset.Now.Offset);
    }

    public string MOffsetDate2S(DateTimeOffset? mDateOffset)
    {
        var mDate = mDateOffset.Value.DateTime;
        return M2S(mDate);
    }

    public string ShamsiDate()
    {
        return M2S(DateTime.Now);
    }

    public string ShamsiDateFullTextFromSDate(string sdate)
    {
        var shamsiDate = new string[8];
        string shamsiDateText = null, weekDay, day, month, year;

        var now = S2M(sdate);

        var PC = new PersianCalendar();
        weekDay = PC.GetDayOfWeek(now).ToString().ToUpper();

        switch (weekDay)
        {
            case "SATURDAY":
                weekDay = "شنبه";
                break;
            case "SUNDAY":
                weekDay = "یکشنبه";
                break;
            case "MONDAY":
                weekDay = "دوشنبه";
                break;
            case "TUESDAY":
                weekDay = "سه شنبه";
                break;
            case "WEDNESDAY":
                weekDay = "چهارشنبه";
                break;
            case "THURSDAY":
                weekDay = "پنجشنبه";
                break;
            case "FRIDAY":
                weekDay = "جمعه";
                break;
        }

        day = PC.GetDayOfMonth(now).ToString();
        month = PC.GetMonth(now).ToString();
        year = PC.GetYear(now).ToString();

        switch (month)
        {
            case "1":
                month = "فروردین";
                break;
            case "2":
                month = "اردیبهشت";
                break;
            case "3":
                month = "خرداد";
                break;
            case "4":
                month = "تیر";
                break;
            case "5":
                month = "مرداد";
                break;
            case "6":
                month = "شهریور";
                break;
            case "7":
                month = "مهر";
                break;
            case "8":
                month = "آبان";
                break;
            case "9":
                month = "آذر";
                break;
            case "10":
                month = "دی";
                break;
            case "11":
                month = "بهمن";
                break;
            case "12":
                month = "اسفند";
                break;
        }

        shamsiDateText = weekDay + " " + day + " " + month + " " + year;
        return shamsiDateText;
    }

    public string AddDate(int days)
    {
        var now = DateTime.Now;
        now = now.AddDays(days);
        return M2S(now);
    }

    public string AddDateDay(string date, int days)
    {
        var mDate = S2M(date);
        mDate = mDate.AddDays(days);
        return M2S(mDate);
    }

    public int GetPersianDaysDiffDate(string Date1, string Date2)
    {
        int year1 = Convert.ToInt16(Date1.Substring(0, 4));
        int month1 = Convert.ToInt16(Date1.Substring(5, 2));
        int day1 = Convert.ToInt16(Date1.Substring(8, 2));

        int year2 = Convert.ToInt16(Date2.Substring(0, 4));
        int month2 = Convert.ToInt16(Date2.Substring(5, 2));
        int day2 = Convert.ToInt16(Date2.Substring(8, 2));

        var calendar = new PersianCalendar();
        var dt1 = calendar.ToDateTime(year1, month1, day1, 0, 0, 0, 0);
        var dt2 = calendar.ToDateTime(year2, month2, day2, 0, 0, 0, 0);
        var ts = dt2.Subtract(dt1);

        return ts.Days;
    }

    private string M2S(DateTime mDate)
    {
        var pc = new PersianCalendar();
        var pdate = pc.GetYear(mDate).ToString("0000") + "/" + pc.GetMonth(mDate).ToString("00") + "/" +
                    pc.GetDayOfMonth(mDate).ToString("00");

        return pdate;
    }

    private DateTime S2M(string inputDate)
    {
        DateTime result;
        try
        {
            var persianCalendar = new PersianCalendar();
            var year = Convert.ToInt32(inputDate.Substring(0, 4));
            var month = Convert.ToInt32(inputDate.Substring(5, 2));
            var day = Convert.ToInt32(inputDate.Substring(8, 2));

            result = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
        }
        catch (Exception)
        {
            throw new FormatException();
        }

        return result;
    }
}