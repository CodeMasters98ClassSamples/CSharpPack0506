using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPack0506.BusinessLayer.Dtos;

public sealed class UpdateStudentDto
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int UserId { get; set; }
}
