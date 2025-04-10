
namespace InfraVision2
{
    partial class NewUserForm
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
            userinfo = new GroupBox();
            confirmPasstextbox = new TextBox();
            password_textbox = new TextBox();
            confirm_passlabel = new Label();
            password_label = new Label();
            email_textbox = new TextBox();
            Full_name_textbox = new TextBox();
            UserNameTextBox = new TextBox();
            email_label = new Label();
            fullname_label = new Label();
            username_label = new Label();
            access_control_gbox = new GroupBox();
            roles_comboBox = new ComboBox();
            roles_label = new Label();
            CreateUserButton = new Button();
            cancel_button = new Button();
            acct_setting_grpbox1 = new GroupBox();
            apienable_checkBox = new CheckBox();
            twofa_checkbox = new CheckBox();
            passchangebox = new CheckBox();
            acct_active = new CheckBox();
            userinfo.SuspendLayout();
            access_control_gbox.SuspendLayout();
            acct_setting_grpbox1.SuspendLayout();
            SuspendLayout();
            // 
            // userinfo
            // 
            userinfo.Controls.Add(confirmPasstextbox);
            userinfo.Controls.Add(password_textbox);
            userinfo.Controls.Add(confirm_passlabel);
            userinfo.Controls.Add(password_label);
            userinfo.Controls.Add(email_textbox);
            userinfo.Controls.Add(Full_name_textbox);
            userinfo.Controls.Add(UserNameTextBox);
            userinfo.Controls.Add(email_label);
            userinfo.Controls.Add(fullname_label);
            userinfo.Controls.Add(username_label);
            userinfo.Location = new Point(26, 32);
            userinfo.Name = "userinfo";
            userinfo.Size = new Size(724, 161);
            userinfo.TabIndex = 0;
            userinfo.TabStop = false;
            userinfo.Text = "User Information";
            // 
            // confirmPasstextbox
            // 
            confirmPasstextbox.Location = new Point(535, 91);
            confirmPasstextbox.Name = "confirmPasstextbox";
            confirmPasstextbox.Size = new Size(174, 27);
            confirmPasstextbox.TabIndex = 9;
            confirmPasstextbox.TextChanged += confirmPasstextbox_TextChanged;
            // 
            // password_textbox
            // 
            password_textbox.Location = new Point(535, 51);
            password_textbox.Name = "password_textbox";
            password_textbox.Size = new Size(174, 27);
            password_textbox.TabIndex = 8;
            password_textbox.TextChanged += password_textbox_TextChanged;
            // 
            // confirm_passlabel
            // 
            confirm_passlabel.AutoSize = true;
            confirm_passlabel.Location = new Point(390, 94);
            confirm_passlabel.Name = "confirm_passlabel";
            confirm_passlabel.Size = new Size(127, 20);
            confirm_passlabel.TabIndex = 7;
            confirm_passlabel.Text = "Confirm Password";
            // 
            // password_label
            // 
            password_label.AutoSize = true;
            password_label.Location = new Point(390, 58);
            password_label.Name = "password_label";
            password_label.Size = new Size(70, 20);
            password_label.TabIndex = 6;
            password_label.Text = "Password";
            // 
            // email_textbox
            // 
            email_textbox.Location = new Point(126, 123);
            email_textbox.Name = "email_textbox";
            email_textbox.Size = new Size(216, 27);
            email_textbox.TabIndex = 5;
            email_textbox.TextChanged += email_textbox_TextChanged;
            // 
            // Full_name_textbox
            // 
            Full_name_textbox.Location = new Point(126, 74);
            Full_name_textbox.Name = "Full_name_textbox";
            Full_name_textbox.Size = new Size(216, 27);
            Full_name_textbox.TabIndex = 4;
            Full_name_textbox.TextChanged += Full_name_textbox_TextChanged;
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(126, 33);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(216, 27);
            UserNameTextBox.TabIndex = 3;
            UserNameTextBox.TextChanged += UserNameTextBox_TextChanged;
            // 
            // email_label
            // 
            email_label.AutoSize = true;
            email_label.Location = new Point(23, 116);
            email_label.Name = "email_label";
            email_label.Size = new Size(52, 20);
            email_label.TabIndex = 2;
            email_label.Text = "E-Mail";
            // 
            // fullname_label
            // 
            fullname_label.AutoSize = true;
            fullname_label.Location = new Point(23, 74);
            fullname_label.Name = "fullname_label";
            fullname_label.Size = new Size(76, 20);
            fullname_label.TabIndex = 1;
            fullname_label.Text = "Full Name";
            // 
            // username_label
            // 
            username_label.AutoSize = true;
            username_label.Location = new Point(23, 40);
            username_label.Name = "username_label";
            username_label.Size = new Size(78, 20);
            username_label.TabIndex = 0;
            username_label.Text = "UserName";
            username_label.Click += username_label_Click;
            // 
            // access_control_gbox
            // 
            access_control_gbox.Controls.Add(roles_comboBox);
            access_control_gbox.Controls.Add(roles_label);
            access_control_gbox.Location = new Point(30, 225);
            access_control_gbox.Name = "access_control_gbox";
            access_control_gbox.Size = new Size(721, 88);
            access_control_gbox.TabIndex = 1;
            access_control_gbox.TabStop = false;
            access_control_gbox.Text = "Access Control";
            // 
            // roles_comboBox
            // 
            roles_comboBox.FormattingEnabled = true;
            roles_comboBox.Items.AddRange(new object[] { "Admin", "Manager", "Operator", "Viewer" });
            roles_comboBox.Location = new Point(224, 20);
            roles_comboBox.Name = "roles_comboBox";
            roles_comboBox.Size = new Size(278, 28);
            roles_comboBox.TabIndex = 1;
            roles_comboBox.SelectedIndexChanged += roles_comboBox_SelectedIndexChanged;
            // 
            // roles_label
            // 
            roles_label.AutoSize = true;
            roles_label.Location = new Point(32, 28);
            roles_label.Name = "roles_label";
            roles_label.Size = new Size(48, 20);
            roles_label.TabIndex = 0;
            roles_label.Text = "Roles:";
            // 
            // CreateUserButton
            // 
            CreateUserButton.Location = new Point(289, 468);
            CreateUserButton.Name = "CreateUserButton";
            CreateUserButton.Size = new Size(94, 29);
            CreateUserButton.TabIndex = 2;
            CreateUserButton.Text = "Create User";
            CreateUserButton.UseVisualStyleBackColor = true;
            CreateUserButton.Click += button1_Click;
            // 
            // cancel_button
            // 
            cancel_button.Location = new Point(438, 468);
            cancel_button.Name = "cancel_button";
            cancel_button.Size = new Size(94, 29);
            cancel_button.TabIndex = 3;
            cancel_button.Text = "Cancel";
            cancel_button.UseVisualStyleBackColor = true;
            cancel_button.Click += cancel_button_Click;
            // 
            // acct_setting_grpbox1
            // 
            acct_setting_grpbox1.Controls.Add(apienable_checkBox);
            acct_setting_grpbox1.Controls.Add(twofa_checkbox);
            acct_setting_grpbox1.Controls.Add(passchangebox);
            acct_setting_grpbox1.Controls.Add(acct_active);
            acct_setting_grpbox1.Location = new Point(34, 331);
            acct_setting_grpbox1.Name = "acct_setting_grpbox1";
            acct_setting_grpbox1.Size = new Size(716, 125);
            acct_setting_grpbox1.TabIndex = 4;
            acct_setting_grpbox1.TabStop = false;
            acct_setting_grpbox1.Text = "Account Settings";
            // 
            // apienable_checkBox
            // 
            apienable_checkBox.AutoSize = true;
            apienable_checkBox.Location = new Point(382, 78);
            apienable_checkBox.Name = "apienable_checkBox";
            apienable_checkBox.Size = new Size(157, 24);
            apienable_checkBox.TabIndex = 3;
            apienable_checkBox.Text = "API access enabled";
            apienable_checkBox.UseVisualStyleBackColor = true;
            apienable_checkBox.CheckedChanged += apienable_checkBox_CheckedChanged;
            // 
            // twofa_checkbox
            // 
            twofa_checkbox.AutoSize = true;
            twofa_checkbox.Location = new Point(381, 26);
            twofa_checkbox.Name = "twofa_checkbox";
            twofa_checkbox.Size = new Size(242, 24);
            twofa_checkbox.TabIndex = 2;
            twofa_checkbox.Text = "2 Factor Authentication enabled";
            twofa_checkbox.UseVisualStyleBackColor = true;
            twofa_checkbox.CheckedChanged += twofa_checkbox_CheckedChanged;
            // 
            // passchangebox
            // 
            passchangebox.AutoSize = true;
            passchangebox.Location = new Point(15, 78);
            passchangebox.Name = "passchangebox";
            passchangebox.Size = new Size(289, 24);
            passchangebox.TabIndex = 1;
            passchangebox.Text = "Require Password Change on first login";
            passchangebox.UseVisualStyleBackColor = true;
            passchangebox.CheckedChanged += passchangebox_CheckedChanged;
            // 
            // acct_active
            // 
            acct_active.AutoSize = true;
            acct_active.Location = new Point(15, 38);
            acct_active.Name = "acct_active";
            acct_active.Size = new Size(130, 24);
            acct_active.TabIndex = 0;
            acct_active.Text = "Account Active";
            acct_active.UseVisualStyleBackColor = true;
            acct_active.CheckedChanged += acct_active_CheckedChanged;
            // 
            // NewUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 509);
            Controls.Add(acct_setting_grpbox1);
            Controls.Add(cancel_button);
            Controls.Add(CreateUserButton);
            Controls.Add(access_control_gbox);
            Controls.Add(userinfo);
            Name = "NewUserForm";
            Text = "User Registeration";
            userinfo.ResumeLayout(false);
            userinfo.PerformLayout();
            access_control_gbox.ResumeLayout(false);
            access_control_gbox.PerformLayout();
            acct_setting_grpbox1.ResumeLayout(false);
            acct_setting_grpbox1.PerformLayout();
            ResumeLayout(false);
        }

        private void button1_Click(object sender, EventArgs e)
        { 
        }

        private void username_label_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private GroupBox userinfo;
        private Label username_label;
        private Label fullname_label;
        private Label email_label;
        private TextBox UserNameTextBox;
        private TextBox Full_name_textbox;
        private TextBox email_textbox;
        private Label password_label;
        private Label confirm_passlabel;
        private TextBox password_textbox;
        private TextBox confirmPasstextbox;
        private GroupBox access_control_gbox;
        private Label roles_label;
        private ComboBox roles_comboBox;
        private Button CreateUserButton;
        private Button cancel_button;
        private GroupBox acct_setting_grpbox1;
        private CheckBox acct_active;
        private CheckBox passchangebox;
        private CheckBox twofa_checkbox;
        private CheckBox apienable_checkBox;
    }
}