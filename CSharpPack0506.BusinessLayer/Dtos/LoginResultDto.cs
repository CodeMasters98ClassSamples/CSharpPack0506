namespace CSharpPack0506.BusinessLayer.Dtos;

/// <summary>
/// خروجی عملیات ورود.
/// لایه نمایش بر اساس Success پیام مناسب را نمایش می دهد و متن پیام داخل UI نوشته نمی شود.
/// </summary>
public sealed class LoginResultDto
{
    public bool Success { get; init; }

    public string Message { get; init; } = string.Empty;

    public static LoginResultDto Succeeded(string username) => new()
    {
        Success = true,
        Message = $"خوش آمدید {username}."
    };

    public static LoginResultDto Failed() => new()
    {
        Success = false,
        Message = "نام کاربری یا رمزعبور اشتباه میباشد."
    };

    public static LoginResultDto Unavailable() => new()
    {
        Success = false,
        Message = "سیستم با مشکل مواجه شد."
    };
}
