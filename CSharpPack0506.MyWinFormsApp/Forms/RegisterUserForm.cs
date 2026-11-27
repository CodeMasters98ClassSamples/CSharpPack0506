using CSharpPack0506.BusinessLayer.Businesses;
using CSharpPack0506.BusinessLayer.Businesses.Abstract;
using CSharpPack0506.BusinessLayer.Dtos;
using CSharpPack0506.DataLayer.Models;

namespace CSharpPack0506.MyWinFormsApp.Forms
{
    public partial class RegisterUserForm : Form
    {
        // فرم فقط Interface منطق کسب و کار را می شناسد
        private readonly IStudentBusiness _studentBusiness;

        private Student? curretStudentForUpdate;

        public RegisterUserForm(IStudentBusiness studentBusiness)
        {
            InitializeComponent();
            _studentBusiness = studentBusiness;
            var x = new StudentBusiness();
            //Show Data
            LoadStudents();
        }

        private void LoadStudents()
        {
            userDataGridView.DataSource = _studentBusiness.GetStudents();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void createUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Application business rule => داخل لایه Business بررسی می شود
                RegisterStudentByAdminDto dto = new RegisterStudentByAdminDto()
                {
                    name = firstNameTextBox.Text,
                    lastName = lastNameTextBox.Text,
                    mobile = mobileTextBox.Text,
                    nationalCode = nationalCodeTextBox.Text,
                    birthDate = birthDateTimePicker.Value,
                };

                bool isSuccess = _studentBusiness.RegisterByAdmin(dto);
                if (!isSuccess)
                {
                    MessageBox.Show("اطلاعات وارد شده معتبر نمی باشد. لطفا نام، نام خانوادگی و شماره همراه را بررسی نمایید.");
                    return;
                }

                LoadStudents();
                ResetForm();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی رخ داده است.");
            }
        }

        private void showByMockButton_Click(object sender, EventArgs e)
        {
            userDataGridView.DataSource = _studentBusiness.LoadStudentMockData();
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
                int id = Convert.ToInt32(row.Cells["Id"].Value);

                curretStudentForUpdate = _studentBusiness.GetById(id);
                if (curretStudentForUpdate is null)
                {
                    MessageBox.Show("اطلاعات کاربر مورد نظر یافت نشد.");
                    return;
                }

                firstNameTextBox.Text = curretStudentForUpdate.Name;
                lastNameTextBox.Text = curretStudentForUpdate.LastName;
                mobileTextBox.Text = curretStudentForUpdate.MobileNumber;
                nationalCodeTextBox.Text = curretStudentForUpdate.NationalCode;
                birthDateTimePicker.Value = curretStudentForUpdate.BirthDate == DateTime.MinValue
                    ? DateTime.Now
                    : curretStudentForUpdate.BirthDate;
            }
        }

        private void updateStudentButton_Click(object sender, EventArgs e)
        {
            if (curretStudentForUpdate is null)
            {
                MessageBox.Show("لطفا کاربری را جهت ویرایش انتخاب نمایید.");
                return;
            }

            UpdateStudentDto dto = new UpdateStudentDto()
            {
                LastName = lastNameTextBox.Text,
                Name = firstNameTextBox.Text,
                UserId = curretStudentForUpdate.Id,
            };

            bool isSuccess = _studentBusiness.Update(dto);
            if (isSuccess)
            {
                MessageBox.Show("اطلاعات با موفقیت ویرایش شد.");
                LoadStudents();
                ResetForm();
            }
            else
            {
                MessageBox.Show("ویرایش اطلاعات با مشکل مواجه شد.");
            }
        }

        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            if (curretStudentForUpdate is null)
            {
                MessageBox.Show("لطفا کاربری را جهت حذف انتخاب نمایید.");
                return;
            }
            bool isSuccess = _studentBusiness.HardDelete(id: curretStudentForUpdate.Id);
            if (isSuccess)
            {
                MessageBox.Show("اطلاعات با موفقیت حذف شد.");
                LoadStudents();
                ResetForm();
            }
            else
            {
                MessageBox.Show("حذف اطلاعات با مشکل مواجه شد.");
            }

        }

        private void ResetForm()
        {
            curretStudentForUpdate = null;

            firstNameTextBox.Text = string.Empty;
            lastNameTextBox.Text = string.Empty;
            mobileTextBox.Text = string.Empty;
            nationalCodeTextBox.Text = string.Empty;
            birthDateTimePicker.Value = DateTime.Now;
        }

        private void softDeleteUserButton_Click(object sender, EventArgs e)
        {
            if (curretStudentForUpdate is null)
            {
                MessageBox.Show("لطفا کاربری را جهت حذف انتخاب نمایید.");
                return;
            }

            bool isSuccess = _studentBusiness.SoftDelete(id: curretStudentForUpdate.Id);
            if (isSuccess)
            {
                MessageBox.Show("اطلاعات با موفقیت حذف شد.");
                LoadStudents();
                ResetForm();
            }
            else
            {
                MessageBox.Show("حذف اطلاعات با مشکل مواجه شد.");
            }
        }
    }
}

