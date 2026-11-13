using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPack0506.BusinessLayer.Dtos;

public sealed class RegisterStudentByAdminDto
{
    public string name { get; set; }
    public string lastName { get; set; }
    public string mobile { get; set; }
    public string nationalCode { get; set; }
    public DateTime birthDate { get; set; }
}
