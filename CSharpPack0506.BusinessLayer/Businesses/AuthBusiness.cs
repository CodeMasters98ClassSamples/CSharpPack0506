using CSharpPack0506.BusinessLayer.Businesses.Abstract;
using CSharpPack0506.BusinessLayer.Dtos;
using CSharpPack0506.DataLayer.Repositories.Abstract;

namespace CSharpPack0506.BusinessLayer.Businesses;

/// <summary>
/// منطق ورود به سیستم.
/// قبلا این منطق (خواندن فایل + مقایسه) داخل LoginForm نوشته شده بود که نقض Separation of Concerns بود.
/// </summary>
public sealed class AuthBusiness : IAuthBusiness
{
    private readonly ILoginRepository _loginRepository;

    public AuthBusiness(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }

    public LoginResultDto Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return LoginResultDto.Failed();

        Dictionary<string, string> logins;
        try
        {
            logins = _loginRepository.GetLogins();
        }
        catch (Exception ex)
        {
            // Log -> File , Db , ...
            Console.WriteLine($"Error: {ex.Message}");
            return LoginResultDto.Unavailable();
        }

        if (logins.Count == 0)
            return LoginResultDto.Unavailable();

        string normalizedUsername = username.ToLower().Trim();

        // مقایسه رمزعبور بدون در نظر گرفتن حروف کوچک و بزرگ (Case Insensitive)
        bool isAuthenticated = logins.TryGetValue(normalizedUsername, out string? storedPassword)
            && string.Equals(storedPassword, password.Trim(), StringComparison.OrdinalIgnoreCase);

        return isAuthenticated
            ? LoginResultDto.Succeeded(normalizedUsername)
            : LoginResultDto.Failed();
    }
}
