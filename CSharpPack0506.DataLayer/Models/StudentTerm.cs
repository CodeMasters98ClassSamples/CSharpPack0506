using CSharpPack0506.DataLayer.Enums;

namespace CSharpPack0506.DataLayer.Models;

public class StudentTerm
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int TermId { get; set; }
    public Term Term { get; set; }

    public RegistrationStatus RegistrationStatus { get; set; }
    public DateTime RegisteredAt { get; set; }
    public decimal PaidAmount { get; set; }
}
