using System;
using System.Drawing;
using System.Windows.Forms;

namespace InfraVision2
{
    public partial class Servers : Form
    {
        private int _serverID;
        private string _serverName;

        // Default constructor for designer
        public Servers()
        {
            InitializeComponent();
        }

        // Constructor with server details
        public Servers(int serverID, string serverName)
        {
            InitializeComponent();
            _serverID = serverID;
            _serverName = serverName;

            // Set form title
            this.Text = $"Server Details: {_serverName}";

            // Subscribe to form load event
            this.Load += Servers_Load;
        }

        // You can call this from the designer-generated InitializeComponent method
        // or create controls manually if you prefer
        private void CreateServerDetailsControls()
        {
            // Configure the form
            this.Text = $"Server Details: {_serverName}";
            this.Size = new Size(600, 475);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Close button (X)
            Button btnClose = new Button
            {
                Text = "X",
                Location = new Point(560, 10),
                Size = new Size(25, 25),
                FlatStyle = FlatStyle.Flat,
                Name = "btnClose"
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            // 1. General Information GroupBox
            GroupBox grpGeneralInfo = new GroupBox
            {
                Text = "General Information",
                Location = new Point(20, 20),
                Size = new Size(250, 180),
                Name = "grpGeneralInfo"
            };

            // Labels for general info
            Label lblIP = new Label
            {
                Text = "IP: 192.168.1.10",
                Location = new Point(10, 25),
                Size = new Size(230, 20),
                Name = "lblIP"
            };

            Label lblOS = new Label
            {
                Text = "OS: Linux Ubuntu",
                Location = new Point(10, 50),
                Size = new Size(230, 20),
                Name = "lblOS"
            };

            Label lblLocation = new Label
            {
                Text = "Location: NYC-DC1",
                Location = new Point(10, 75),
                Size = new Size(230, 20),
                Name = "lblLocation"
            };

            Label lblStatus = new Label
            {
                Text = "Status: Active",
                Location = new Point(10, 100),
                Size = new Size(230, 20),
                Name = "lblStatus"
            };

            Label lblLastRestart = new Label
            {
                Text = "Last Restart:",
                Location = new Point(10, 125),
                Size = new Size(230, 20),
                Name = "lblLastRestart"
            };

            Label lblRestartTime = new Label
            {
                Text = "2025-03-20 08:15:30",
                Location = new Point(10, 145),
                Size = new Size(230, 20),
                Name = "lblRestartTime"
            };

            // Add labels to general info group
            grpGeneralInfo.Controls.AddRange(new Control[] {
                lblIP, lblOS, lblLocation, lblStatus, lblLastRestart, lblRestartTime
            });

            // 2. Performance Metrics GroupBox
            GroupBox grpPerformance = new GroupBox
            {
                Text = "Performance Metrics",
                Location = new Point(290, 20),
                Size = new Size(280, 180),
                Name = "grpPerformance"
            };

            // Chart panel
            Panel pnlChart = new Panel
            {
                Location = new Point(10, 25),
                Size = new Size(260, 80),
                BorderStyle = BorderStyle.FixedSingle,
                Name = "pnlChart"
            };

            // Chart placeholder
            Label lblChartPlaceholder = new Label
            {
                Text = "[Chart showing CPU/Memory usage]",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Name = "lblChartPlaceholder"
            };
            pnlChart.Controls.Add(lblChartPlaceholder);

            // Performance metrics labels
            Label lblCPU = new Label
            {
                Text = "Current CPU: 78%",
                Location = new Point(10, 115),
                Size = new Size(260, 20),
                Name = "lblCPU"
            };

            Label lblMemory = new Label
            {
                Text = "Current Memory: 45%",
                Location = new Point(10, 135),
                Size = new Size(260, 20),
                Name = "lblMemory"
            };

            Label lblDisk = new Label
            {
                Text = "Disk Usage: 67%",
                Location = new Point(10, 155),
                Size = new Size(120, 20),
                Name = "lblDisk"
            };

            Label lblNetwork = new Label
            {
                Text = "Network: 25 Mbps",
                Location = new Point(150, 155),
                Size = new Size(120, 20),
                Name = "lblNetwork"
            };

            // Add controls to performance group
            grpPerformance.Controls.AddRange(new Control[] {
                pnlChart, lblCPU, lblMemory, lblDisk, lblNetwork
            });

            // 3. Recent Alerts GroupBox
            GroupBox grpAlerts = new GroupBox
            {
                Text = "Recent Alerts (3)",
                Location = new Point(20, 210),
                Size = new Size(550, 120),
                Name = "grpAlerts"
            };

            // Alert labels
            Label lblAlert1 = new Label
            {
                Text = "• High CPU Usage - 2025-03-23 13:45:22",
                Location = new Point(10, 25),
                Size = new Size(530, 20),
                Name = "lblAlert1"
            };

            Label lblAlert2 = new Label
            {
                Text = "• Memory Warning - 2025-03-23 09:12:05",
                Location = new Point(10, 50),
                Size = new Size(530, 20),
                Name = "lblAlert2"
            };

            Label lblAlert3 = new Label
            {
                Text = "• Disk Space Low - 2025-03-22 23:10:45",
                Location = new Point(10, 75),
                Size = new Size(530, 20),
                Name = "lblAlert3"
            };

            // Add alerts to group
            grpAlerts.Controls.AddRange(new Control[] {
                lblAlert1, lblAlert2, lblAlert3
            });

            // 4. Action Buttons
            Button btnRestart = new Button
            {
                Text = "Restart",
                Location = new Point(20, 350),
                Size = new Size(120, 30),
                Name = "btnRestart"
            };
            btnRestart.Click += (s, e) => MessageBox.Show("Server restart initiated.", "Restart", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Button btnEditConfig = new Button
            {
                Text = "Edit Config",
                Location = new Point(150, 350),
                Size = new Size(120, 30),
                Name = "btnEditConfig"
            };
            btnEditConfig.Click += (s, e) => MessageBox.Show("Config editor would open here.", "Edit Config", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Button btnViewLogs = new Button
            {
                Text = "View Logs",
                Location = new Point(280, 350),
                Size = new Size(120, 30),
                Name = "btnViewLogs"
            };
            btnViewLogs.Click += (s, e) => MessageBox.Show("Server logs would appear here.", "View Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Button btnManageAlerts = new Button
            {
                Text = "Manage Alerts",
                Location = new Point(410, 350),
                Size = new Size(120, 30),
                Name = "btnManageAlerts"
            };
            btnManageAlerts.Click += (s, e) => MessageBox.Show("Alert management would open here.", "Manage Alerts", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 5. System Info Labels
            Label lblCurrentDateTime = new Label
            {
                Text = "Current Date and Time (UTC): 2025-03-23 22:03:03",
                Location = new Point(20, 390),
                Size = new Size(300, 20),
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 8),
                Name = "lblCurrentDateTime"
            };

            Label lblCurrentUser = new Label
            {
                Text = "Current User's Login: Deep-Axe",
                Location = new Point(350, 390),
                Size = new Size(220, 20),
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 8),
                TextAlign = ContentAlignment.MiddleRight,
                Name = "lblCurrentUser"
            };

            // Add all controls to the form
            this.Controls.AddRange(new Control[] {
                btnClose,
                grpGeneralInfo,
                grpPerformance,
                grpAlerts,
                btnRestart,
                btnEditConfig,
                btnViewLogs,
                btnManageAlerts,
                lblCurrentDateTime,
                lblCurrentUser
            });
        }

        private void Servers_Load(object sender, EventArgs e)
        {
            // If using designer:
            // UpdateServerDetails();

            // If creating controls manually:
            CreateServerDetailsControls();
            UpdateServerDetails();
        }

        private void UpdateServerDetails()
        {
            // Update labels with server-specific information
            try
            {
             

                if (Controls.Find("lblIP", true).Length > 0)
                    ((Label)Controls.Find("lblIP", true)[0]).Text = $"IP: 192.168.1.{10 + _serverID}";

                if (Controls.Find("lblOS", true).Length > 0)
                    ((Label)Controls.Find("lblOS", true)[0]).Text = $"OS: {(_serverID % 2 == 0 ? "Windows Server 2022" : "Linux Ubuntu 22.04")}";

                if (Controls.Find("lblStatus", true).Length > 0)
                {
                    string status = _serverID == 5 ? "Down" : _serverID == 4 ? "Warning" : "Active";
                    ((Label)Controls.Find("lblStatus", true)[0]).Text = $"Status: {status}";
                }

                if (Controls.Find("lblRestartTime", true).Length > 0)
                    ((Label)Controls.Find("lblRestartTime", true)[0]).Text = $"2025-03-{20 + (_serverID % 3)} 08:15:30";

                // Update metrics
                int cpuUsage = 60 + (_serverID * 5) % 40;
                int memoryUsage = 40 + (_serverID * 10) % 55;
                int diskUsage = 50 + (_serverID * 7) % 40;
                int networkSpeed = 20 + (_serverID * 3);

                if (Controls.Find("lblCPU", true).Length > 0)
                    ((Label)Controls.Find("lblCPU", true)[0]).Text = $"Current CPU: {cpuUsage}%";

                if (Controls.Find("lblMemory", true).Length > 0)
                    ((Label)Controls.Find("lblMemory", true)[0]).Text = $"Current Memory: {memoryUsage}%";

                if (Controls.Find("lblDisk", true).Length > 0)
                    ((Label)Controls.Find("lblDisk", true)[0]).Text = $"Disk Usage: {diskUsage}%";

                if (Controls.Find("lblNetwork", true).Length > 0)
                    ((Label)Controls.Find("lblNetwork", true)[0]).Text = $"Network: {networkSpeed} Mbps";

                // Set current date and time
                if (Controls.Find("lblCurrentDateTime", true).Length > 0)
                    ((Label)Controls.Find("lblCurrentDateTime", true)[0]).Text = $"Current Date and Time (UTC): {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating server details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}