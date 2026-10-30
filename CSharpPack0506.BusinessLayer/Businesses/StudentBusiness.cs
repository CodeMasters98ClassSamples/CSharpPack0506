using CSharpPack0506.BusinessLayer.Dtos;
using CSharpPack0506.DataLayer.Models;


namespace CSharpPack0506.BusinessLayer.Businesses;

public partial class StudentBusiness
{
    //obj , file , database

    // List<Student> students { get; set; }

    private static List<Student> students = new List<Student>();

    //Register
    public bool Register(RegisterDto dto)
    {
        bool isSuccessfullRegister = false;

        Student st = new Student(dto.name, dto.lastName, dto.mobile, dto.nationalCode);
        students.Add(st);
        isSuccessfullRegister = true;
        if (isSuccessfullRegister)
        {
            NotifyManager();
        }

        return isSuccessfullRegister;
    }


    public List<Student> GetStudents()
    {
        return students;
    }

}
