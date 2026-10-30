using CSharpPack0506.BusinessLayer.Dtos;
using CSharpPack0506.DataLayer.Models;
using Newtonsoft.Json;

namespace CSharpPack0506.BusinessLayer.Businesses;

public partial class StudentBusiness
{
    //Register

    public List<Student> LoadStudentMockData()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "MockData", "students.json");
        string json = null;
        // To read the entire file at once

        if (File.Exists(filePath))
        {
            // Read all the content in one string
            // and display the string
            json = File.ReadAllText(filePath);
        }
        else
        {
            throw new Exception(message: "فایل مورد نظر یافت نشد.");
        }

        List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);
        return students;
    }

    public bool RegisterByAdmin(RegisterStudentByAdminDto dto)
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

    private void NotifyManager()
    {
        //  
    }
}
