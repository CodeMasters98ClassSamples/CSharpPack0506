using CSharpPack0506.BusinessLayer.Dtos;
using CSharpPack0506.DataLayer.Models;
using Microsoft.Data.SqlClient;
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
        Student st = new Student(dto.name, dto.lastName, dto.mobile, dto.nationalCode,dto.birthDate);
        students.Add(st);
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();


                // Create a SQL command to insert a new person record
                string query = @"INSERT INTO dbo.Student
                    ([Name], LastName, MobileNumber, NationalCode, BirthDate, LastDocument)
                    VALUES
                    (@Name, @LastName, @MobileNumber, @NationalCode, @BirthDate, @LastDocument)";
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters to the SQL command
                command.Parameters.AddWithValue("@Name", st.Name);
                command.Parameters.AddWithValue("@LastName", st.LastName);
                command.Parameters.AddWithValue("@MobileNumber", st.MobileNumber);
                command.Parameters.AddWithValue("@NationalCode", st.NationalCode);
                command.Parameters.AddWithValue("@BirthDate", st.BirthDate);
                command.Parameters.AddWithValue("@LastDocument", st.LastDocument);

                // Execute the insert query
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    private void NotifyManager()
    {
        //  
    }
}
