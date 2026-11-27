using CSharpPack0506.BusinessLayer.Dtos;
using CSharpPack0506.DataLayer.Models;

namespace CSharpPack0506.BusinessLayer.Businesses.Abstract;

/// <summary>
/// قرارداد منطق کسب و کار دانشجو.
/// لایه نمایش (WinForms / Console / Web) فقط با این Interface کار می کند،
/// نه با کلاس Concrete؛ بنابراین تست و تعویض پیاده سازی ساده است.
/// </summary>
public interface IStudentBusiness
{
    bool Register(RegisterDto dto);

    bool RegisterByAdmin(RegisterStudentByAdminDto dto);

    bool Update(UpdateStudentDto dto);

    bool HardDelete(int id);

    bool SoftDelete(int id);

    Student? GetById(int id);

    List<Student> GetStudents();

    List<Student> LoadStudentMockData();
}
