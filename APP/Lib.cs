namespace API.APP;

public class Lib
{
    public Tuple<double, string, int, int, int, string, string> CalcBMI(int Height, int Weight, int Age, int Gender)
    {
        double BMI = 0, he = 0;
        var BMIText = "";
        int normal1 = 0, normal2 = 0, wDiff = 0;

        he = Height / 100.0;
        he = he * he;

        BMI = Weight / he;


        normal1 = (int)(22 * he);
        normal2 = (int)(25 * he);
        wDiff = Weight - normal2;

        BMIText = BMI switch
        {
            // Conditions to find out BMI category 
            < 18.5 => "کمبود وزن",
            >= 18.5 and < 24.9 => "نرمال",
            >= 24.9 and < 30 => "اضافه وزن",
            >= 30 and < 35 => "چاقی کلاس 1",
            >= 35 and < 40 => "چاقی کلاس 2",
            >= 40 => "چاقی کلاس 3",
            _ => BMIText
        };

        var txt1 = "Healthy Weight: " + normal1 + " - " + normal2 + " kg";
        var txt2 = wDiff + " kg for BMI 25";

        return Tuple.Create(BMI, BMIText, normal1, normal2, wDiff, txt1, txt2);
    }

    public string CssBMI(double BMI)
    {
        var _BMICss = "";

        switch (BMI)
        {
            case < 18.5:
                _BMICss = " text-secondary";
                break;
            case >= 18.5 and < 24.9:
                _BMICss = " text-success";
                break;
            case >= 24.9 and < 30:
                _BMICss = " text-warning";
                break;
            case >= 30 and < 35:
            case >= 35 and < 40:
            case >= 40:
                _BMICss = " text-danger";
                break;
            default:
                _BMICss = " text-black";
                break;
        }

        return _BMICss;
    }
}

public class LibQuery
{
    public string ParamReplaceDictionary(string TSQL, Dictionary<string, string> repParam)
    {
        foreach (var param in repParam) TSQL = TSQL.Replace(param.Key, param.Value);


        return TSQL;
    }
}