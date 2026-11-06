using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace CSharpPack0506.DataLayer.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }

    public int MasterId { get; set; }
    public Master Master { get; set; }
    
    public List<Term> Terms { get; set; }
}
