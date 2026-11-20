namespace CSharpPack0506.MyWinFormsApp.Forms
{
    partial class RegisterUserForm
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
            firstNameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lastNameTextBox = new TextBox();
            label3 = new Label();
            mobileTextBox = new TextBox();
            nationalCodeTextBox = new TextBox();
            label4 = new Label();
            searchUserButton = new Button();
            createUserButton = new Button();
            userDataGridView = new DataGridView();
            showByMockButton = new Button();
            birthDateTimePicker = new DateTimePicker();
            label5 = new Label();
            updateStudentButton = new Button();
            ((System.ComponentModel.ISupportInitialize)userDataGridView).BeginInit();
            SuspendLayout();
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(74, 15);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(220, 27);
            firstNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 15);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 1;
            label1.Text = "نام: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 59);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 3;
            label2.Text = "نام خانوادگی:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(133, 59);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(161, 27);
            lastNameTextBox.TabIndex = 2;
            lastNameTextBox.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 98);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 4;
            label3.Text = "شماره موبایل: ";
            // 
            // mobileTextBox
            // 
            mobileTextBox.Location = new Point(133, 98);
            mobileTextBox.Name = "mobileTextBox";
            mobileTextBox.Size = new Size(161, 27);
            mobileTextBox.TabIndex = 5;
            // 
            // nationalCodeTextBox
            // 
            nationalCodeTextBox.Location = new Point(89, 131);
            nationalCodeTextBox.Name = "nationalCodeTextBox";
            nationalCodeTextBox.Size = new Size(205, 27);
            nationalCodeTextBox.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 131);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 6;
            label4.Text = "کدملی: ";
            // 
            // searchUserButton
            // 
            searchUserButton.Location = new Point(34, 223);
            searchUserButton.Name = "searchUserButton";
            searchUserButton.Size = new Size(260, 41);
            searchUserButton.TabIndex = 8;
            searchUserButton.Text = "جستجو کاربر";
            searchUserButton.UseVisualStyleBackColor = true;
            searchUserButton.Click += searchUserButton_Click;
            // 
            // createUserButton
            // 
            createUserButton.Location = new Point(34, 270);
            createUserButton.Name = "createUserButton";
            createUserButton.Size = new Size(260, 41);
            createUserButton.TabIndex = 9;
            createUserButton.Text = "ایجاد کاربر";
            createUserButton.UseVisualStyleBackColor = true;
            createUserButton.Click += createUserButton_Click;
            // 
            // userDataGridView
            // 
            userDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userDataGridView.Location = new Point(308, 18);
            userDataGridView.Name = "userDataGridView";
            userDataGridView.RowHeadersWidth = 51;
            userDataGridView.Size = new Size(821, 420);
            userDataGridView.TabIndex = 10;
            userDataGridView.CellClick += userDataGridView_CellClick;
            // 
            // showByMockButton
            // 
            showByMockButton.Location = new Point(34, 317);
            showByMockButton.Name = "showByMockButton";
            showByMockButton.Size = new Size(260, 41);
            showByMockButton.TabIndex = 11;
            showByMockButton.Text = "نمایش داده ماک";
            showByMockButton.UseVisualStyleBackColor = true;
            showByMockButton.Click += showByMockButton_Click;
            // 
            // birthDateTimePicker
            // 
            birthDateTimePicker.Location = new Point(89, 164);
            birthDateTimePicker.Name = "birthDateTimePicker";
            birthDateTimePicker.Size = new Size(205, 27);
            birthDateTimePicker.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 164);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 13;
            label5.Text = "تاریخ تولد:";
            // 
            // updateStudentButton
            // 
            updateStudentButton.Location = new Point(34, 364);
            updateStudentButton.Name = "updateStudentButton";
            updateStudentButton.Size = new Size(260, 41);
            updateStudentButton.TabIndex = 14;
            updateStudentButton.Text = "ویرایش کاربر";
            updateStudentButton.UseVisualStyleBackColor = true;
            updateStudentButton.Click += updateStudentButton_Click;
            // 
            // RegisterUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 450);
            Controls.Add(updateStudentButton);
            Controls.Add(label5);
            Controls.Add(birthDateTimePicker);
            Controls.Add(showByMockButton);
            Controls.Add(userDataGridView);
            Controls.Add(createUserButton);
            Controls.Add(searchUserButton);
            Controls.Add(nationalCodeTextBox);
            Controls.Add(label4);
            Controls.Add(mobileTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lastNameTextBox);
            Controls.Add(label1);
            Controls.Add(firstNameTextBox);
            Name = "RegisterUserForm";
            Text = "RegisterUserForm";
            ((System.ComponentModel.ISupportInitialize)userDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox firstNameTextBox;
        private Label label1;
        private Label label2;
        private TextBox lastNameTextBox;
        private Label label3;
        private TextBox mobileTextBox;
        private TextBox nationalCodeTextBox;
        private Label label4;
        private Button searchUserButton;
        private Button createUserButton;
        private DataGridView userDataGridView;
        private Button showByMockButton;
        private DateTimePicker birthDateTimePicker;
        private Label label5;
        private Button updateStudentButton;
    }
}