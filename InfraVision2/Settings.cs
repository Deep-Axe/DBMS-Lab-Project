using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfraVision2
{
    public partial class Settings : Form
    {
        private Label lblDateTime;
        private Label lblUser;

        public Settings()
        {
            InitializeComponent();

            // Set form properties
            this.Text = "Server Management System";
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Create all UI elements
            CreateSettingsHeader();
            CreateTabsSection();
            CreateSystemSettingsSection();
            CreateNotificationSettingsSection();
            CreateSecuritySettingsSection();
            CreateActionButtons();
            CreateFooterLabels();

            // Set up a timer to update the date/time periodically
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += (s, e) => UpdateDateTime();
            timer.Start();
        }

        private void CreateSettingsHeader()
        {
            // Header label for the Settings section
            Label lblHeader = new Label();
            lblHeader.Text = "SETTINGS";
            lblHeader.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblHeader.Location = new Point(20, 20);
            lblHeader.Size = new Size(150, 25);
            this.Controls.Add(lblHeader);
        }

        private void CreateTabsSection()
        {
            // Tabs for different settings views
            Button btnSystem = new Button();
            btnSystem.Text = "System";
            btnSystem.Location = new Point(20, 60);
            btnSystem.Size = new Size(150, 35);
            btnSystem.BackColor = Color.FromArgb(240, 240, 240);
            btnSystem.FlatStyle = FlatStyle.Flat;
            btnSystem.Click += (s, e) => {
                // Scroll to System Settings
                this.AutoScrollPosition = new Point(0, 0);
            };

            Button btnNotifications = new Button();
            btnNotifications.Text = "Notifications";
            btnNotifications.Location = new Point(180, 60);
            btnNotifications.Size = new Size(150, 35);
            btnNotifications.FlatStyle = FlatStyle.Flat;
            btnNotifications.Click += (s, e) => {
                // Scroll to Notification Settings
                if (this.Controls[0] is Panel pnlContent)
                {
                    this.AutoScrollPosition = new Point(0, 250);
                }
               
                
            };

            Button btnSecurity = new Button();
            btnSecurity.Text = "Security";
            btnSecurity.Location = new Point(340, 60);
            btnSecurity.Size = new Size(180, 35);
            btnSecurity.FlatStyle = FlatStyle.Flat;
            btnSecurity.Click += (s, e) => {
                // Scroll to Security Settings
                this.AutoScrollPosition = new Point(0, 500);
            };

            this.Controls.AddRange(new Control[] { btnSystem, btnNotifications, btnSecurity });
        }

        private void CreateSystemSettingsSection()
        {
            // System Settings header
            Label lblSystemHeader = new Label();
            lblSystemHeader.Text = "System Settings";
            lblSystemHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSystemHeader.Location = new Point(20, 110);
            lblSystemHeader.Size = new Size(150, 20);
            this.Controls.Add(lblSystemHeader);

            // System Settings group
            GroupBox grpSystem = new GroupBox();
            grpSystem.Text = "General";
            grpSystem.Location = new Point(20, 140);
            grpSystem.Size = new Size(900, 170);

            // Session Timeout
            Label lblSessionTimeout = new Label();
            lblSessionTimeout.Text = "Session Timeout:";
            lblSessionTimeout.Location = new Point(20, 30);
            lblSessionTimeout.Size = new Size(150, 20);

            NumericUpDown nudSessionTimeout = new NumericUpDown();
            nudSessionTimeout.Value = 30;
            nudSessionTimeout.Minimum = 5;
            nudSessionTimeout.Maximum = 120;
            nudSessionTimeout.Location = new Point(200, 28);
            nudSessionTimeout.Size = new Size(70, 25);

            Label lblSessionTimeoutUnit = new Label();
            lblSessionTimeoutUnit.Text = "minutes";
            lblSessionTimeoutUnit.Location = new Point(280, 30);
            lblSessionTimeoutUnit.Size = new Size(100, 20);

            // Default Page
            Label lblDefaultPage = new Label();
            lblDefaultPage.Text = "Default Page:";
            lblDefaultPage.Location = new Point(20, 60);
            lblDefaultPage.Size = new Size(150, 20);

            ComboBox cboDefaultPage = new ComboBox();
            cboDefaultPage.Text = "Dashboard";
            cboDefaultPage.Location = new Point(200, 58);
            cboDefaultPage.Size = new Size(200, 25);
            cboDefaultPage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDefaultPage.Items.AddRange(new object[] {
                "Dashboard", "Servers", "Alerts", "Incidents", "Reports"
            });
            cboDefaultPage.SelectedIndex = 0;

            // Data Retention
            Label lblDataRetention = new Label();
            lblDataRetention.Text = "Data Retention:";
            lblDataRetention.Location = new Point(20, 90);
            lblDataRetention.Size = new Size(150, 20);

            NumericUpDown nudDataRetention = new NumericUpDown();
            nudDataRetention.Value = 90;
            nudDataRetention.Minimum = 30;
            nudDataRetention.Maximum = 365;
            nudDataRetention.Location = new Point(200, 88);
            nudDataRetention.Size = new Size(70, 25);

            Label lblDataRetentionUnit = new Label();
            lblDataRetentionUnit.Text = "days";
            lblDataRetentionUnit.Location = new Point(280, 90);
            lblDataRetentionUnit.Size = new Size(100, 20);

            // Timezone
            Label lblTimezone = new Label();
            lblTimezone.Text = "Timezone:";
            lblTimezone.Location = new Point(20, 120);
            lblTimezone.Size = new Size(150, 20);

            ComboBox cboTimezone = new ComboBox();
            cboTimezone.Text = "UTC";
            cboTimezone.Location = new Point(200, 118);
            cboTimezone.Size = new Size(200, 25);
            cboTimezone.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimezone.Items.AddRange(new object[] {
                "UTC", "GMT", "EST", "CST", "PST", "JST", "AEST"
            });
            cboTimezone.SelectedIndex = 0;

            // Theme
            Label lblTheme = new Label();
            lblTheme.Text = "Theme:";
            lblTheme.Location = new Point(20, 150);
            lblTheme.Size = new Size(150, 20);

            ComboBox cboTheme = new ComboBox();
            cboTheme.Text = "Light";
            cboTheme.Location = new Point(200, 148);
            cboTheme.Size = new Size(200, 25);
            cboTheme.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTheme.Items.AddRange(new object[] {
                "Light", "Dark", "System Default"
            });
            cboTheme.SelectedIndex = 0;

            // Add all controls to the group
            grpSystem.Controls.AddRange(new Control[] {
                lblSessionTimeout, nudSessionTimeout, lblSessionTimeoutUnit,
                lblDefaultPage, cboDefaultPage,
                lblDataRetention, nudDataRetention, lblDataRetentionUnit,
                lblTimezone, cboTimezone,
                lblTheme, cboTheme
            });

            this.Controls.Add(grpSystem);
        }

        private void CreateNotificationSettingsSection()
        {
            // Notification Settings header
            Label lblNotificationsHeader = new Label();
            lblNotificationsHeader.Text = "Notification Settings";
            lblNotificationsHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblNotificationsHeader.Location = new Point(20, 320);
            lblNotificationsHeader.Size = new Size(200, 20);
            this.Controls.Add(lblNotificationsHeader);

            // Notification Settings group
            GroupBox grpNotifications = new GroupBox();
            grpNotifications.Text = "Email Configuration";
            grpNotifications.Location = new Point(20, 350);
            grpNotifications.Size = new Size(900, 210);

            // SMTP Server
            Label lblSmtpServer = new Label();
            lblSmtpServer.Text = "SMTP Server:";
            lblSmtpServer.Location = new Point(20, 30);
            lblSmtpServer.Size = new Size(150, 20);

            TextBox txtSmtpServer = new TextBox();
            txtSmtpServer.Text = "smtp.company.com";
            txtSmtpServer.Location = new Point(200, 28);
            txtSmtpServer.Size = new Size(250, 25);

            // SMTP Port
            Label lblSmtpPort = new Label();
            lblSmtpPort.Text = "SMTP Port:";
            lblSmtpPort.Location = new Point(20, 60);
            lblSmtpPort.Size = new Size(150, 20);

            NumericUpDown nudSmtpPort = new NumericUpDown();
            
            nudSmtpPort.Minimum = 1;
            nudSmtpPort.Maximum = 65535;
            nudSmtpPort.Value = 57;
            nudSmtpPort.Location = new Point(200, 58);
            nudSmtpPort.Size = new Size(100, 25);

            // From Address
            Label lblFromAddress = new Label();
            lblFromAddress.Text = "From Address:";
            lblFromAddress.Location = new Point(20, 90);
            lblFromAddress.Size = new Size(150, 20);

            TextBox txtFromAddress = new TextBox();
            txtFromAddress.Text = "alerts@company.com";
            txtFromAddress.Location = new Point(200, 88);
            txtFromAddress.Size = new Size(250, 25);

            // Enable SSL
            CheckBox chkEnableSsl = new CheckBox();
            chkEnableSsl.Text = "Enable SSL";
            chkEnableSsl.Checked = true;
            chkEnableSsl.Location = new Point(200, 118);
            chkEnableSsl.Size = new Size(250, 20);

            // Authentication
            CheckBox chkAuthentication = new CheckBox();
            chkAuthentication.Text = "Authentication";
            chkAuthentication.Checked = true;
            chkAuthentication.Location = new Point(200, 148);
            chkAuthentication.Size = new Size(250, 20);

            // Username
            Label lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Location = new Point(20, 180);
            lblUsername.Size = new Size(150, 20);

            TextBox txtUsername = new TextBox();
            txtUsername.Text = "alertsystem";
            txtUsername.Location = new Point(200, 178);
            txtUsername.Size = new Size(250, 25);

            // Password
            Label lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(500, 30);
            lblPassword.Size = new Size(100, 20);

            TextBox txtPassword = new TextBox();
            txtPassword.Text = "••••••••••";
            txtPassword.PasswordChar = '•';
            txtPassword.Location = new Point(600, 28);
            txtPassword.Size = new Size(250, 25);

            // Test Email Configuration button
            Button btnTestEmail = new Button();
            btnTestEmail.Text = "Test Email Configuration";
            btnTestEmail.Location = new Point(500, 80);
            btnTestEmail.Size = new Size(200, 30);
            btnTestEmail.Click += (s, e) => {
                MessageBox.Show("Test email sent successfully!", "Email Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Add all controls to the group
            grpNotifications.Controls.AddRange(new Control[] {
                lblSmtpServer, txtSmtpServer,
                lblSmtpPort, nudSmtpPort,
                lblFromAddress, txtFromAddress,
                chkEnableSsl,
                chkAuthentication,
                lblUsername, txtUsername,
                lblPassword, txtPassword,
                btnTestEmail
            });

            this.Controls.Add(grpNotifications);
        }

        private void CreateSecuritySettingsSection()
        {
            // Security Settings header
            Label lblSecurityHeader = new Label();
            lblSecurityHeader.Text = "Security Settings";
            lblSecurityHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSecurityHeader.Location = new Point(20, 570);
            lblSecurityHeader.Size = new Size(150, 20);
            this.Controls.Add(lblSecurityHeader);

            // Security Settings group
            GroupBox grpSecurity = new GroupBox();
            grpSecurity.Text = "Password Policy";
            grpSecurity.Location = new Point(20, 600);
            grpSecurity.Size = new Size(900, 250);

            // Minimum Length
            Label lblMinLength = new Label();
            lblMinLength.Text = "Minimum Length:";
            lblMinLength.Location = new Point(20, 30);
            lblMinLength.Size = new Size(150, 20);

            NumericUpDown nudMinLength = new NumericUpDown();
            nudMinLength.Value = 12;
            nudMinLength.Minimum = 8;
            nudMinLength.Maximum = 24;
            nudMinLength.Location = new Point(200, 28);
            nudMinLength.Size = new Size(70, 25);

            Label lblMinLengthUnit = new Label();
            lblMinLengthUnit.Text = "characters";
            lblMinLengthUnit.Location = new Point(280, 30);
            lblMinLengthUnit.Size = new Size(100, 20);

            // Complexity Requirements label
            Label lblComplexity = new Label();
            lblComplexity.Text = "Complexity Requirements:";
            lblComplexity.Location = new Point(20, 60);
            lblComplexity.Size = new Size(150, 20);

            // Require uppercase
            CheckBox chkUppercase = new CheckBox();
            chkUppercase.Text = "Require uppercase letters";
            chkUppercase.Checked = true;
            chkUppercase.Location = new Point(200, 60);
            chkUppercase.Size = new Size(250, 20);

            // Require lowercase
            CheckBox chkLowercase = new CheckBox();
            chkLowercase.Text = "Require lowercase letters";
            chkLowercase.Checked = true;
            chkLowercase.Location = new Point(200, 85);
            chkLowercase.Size = new Size(250, 20);

            // Require numbers
            CheckBox chkNumbers = new CheckBox();
            chkNumbers.Text = "Require numbers";
            chkNumbers.Checked = true;
            chkNumbers.Location = new Point(200, 110);
            chkNumbers.Size = new Size(250, 20);

            // Require special characters
            CheckBox chkSpecialChars = new CheckBox();
            chkSpecialChars.Text = "Require special characters";
            chkSpecialChars.Checked = true;
            chkSpecialChars.Location = new Point(200, 135);
            chkSpecialChars.Size = new Size(250, 20);

            // Maximum Age
            Label lblMaxAge = new Label();
            lblMaxAge.Text = "Maximum Age:";
            lblMaxAge.Location = new Point(20, 165);
            lblMaxAge.Size = new Size(150, 20);

            NumericUpDown nudMaxAge = new NumericUpDown();
            nudMaxAge.Value = 90;
            nudMaxAge.Minimum = 30;
            nudMaxAge.Maximum = 365;
            nudMaxAge.Location = new Point(200, 163);
            nudMaxAge.Size = new Size(70, 25);

            Label lblMaxAgeUnit = new Label();
            lblMaxAgeUnit.Text = "days";
            lblMaxAgeUnit.Location = new Point(280, 165);
            lblMaxAgeUnit.Size = new Size(100, 20);

            // Failed Login Lockout
            Label lblLoginLockout = new Label();
            lblLoginLockout.Text = "Failed Login Lockout:";
            lblLoginLockout.Location = new Point(20, 195);
            lblLoginLockout.Size = new Size(150, 20);

            NumericUpDown nudLoginLockout = new NumericUpDown();
            nudLoginLockout.Value = 5;
            nudLoginLockout.Minimum = 3;
            nudLoginLockout.Maximum = 10;
            nudLoginLockout.Location = new Point(200, 193);
            nudLoginLockout.Size = new Size(70, 25);

            Label lblLoginLockoutUnit = new Label();
            lblLoginLockoutUnit.Text = "attempts";
            lblLoginLockoutUnit.Location = new Point(280, 195);
            lblLoginLockoutUnit.Size = new Size(100, 20);

            // Lockout Duration
            Label lblLockoutDuration = new Label();
            lblLockoutDuration.Text = "Lockout Duration:";
            lblLockoutDuration.Location = new Point(20, 225);
            lblLockoutDuration.Size = new Size(150, 20);

            NumericUpDown nudLockoutDuration = new NumericUpDown();
            nudLockoutDuration.Value = 30;
            nudLockoutDuration.Minimum = 5;
            nudLockoutDuration.Maximum = 1440; // 24 hours
            nudLockoutDuration.Location = new Point(200, 223);
            nudLockoutDuration.Size = new Size(70, 25);

            Label lblLockoutDurationUnit = new Label();
            lblLockoutDurationUnit.Text = "minutes";
            lblLockoutDurationUnit.Location = new Point(280, 225);
            lblLockoutDurationUnit.Size = new Size(100, 20);

            // Require 2FA
            CheckBox chk2FA = new CheckBox();
            chk2FA.Text = "Require 2FA for admin accounts";
            chk2FA.Checked = true;
            chk2FA.Location = new Point(500, 60);
            chk2FA.Size = new Size(250, 20);

            // Log all security events
            CheckBox chkLogEvents = new CheckBox();
            chkLogEvents.Text = "Log all security events";
            chkLogEvents.Checked = true;
            chkLogEvents.Location = new Point(500, 85);
            chkLogEvents.Size = new Size(250, 20);

            // Add all controls to the group
            grpSecurity.Controls.AddRange(new Control[] {
                lblMinLength, nudMinLength, lblMinLengthUnit,
                lblComplexity, chkUppercase, chkLowercase, chkNumbers, chkSpecialChars,
                lblMaxAge, nudMaxAge, lblMaxAgeUnit,
                lblLoginLockout, nudLoginLockout, lblLoginLockoutUnit,
                lblLockoutDuration, nudLockoutDuration, lblLockoutDurationUnit,
                chk2FA, chkLogEvents
            });

            this.Controls.Add(grpSecurity);
        }

        private void CreateActionButtons()
        {
            // Save Changes button
            Button btnSaveChanges = new Button();
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.Location = new Point(20, 860);
            btnSaveChanges.Size = new Size(150, 30);
            btnSaveChanges.BackColor = Color.FromArgb(70, 130, 180);
            btnSaveChanges.ForeColor = Color.White;
            btnSaveChanges.Click += (s, e) => {
                MessageBox.Show("Settings saved successfully!", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Reset to Defaults button
            Button btnResetDefaults = new Button();
            btnResetDefaults.Text = "Reset to Defaults";
            btnResetDefaults.Location = new Point(180, 860);
            btnResetDefaults.Size = new Size(150, 30);
            btnResetDefaults.Click += (s, e) => {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to reset all settings to default values?",
                    "Confirm Reset",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Settings have been reset to defaults.", "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            this.Controls.Add(btnSaveChanges);
            this.Controls.Add(btnResetDefaults);
        }

        private void CreateFooterLabels()
        {
            // Create date/time label
            lblDateTime = new Label();
            lblDateTime.Location = new Point(20, 900);
            lblDateTime.Size = new Size(500, 20);
            lblDateTime.ForeColor = Color.Gray;
            lblDateTime.Font = new Font("Segoe UI", 8);

            // Get current date/time and format it
            string formattedDateTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            lblDateTime.Text = $"Current Date and Time (UTC - YYYY-MM-DD HH:MM:SS formatted): {formattedDateTime}";

            // Create user login label
            lblUser = new Label();
            lblUser.Location = new Point(600, 900);
            lblUser.Size = new Size(270, 20);
            lblUser.ForeColor = Color.Gray;
            lblUser.Font = new Font("Segoe UI", 8);
            lblUser.TextAlign = ContentAlignment.MiddleRight;
            lblUser.Text = "Current User's Login: Deep-Axe";

            // Add labels to the form
            this.Controls.Add(lblDateTime);
            this.Controls.Add(lblUser);

            // Set the form's AutoScroll property to true to handle overflow
            this.AutoScroll = true;
        }

        private void UpdateDateTime()
        {
            if (lblDateTime != null)
            {
                string formattedDateTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                lblDateTime.Text = $"Current Date and Time (UTC - YYYY-MM-DD HH:MM:SS formatted): {formattedDateTime}";
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
        }
    }
}