using CSharpPack0506.MyWinFormsApp.Forms;

namespace CSharpPack0506.MyWinFormsApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "Configs", "logins.txt");
            string[] logins = null;
            // To read the entire file at once

            if (File.Exists(filePath))
            {
                // Read all the content in one string
                // and display the string
                logins = File.ReadAllLines(filePath);
            }
            else
            {
                MessageBox.Show("سیستم با مشکل مواجه شد.");
                return;
            }

            if (logins is null || logins.Length == 0)
            {
                MessageBox.Show("سیستم با مشکل مواجه شد.");
                return;
            }

            //Developer imp
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Text;

            //C# -> File -> Read , write
            bool succcessfulLogin = false;

            for (int i = 0; i < logins.Length; i++)
            {
                var loginRow = logins[i];
                //admin;123456 ->array [ "admin" , "123456" ]
                string[] login = loginRow.Split(';');

                if (username.ToLower().Trim() == login[0] && password == login[1])
                {
                    succcessfulLogin = true;
                    break;
                }
            }

            if (succcessfulLogin)
            {
                LayoutForm layoutForm = new LayoutForm();
                layoutForm.Show();
            }
            else
            {
                MessageBox.Show("نام کاربری یا رمزعبور اشتباه میباشد.");
                userNameTextBox.Text = string.Empty;
                passwordTextBox.Text = string.Empty;
            }

        }

    }
}
