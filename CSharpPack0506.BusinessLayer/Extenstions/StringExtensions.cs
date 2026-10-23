namespace CSharpPack0506.BusinessLayer.Extenstions;

public static class StringExtensions
{
    public static string ToMobileFormat(this string str)
    {
        str = str.Trim();
        if (str.StartsWith("+98"))
        {
            str = str.Replace("+98", "0");
        }
        if (str.Length == 10 && str.StartsWith("9"))
        {
            str = "0" + str;
        }

        return str;
    }
}
