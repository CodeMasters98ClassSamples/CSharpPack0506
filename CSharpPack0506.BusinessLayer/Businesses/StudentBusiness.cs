using CSharpPack0506.BusinessLayer.Dtos;
using CSharpPack0506.DataLayer.Enums;
using CSharpPack0506.DataLayer.Models;
using Microsoft.Data.SqlClient;
using System;


namespace CSharpPack0506.BusinessLayer.Businesses;

public partial class StudentBusiness
{
    string connectionString = "Data Source=.;Database=CSharpPack0506DB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0";
    //obj , file , database

    // List<Student> students { get; set; }

    private static List<Student> students = new List<Student>();

    //Register
    public bool Register(RegisterDto dto)
    {
        Student st = new Student(dto.name, dto.lastName, dto.mobile, dto.nationalCode);
        students.Add(st);
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();


                // Create a SQL command to insert a new person record
                string query = $"INSERT INTO dbo.Student([Name],LastName,MobileNumber,NationalCode,BirthDate,LastDocument) " +
                                "VALUES(@Name, @LastName ,@MobileNumber, @NationalCode, @BirthDate, @LastDocument)";
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

    public bool Update(UpdateStudentDto dto)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();


                // Create a SQL command to insert a new person record
                string query = $"UPDATE dbo.Student SET [Name] = @Name , LastName = @LastName WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters to the SQL command
                command.Parameters.AddWithValue("@Id", dto.UserId);
                command.Parameters.AddWithValue("@Name", dto.Name);
                command.Parameters.AddWithValue("@LastName", dto.LastName);

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

    public Student GetById(int id)
    {
        Student student = new Student();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Create a SQL command to select data from the table
                string query = $"SELECT * FROM dbo.Student WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, connection);
                // Create a data reader to fetch the data
                SqlDataReader reader = command.ExecuteReader();

                // Read data and map it to Person objects
                if (reader.Read())
                {
                    student.Id = int.Parse(reader["Id"].ToString());
                    student.Name = reader["Name"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.MobileNumber = reader["MobileNumber"].ToString();
                    student.NationalCode = reader["NationalCode"].ToString();
                    student.BirthDate = DateTime.Parse(reader["BirthDate"].ToString());
                    student.LastDocument = (LastDocumentTypes)reader["LastDocument"];
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();

            }
            return student;
        }
        return student;
    }

    public List<Student> GetStudents()
    {
        //Read From DB

        //Connection to Db
        List<Student> students = new List<Student>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Create a SQL command to select data from the table
                string query = $"select * from dbo.Student";
                SqlCommand command = new SqlCommand(query, connection);

                // Create a data reader to fetch the data
                SqlDataReader reader = command.ExecuteReader();

                // Read data and map it to Person objects
                while (reader.Read())
                {
                    Student st = new Student
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        MobileNumber = reader["MobileNumber"].ToString(),
                        NationalCode = reader["NationalCode"].ToString(),
                        BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                        LastDocument = (LastDocumentTypes)reader["LastDocument"],
                    };

                    students.Add(st);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();

            }
            return students;
        }
        return students;
    }

}
