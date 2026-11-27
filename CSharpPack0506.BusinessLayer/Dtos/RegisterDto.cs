using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPack0506.BusinessLayer.Dtos;

public sealed class RegisterDto
{
    public string name { get; set; } = string.Empty;
    public string lastName { get; set; } = string.Empty;
    public string mobile { get; set; } = string.Empty;
    public string nationalCode { get; set; } = string.Empty;
    public string LastDocument { get; set; } = string.Empty;
}
