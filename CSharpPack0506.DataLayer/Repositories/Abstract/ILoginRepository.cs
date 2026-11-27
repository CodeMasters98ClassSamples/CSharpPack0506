namespace CSharpPack0506.DataLayer.Repositories.Abstract;

/// <summary>
/// قرارداد خواندن اطلاعات ورود (نام کاربری و رمزعبور) از دیتاسورس.
/// خروجی یک Dictionary از "نام کاربری" به "رمزعبور" است.
/// </summary>
public interface ILoginRepository
{
    Dictionary<string, string> GetLogins();
}
