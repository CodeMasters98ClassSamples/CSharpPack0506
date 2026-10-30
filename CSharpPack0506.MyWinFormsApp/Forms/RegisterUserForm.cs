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
        public RegisterUserForm()
        {
            InitializeComponent();

            //Show Data
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
                };

                //MobileValidation mobileValidation = new MobileValidation();
                if (!MobileValidation.Validate(dto.mobile))
                {
                    MessageBox.Show("لطفا شماره همراه خود را به صورت صحیح و عددی و با 11 کاراکتر وارد نمایید.");
                    return;
                }

                int x = 1;

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


       
    }
}
