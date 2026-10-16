namespace CSharpPack0506.MyWinFormsApp.Forms
{
    public partial class LayoutForm : Form
    {
        public LayoutForm()
        {
            InitializeComponent();
        }

        private void ثبتنامدانشجوToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterUserForm form = new RegisterUserForm();
            form.Show();
        }

        private void LayoutForm_Load(object sender, EventArgs e)
        {

        }

        private void مشاهدهدانشجویانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserListForm userListForm = new UserListForm();
            userListForm.Show();
        }
    }
}
