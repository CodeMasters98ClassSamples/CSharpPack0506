using CSharpPack0506.DataLayer.Models;

namespace CSharpPack0506.DataLayer.Repositories.Abstract;

/// <summary>
/// قرارداد دسترسی به داده دانشجو.
/// لایه Business فقط این Interface را می شناسد و از پیاده سازی (SQL Server / File / ...) بی خبر است.
/// </summary>
public interface IStudentRepository
{
    bool Insert(Student student);

    bool Update(Student student);

    bool HardDelete(int id);

    bool SoftDelete(int id);

    Student? GetById(int id);

    List<Student> GetAll();
}
