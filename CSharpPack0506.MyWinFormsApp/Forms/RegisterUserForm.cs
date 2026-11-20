using CSharpPack0506.BusinessLayer.Businesses;
using CSharpPack0506.BusinessLayer.Dtos;
using CSharpPack0506.BusinessLayer.Extenstions;
using CSharpPack0506.BusinessLayer.Validations;
using CSharpPack0506.DataLayer.Models;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CSharpPack0506.MyWinFormsApp.Forms
{
    public partial class RegisterUserForm : Form
    {
        private Student curretStudentForUpdate = null;
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

                //Application business rule
                RegisterStudentByAdminDto dto = new RegisterStudentByAdminDto()
                {
                    name = firstNameTextBox.Text,
                    lastName = lastNameTextBox.Text,
                    mobile = mobileTextBox.Text,
                    nationalCode = nationalCodeTextBox.Text,
                    birthDate = birthDateTimePicker.Value,
                };

                if (dto.name.Length < 2 && dto.lastName.Length < 2)
                {
                    MessageBox.Show("لطفا شماره همراه خود را به صورت صحیح و عددی و با 11 کاراکتر وارد نمایید.");
                    return;
                }

                //MobileValidation mobileValidation = new MobileValidation();
                if (!MobileValidation.Validate(dto.mobile))
                {
                    MessageBox.Show("لطفا شماره همراه خود را به صورت صحیح و عددی و با 11 کاراکتر وارد نمایید.");
                    return;
                }

                //DB (Sql server, mysql , posgre , Db2 , oracel) , File , Cache , 
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

        private void searchUserButton_Click(object sender, EventArgs e)
        {

        }

        private void userDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header row clicks
            if (e.RowIndex >= 0)
            {
                // Get the current row
                var row = userDataGridView.Rows[e.RowIndex];

                // Access the ID from the row's data
                var id = (int)row.Cells["Id"].Value;

                // Display or use the ID
                //MessageBox.Show($"Row ID: {id}");
                curretStudentForUpdate = studentBusiness.GetById(id);
                firstNameTextBox.Text = curretStudentForUpdate.Name;
                lastNameTextBox.Text = curretStudentForUpdate.LastName;
                mobileTextBox.Text = curretStudentForUpdate.MobileNumber;
                nationalCodeTextBox.Text = curretStudentForUpdate.NationalCode;
                birthDateTimePicker.Value = curretStudentForUpdate.BirthDate;
            }
        }

        private void updateStudentButton_Click(object sender, EventArgs e)
        {
            UpdateStudentDto dto = new UpdateStudentDto()
            {
                LastName = lastNameTextBox.Text,
                Name = firstNameTextBox.Text,
                UserId = curretStudentForUpdate.Id,
            };
            bool isSuccess = studentBusiness.Update(dto);
            if (isSuccess)
            {
                curretStudentForUpdate = null;
                MessageBox.Show("اطلاعات با موفقیت ویرایش شد.");
                firstNameTextBox.Text = default;
                lastNameTextBox.Text = default;
                mobileTextBox.Text = default;
                nationalCodeTextBox.Text = default;
            }
            else
            {
                MessageBox.Show("ویرایش اطلاعات با مشکل مواجه شد.");
            }

        }
    }
}
