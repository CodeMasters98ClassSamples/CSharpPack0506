using CSharpPack0506.BusinessLayer.Businesses.Abstract;
using CSharpPack0506.BusinessLayer.Dtos;
using CSharpPack0506.MyWinFormsApp.Forms;

namespace CSharpPack0506.MyWinFormsApp
{
    public partial class LoginForm : Form
    {
        // لایه نمایش فقط Interface لایه Business را می شناسد
        private readonly IAuthBusiness _authBusiness;

        public LoginForm(IAuthBusiness authBusiness)
        {
            InitializeComponent();
            _authBusiness = authBusiness;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Text;

            LoginResultDto result = _authBusiness.Login(username, password);

            if (result.Success)
            {
                Hide();

                LayoutForm layoutForm = Program.ResolveForm<LayoutForm>();
                layoutForm.FormClosed += (_, _) => Close();
                layoutForm.Show();
            }
            else
            {
                MessageBox.Show(result.Message);
                userNameTextBox.Text = string.Empty;
                passwordTextBox.Text = string.Empty;
            }
        }

    }
}
