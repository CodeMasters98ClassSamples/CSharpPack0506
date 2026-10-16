namespace CSharpPack0506.MyWinFormsApp.Forms
{
    partial class LayoutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            دانشجویانToolStripMenuItem = new ToolStripMenuItem();
            ثبتنامدانشجوToolStripMenuItem = new ToolStripMenuItem();
            مشاهدهدانشجویانToolStripMenuItem = new ToolStripMenuItem();
            ترمهاToolStripMenuItem = new ToolStripMenuItem();
            ایجادترمToolStripMenuItem = new ToolStripMenuItem();
            مشاهدهترمهاToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { دانشجویانToolStripMenuItem, ترمهاToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // دانشجویانToolStripMenuItem
            // 
            دانشجویانToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ثبتنامدانشجوToolStripMenuItem, مشاهدهدانشجویانToolStripMenuItem });
            دانشجویانToolStripMenuItem.Name = "دانشجویانToolStripMenuItem";
            دانشجویانToolStripMenuItem.Size = new Size(90, 24);
            دانشجویانToolStripMenuItem.Text = "دانشجویان";
            // 
            // ثبتنامدانشجوToolStripMenuItem
            // 
            ثبتنامدانشجوToolStripMenuItem.Name = "ثبتنامدانشجوToolStripMenuItem";
            ثبتنامدانشجوToolStripMenuItem.Size = new Size(224, 26);
            ثبتنامدانشجوToolStripMenuItem.Text = "ثبت نام دانشجو";
            ثبتنامدانشجوToolStripMenuItem.Click += ثبتنامدانشجوToolStripMenuItem_Click;
            // 
            // مشاهدهدانشجویانToolStripMenuItem
            // 
            مشاهدهدانشجویانToolStripMenuItem.Name = "مشاهدهدانشجویانToolStripMenuItem";
            مشاهدهدانشجویانToolStripMenuItem.Size = new Size(224, 26);
            مشاهدهدانشجویانToolStripMenuItem.Text = "مشاهده دانشجویان";
            مشاهدهدانشجویانToolStripMenuItem.Click += مشاهدهدانشجویانToolStripMenuItem_Click;
            // 
            // ترمهاToolStripMenuItem
            // 
            ترمهاToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ایجادترمToolStripMenuItem, مشاهدهترمهاToolStripMenuItem });
            ترمهاToolStripMenuItem.Name = "ترمهاToolStripMenuItem";
            ترمهاToolStripMenuItem.Size = new Size(60, 24);
            ترمهاToolStripMenuItem.Text = "ترم ها";
            // 
            // ایجادترمToolStripMenuItem
            // 
            ایجادترمToolStripMenuItem.Name = "ایجادترمToolStripMenuItem";
            ایجادترمToolStripMenuItem.Size = new Size(185, 26);
            ایجادترمToolStripMenuItem.Text = "ایجاد ترم";
            // 
            // مشاهدهترمهاToolStripMenuItem
            // 
            مشاهدهترمهاToolStripMenuItem.Name = "مشاهدهترمهاToolStripMenuItem";
            مشاهدهترمهاToolStripMenuItem.Size = new Size(185, 26);
            مشاهدهترمهاToolStripMenuItem.Text = "مشاهده ترم ها";
            // 
            // LayoutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "LayoutForm";
            Text = "LayoutForm";
            Load += LayoutForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem دانشجویانToolStripMenuItem;
        private ToolStripMenuItem ثبتنامدانشجوToolStripMenuItem;
        private ToolStripMenuItem مشاهدهدانشجویانToolStripMenuItem;
        private ToolStripMenuItem ترمهاToolStripMenuItem;
        private ToolStripMenuItem ایجادترمToolStripMenuItem;
        private ToolStripMenuItem مشاهدهترمهاToolStripMenuItem;
    }
}