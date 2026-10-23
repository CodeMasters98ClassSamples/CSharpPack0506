using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPack0506.DataLayer.Models;

public class Master : User
{
    public Master(string name, string lastName, string mobile, string nationalCode, string card): base(name, lastName, mobile, nationalCode)
    {
        Card = card;
    }

    public string Card { get; set; }
}
