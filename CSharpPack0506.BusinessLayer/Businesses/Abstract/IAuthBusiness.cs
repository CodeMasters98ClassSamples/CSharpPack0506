using CSharpPack0506.BusinessLayer.Dtos;

namespace CSharpPack0506.BusinessLayer.Businesses.Abstract;

/// <summary>
/// قرارداد منطق کسب و کار ورود به سیستم (احراز هویت).
/// </summary>
public interface IAuthBusiness
{
    /// <summary>
    /// نتیجه ورود: موفق / نام کاربری یا رمزعبور اشتباه / عدم دسترسی به اطلاعات.
    /// </summary>
    LoginResultDto Login(string username, string password);
}
