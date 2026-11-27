using System.Reflection;
using CSharpPack0506.DataLayer.Models;
using CSharpPack0506.DataLayer.Repositories.Abstract;
using Newtonsoft.Json;

namespace CSharpPack0506.DataLayer.Repositories.Concrete;

/// <summary>
/// پیاده سازی Mock از IStudentRepository.
/// داده ها از فایل students.json خوانده می شوند و در حافظه نگهداری می گردند؛
/// بنابراین در زمان توسعه (بدون نیاز به SQL Server) می توان همان Business Layer را اجرا/تست کرد.
/// Interface Segregation / Liskov: این کلاس جایگزین کامل StudentRepository است.
/// </summary>
public sealed class StudentMockRepository : IStudentRepository
{
    private const string ResourceName = "CSharpPack0506.DataLayer.Data.MockData.students.json";

    private readonly List<Student> _students;
    private int _lastId;

    public StudentMockRepository()
    {
        _students = ReadMockData();

        // اختصاص شناسه برای رکوردهای فایل (Json شامل Id نیست)
        int id = 0;
        foreach (Student student in _students)
        {
            student.Id = ++id;
        }

        _lastId = id;
    }

    public bool Insert(Student student)
    {
        student.Id = ++_lastId;
        _students.Add(student);
        return true;
    }

    public bool Update(Student student)
    {
        Student? current = _students.FirstOrDefault(x => x.Id == student.Id);
        if (current is null)
            return false;

        current.Name = student.Name;
        current.LastName = student.LastName;
        return true;
    }

    public bool HardDelete(int id)
    {
        return _students.RemoveAll(x => x.Id == id) > 0;
    }

    public bool SoftDelete(int id)
    {
        Student? current = _students.FirstOrDefault(x => x.Id == id);
        if (current is null)
            return false;

        current.IsDeleted = true;
        current.DeletedAt = DateTime.Now;
        return true;
    }

    public Student? GetById(int id)
    {
        return _students.FirstOrDefault(x => x.Id == id);
    }

    public List<Student> GetAll()
    {
        return _students.Where(x => !x.IsDeleted).ToList();
    }

    private static List<Student> ReadMockData()
    {
        Assembly assembly = typeof(StudentMockRepository).Assembly;
        using Stream? stream = assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidOperationException("فایل داده ماک یافت نشد.");

        using StreamReader reader = new StreamReader(stream);
        string json = reader.ReadToEnd();

        return JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();
    }
}
