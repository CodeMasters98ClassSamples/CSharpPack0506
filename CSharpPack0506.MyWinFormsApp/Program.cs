using CSharpPack0506.BusinessLayer;
using CSharpPack0506.DataLayer.Configuration;
using CSharpPack0506.MyWinFormsApp.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace CSharpPack0506.MyWinFormsApp;

/// <summary>
/// Composition Root لایه نمایش.
/// تنها این نقطه از پروژه می داند کلاس های Concrete در کدام لایه هستند؛
/// فرم ها فقط Interface دریافت می کنند (Dependency Inversion).
/// </summary>
internal static class Program
{
    // نمونه واحد ServiceProvider برای کل برنامه
    internal static IServiceProvider Services { get; private set; } = default!;

    /// <summary>
    /// ساخت فرم به همراه تزریق وابستگی ها. برای فرم هایی که فقط Constructor پیش فرض دارند هم قابل استفاده است.
    /// </summary>
    internal static TForm ResolveForm<TForm>() where TForm : Form
    {
        return ActivatorUtilities.CreateInstance<TForm>(Services);
    }

    /// <summary>
    /// نمایش فرم به صورت Child داخل فرم والد.
    /// </summary>
    internal static void ShowChildForm<TForm>(Form parent) where TForm : Form
    {
        TForm form = ResolveForm<TForm>();
        form.MdiParent = parent;
        form.Show();
    }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        Services = ConfigureServices();

        Application.Run(ResolveForm<LoginForm>());
    }

    private static IServiceProvider ConfigureServices()
    {
        ServiceCollection services = new ServiceCollection();

        // ثبت منطق کسب و کار و دسترسی به داده در یک نقطه
        services.AddBusinessLayer(CreateDatabaseOptions());

        // فرم ها از DI ساخته می شوند (به جای new Form() داخل فرم ها)
        services.AddTransient<LoginForm>();
        services.AddTransient<LayoutForm>();
        services.AddTransient<RegisterUserForm>();
        services.AddTransient<UserListForm>();

        return services.BuildServiceProvider();
    }

    private static DatabaseOptions CreateDatabaseOptions()
    {
        string? connectionString = ConfigurationManager.ConnectionStrings["CSharpPack0506DB"]?.ConnectionString;

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ConfigurationErrorsException("Connection String با نام CSharpPack0506DB یافت نشد.");

        return new DatabaseOptions { ConnectionString = connectionString };
    }
}