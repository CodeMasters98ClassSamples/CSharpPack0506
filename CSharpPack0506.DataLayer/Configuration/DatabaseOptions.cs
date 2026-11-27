namespace CSharpPack0506.DataLayer.Configuration;

/// <summary>
/// تنظیمات اتصال به بانک اطلاعاتی.
/// Connection String نباید در کد (Hard Code) نوشته شود؛ از فایل تنظیمات خوانده می شود.
/// </summary>
public sealed class DatabaseOptions
{
    public const string SectionName = "Database";

    public string ConnectionString { get; set; } = string.Empty;
}
