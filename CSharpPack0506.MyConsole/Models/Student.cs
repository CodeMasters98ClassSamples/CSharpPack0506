using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPack0506.MyConsole.Models
{
    //Class => Proprties , methods
    internal class Student : User
    {

        //constructor
        public Student(string name, string lastName , string mobile, string nationalCode) : base(name, lastName, mobile, nationalCode)
        {
           
        }

        //this vs base
        public Student(string name, string lastName, string mobile, string nationalCode,DateTime birthDate) : this(name,lastName,mobile,nationalCode)
        {
            if (birthDate == DateTime.MinValue)
                throw new Exception("لطفا تاریخ تولد را به صورت کامل و صحیح وارد نمایید.");

            BirthDate = birthDate;
        }

        public string GetInfo()
        {
            return $"دانشجویی با نام: {Name} و نام خانوادگی: {LastName} ثبت شده است.";
        }


        //property
       
        public string Relation { get; set; }

        public void Register()
        {

        }
    }
}
