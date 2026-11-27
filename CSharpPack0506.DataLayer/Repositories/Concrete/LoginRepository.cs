using System.Reflection;
using System.Text;
using CSharpPack0506.DataLayer.Repositories.Abstract;

namespace CSharpPack0506.DataLayer.Repositories.Concrete;

/// <summary>
/// پیاده سازی خواندن اطلاعات ورود از فایل.
/// فایل logins.txt به عنوان Embedded Resource داخل اسمبلی Data Layer قرار دارد،
/// بنابراین لایه UI به مسیر فایل (Path) واکشی داده دسترسی ندارد.
/// </summary>
public sealed class LoginRepository : ILoginRepository
{
    private const string ResourceName = "CSharpPack0506.DataLayer.Data.MockData.logins.txt";
    private static readonly char[] RowSeparator = { ';' };

    public Dictionary<string, string> GetLogins()
    {
        Dictionary<string, string> logins = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        foreach (string row in ReadResourceLines())
        {
            if (string.IsNullOrWhiteSpace(row))
                continue;

            //admin;123456 -> [ "admin" , "123456" ]
            string[] login = row.Split(RowSeparator, StringSplitOptions.TrimEntries);
            if (login.Length < 2)
                continue;

            logins[login[0]] = login[1];
        }

        return logins;
    }

    private static string[] ReadResourceLines()
    {
        Assembly assembly = typeof(LoginRepository).Assembly;
        using Stream? stream = assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidOperationException("منبع اطلاعات ورود یافت نشد.");

        using StreamReader reader = new StreamReader(stream, Encoding.UTF8);
        return reader.ReadToEnd().Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
    }
}
