namespace CSharpPack0506.MyWinFormsApp
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            userNameTextBox = new TextBox();
            loginButton = new Button();
            passwordTextBox = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 47);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "نام کاربری: ";
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(104, 47);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(244, 27);
            userNameTextBox.TabIndex = 1;
            // 
            // loginButton
            // 
            loginButton.BackColor = SystemColors.ActiveCaption;
            loginButton.Location = new Point(12, 161);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(336, 59);
            loginButton.TabIndex = 2;
            loginButton.Text = "ورود به پنل";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(104, 102);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(244, 27);
            passwordTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 102);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 3;
            label2.Text = "رمزعبور: ";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 233);
            Controls.Add(passwordTextBox);
            Controls.Add(label2);
            Controls.Add(loginButton);
            Controls.Add(userNameTextBox);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox userNameTextBox;
        private Button loginButton;
        private TextBox passwordTextBox;
        private Label label2;
    }
}
