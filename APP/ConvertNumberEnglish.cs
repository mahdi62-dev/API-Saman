namespace APP;

public class ConvertNumberEnglish
{
    public string toEnglishNumber(string input)
    {
        var EnglishNumbers = "";
        for (var i = 0; i < input.Length; i++)
            if (char.IsDigit(input[i]))
                EnglishNumbers += char.GetNumericValue(input, i);
            else
                EnglishNumbers += input[i].ToString();

        return EnglishNumbers;
    }
}