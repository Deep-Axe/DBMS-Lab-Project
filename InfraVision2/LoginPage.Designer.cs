namespace InfraVision2
{
    partial class LoginPage
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
            TitleLable = new Label();
            LoginLabel = new Label();
            UserNameLabel = new Label();
            UserNameTextBox = new TextBox();
            PasswordLabel = new Label();
            passwordTextBox1 = new MaskedTextBox();
            LoginButton = new Button();
            Forgot_PasswordButton = new Button();
            Enable2FaCheckBox = new CheckBox();
            NewUserButton = new Button();
            SuspendLayout();
            // 
            // TitleLable
            // 
            TitleLable.AutoSize = true;
            TitleLable.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            TitleLable.Location = new Point(166, 9);
            TitleLable.Name = "TitleLable";
            TitleLable.Size = new Size(196, 38);
            TitleLable.TabIndex = 0;
            TitleLable.Text = "INFRAVISION";
            // 
            // LoginLabel
            // 
            LoginLabel.AutoSize = true;
            LoginLabel.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            LoginLabel.Location = new Point(209, 57);
            LoginLabel.Name = "LoginLabel";
            LoginLabel.Size = new Size(101, 25);
            LoginLabel.TabIndex = 1;
            LoginLabel.Text = "Login Page";
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserNameLabel.Location = new Point(66, 135);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(99, 23);
            UserNameLabel.TabIndex = 2;
            UserNameLabel.Text = "UserName: ";
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(209, 131);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(196, 27);
            UserNameTextBox.TabIndex = 3;
            UserNameTextBox.TextChanged += UserNameTextBox_TextChanged;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordLabel.Location = new Point(66, 205);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(86, 23);
            PasswordLabel.TabIndex = 4;
            PasswordLabel.Text = "Password:";
            // 
            // passwordTextBox1
            // 
            passwordTextBox1.Location = new Point(209, 201);
            passwordTextBox1.Name = "passwordTextBox1";
            passwordTextBox1.Size = new Size(196, 27);
            passwordTextBox1.TabIndex = 5;
            passwordTextBox1.MaskInputRejected += passwordTextBox1_MaskInputRejected;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(117, 312);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(94, 29);
            LoginButton.TabIndex = 6;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // Forgot_PasswordButton
            // 
            Forgot_PasswordButton.Location = new Point(252, 312);
            Forgot_PasswordButton.Name = "Forgot_PasswordButton";
            Forgot_PasswordButton.Size = new Size(153, 29);
            Forgot_PasswordButton.TabIndex = 7;
            Forgot_PasswordButton.Text = "Forgot Password";
            Forgot_PasswordButton.UseVisualStyleBackColor = true;
            Forgot_PasswordButton.Click += Forgot_PasswordButton_Click;
            // 
            // Enable2FaCheckBox
            // 
            Enable2FaCheckBox.AutoSize = true;
            Enable2FaCheckBox.Location = new Point(144, 269);
            Enable2FaCheckBox.Name = "Enable2FaCheckBox";
            Enable2FaCheckBox.Size = new Size(233, 24);
            Enable2FaCheckBox.TabIndex = 8;
            Enable2FaCheckBox.Text = "Enable 2 Factor Authentication";
            Enable2FaCheckBox.UseVisualStyleBackColor = true;
            // 
            // NewUserButton
            // 
            NewUserButton.Location = new Point(166, 370);
            NewUserButton.Name = "NewUserButton";
            NewUserButton.Size = new Size(168, 29);
            NewUserButton.TabIndex = 9;
            NewUserButton.Text = "Register New User";
            NewUserButton.UseVisualStyleBackColor = true;
            NewUserButton.Click += NewUserButton_Click;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 450);
            Controls.Add(NewUserButton);
            Controls.Add(Enable2FaCheckBox);
            Controls.Add(Forgot_PasswordButton);
            Controls.Add(LoginButton);
            Controls.Add(passwordTextBox1);
            Controls.Add(PasswordLabel);
            Controls.Add(UserNameTextBox);
            Controls.Add(UserNameLabel);
            Controls.Add(LoginLabel);
            Controls.Add(TitleLable);
            Name = "LoginPage";
            Text = "Login Page";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLable;
        private Label LoginLabel;
        private Label UserNameLabel;
        private TextBox UserNameTextBox;
        private Label PasswordLabel;
        private MaskedTextBox passwordTextBox1;
        private Button LoginButton;
        private Button Forgot_PasswordButton;
        private CheckBox Enable2FaCheckBox;
        private Button NewUserButton;
    }
}
