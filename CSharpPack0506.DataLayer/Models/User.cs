using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPack0506.DataLayer.Models;

//template
public abstract class User
{
    public User(string name, string lastName, string mobile, string nationalCode)
    {
        //if (string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(nationalCode))
        //{
        //    throw new Exception("لطفا اطلاعات را به صورت کامل وارد نمایید");
        //}
        Name = name;
        LastName = lastName;
        MobileNumber = mobile;
        NationalCode = nationalCode;
    }

    //(access modifier)
    //public type    { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    public string NationalCode { get; set; }
    public DateTime BirthDate { get; set; }
}
