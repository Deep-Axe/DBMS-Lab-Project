using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace InfraVision2
{
    public partial class Users : Form
    {
        private Label lblDateTime;
        private Label lblUser;
        private DataGridView dgvUsers;
        private DataGridView dgvRoles;

        public Users()
        {
            InitializeComponent();

            // Set form properties
            this.Text = "Server Management System";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Create all UI elements
            CreateHeaderSection();
            CreateUserSection();
            CreateRoleSection();
            CreateFooterLabels();

            // Load sample data
            LoadSampleData();

            // Set up a timer to update the date/time periodically
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += (s, e) => UpdateDateTime();
            timer.Start();
        }

        private void CreateHeaderSection()
        {
            // Main header for the page
            Label lblHeader = new Label();
            lblHeader.Text = "USERS & ACCESS CONTROL";
            lblHeader.Location = new Point(20, 20);
            lblHeader.Size = new Size(300, 25);
            lblHeader.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.Controls.Add(lblHeader);
        }

        private void CreateUserSection()
        {
            // Users label
            Label lblUsers = new Label();
            lblUsers.Text = "Users";
            lblUsers.Location = new Point(20, 60);
            lblUsers.Size = new Size(100, 20);
            lblUsers.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.Controls.Add(lblUsers);

            // Search textbox
            TextBox txtSearch = new TextBox();
            txtSearch.Text = "Search users...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(580, 60);
            txtSearch.Size = new Size(250, 23);

            // Events for placeholder text behavior
            txtSearch.Enter += (s, e) => {
                if (txtSearch.Text == "Search users...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search users...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            this.Controls.Add(txtSearch);

            // User actions panel
            Panel pnlUserActions = new Panel();
            pnlUserActions.Location = new Point(20, 90);
            pnlUserActions.Size = new Size(850, 40);
            pnlUserActions.BorderStyle = BorderStyle.FixedSingle;

            // Add User button
            Button btnAddUser = new Button();
            btnAddUser.Text = "[+] Add User";
            btnAddUser.Location = new Point(10, 5);
            btnAddUser.Size = new Size(120, 30);
            btnAddUser.Click += (s, e) => MessageBox.Show("Add User dialog would open here", "Add User");

            // Bulk Import button
            Button btnBulkImport = new Button();
            btnBulkImport.Text = "[👥] Bulk Import";
            btnBulkImport.Location = new Point(140, 5);
            btnBulkImport.Size = new Size(120, 30);
            btnBulkImport.Click += (s, e) => MessageBox.Show("Bulk Import dialog would open here", "Bulk Import");

            // Refresh button
            Button btnRefresh = new Button();
            btnRefresh.Text = "[↻] Refresh";
            btnRefresh.Location = new Point(270, 5);
            btnRefresh.Size = new Size(120, 30);
            btnRefresh.Click += (s, e) => {
                LoadSampleData();
                MessageBox.Show("Data refreshed successfully.", "Refresh");
            };

            // Add buttons to panel
            pnlUserActions.Controls.AddRange(new Control[] {
                btnAddUser, btnBulkImport, btnRefresh
            });

            this.Controls.Add(pnlUserActions);

            // Users DataGridView
            dgvUsers = new DataGridView();
            dgvUsers.Location = new Point(20, 140);
            dgvUsers.Size = new Size(850, 180);
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.Fixed3D;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.RowTemplate.Height = 30;
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);

            // Create columns for users grid
            dgvUsers.Columns.Add("Username", "Username");
            dgvUsers.Columns.Add("FullName", "Full Name");
            dgvUsers.Columns.Add("Role", "Role");
            dgvUsers.Columns.Add("Status", "Status");
            dgvUsers.Columns.Add("LastLogin", "Last Login");

            // Set column widths
            dgvUsers.Columns["Username"].Width = 150;
            dgvUsers.Columns["FullName"].Width = 200;
            dgvUsers.Columns["Role"].Width = 150;
            dgvUsers.Columns["Status"].Width = 100;
            dgvUsers.Columns["LastLogin"].Width = 150;

            // Click handler for user details (changed from double-click to single-click)
            dgvUsers.CellClick += DgvUsers_CellClick;

            this.Controls.Add(dgvUsers);
        }

        // New method to handle the user click with confirmation dialog
        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected user's information
                string username = dgvUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                string fullName = dgvUsers.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                string role = dgvUsers.Rows[e.RowIndex].Cells["Role"].Value.ToString();
                string status = dgvUsers.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                string lastLogin = dgvUsers.Rows[e.RowIndex].Cells["LastLogin"].Value.ToString();

                // Show confirmation dialog
                DialogResult result = MessageBox.Show(
                    $"Would you like to see details for user {username}?",
                    "Show User Details",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // If user clicks Yes, open the details form
                if (result == DialogResult.Yes)
                {
                    OpenUserDetailsForm(username, fullName, role, status, lastLogin);
                }
            }
        }

        // New method to open the user details form
        private void OpenUserDetailsForm(string username, string fullName, string role, string status, string lastLogin)
        {
            // Create and show the user details form
            using (UserDetailsForm detailsForm = new UserDetailsForm(username, fullName, role, status, lastLogin))
            {
                detailsForm.ShowDialog(this);
            }
        }

        private void CreateRoleSection()
        {
            // Role Management label
            Label lblRoleManagement = new Label();
            lblRoleManagement.Text = "Role Management";
            lblRoleManagement.Location = new Point(20, 330);
            lblRoleManagement.Size = new Size(200, 20);
            lblRoleManagement.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.Controls.Add(lblRoleManagement);

            // Role actions panel
            Panel pnlRoleActions = new Panel();
            pnlRoleActions.Location = new Point(20, 360);
            pnlRoleActions.Size = new Size(850, 40);
            pnlRoleActions.BorderStyle = BorderStyle.FixedSingle;

            // Add Role button
            Button btnAddRole = new Button();
            btnAddRole.Text = "[+] Add Role";
            btnAddRole.Location = new Point(10, 5);
            btnAddRole.Size = new Size(120, 30);
            btnAddRole.Click += (s, e) => MessageBox.Show("Add Role dialog would open here", "Add Role");

            // Edit Permissions button
            Button btnEditPermissions = new Button();
            btnEditPermissions.Text = "[✏️] Edit Permissions";
            btnEditPermissions.Location = new Point(140, 5);
            btnEditPermissions.Size = new Size(150, 30);
            btnEditPermissions.Click += (s, e) => MessageBox.Show("Edit Permissions dialog would open here", "Edit Permissions");

            // Add buttons to panel
            pnlRoleActions.Controls.AddRange(new Control[] {
                btnAddRole, btnEditPermissions
            });

            this.Controls.Add(pnlRoleActions);

            // Roles DataGridView
            dgvRoles = new DataGridView();
            dgvRoles.Location = new Point(20, 410);
            dgvRoles.Size = new Size(850, 170);
            dgvRoles.ReadOnly = true;
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.AllowUserToResizeRows = false;
            dgvRoles.RowHeadersVisible = false;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.BackgroundColor = Color.White;
            dgvRoles.BorderStyle = BorderStyle.Fixed3D;
            dgvRoles.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRoles.RowTemplate.Height = 30;
            dgvRoles.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);

            // Create columns for roles grid
            dgvRoles.Columns.Add("RoleName", "Role Name");
            dgvRoles.Columns.Add("PermissionLevel", "Permission Level");
            dgvRoles.Columns.Add("UserCount", "# Users");
            dgvRoles.Columns.Add("Description", "Description");

            // Set column widths
            dgvRoles.Columns["RoleName"].Width = 150;
            dgvRoles.Columns["PermissionLevel"].Width = 150;
            dgvRoles.Columns["UserCount"].Width = 100;
            dgvRoles.Columns["Description"].Width = 400;

            this.Controls.Add(dgvRoles);
        }

        private void CreateFooterLabels()
        {
            // Create date/time label
            lblDateTime = new Label();
            lblDateTime.Location = new Point(20, 590);
            lblDateTime.Size = new Size(500, 20);
            lblDateTime.ForeColor = Color.Gray;
            lblDateTime.Font = new Font("Segoe UI", 8);

            // Get current date/time and format it
            string formattedDateTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            lblDateTime.Text = $"Current Date and Time (UTC - YYYY-MM-DD HH:MM:SS formatted): {formattedDateTime}";

            // Create user login label
            lblUser = new Label();
            lblUser.Location = new Point(600, 590);
            lblUser.Size = new Size(270, 20);
            lblUser.ForeColor = Color.Gray;
            lblUser.Font = new Font("Segoe UI", 8);
            lblUser.TextAlign = ContentAlignment.MiddleRight;
            lblUser.Text = "Current User's Login: Deep-Axe";

            // Add labels to the form
            this.Controls.Add(lblDateTime);
            this.Controls.Add(lblUser);
        }

        private void UpdateDateTime()
        {
            if (lblDateTime != null)
            {
                string formattedDateTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                lblDateTime.Text = $"Current Date and Time (UTC - YYYY-MM-DD HH:MM:SS formatted): {formattedDateTime}";
            }
        }

        private void LoadSampleData()
        {
            // Clear existing data
            if (dgvUsers != null && dgvUsers.Rows.Count > 0)
                dgvUsers.Rows.Clear();

            if (dgvRoles != null && dgvRoles.Rows.Count > 0)
                dgvRoles.Rows.Clear();

            // Load sample user data
            if (dgvUsers != null)
            {
                dgvUsers.Rows.Add("Deep-Axe", "Deep Axelrod", "Admin", "Active", "Now");
                dgvUsers.Rows.Add("jsmith", "John Smith", "Operator", "Active", "1hr ago");
                dgvUsers.Rows.Add("agarcia", "Ana Garcia", "Manager", "Active", "Yesterday");
                dgvUsers.Rows.Add("tchen", "Tao Chen", "Viewer", "Active", "3 days ago");
                dgvUsers.Rows.Add("mwilson", "Mike Wilson", "Operator", "Locked", "15 days");

                // Style the "Locked" status cell with red text
                foreach (DataGridViewRow row in dgvUsers.Rows)
                {
                    if (row.Cells["Status"].Value.ToString() == "Locked")
                    {
                        row.Cells["Status"].Style.ForeColor = Color.Red;
                        row.Cells["Status"].Style.Font = new Font(dgvUsers.Font, FontStyle.Bold);
                    }
                }
            }

            // Load sample role data
            if (dgvRoles != null)
            {
                dgvRoles.Rows.Add("Admin", "9", "3", "Full system access");
                dgvRoles.Rows.Add("Manager", "7", "5", "Department manager");
                dgvRoles.Rows.Add("Operator", "5", "12", "Day-to-day operations");
                dgvRoles.Rows.Add("Viewer", "1", "8", "Read-only access");
            }
        }

        // This is the event handler referenced in the InitializeComponent method
        private void Users_Load(object sender, EventArgs e)
        {
            // This can be empty since we're doing initialization in the constructor
        }
    }

    // User Details Form Class
    public class UserDetailsForm : Form
    {
        public UserDetailsForm(string username, string fullName, string role, string status, string lastLogin)
        {
            // Set form properties
            this.Text = $"User Details: {username}";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Create the user details UI
            CreateUserDetailsUI(username, fullName, role, status, lastLogin);
        }

        private void CreateUserDetailsUI(string username, string fullName, string role, string status, string lastLogin)
        {
            this.Size = new Size(600, 480);
            GroupBox grpUserInfo = new GroupBox();
            grpUserInfo.Text = "User Information";
            grpUserInfo.Location = new Point(20, 20);
            grpUserInfo.Size = new Size(260, 180);

            // Create labels for user information
            Label lblFullName = new Label();
            lblFullName.Text = $"Full Name: {fullName}";
            lblFullName.Location = new Point(15, 30);
            lblFullName.Size = new Size(230, 20);
            lblFullName.Font = new Font("Segoe UI", 9);

            // Add email (mock data)
            Label lblEmail = new Label();
            lblEmail.Text = $"Email: {username.ToLower()}@comp.com";
            lblEmail.Location = new Point(15, 55);
            lblEmail.Size = new Size(230, 20);
            lblEmail.Font = new Font("Segoe UI", 9);

            // Status
            Label lblStatus = new Label();
            lblStatus.Text = $"Status: {status}";
            lblStatus.Location = new Point(15, 80);
            lblStatus.Size = new Size(230, 20);
            lblStatus.Font = new Font("Segoe UI", 9);
            if (status == "Locked")
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }

            // 2FA Status (mock data)
            Label lbl2FA = new Label();
            lbl2FA.Text = "2FA: Enabled";
            lbl2FA.Location = new Point(15, 105);
            lbl2FA.Size = new Size(230, 20);
            lbl2FA.Font = new Font("Segoe UI", 9);

            // Last Password Change (mock data)
            Label lblLastPwdChange = new Label();
            lblLastPwdChange.Text = "Last Pwd Change:\r\n2025-02-15";
            lblLastPwdChange.Location = new Point(15, 130);
            lblLastPwdChange.Size = new Size(230, 40);
            lblLastPwdChange.Font = new Font("Segoe UI", 9);

            // Add labels to the group box
            grpUserInfo.Controls.AddRange(new Control[] {
                lblFullName, lblEmail, lblStatus, lbl2FA, lblLastPwdChange
            });

            // ========== ACCESS CONTROL PANEL (RIGHT) ==========
            GroupBox grpAccessControl = new GroupBox();
            grpAccessControl.Text = "Access Control";
            grpAccessControl.Location = new Point(300, 20);
            grpAccessControl.Size = new Size(260, 180);

            Label lblRole = new Label();
            lblRole.Text = $"Role: {role}";
            lblRole.Location = new Point(15, 30);
            lblRole.Size = new Size(230, 20);
            lblRole.Font = new Font("Segoe UI", 9);

            Label lblAssigned = new Label();
            lblAssigned.Text = "Assigned: 2024-05-10";
            lblAssigned.Location = new Point(15, 55);
            lblAssigned.Size = new Size(230, 20);
            lblAssigned.Font = new Font("Segoe UI", 9);

            Button btnEditPermissions = new Button();
            btnEditPermissions.Text = "Edit Permissions";
            btnEditPermissions.Location = new Point(15, 90);
            btnEditPermissions.Size = new Size(140, 30);
            btnEditPermissions.Click += (s, e) => MessageBox.Show("Edit permissions dialog would open here", "Edit Permissions");

            Label lblApiKey = new Label();
            lblApiKey.Text = "API Key: ••••••••••";
            lblApiKey.Location = new Point(15, 135);
            lblApiKey.Size = new Size(120, 20);
            lblApiKey.Font = new Font("Segoe UI", 9);

            Button btnRegenerateKey = new Button();
            btnRegenerateKey.Text = "Regenerate";
            btnRegenerateKey.Location = new Point(140, 130);
            btnRegenerateKey.Size = new Size(100, 30);
            btnRegenerateKey.Click += (s, e) => MessageBox.Show("API key would be regenerated here", "Regenerate API Key");

            grpAccessControl.Controls.AddRange(new Control[] {
                lblRole, lblAssigned, btnEditPermissions, lblApiKey, btnRegenerateKey
            });

            GroupBox grpActivity = new GroupBox();
            grpActivity.Text = "Recent Activity";
            grpActivity.Location = new Point(20, 210);
            grpActivity.Size = new Size(540, 150);

            Label lblRecentActivity = new Label();
            lblRecentActivity.Text = "• Login - 2025-03-23 14:15:22 - 192.168.4.56\r\n" +
                                    "• Config Change - 2025-03-23 10:45:08 - SERVER-05\r\n" +
                                    "• Alert ACK - 2025-03-22 21:12:45 - Critical CPU Alert";
            lblRecentActivity.Location = new Point(15, 25);
            lblRecentActivity.Size = new Size(510, 110);
            lblRecentActivity.Font = new Font("Segoe UI", 9);

            grpActivity.Controls.Add(lblRecentActivity);

            Button btnResetPassword = new Button();
            btnResetPassword.Text = "Reset Password";
            btnResetPassword.Location = new Point(20, 380);
            btnResetPassword.Size = new Size(120, 30);
            btnResetPassword.Click += (s, e) => MessageBox.Show("Password reset dialog would open here", "Reset Password");

            Button btnDisableAccount = new Button();
            btnDisableAccount.Text = "Disable Account";
            btnDisableAccount.Location = new Point(150, 380);
            btnDisableAccount.Size = new Size(120, 30);
            btnDisableAccount.Click += (s, e) => {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to disable this account?",
                    "Confirm Disable",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Account would be disabled here", "Disable Account");
                }
            };

            Button btnEditUser = new Button();
            btnEditUser.Text = "Edit User";
            btnEditUser.Location = new Point(280, 380);
            btnEditUser.Size = new Size(120, 30);
            btnEditUser.Click += (s, e) => MessageBox.Show("Edit user dialog would open here", "Edit User");

            Button btnViewAllActivity = new Button();
            btnViewAllActivity.Text = "View All Activity";
            btnViewAllActivity.Location = new Point(410, 380);
            btnViewAllActivity.Size = new Size(150, 30);
            btnViewAllActivity.Click += (s, e) => MessageBox.Show("Activity log would open here", "User Activity");

            // Add all controls to the form
            this.Controls.AddRange(new Control[] {
                grpUserInfo,
                grpAccessControl,
                grpActivity,
                btnResetPassword,
                btnDisableAccount,
                btnEditUser,
                btnViewAllActivity
            });
        }
    
    }
}