
namespace InfraVision2
{
    partial class ForgotPassword
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
            InfoText = new Label();
            userName_email_label = new Label();
            username_textbox = new TextBox();
            VerificationMethodGroupBox1 = new GroupBox();
            email_ver_method_radioButton1 = new RadioButton();
            sec_ques_radio = new RadioButton();
            send_reset_button = new Button();
            cancel_button = new Button();
            date_time = new Label();
            curr_date_time = new Label();
            VerificationMethodGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // InfoText
            // 
            InfoText.AutoSize = true;
            InfoText.Location = new Point(12, 34);
            InfoText.Name = "InfoText";
            InfoText.Size = new Size(562, 20);
            InfoText.TabIndex = 0;
            InfoText.Text = "Please enter your username or email address to receive password reset instructions. ";
            // 
            // userName_email_label
            // 
            userName_email_label.AutoSize = true;
            userName_email_label.Location = new Point(13, 100);
            userName_email_label.Name = "userName_email_label";
            userName_email_label.Size = new Size(141, 20);
            userName_email_label.TabIndex = 1;
            userName_email_label.Text = "User Name or Email";
            // 
            // username_textbox
            // 
            username_textbox.Location = new Point(183, 97);
            username_textbox.Name = "username_textbox";
            username_textbox.Size = new Size(327, 27);
            username_textbox.TabIndex = 2;
            // 
            // VerificationMethodGroupBox1
            // 
            VerificationMethodGroupBox1.Controls.Add(sec_ques_radio);
            VerificationMethodGroupBox1.Controls.Add(email_ver_method_radioButton1);
            VerificationMethodGroupBox1.Location = new Point(13, 175);
            VerificationMethodGroupBox1.Name = "VerificationMethodGroupBox1";
            VerificationMethodGroupBox1.Size = new Size(497, 125);
            VerificationMethodGroupBox1.TabIndex = 3;
            VerificationMethodGroupBox1.TabStop = false;
            VerificationMethodGroupBox1.Text = "Verification Method";
            // 
            // email_ver_method_radioButton1
            // 
            email_ver_method_radioButton1.AutoSize = true;
            email_ver_method_radioButton1.Location = new Point(16, 36);
            email_ver_method_radioButton1.Name = "email_ver_method_radioButton1";
            email_ver_method_radioButton1.Size = new Size(223, 24);
            email_ver_method_radioButton1.TabIndex = 0;
            email_ver_method_radioButton1.TabStop = true;
            email_ver_method_radioButton1.Text = "E-Mail to Registered Address";
            email_ver_method_radioButton1.UseVisualStyleBackColor = true;
            // 
            // sec_ques_radio
            // 
            sec_ques_radio.AutoSize = true;
            sec_ques_radio.Location = new Point(19, 81);
            sec_ques_radio.Name = "sec_ques_radio";
            sec_ques_radio.Size = new Size(145, 24);
            sec_ques_radio.TabIndex = 1;
            sec_ques_radio.TabStop = true;
            sec_ques_radio.Text = "Security Question";
            sec_ques_radio.UseVisualStyleBackColor = true;
            // 
            // send_reset_button
            // 
            send_reset_button.Location = new Point(65, 340);
            send_reset_button.Name = "send_reset_button";
            send_reset_button.Size = new Size(140, 29);
            send_reset_button.TabIndex = 4;
            send_reset_button.Text = "Send Reset Link";
            send_reset_button.UseVisualStyleBackColor = true;
            // 
            // cancel_button
            // 
            cancel_button.Location = new Point(314, 340);
            cancel_button.Name = "cancel_button";
            cancel_button.Size = new Size(121, 29);
            cancel_button.TabIndex = 5;
            cancel_button.Text = "Cancel";
            cancel_button.UseVisualStyleBackColor = true;
            // 
            // date_time
            // 
            date_time.AutoSize = true;
            date_time.Location = new Point(26, 405);
            date_time.Name = "date_time";
            date_time.Size = new Size(166, 20);
            date_time.TabIndex = 6;
            date_time.Text = "Current Data and Time: ";
            // 
            // curr_date_time
            // 
            curr_date_time.AutoSize = true;
            curr_date_time.Location = new Point(199, 403);
            curr_date_time.Name = "curr_date_time";
            curr_date_time.Size = new Size(50, 20);
            curr_date_time.TabIndex = 7;
            curr_date_time.Text = "label1";
            curr_date_time.Click += this.curr_date_time_Click;
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 450);
            Controls.Add(curr_date_time);
            Controls.Add(date_time);
            Controls.Add(cancel_button);
            Controls.Add(send_reset_button);
            Controls.Add(VerificationMethodGroupBox1);
            Controls.Add(username_textbox);
            Controls.Add(userName_email_label);
            Controls.Add(InfoText);
            Name = "ForgotPassword";
            Text = "Forgot Password";
            VerificationMethodGroupBox1.ResumeLayout(false);
            VerificationMethodGroupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void curr_date_time_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label InfoText;
        private Label userName_email_label;
        private TextBox username_textbox;
        private GroupBox VerificationMethodGroupBox1;
        private RadioButton email_ver_method_radioButton1;
        private RadioButton sec_ques_radio;
        private Button send_reset_button;
        private Button cancel_button;
        private Label date_time;
        private Label curr_date_time;
    }
}