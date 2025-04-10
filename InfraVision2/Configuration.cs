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
    public partial class Configuration : Form
    {
        private Label lblDateTime;
        private Label lblUser;
        private DataGridView dgvProfiles;
        private DataGridView dgvHistory;

        public Configuration()
        {
            InitializeComponent();

            // Set form properties
            this.Text = "Server Management System";
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Create all UI elements
            CreateConfigHeader();
            CreateTabsSection();
            CreateActionsPanel();
            CreateProfilesTable();
            CreateHistorySection();
            CreateFooterLabels();

            // Load sample data
            LoadSampleData();

            // Set up a timer to update the date/time periodically
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += (s, e) => UpdateDateTime();
            timer.Start();
        }

        private void CreateConfigHeader()
        {
            // Header label for the Configuration section
            Label lblHeader = new Label();
            lblHeader.Text = "CONFIGURATION";
            lblHeader.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblHeader.Location = new Point(20, 20);
            lblHeader.Size = new Size(200, 25);
            this.Controls.Add(lblHeader);
        }

        private void CreateTabsSection()
        {
            // Tabs for different configuration views
            Button btnProfiles = new Button();
            btnProfiles.Text = "Profiles";
            btnProfiles.Location = new Point(20, 60);
            btnProfiles.Size = new Size(180, 35);
            btnProfiles.BackColor = Color.FromArgb(240, 240, 240);
            btnProfiles.FlatStyle = FlatStyle.Flat;
            btnProfiles.Click += (s, e) => {
                // Already on profiles view
            };

            Button btnTemplates = new Button();
            btnTemplates.Text = "Templates";
            btnTemplates.Location = new Point(210, 60);
            btnTemplates.Size = new Size(150, 35);
            btnTemplates.FlatStyle = FlatStyle.Flat;
            btnTemplates.Click += (s, e) => {
                MessageBox.Show("Templates view would be displayed here", "Templates");
            };

            Button btnHistory = new Button();
            btnHistory.Text = "History";
            btnHistory.Location = new Point(370, 60);
            btnHistory.Size = new Size(180, 35);
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Click += (s, e) => {
                // Show history section by scrolling down
                this.AutoScrollPosition = new Point(0, 400);
            };

            this.Controls.AddRange(new Control[] { btnProfiles, btnTemplates, btnHistory });
        }

        private void CreateActionsPanel()
        {
            // Actions panel
            Panel pnlActions = new Panel();
            pnlActions.Location = new Point(20, 110);
            pnlActions.Size = new Size(900, 50);
            pnlActions.BorderStyle = BorderStyle.FixedSingle;

            // New Profile button
            Button btnNewProfile = new Button();
            btnNewProfile.Text = "[+] New Profile";
            btnNewProfile.Location = new Point(10, 10);
            btnNewProfile.Size = new Size(120, 30);
            btnNewProfile.Click += (s, e) => {
                MessageBox.Show("New profile dialog would open here", "New Profile");
            };

            // Clone button
            Button btnClone = new Button();
            btnClone.Text = "[📋] Clone";
            btnClone.Location = new Point(140, 10);
            btnClone.Size = new Size(100, 30);
            btnClone.Click += (s, e) => {
                if (dgvProfiles.SelectedRows.Count > 0)
                {
                    string profileName = dgvProfiles.SelectedRows[0].Cells["ProfileName"].Value.ToString();
                    MessageBox.Show($"Clone {profileName} dialog would open here", "Clone Profile");
                }
                else
                {
                    MessageBox.Show("Please select a profile to clone", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            // Refresh button
            Button btnRefresh = new Button();
            btnRefresh.Text = "[↻] Refresh";
            btnRefresh.Location = new Point(250, 10);
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.Click += (s, e) => {
                LoadSampleData();
                MessageBox.Show("Data refreshed", "Refresh");
            };

            pnlActions.Controls.AddRange(new Control[] {
                btnNewProfile, btnClone, btnRefresh
            });

            this.Controls.Add(pnlActions);
        }

        private void CreateProfilesTable()
        {
            // DataGridView for configuration profiles
            dgvProfiles = new DataGridView();
            dgvProfiles.Location = new Point(20, 170);
            dgvProfiles.Size = new Size(900, 180);
            dgvProfiles.ReadOnly = true;
            dgvProfiles.AllowUserToAddRows = false;
            dgvProfiles.AllowUserToDeleteRows = false;
            dgvProfiles.AllowUserToResizeRows = false;
            dgvProfiles.RowHeadersVisible = false;
            dgvProfiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfiles.BackgroundColor = Color.White;
            dgvProfiles.BorderStyle = BorderStyle.Fixed3D;
            dgvProfiles.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProfiles.RowTemplate.Height = 30;
            dgvProfiles.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);

            // Create columns for profiles grid
            dgvProfiles.Columns.Add("ProfileName", "Profile Name");
            dgvProfiles.Columns.Add("Description", "Description");
            dgvProfiles.Columns.Add("Servers", "Servers");
            dgvProfiles.Columns.Add("LastModified", "Last Modified");

            // Set column widths
            dgvProfiles.Columns["ProfileName"].Width = 200;
            dgvProfiles.Columns["Description"].Width = 300;
            dgvProfiles.Columns["Servers"].Width = 150;
            dgvProfiles.Columns["LastModified"].Width = 150;

            // Set up click handler for profiles
            dgvProfiles.CellClick += DgvProfiles_CellClick;

            this.Controls.Add(dgvProfiles);
        }

        private void DgvProfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected profile's information
                string profileName = dgvProfiles.Rows[e.RowIndex].Cells["ProfileName"].Value.ToString();
                string description = dgvProfiles.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                string servers = dgvProfiles.Rows[e.RowIndex].Cells["Servers"].Value.ToString();
                string lastModified = dgvProfiles.Rows[e.RowIndex].Cells["LastModified"].Value.ToString();

                // Show confirmation dialog
                DialogResult result = MessageBox.Show(
                    $"Do you want to view the compliance details for {profileName}?",
                    "View Configuration Profile",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // If user clicks Yes, open the details form
                if (result == DialogResult.Yes)
                {
                    ShowProfileDetailsForm(profileName, description, servers, lastModified);
                }
            }
        }

        private void ShowProfileDetailsForm(string profileName, string description, string servers, string lastModified)
        {
            // Create and show the profile details form
            using (ConfigProfileDetailsForm detailsForm = new ConfigProfileDetailsForm(profileName, description, servers, lastModified))
            {
                detailsForm.ShowDialog(this);
            }
        }

        private void CreateHistorySection()
        {
            // History section header
            Label lblHistoryHeader = new Label();
            lblHistoryHeader.Text = "Configuration History";
            lblHistoryHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblHistoryHeader.Location = new Point(20, 360);
            lblHistoryHeader.Size = new Size(200, 20);
            this.Controls.Add(lblHistoryHeader);

            // Filter panel
            Panel pnlHistoryFilter = new Panel();
            pnlHistoryFilter.Location = new Point(20, 390);
            pnlHistoryFilter.Size = new Size(900, 40);
            pnlHistoryFilter.BorderStyle = BorderStyle.FixedSingle;

            Label lblServer = new Label();
            lblServer.Text = "Server:";
            lblServer.Location = new Point(10, 12);
            lblServer.Size = new Size(50, 20);

            ComboBox cboServer = new ComboBox();
            cboServer.Text = "Select Server ▼";
            cboServer.Location = new Point(70, 8);
            cboServer.Size = new Size(150, 25);
            cboServer.Items.AddRange(new object[] { "All Servers", "DB-01", "DB-02", "WEB-01", "APP-01" });

            Label lblProfile = new Label();
            lblProfile.Text = "Profile:";
            lblProfile.Location = new Point(280, 12);
            lblProfile.Size = new Size(50, 20);

            ComboBox cboProfile = new ComboBox();
            cboProfile.Text = "Select Profile ▼";
            cboProfile.Location = new Point(340, 8);
            cboProfile.Size = new Size(150, 25);
            cboProfile.Items.AddRange(new object[] { "All Profiles", "Database-Standard", "WebServer-Prod", "AppServer-Base" });

            pnlHistoryFilter.Controls.AddRange(new Control[] {
                lblServer, cboServer, lblProfile, cboProfile
            });

            this.Controls.Add(pnlHistoryFilter);

            // History grid
            dgvHistory = new DataGridView();
            dgvHistory.Location = new Point(20, 440);
            dgvHistory.Size = new Size(900, 120);
            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.AllowUserToResizeRows = false;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.Fixed3D;
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.RowTemplate.Height = 30;
            dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);

            // Create columns for history grid
            dgvHistory.Columns.Add("DateTime", "Date/Time");
            dgvHistory.Columns.Add("User", "User");
            dgvHistory.Columns.Add("ChangeType", "Change Type");
            dgvHistory.Columns.Add("Version", "Version");

            // Set column widths
            dgvHistory.Columns["DateTime"].Width = 200;
            dgvHistory.Columns["User"].Width = 150;
            dgvHistory.Columns["ChangeType"].Width = 200;
            dgvHistory.Columns["Version"].Width = 150;

            this.Controls.Add(dgvHistory);
        }

        private void CreateFooterLabels()
        {
            // Create date/time label
            lblDateTime = new Label();
            lblDateTime.Location = new Point(20, 575);
            lblDateTime.Size = new Size(500, 20);
            lblDateTime.ForeColor = Color.Gray;
            lblDateTime.Font = new Font("Segoe UI", 8);

            // Get current date/time and format it
            string formattedDateTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            lblDateTime.Text = $"Current Date and Time (UTC - YYYY-MM-DD HH:MM:SS formatted): {formattedDateTime}";

            // Create user login label
            lblUser = new Label();
            lblUser.Location = new Point(600, 575);
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
            // Load profiles data
            if (dgvProfiles != null)
            {
                dgvProfiles.Rows.Clear();

                dgvProfiles.Rows.Add("Database-Standard", "Standard DB conf", "8", "Yesterday");
                dgvProfiles.Rows.Add("WebServer-Prod", "Production web", "12", "3 days ago");
                dgvProfiles.Rows.Add("AppServer-Base", "Base app server", "15", "1 week ago");
                dgvProfiles.Rows.Add("Monitoring-Base", "Monitoring agents", "42", "2 weeks ago");
                dgvProfiles.Rows.Add("Security-Standard", "Security baseline", "30", "1 month ago");
            }

            // Load history data
            if (dgvHistory != null)
            {
                dgvHistory.Rows.Clear();

                dgvHistory.Rows.Add("2025-03-22 15:40:22", "Deep-Axe", "Update", "2.3 → 2.4");
                dgvHistory.Rows.Add("2025-03-18 09:12:05", "jsmith", "Security Patch", "2.2 → 2.3");
                dgvHistory.Rows.Add("2025-03-10 14:55:33", "agarcia", "Performance", "2.1 → 2.2");
            }
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
        }
    }

    // Configuration Profile Details Form
    public class ConfigProfileDetailsForm : Form
    {
        public ConfigProfileDetailsForm(string profileName, string description, string servers, string lastModified)
        {
            // Set form properties
            this.Text = $"Configuration Profile: {profileName}";
            this.Size = new Size(650, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Create the profile details UI
            CreateProfileDetailsUI(profileName, description, servers, lastModified);
        }

        private void CreateProfileDetailsUI(string profileName, string description, string servers, string lastModified)
        {
            // ========== PROFILE INFORMATION PANEL (LEFT) ==========
            GroupBox grpProfileInfo = new GroupBox();
            grpProfileInfo.Text = "Profile Information";
            grpProfileInfo.Location = new Point(20, 20);
            grpProfileInfo.Size = new Size(260, 180);

            // Created date (mock data)
            Label lblCreated = new Label();
            lblCreated.Text = "Created: 2024-11-15";
            lblCreated.Location = new Point(15, 30);
            lblCreated.Size = new Size(230, 20);
            lblCreated.Font = new Font("Segoe UI", 9);

            // Created by
            Label lblCreatedBy = new Label();
            lblCreatedBy.Text = "By: Deep-Axe";
            lblCreatedBy.Location = new Point(15, 55);
            lblCreatedBy.Size = new Size(230, 20);
            lblCreatedBy.Font = new Font("Segoe UI", 9);

            // Version
            Label lblVersion = new Label();
            lblVersion.Text = "Version: 2.4";
            lblVersion.Location = new Point(15, 80);
            lblVersion.Size = new Size(230, 20);
            lblVersion.Font = new Font("Segoe UI", 9);

            // Last modified date
            string modifiedDate = "2025-03-22 15:40:22";
            if (lastModified == "Yesterday")
                modifiedDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
            else if (lastModified.Contains("days"))
                modifiedDate = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss");

            Label lblLastModified = new Label();
            lblLastModified.Text = $"Last Modified:\r\n{modifiedDate}";
            lblLastModified.Location = new Point(15, 105);
            lblLastModified.Size = new Size(230, 40);
            lblLastModified.Font = new Font("Segoe UI", 9);

            // Modified by
            Label lblModifiedBy = new Label();
            lblModifiedBy.Text = "Modified By: Deep-Axe";
            lblModifiedBy.Location = new Point(15, 150);
            lblModifiedBy.Size = new Size(230, 20);
            lblModifiedBy.Font = new Font("Segoe UI", 9);

            // Add labels to the group box
            grpProfileInfo.Controls.AddRange(new Control[] {
                lblCreated, lblCreatedBy, lblVersion, lblLastModified, lblModifiedBy
            });

            // ========== ASSIGNED SERVERS PANEL (RIGHT) ==========
            GroupBox grpServers = new GroupBox();
            grpServers.Text = $"Assigned Servers ({servers})";
            grpServers.Location = new Point(300, 20);
            grpServers.Size = new Size(310, 180);

            // Assigned servers list (generate based on profile name)
            string[] serverList;
            if (profileName.Contains("Database"))
            {
                serverList = new string[] {
                    "DB-01", "DB-02", "DB-BACKUP-01", "DB-BACKUP-02",
                    "DB-REPLICA-01", "DB-REPLICA-02", "DB-DEV-01", "DB-DEV-02"
                };
            }
            else if (profileName.Contains("Web"))
            {
                serverList = new string[] {
                    "WEB-01", "WEB-02", "WEB-03", "WEB-04", "WEB-05",
                    "WEB-06", "WEB-STAGING-01", "WEB-STAGING-02",
                    "WEB-DEV-01", "WEB-DEV-02", "WEB-CACHE-01", "WEB-CACHE-02"
                };
            }
            else if (profileName.Contains("App"))
            {
                serverList = new string[] {
                    "APP-01", "APP-02", "APP-03", "APP-04", "APP-05",
                    "APP-06", "APP-07", "APP-08", "APP-09", "APP-10",
                    "APP-STAGING-01", "APP-STAGING-02", "APP-DEV-01",
                    "APP-DEV-02", "APP-DEV-03"
                };
            }
            else if (profileName.Contains("Monitor"))
            {
                serverList = new string[] { "All Servers (42)" };
            }
            else
            {
                serverList = new string[] {
                    "Various servers", "See documentation",
                    "for complete list"
                };
            }

            // Create server list
            string serverText = "";
            int count = Math.Min(serverList.Length, 8); // Show max 8 servers
            for (int i = 0; i < count; i++)
            {
                serverText += $"• {serverList[i]}\r\n";
            }

            Label lblServerList = new Label();
            lblServerList.Text = serverText;
            lblServerList.Location = new Point(15, 30);
            lblServerList.Size = new Size(280, 140);
            lblServerList.Font = new Font("Segoe UI", 9);

            grpServers.Controls.Add(lblServerList);

            // ========== CONFIGURATION DATA SECTION ==========
            Label lblConfigDataTitle = new Label();
            lblConfigDataTitle.Text = "Configuration Data:";
            lblConfigDataTitle.Location = new Point(20, 210);
            lblConfigDataTitle.Size = new Size(150, 20);
            lblConfigDataTitle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Get appropriate sample JSON based on profile type
            string jsonConfig = GetSampleConfigJson(profileName);

            // JSON config display in a rich text box with a border
            Panel pnlConfig = new Panel();
            pnlConfig.Location = new Point(20, 235);
            pnlConfig.Size = new Size(590, 200);
            pnlConfig.BorderStyle = BorderStyle.FixedSingle;

            RichTextBox rtbConfigData = new RichTextBox();
            rtbConfigData.Text = jsonConfig;
            rtbConfigData.Location = new Point(2, 2);
            rtbConfigData.Size = new Size(584, 194);
            rtbConfigData.ReadOnly = true;
            rtbConfigData.Font = new Font("Consolas", 9);
            rtbConfigData.BorderStyle = BorderStyle.None;
            rtbConfigData.BackColor = Color.White;

            pnlConfig.Controls.Add(rtbConfigData);

            // ========== ACTION BUTTONS ==========
            Button btnEditProfile = new Button();
            btnEditProfile.Text = "Edit Profile";
            btnEditProfile.Location = new Point(20, 450);
            btnEditProfile.Size = new Size(120, 30);
            btnEditProfile.Click += (s, e) => MessageBox.Show("Edit profile dialog would open here", "Edit Profile");

            Button btnApplyToServer = new Button();
            btnApplyToServer.Text = "Apply to Server";
            btnApplyToServer.Location = new Point(160, 450);
            btnApplyToServer.Size = new Size(120, 30);
            btnApplyToServer.Click += (s, e) => MessageBox.Show("Apply to server dialog would open here", "Apply to Server");

            Button btnCompareVersions = new Button();
            btnCompareVersions.Text = "Compare Versions";
            btnCompareVersions.Location = new Point(300, 450);
            btnCompareVersions.Size = new Size(150, 30);
            btnCompareVersions.Click += (s, e) => MessageBox.Show("Version comparison dialog would open here", "Compare Versions");

            // Add all controls to the form
            this.Controls.AddRange(new Control[] {
                grpProfileInfo,
                grpServers,
                lblConfigDataTitle,
                pnlConfig,
                btnEditProfile,
                btnApplyToServer,
                btnCompareVersions
            });
        }

        private string GetSampleConfigJson(string profileName)
        {
            if (profileName.Contains("Database"))
            {
                return "{\r\n" +
                       "  \"database\": {\r\n" +
                       "    \"max_connections\": 500,\r\n" +
                       "    \"query_cache_size\": \"256M\",\r\n" +
                       "    \"innodb_buffer_pool_size\": \"8G\",\r\n" +
                       "    \"log_retention_days\": 14\r\n" +
                       "  },\r\n" +
                       "  \"security\": {\r\n" +
                       "    \"remote_access\": false,\r\n" +
                       "    \"encryption_enabled\": true\r\n" +
                       "  }\r\n" +
                       "}";
            }
            else if (profileName.Contains("Web"))
            {
                return "{\r\n" +
                       "  \"http\": {\r\n" +
                       "    \"port\": 80,\r\n" +
                       "    \"ssl_port\": 443,\r\n" +
                       "    \"max_clients\": 2000,\r\n" +
                       "    \"timeout\": 60\r\n" +
                       "  },\r\n" +
                       "  \"ssl\": {\r\n" +
                       "    \"enabled\": true,\r\n" +
                       "    \"cert_path\": \"/etc/ssl/certs/\",\r\n" +
                       "    \"protocols\": [\"TLSv1.2\", \"TLSv1.3\"]\r\n" +
                       "  },\r\n" +
                       "  \"cache\": {\r\n" +
                       "    \"enabled\": true,\r\n" +
                       "    \"max_size\": \"4G\"\r\n" +
                       "  }\r\n" +
                       "}";
            }
            else if (profileName.Contains("App"))
            {
                return "{\r\n" +
                       "  \"application\": {\r\n" +
                       "    \"workers\": 8,\r\n" +
                       "    \"queue_size\": 1000,\r\n" +
                       "    \"log_level\": \"info\",\r\n" +
                       "    \"debug_mode\": false\r\n" +
                       "  },\r\n" +
                       "  \"resources\": {\r\n" +
                       "    \"max_memory\": \"16G\",\r\n" +
                       "    \"max_cpu\": 8,\r\n" +
                       "    \"max_file_descriptors\": 65535\r\n" +
                       "  },\r\n" +
                       "  \"dependencies\": {\r\n" +
                       "    \"database\": \"DB-01\",\r\n" +
                       "    \"cache\": \"CACHE-01\"\r\n" +
                       "  }\r\n" +
                       "}";
            }
            else if (profileName.Contains("Monitor"))
            {
                return "{\r\n" +
                       "  \"monitoring\": {\r\n" +
                       "    \"interval\": 60,\r\n" +
                       "    \"retention_days\": 30,\r\n" +
                       "    \"metrics\": [\"cpu\", \"memory\", \"disk\", \"network\"]\r\n" +
                       "  },\r\n" +
                       "  \"alerts\": {\r\n" +
                       "    \"enabled\": true,\r\n" +
                       "    \"endpoints\": [\"email\", \"sms\", \"api\"],\r\n" +
                       "    \"thresholds\": {\r\n" +
                       "      \"cpu_warning\": 80,\r\n" +
                       "      \"cpu_critical\": 95,\r\n" +
                       "      \"memory_warning\": 80,\r\n" +
                       "      \"memory_critical\": 90\r\n" +
                       "    }\r\n" +
                       "  }\r\n" +
                       "}";
            }
            else // Security profile
            {
                return "{\r\n" +
                       "  \"firewall\": {\r\n" +
                       "    \"enabled\": true,\r\n" +
                       "    \"allowed_ports\": [22, 80, 443, 3306],\r\n" +
                       "    \"blocked_countries\": [\"XX\", \"YY\", \"ZZ\"]\r\n" +
                       "  },\r\n" +
                       "  \"authentication\": {\r\n" +
                       "    \"min_password_length\": 12,\r\n" +
                       "    \"require_mfa\": true,\r\n" +
                       "    \"password_expiry_days\": 90,\r\n" +
                       "    \"failed_login_lockout\": 5\r\n" +
                       "  },\r\n" +
                       "  \"updates\": {\r\n" +
                       "    \"auto_security_updates\": true,\r\n" +
                       "    \"scan_frequency\": \"daily\"\r\n" +
                       "  }\r\n" +
                       "}";
            }
        }
    }
}