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
    public partial class Alerts : Form
    {
        private Label lblDateTime;
        private Label lblUser;
        private Panel pnlActiveAlerts;
        private Panel pnlAlertDefinitions;
        private DataGridView dgvAlerts;
        private DataGridView dgvAlertDefinitions;

        public Alerts()
        {
            InitializeComponent();

            // Set form properties
            this.Text = "Server Management System";
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Create all UI elements
            //CreateHeaderBar();
            //CreateSidebar();
            CreateAlertsHeader();
            CreateFilterSection();
            CreateActiveAlertsSection();
            CreateAlertDefinitionsSection();
           // CreateFooterLabels();

            // Load sample data
            LoadSampleData();

            // Set up a timer to update the date/time periodically
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += (s, e) => UpdateDateTime();
            timer.Start();
        }

      

        private void Alerts_Load(object sender, EventArgs e)
        {

        }

        private void CreateHeaderBar()
        {
            // Header panel
            Panel pnlHeader = new Panel();
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 50;
            pnlHeader.BackColor = Color.FromArgb(240, 240, 240);
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;

            // Title label
            Label lblTitle = new Label();
            lblTitle.Text = "Server Management System";
            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(15, 15);

            // User dropdown
            Button btnUser = new Button();
            btnUser.Text = "Deep-Axe ▼";
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.Location = new Point(800, 12);
            btnUser.Size = new Size(120, 28);
            btnUser.Click += (s, e) => MessageBox.Show("User menu would open here");

            // Icons
            Button btnNotifications = new Button();
            btnNotifications.Text = "🔔";
            btnNotifications.FlatStyle = FlatStyle.Flat;
            btnNotifications.Location = new Point(930, 12);
            btnNotifications.Size = new Size(40, 28);
            btnNotifications.Click += (s, e) => MessageBox.Show("Notifications would open here");

            Button btnSettings = new Button();
            btnSettings.Text = "⚙️";
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Location = new Point(980, 12);
            btnSettings.Size = new Size(40, 28);
            btnSettings.Click += (s, e) => MessageBox.Show("Settings would open here");

            Button btnHelp = new Button();
            btnHelp.Text = "❓";
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.Location = new Point(1030, 12);
            btnHelp.Size = new Size(40, 28);
            btnHelp.Click += (s, e) => MessageBox.Show("Help documentation would open here");

            // Add controls to header panel
            pnlHeader.Controls.AddRange(new Control[] {
                lblTitle, btnUser, btnNotifications, btnSettings, btnHelp
            });

            this.Controls.Add(pnlHeader);
        }

        private void CreateSidebar()
        {
            // Sidebar panel
            Panel pnlSidebar = new Panel();
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 120;
            pnlSidebar.BackColor = Color.FromArgb(50, 50, 80);
            pnlSidebar.Location = new Point(0, 50);
            pnlSidebar.Height = this.ClientSize.Height - 50;

            // Menu items
            string[] menuItems = { "Servers", "Users", "Alerts", "Incidents", "Config", "Reports", "Settings" };
            int yPos = 20;

            foreach (string item in menuItems)
            {
                Button btnMenu = new Button();
                btnMenu.Text = item;
                btnMenu.FlatStyle = FlatStyle.Flat;
                btnMenu.FlatAppearance.BorderSize = 0;
                btnMenu.ForeColor = Color.White;
                btnMenu.BackColor = (item == "Alerts") ? Color.FromArgb(70, 70, 100) : Color.Transparent;
                btnMenu.Location = new Point(0, yPos);
                btnMenu.Size = new Size(120, 40);
                btnMenu.TextAlign = ContentAlignment.MiddleLeft;
                btnMenu.Padding = new Padding(15, 0, 0, 0);

                btnMenu.Click += (s, e) => {
                    MessageBox.Show($"Would navigate to {item} page");
                };

                pnlSidebar.Controls.Add(btnMenu);
                yPos += 50;
            }

            this.Controls.Add(pnlSidebar);
        }

        private void CreateAlertsHeader()
        {
            // Main content area
            Panel pnlContent = new Panel();
            pnlContent.Location = new Point(120, 50);
            pnlContent.Size = new Size(this.ClientSize.Width - 120, this.ClientSize.Height - 50);
            pnlContent.AutoScroll = true;  // Enable scrolling

            // ALERTS header
            Label lblAlertsHeader = new Label();
            lblAlertsHeader.Text = "ALERTS";
            lblAlertsHeader.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblAlertsHeader.Location = new Point(20, 20);
            lblAlertsHeader.Size = new Size(150, 25);
            pnlContent.Controls.Add(lblAlertsHeader);

            // Navigation tabs
            Panel pnlTabs = new Panel();
            pnlTabs.Location = new Point(20, 50);
            pnlTabs.Size = new Size(900, 40);

            Button btnActiveAlerts = new Button();
            btnActiveAlerts.Text = "Active Alerts";
            btnActiveAlerts.FlatStyle = FlatStyle.Flat;
            btnActiveAlerts.Location = new Point(0, 0);
            btnActiveAlerts.Size = new Size(150, 40);
            btnActiveAlerts.BackColor = Color.FromArgb(240, 240, 240);
            btnActiveAlerts.Click += (s, e) => {
                // Scroll to Active Alerts section
                pnlContent.AutoScrollPosition = new Point(0, 0);
            };

            Button btnAlertHistory = new Button();
            btnAlertHistory.Text = "Alert History";
            btnAlertHistory.FlatStyle = FlatStyle.Flat;
            btnAlertHistory.Location = new Point(160, 0);
            btnAlertHistory.Size = new Size(150, 40);
            btnAlertHistory.Click += (s, e) => {
                // Show Alert History in message box
                ShowAlertHistory();
            };

            Button btnAlertDefinitions = new Button();
            btnAlertDefinitions.Text = "Alert Definitions";
            btnAlertDefinitions.FlatStyle = FlatStyle.Flat;
            btnAlertDefinitions.Location = new Point(320, 0);
            btnAlertDefinitions.Size = new Size(180, 40);
            btnAlertDefinitions.Click += (s, e) => {
                // Scroll to Alert Definitions section
                pnlContent.AutoScrollPosition = new Point(0, pnlAlertDefinitions.Location.Y - 100);
            };

            pnlTabs.Controls.AddRange(new Control[] {
                btnActiveAlerts, btnAlertHistory, btnAlertDefinitions
            });

            pnlContent.Controls.Add(pnlTabs);
            this.Controls.Add(pnlContent);
        }

        private void CreateFilterSection()
        {
            // Find the content panel
            Panel pnlContent = (Panel)this.Controls[this.Controls.Count - 1];

            // Filter panel
            Panel pnlFilter = new Panel();
            pnlFilter.Location = new Point(20, 100);
            pnlFilter.Size = new Size(900, 50);
            pnlFilter.BorderStyle = BorderStyle.FixedSingle;

            // Severity filter
            Label lblSeverity = new Label();
            lblSeverity.Text = "Severity:";
            lblSeverity.Location = new Point(20, 15);
            lblSeverity.Size = new Size(70, 20);

            ComboBox cboSeverity = new ComboBox();
            cboSeverity.Text = "All";
            cboSeverity.Location = new Point(90, 12);
            cboSeverity.Size = new Size(100, 25);
            cboSeverity.Items.AddRange(new object[] { "All", "Critical", "Warning", "Info" });

            // Type filter
            Label lblType = new Label();
            lblType.Text = "Type:";
            lblType.Location = new Point(220, 15);
            lblType.Size = new Size(50, 20);

            ComboBox cboType = new ComboBox();
            cboType.Text = "All";
            cboType.Location = new Point(270, 12);
            cboType.Size = new Size(120, 25);
            cboType.Items.AddRange(new object[] { "All", "CPU", "Memory", "Disk", "Network", "Service" });

            // Server filter
            Label lblServer = new Label();
            lblServer.Text = "Server:";
            lblServer.Location = new Point(420, 15);
            lblServer.Size = new Size(60, 20);

            ComboBox cboServer = new ComboBox();
            cboServer.Text = "All";
            cboServer.Location = new Point(480, 12);
            cboServer.Size = new Size(120, 25);
            cboServer.Items.AddRange(new object[] { "All", "APP-01", "APP-02", "APP-03", "DB-01", "WEB-01", "WEB-02", "CACHE-01" });

            pnlFilter.Controls.AddRange(new Control[] {
                lblSeverity, cboSeverity, lblType, cboType, lblServer, cboServer
            });

            pnlContent.Controls.Add(pnlFilter);
        }

        private void CreateActiveAlertsSection()
        {
            // Find the content panel
            Panel pnlContent = (Panel)this.Controls[this.Controls.Count - 1];

            // Active Alerts panel
            pnlActiveAlerts = new Panel();
            pnlActiveAlerts.Location = new Point(20, 160);
            pnlActiveAlerts.Size = new Size(900, 200);

            // DataGridView for active alerts
            dgvAlerts = new DataGridView();
            dgvAlerts.Location = new Point(0, 0);
            dgvAlerts.Size = new Size(900, 200);
            dgvAlerts.ReadOnly = true;
            dgvAlerts.AllowUserToAddRows = false;
            dgvAlerts.AllowUserToDeleteRows = false;
            dgvAlerts.AllowUserToResizeRows = false;
            dgvAlerts.RowHeadersVisible = false;
            dgvAlerts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlerts.BackgroundColor = Color.White;
            dgvAlerts.BorderStyle = BorderStyle.Fixed3D;
            dgvAlerts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAlerts.RowTemplate.Height = 30;
            dgvAlerts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);

            // Create columns for alerts grid
            dgvAlerts.Columns.Add("Severity", "Severity");
            dgvAlerts.Columns.Add("Alert", "Alert");
            dgvAlerts.Columns.Add("Server", "Server");
            dgvAlerts.Columns.Add("Time", "Time");
            dgvAlerts.Columns.Add("Status", "Status");

            // Set column widths
            dgvAlerts.Columns["Severity"].Width = 100;
            dgvAlerts.Columns["Alert"].Width = 250;
            dgvAlerts.Columns["Server"].Width = 150;
            dgvAlerts.Columns["Time"].Width = 150;
            dgvAlerts.Columns["Status"].Width = 120;
            dgvAlerts.CellClick += DgvAlerts_CellClick;

            pnlActiveAlerts.Controls.Add(dgvAlerts);
            pnlContent.Controls.Add(pnlActiveAlerts);
        }

        private void CreateAlertDefinitionsSection()
        {
            // Find the content panel
            Panel pnlContent = (Panel)this.Controls[this.Controls.Count - 1];

            // Alert Definitions section
            pnlAlertDefinitions = new Panel();
            pnlAlertDefinitions.Location = new Point(20, 380);
            pnlAlertDefinitions.Size = new Size(900, 250);

            // Alert Definitions header
            Label lblDefinitionsHeader = new Label();
            lblDefinitionsHeader.Text = "Alert Definitions";
            lblDefinitionsHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblDefinitionsHeader.Location = new Point(0, 0);
            lblDefinitionsHeader.Size = new Size(150, 20);

            // Action buttons panel
            Panel pnlDefinitionActions = new Panel();
            pnlDefinitionActions.Location = new Point(0, 30);
            pnlDefinitionActions.Size = new Size(900, 40);
            pnlDefinitionActions.BorderStyle = BorderStyle.FixedSingle;

            Button btnAddDefinition = new Button();
            btnAddDefinition.Text = "[+] Add Definition";
            btnAddDefinition.Location = new Point(10, 5);
            btnAddDefinition.Size = new Size(140, 30);
            btnAddDefinition.Click += (s, e) => MessageBox.Show("Add Definition dialog would open here");

            Button btnEditSelected = new Button();
            btnEditSelected.Text = "[✏️] Edit Selected";
            btnEditSelected.Location = new Point(160, 5);
            btnEditSelected.Size = new Size(150, 30);
            btnEditSelected.Click += (s, e) => {
                if (dgvAlertDefinitions.SelectedRows.Count > 0)
                {
                    MessageBox.Show("Edit Definition dialog would open here");
                }
                else
                {
                    MessageBox.Show("Please select a definition to edit", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            pnlDefinitionActions.Controls.AddRange(new Control[] {
                btnAddDefinition, btnEditSelected
            });

            // DataGridView for alert definitions
            dgvAlertDefinitions = new DataGridView();
            dgvAlertDefinitions.Location = new Point(0, 80);
            dgvAlertDefinitions.Size = new Size(900, 170);
            dgvAlertDefinitions.ReadOnly = true;
            dgvAlertDefinitions.AllowUserToAddRows = false;
            dgvAlertDefinitions.AllowUserToDeleteRows = false;
            dgvAlertDefinitions.AllowUserToResizeRows = false;
            dgvAlertDefinitions.RowHeadersVisible = false;
            dgvAlertDefinitions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlertDefinitions.BackgroundColor = Color.White;
            dgvAlertDefinitions.BorderStyle = BorderStyle.Fixed3D;
            dgvAlertDefinitions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAlertDefinitions.RowTemplate.Height = 30;
            dgvAlertDefinitions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);

            // Create columns for definitions grid
            dgvAlertDefinitions.Columns.Add("Metric", "Metric");
            dgvAlertDefinitions.Columns.Add("Condition", "Condition");
            dgvAlertDefinitions.Columns.Add("Threshold", "Threshold");
            dgvAlertDefinitions.Columns.Add("Severity", "Severity");
            dgvAlertDefinitions.Columns.Add("Description", "Description");

            // Set column widths
            dgvAlertDefinitions.Columns["Metric"].Width = 150;
            dgvAlertDefinitions.Columns["Condition"].Width = 100;
            dgvAlertDefinitions.Columns["Threshold"].Width = 100;
            dgvAlertDefinitions.Columns["Severity"].Width = 100;
            dgvAlertDefinitions.Columns["Description"].Width = 400;

            // Add all to the definitions panel
            pnlAlertDefinitions.Controls.AddRange(new Control[] {
                lblDefinitionsHeader, pnlDefinitionActions, dgvAlertDefinitions
            });

            pnlContent.Controls.Add(pnlAlertDefinitions);
        }

        private void CreateFooterLabels()
        {
            // Footer panel
            Panel pnlFooter = new Panel();
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Height = 30;
            pnlFooter.BackColor = Color.FromArgb(240, 240, 240);

            // Create date/time label
            lblDateTime = new Label();
            lblDateTime.Location = new Point(20, 5);
            lblDateTime.Size = new Size(500, 20);
            lblDateTime.ForeColor = Color.Gray;
            lblDateTime.Font = new Font("Segoe UI", 8);

            // Get current date/time and format it
            string formattedDateTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            lblDateTime.Text = $"Current Date and Time (UTC - YYYY-MM-DD HH:MM:SS formatted): {formattedDateTime}";

            // Create user login label
            lblUser = new Label();
            lblUser.Location = new Point(800, 5);
            lblUser.Size = new Size(270, 20);
            lblUser.ForeColor = Color.Gray;
            lblUser.Font = new Font("Segoe UI", 8);
            lblUser.TextAlign = ContentAlignment.MiddleRight;
            lblUser.Text = "Current User's Login: Deep-Axe";

            // Add labels to the footer
            pnlFooter.Controls.Add(lblDateTime);
            pnlFooter.Controls.Add(lblUser);

            this.Controls.Add(pnlFooter);
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
            // Load active alerts data
            if (dgvAlerts != null)
            {
                dgvAlerts.Rows.Clear();

                // Add sample alerts with emoji indicators
                dgvAlerts.Rows.Add("🔴 CRIT", "CPU Usage > 95%", "APP-03", "10 min ago", "Active");
                dgvAlerts.Rows.Add("🔴 CRIT", "Disk Space < 5%", "DB-01", "25 min ago", "Active");
                dgvAlerts.Rows.Add("🟠 WARN", "Memory Use > 90%", "CACHE-01", "35 min ago", "Active");
                dgvAlerts.Rows.Add("🟠 WARN", "High Network I/O", "WEB-02", "1 hr ago", "Active");
                dgvAlerts.Rows.Add("🟡 INFO", "Server Restarted", "APP-02", "2 hrs ago", "Active");

                // Style critical alerts with red text
                foreach (DataGridViewRow row in dgvAlerts.Rows)
                {
                    if (row.Cells["Severity"].Value.ToString().Contains("CRIT"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        row.DefaultCellStyle.Font = new Font(dgvAlerts.Font, FontStyle.Bold);
                    }
                    else if (row.Cells["Severity"].Value.ToString().Contains("WARN"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                    }
                }
            }

            // Load alert definitions data
            if (dgvAlertDefinitions != null)
            {
                dgvAlertDefinitions.Rows.Clear();

                dgvAlertDefinitions.Rows.Add("CPU Usage", ">", "90", "Critical", "High CPU utilization");
                dgvAlertDefinitions.Rows.Add("CPU Usage", ">", "80", "Warning", "Medium CPU utilization");
                dgvAlertDefinitions.Rows.Add("Memory", ">", "85", "Critical", "High memory usage");
                dgvAlertDefinitions.Rows.Add("Disk Space", "<", "10", "Warning", "Low disk space");

                // Style critical definitions
                foreach (DataGridViewRow row in dgvAlertDefinitions.Rows)
                {
                    if (row.Cells["Severity"].Value.ToString() == "Critical")
                    {
                        row.Cells["Severity"].Style.ForeColor = Color.DarkRed;
                        row.Cells["Severity"].Style.Font = new Font(dgvAlertDefinitions.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void ShowAlertHistory()
        {
            // Create a form to display alert history
            Form frmAlertHistory = new Form();
            frmAlertHistory.Text = "Alert History";
            frmAlertHistory.Size = new Size(800, 500);
            frmAlertHistory.StartPosition = FormStartPosition.CenterParent;
            frmAlertHistory.MinimizeBox = false;
            frmAlertHistory.MaximizeBox = false;
            frmAlertHistory.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Filter panel
            Panel pnlFilter = new Panel();
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Height = 60;
            pnlFilter.Padding = new Padding(10);

            Label lblTimeRange = new Label();
            lblTimeRange.Text = "Time Range:";
            lblTimeRange.Location = new Point(15, 20);
            lblTimeRange.Size = new Size(80, 25);

            ComboBox cboTimeRange = new ComboBox();
            cboTimeRange.Text = "Last 24 Hours";
            cboTimeRange.Location = new Point(100, 18);
            cboTimeRange.Size = new Size(150, 25);
            cboTimeRange.Items.AddRange(new object[] { "Last 24 Hours", "Last 7 Days", "Last 30 Days", "Custom Range" });

            Button btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new Point(680, 16);
            btnRefresh.Size = new Size(90, 30);

            pnlFilter.Controls.AddRange(new Control[] {
                lblTimeRange, cboTimeRange, btnRefresh
            });

            // Alert history grid
            DataGridView dgvHistory = new DataGridView();
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.RowTemplate.Height = 30;
            dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);

            // Create columns for history grid
            dgvHistory.Columns.Add("Severity", "Severity");
            dgvHistory.Columns.Add("Alert", "Alert");
            dgvHistory.Columns.Add("Server", "Server");
            dgvHistory.Columns.Add("StartTime", "Start Time");
            dgvHistory.Columns.Add("EndTime", "End Time");
            dgvHistory.Columns.Add("Duration", "Duration");
            dgvHistory.Columns.Add("Acknowledged", "Acknowledged By");

            // Set column widths
            dgvHistory.Columns["Severity"].Width = 80;
            dgvHistory.Columns["Alert"].Width = 200;
            dgvHistory.Columns["Server"].Width = 100;
            dgvHistory.Columns["StartTime"].Width = 120;
            dgvHistory.Columns["EndTime"].Width = 120;
            dgvHistory.Columns["Duration"].Width = 80;
            dgvHistory.Columns["Acknowledged"].Width = 120;

            // Add sample history data
            dgvHistory.Rows.Add("🔴 CRIT", "CPU Usage > 95%", "APP-01", "2025-03-23 10:15:22", "2025-03-23 11:30:45", "1h 15m", "Deep-Axe");
            dgvHistory.Rows.Add("🔴 CRIT", "Service Down", "DB-01", "2025-03-22 18:30:10", "2025-03-22 20:45:33", "2h 15m", "jsmith");
            dgvHistory.Rows.Add("🟠 WARN", "Memory Use > 90%", "APP-02", "2025-03-22 14:22:18", "2025-03-22 15:05:44", "43m", "mwilson");
            dgvHistory.Rows.Add("🟠 WARN", "High Network I/O", "WEB-01", "2025-03-21 22:17:09", "2025-03-22 02:10:30", "3h 53m", "Deep-Axe");
            dgvHistory.Rows.Add("🟡 INFO", "Server Restarted", "CACHE-01", "2025-03-21 09:05:12", "2025-03-21 09:05:12", "-", "System");
            dgvHistory.Rows.Add("🔴 CRIT", "Disk Space < 5%", "DB-02", "2025-03-20 16:45:33", "2025-03-20 19:30:22", "2h 45m", "agarcia");
            dgvHistory.Rows.Add("🟠 WARN", "CPU Usage > 80%", "APP-03", "2025-03-20 11:20:54", "2025-03-20 12:15:10", "54m", "tchen");
            dgvHistory.Rows.Add("🟡 INFO", "Backup Completed", "DB-01", "2025-03-20 03:00:00", "2025-03-20 03:00:00", "-", "System");

            // Style based on severity
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                if (row.Cells["Severity"].Value.ToString().Contains("CRIT"))
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else if (row.Cells["Severity"].Value.ToString().Contains("WARN"))
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                }
            }

            // Add controls to form
            frmAlertHistory.Controls.Add(dgvHistory);
            frmAlertHistory.Controls.Add(pnlFilter);

            // Show the form as dialog
            frmAlertHistory.ShowDialog();
        }
        private void DgvAlerts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected alert information
                string severity = dgvAlerts.Rows[e.RowIndex].Cells["Severity"].Value.ToString();
                string alertName = dgvAlerts.Rows[e.RowIndex].Cells["Alert"].Value.ToString();
                string server = dgvAlerts.Rows[e.RowIndex].Cells["Server"].Value.ToString();
                string timeAgo = dgvAlerts.Rows[e.RowIndex].Cells["Time"].Value.ToString();
                string status = dgvAlerts.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                // Show confirmation dialog
                DialogResult result = MessageBox.Show(
                    $"Would you like to see details for alert '{alertName}' on {server}?",
                    "Show Alert Details",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // If user clicks Yes, open the details form
                if (result == DialogResult.Yes)
                {
                    ShowAlertDetailsForm(alertName, server, severity, timeAgo, status);
                }
            }
        }
        private void ShowAlertDetailsForm(string alertName, string server, string severity, string timeAgo, string status)
        {
            // Create and show the alert details form
            using (AlertDetailsForm detailsForm = new AlertDetailsForm(alertName, server, severity, timeAgo, status))
            {
                detailsForm.ShowDialog(this);
            }
        }

        
        
    }
}