using CSharpPack0506.BusinessLayer;
using CSharpPack0506.BusinessLayer.Businesses.Abstract;
using CSharpPack0506.BusinessLayer.Dtos;
using CSharpPack0506.DataLayer.Configuration;
using CSharpPack0506.DataLayer.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpPack0506.MyConsole
{
    /// <summary>
    /// لایه نمایش (Console).
    /// فقط Interface منطق کسب و کار را می شناسد؛ ساخت وابستگی ها در Composition Root انجام می شود.
    /// </summary>
    internal class Program
    {
        private const string ConnectionString = "Data Source=.;Database=CSharpPack0506DB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"CSharpPack0506.MyConsole\";Command Timeout=0";

        static void Main(string[] args)
        {
            // Composition Root: استفاده از داده ماک تا اجرای برنامه نیاز به بانک اطلاعاتی نداشته باشد.
            // برای اتصال به SQL Server، این خط را با خط زیر جایگزین کنید:
            // services.AddBusinessLayer(new DatabaseOptions { ConnectionString = ConnectionString });
            ServiceCollection services = new ServiceCollection();
            services.AddBusinessLayerWithMockData();

            using ServiceProvider provider = services.BuildServiceProvider();
            IStudentBusiness studentBusiness = provider.GetRequiredService<IStudentBusiness>();

            ShowStudents(studentBusiness);

            // نمونه ثبت نام (اعتبارسنجی داخل لایه Business انجام می شود)
            bool isRegistered = studentBusiness.RegisterByAdmin(new RegisterStudentByAdminDto
            {
                name = "پرهام",
                lastName = "درویشی",
                mobile = "+989129564205",
                nationalCode = "0020500000",
                birthDate = DateTime.Now.AddYears(-50),
            });

            Console.WriteLine(isRegistered
                ? "ثبت نام با موفقیت انجام شد."
                : "ثبت نام انجام نشد. لطفا اطلاعات را بررسی نمایید.");

            ShowStudents(studentBusiness);
        }

        private static void ShowStudents(IStudentBusiness studentBusiness)
        {
            List<Student> students = studentBusiness.GetStudents();

            Console.WriteLine($"تعداد دانشجویان: {students.Count}");
            foreach (Student student in students)
            {
                Console.WriteLine(student.GetInfo());
            }
        }
    }
}
