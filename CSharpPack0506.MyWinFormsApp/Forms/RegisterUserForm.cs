using CSharpPack0506.BusinessLayer.Businesses;
using CSharpPack0506.BusinessLayer.Dtos;
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
        StudentBusiness studentBusiness = new();
        public RegisterUserForm()
        {
            InitializeComponent();

            //Show Data

            StudentBusiness studentBusiness = new StudentBusiness();
            userDataGridView.DataSource = studentBusiness.GetStudents();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void createUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                //static class -> refactor -> json & json -> class

                RegisterStudentByAdminDto dto = new RegisterStudentByAdminDto()
                {
                    name = firstNameTextBox.Text,
                    lastName = lastNameTextBox.Text,
                    mobile = mobileTextBox.Text,
                    nationalCode = nationalCodeTextBox.Text,
                    birthDate = birthDateTimePicker.Value,
                };

                //MobileValidation mobileValidation = new MobileValidation();
                if (!MobileValidation.Validate(dto.mobile))
                {
                    MessageBox.Show("لطفا شماره همراه خود را به صورت صحیح و عددی و با 11 کاراکتر وارد نمایید.");
                    return;
                }

                StudentBusiness studentBusiness = new StudentBusiness();
                studentBusiness.RegisterByAdmin(dto);
                userDataGridView.DataSource = studentBusiness.GetStudents();
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
            StudentBusiness studentBusiness = new StudentBusiness();
            userDataGridView.DataSource = studentBusiness.LoadStudentMockData();
        }


        private async Task AlertManagers()
        {
            string baleToken = "";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://tapi.bale.ai/{baleToken}/sendMessage");
            var content = new StringContent("{\n    \"chat_id\": \"@chanelName\",\n    \"text\": \"سلام، این یک پیام تست از طرف بات است.\"\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

       
    }
}
