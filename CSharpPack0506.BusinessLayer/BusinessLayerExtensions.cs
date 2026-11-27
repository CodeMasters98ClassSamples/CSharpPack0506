using CSharpPack0506.BusinessLayer.Businesses;
using CSharpPack0506.BusinessLayer.Businesses.Abstract;
using CSharpPack0506.DataLayer.Configuration;
using CSharpPack0506.DataLayer.Repositories.Abstract;
using CSharpPack0506.DataLayer.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpPack0506.BusinessLayer;

/// <summary>
/// نقطه واحد ثبت وابستگی ها (Composition Root کمکی).
/// به این ترتیب لایه نمایش درگیر new کردن کلاس های لایه های پایین نمی شود.
/// </summary>
public static class BusinessLayerExtensions
{
    /// <summary>
    /// ثبت سرویس ها با دیتابیس واقعی (SQL Server). Connection String از فایل تنظیمات خوانده می شود.
    /// </summary>
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services, DatabaseOptions databaseOptions)
    {
        ArgumentNullException.ThrowIfNull(databaseOptions);

        if (string.IsNullOrWhiteSpace(databaseOptions.ConnectionString))
            throw new ArgumentException("Connection String تنظیم نشده است.", nameof(databaseOptions));

        services.AddSingleton(databaseOptions);

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ILoginRepository, LoginRepository>();

        services.AddScoped<IStudentBusiness, StudentBusiness>();
        services.AddScoped<IAuthBusiness, AuthBusiness>();

        return services;
    }

    /// <summary>
    /// ثبت سرویس ها با داده ماک (بدون نیاز به بانک اطلاعاتی) - مناسب توسعه و تست.
    /// </summary>
    public static IServiceCollection AddBusinessLayerWithMockData(this IServiceCollection services)
    {
        services.AddSingleton<IStudentRepository, StudentMockRepository>();
        services.AddScoped<ILoginRepository, LoginRepository>();

        services.AddScoped<IStudentBusiness, StudentBusiness>();
        services.AddScoped<IAuthBusiness, AuthBusiness>();

        return services;
    }
}
