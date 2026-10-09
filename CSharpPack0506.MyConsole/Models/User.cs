using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPack0506.MyConsole.Models
{
    internal class User
    {
        public User(string name, string lastName, string mobile, string nationalCode)
        {
            if (string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(nationalCode))
            {
                throw new Exception("لطفا اطلاعات را به صورت کامل وارد نمایید");
            }
            Name = name;
            LastName = lastName;
            MobileNumebr = mobile;
            NationalCode = nationalCode;
        }


        public string Name { get; set; }
        public string LastName { get; set; }
        public string MobileNumebr { get; set; }
        public string NationalCode { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
