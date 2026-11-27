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
            Program.ShowChildForm<RegisterUserForm>(this);
        }

        private void LayoutForm_Load(object sender, EventArgs e)
        {

        }

        private void مشاهدهدانشجویانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ShowChildForm<UserListForm>(this);
        }

        private void ایجادترمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ShowChildForm<AddTermForm>(this);
        }

        private void مشاهدهترمهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ShowChildForm<TermListForm>(this);
        }
    }
}
