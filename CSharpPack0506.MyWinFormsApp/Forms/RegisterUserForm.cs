using CSharpPack0506.BusinessLayer.Extenstions;
using CSharpPack0506.BusinessLayer.Validations;
using CSharpPack0506.DataLayer.Models;
using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace CSharpPack0506.MyWinFormsApp.Forms
{
    public partial class RegisterUserForm : Form
    {
        List<Student> students = new List<Student>();

        public RegisterUserForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void createUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                //static class -> refactor -> json & json -> class
                string name = firstNameTextBox.Text;
                string lastName = lastNameTextBox.Text;
                string mobile = mobileTextBox.Text.Trim().ToMobileFormat();
                string nationalCode = nationalCodeTextBox.Text;

                //MobileValidation mobileValidation = new MobileValidation();
                if (!MobileValidation.Validate(mobile))
                {
                    MessageBox.Show("لطفا شماره همراه خود را به صورت صحیح و عددی و با 11 کاراکتر وارد نمایید.");
                    return;
                }

                Student st = new Student(name, lastName, mobile, nationalCode);
                students.Add(st);

                userDataGridView.DataSource = students;

                firstNameTextBox.Text = default;
                lastNameTextBox.Text = default;
                mobileTextBox.Text = default;
                nationalCodeTextBox.Text = default;
            }
            catch (Exception ex)
            {

                MessageBox.Show("خطایی رخ داده است.");
            }
        }

        private void showByMockButton_Click(object sender, EventArgs e)
        {
            //hard code
            //students.Add(new Student("پرهام", "درویشی", "09129564205", "11111"));
            //students.Add(new Student("نرگس", "انوشه", "09129564206", "11112"));
            //students.Add(new Student("عسل", "رهبری", "09129564203", "11113"));

            //int -> string
            //string -> int
            // int -> short
            // long -> int

            //json -> obj c#
            //JsonConverter.

            //1- create folder mock data
            // 2- create json file student
            //3- install newtonsoft nuget
            //4- Read from File
            // 5- deserilize

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "MockData", "students.json");
            string json = null;
            // To read the entire file at once

            if (File.Exists(filePath))
            {
                // Read all the content in one string
                // and display the string
                json = File.ReadAllText(filePath);
            }
            else
            {
                MessageBox.Show("فایل داده ماک یافت نشد.");
                return;
            }

            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);

            // Bad Boys
            userDataGridView.DataSource = students;
        }
    }
}
