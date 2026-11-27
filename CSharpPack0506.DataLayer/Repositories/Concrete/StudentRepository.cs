using CSharpPack0506.DataLayer.Configuration;
using CSharpPack0506.DataLayer.Enums;
using CSharpPack0506.DataLayer.Models;
using CSharpPack0506.DataLayer.Repositories.Abstract;
using Microsoft.Data.SqlClient;

namespace CSharpPack0506.DataLayer.Repositories.Concrete;

/// <summary>
/// پیاده سازی دسترسی به داده دانشجو روی SQL Server (ADO.NET).
/// تمام Query ها اینجا قرار می گیرند و لایه Business دیگر هیچ SqlCommand ای نمی شناسد.
/// </summary>
public sealed class StudentRepository : IStudentRepository
{
    private readonly DatabaseOptions _options;

    public StudentRepository(DatabaseOptions options)
    {
        _options = options;
    }

    private SqlConnection CreateConnection() => new SqlConnection(_options.ConnectionString);

    public bool Insert(Student student)
    {
        const string query = @"INSERT INTO dbo.Student
                    ([Name], LastName, MobileNumber, NationalCode, BirthDate, LastDocument)
                    VALUES
                    (@Name, @LastName, @MobileNumber, @NationalCode, @BirthDate, @LastDocument)";

        using SqlConnection connection = CreateConnection();
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Name", student.Name);
        command.Parameters.AddWithValue("@LastName", student.LastName);
        command.Parameters.AddWithValue("@MobileNumber", student.MobileNumber ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@NationalCode", student.NationalCode ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@BirthDate", student.BirthDate == DateTime.MinValue ? DBNull.Value : student.BirthDate);
        command.Parameters.AddWithValue("@LastDocument", (int)student.LastDocument);

        connection.Open();
        int rowsAffected = command.ExecuteNonQuery();
        return rowsAffected > 0;
    }

    public bool Update(Student student)
    {
        const string query = "UPDATE dbo.Student SET [Name] = @Name , LastName = @LastName WHERE Id = @Id";

        using SqlConnection connection = CreateConnection();
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", student.Id);
        command.Parameters.AddWithValue("@Name", student.Name);
        command.Parameters.AddWithValue("@LastName", student.LastName);

        connection.Open();
        int rowsAffected = command.ExecuteNonQuery();
        return rowsAffected > 0;
    }

    public bool HardDelete(int id)
    {
        const string query = "DELETE dbo.Student WHERE Id = @Id";

        using SqlConnection connection = CreateConnection();
        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        int rowsAffected = command.ExecuteNonQuery();
        return rowsAffected > 0;
    }

    public bool SoftDelete(int id)
    {
        const string query = "UPDATE dbo.Student SET [IsDeleted] = 1 , DeletedAt = GETDATE() WHERE Id = @Id";

        using SqlConnection connection = CreateConnection();
        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        int rowsAffected = command.ExecuteNonQuery();
        return rowsAffected > 0;
    }

    public Student? GetById(int id)
    {
        const string query = "SELECT * FROM dbo.Student WHERE Id = @Id";

        using SqlConnection connection = CreateConnection();
        using SqlCommand command = new SqlCommand(query, connection);
        // پارامتر به جای چسباندن مستقیم مقدار در Query (جلوگیری از SQL Injection)
        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();

        return reader.Read() ? MapStudent(reader) : null;
    }

    public List<Student> GetAll()
    {
        const string query = "SELECT * FROM dbo.Student WHERE IsDeleted = 0";

        List<Student> students = new List<Student>();

        using SqlConnection connection = CreateConnection();
        using SqlCommand command = new SqlCommand(query, connection);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            students.Add(MapStudent(reader));
        }

        return students;
    }

    private static Student MapStudent(SqlDataReader reader)
    {
        return new Student
        {
            Id = (int)reader["Id"],
            Name = reader["Name"].ToString() ?? string.Empty,
            LastName = reader["LastName"].ToString() ?? string.Empty,
            MobileNumber = reader["MobileNumber"].ToString() ?? string.Empty,
            NationalCode = reader["NationalCode"].ToString() ?? string.Empty,
            BirthDate = reader["BirthDate"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["BirthDate"]),
            LastDocument = reader["LastDocument"] is DBNull ? LastDocumentTypes.NONE : (LastDocumentTypes)(int)reader["LastDocument"],
        };
    }
}
