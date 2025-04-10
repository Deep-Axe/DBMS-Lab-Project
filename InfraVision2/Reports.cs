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
    public partial class Reports : Form
    {
        private Label lblDateTime;
        private Label lblUser;
        private DataGridView dgvRecentReports;

        public Reports()
        {
            InitializeComponent();

            // Set form properties
            this.Text = "Server Management System";
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Create all UI elements
            CreateReportsHeader();
            CreateTabsSection();
            CreateActionsPanel();
            CreateTemplatesSection();
            CreateRecentReportsSection();
            CreateChartSection();
            CreateFooterLabels();

            // Load sample data
            LoadSampleData();

            // Set up a timer to update the date/time periodically
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += (s, e) => UpdateDateTime();
            timer.Start();
        }

        private void CreateReportsHeader()
        {
            // Header label for the Reports section
            Label lblHeader = new Label();
            lblHeader.Text = "REPORTS";
            lblHeader.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblHeader.Location = new Point(20, 20);
            lblHeader.Size = new Size(150, 25);
            this.Controls.Add(lblHeader);
        }

        private void CreateTabsSection()
        {
            // Tabs for different report types
            Button btnPerformance = new Button();
            btnPerformance.Text = "Performance";
            btnPerformance.Location = new Point(20, 60);
            btnPerformance.Size = new Size(180, 35);
            btnPerformance.BackColor = Color.FromArgb(240, 240, 240);
            btnPerformance.FlatStyle = FlatStyle.Flat;
            btnPerformance.Click += (s, e) => {
                // Already on performance view
            };

            Button btnSecurity = new Button();
            btnSecurity.Text = "Security";
            btnSecurity.Location = new Point(210, 60);
            btnSecurity.Size = new Size(150, 35);
            btnSecurity.FlatStyle = FlatStyle.Flat;
            btnSecurity.Click += (s, e) => {
                MessageBox.Show("Security reports would be displayed here", "Security Reports");
            };

            Button btnCompliance = new Button();
            btnCompliance.Text = "Compliance";
            btnCompliance.Location = new Point(370, 60);
            btnCompliance.Size = new Size(180, 35);
            btnCompliance.FlatStyle = FlatStyle.Flat;
            btnCompliance.Click += (s, e) => {
                MessageBox.Show("Compliance reports would be displayed here", "Compliance Reports");
            };

            this.Controls.AddRange(new Control[] { btnPerformance, btnSecurity, btnCompliance });
        }

        private void CreateActionsPanel()
        {
            // Actions panel
            Panel pnlActions = new Panel();
            pnlActions.Location = new Point(20, 110);
            pnlActions.Size = new Size(900, 50);
            pnlActions.BorderStyle = BorderStyle.FixedSingle;

            // New Report button
            Button btnNewReport = new Button();
            btnNewReport.Text = "[+] New Report";
            btnNewReport.Location = new Point(10, 10);
            btnNewReport.Size = new Size(120, 30);
            btnNewReport.Click += (s, e) => {
                // Show confirmation dialog
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to create a new report?",
                    "Confirm New Report",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // If confirmed, show the report generator form
                if (result == DialogResult.Yes)
                {
                    ShowReportGenerator();
                }
            };

            // Schedule button
            Button btnSchedule = new Button();
            btnSchedule.Text = "[📅] Schedule";
            btnSchedule.Location = new Point(140, 10);
            btnSchedule.Size = new Size(120, 30);
            btnSchedule.Click += (s, e) => {
                MessageBox.Show("Schedule reports dialog would open here", "Schedule Reports");
            };

            // Export button
            Button btnExport = new Button();
            btnExport.Text = "[⬇️] Export";
            btnExport.Location = new Point(270, 10);
            btnExport.Size = new Size(100, 30);
            btnExport.Click += (s, e) => {
                MessageBox.Show("Export options dialog would open here", "Export");
            };

            // Print button
            Button btnPrint = new Button();
            btnPrint.Text = "[🖨️] Print";
            btnPrint.Location = new Point(380, 10);
            btnPrint.Size = new Size(100, 30);
            btnPrint.Click += (s, e) => {
                MessageBox.Show("Print dialog would open here", "Print");
            };

            pnlActions.Controls.AddRange(new Control[] {
                btnNewReport, btnSchedule, btnExport, btnPrint
            });

            this.Controls.Add(pnlActions);
        }

        private void ShowReportGenerator()
        {
            // Create and show the report generator form
            using (ReportGeneratorForm reportGen = new ReportGeneratorForm())
            {
                reportGen.ShowDialog(this);
            }
        }

        private void CreateTemplatesSection()
        {
            // Templates section
            GroupBox grpTemplates = new GroupBox();
            grpTemplates.Text = "Report Templates";
            grpTemplates.Location = new Point(20, 170);
            grpTemplates.Size = new Size(900, 140);

            // Template list
            ListBox lstTemplates = new ListBox();
            lstTemplates.Location = new Point(15, 20);
            lstTemplates.Size = new Size(870, 110);
            lstTemplates.Font = new Font("Segoe UI", 9);
            lstTemplates.Items.AddRange(new object[] {
                "• Server Performance Trend Report",
                "• Monthly Uptime Report",
                "• Incident Resolution Time Analysis",
                "• Security Audit Report",
                "• Resource Utilization by Server Group",
                "• User Activity Report"
            });

            // Double-click to generate report
            lstTemplates.DoubleClick += (s, e) => {
                if (lstTemplates.SelectedIndex >= 0)
                {
                    string template = lstTemplates.SelectedItem.ToString().Replace("• ", "");
                    DialogResult result = MessageBox.Show(
                        $"Generate report using the '{template}' template?",
                        "Generate Report",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        ShowReportGenerator();
                    }
                }
            };

            grpTemplates.Controls.Add(lstTemplates);
            this.Controls.Add(grpTemplates);
        }

        private void CreateRecentReportsSection()
        {
            // Recent Reports header
            Label lblRecentHeader = new Label();
            lblRecentHeader.Text = "Recent Reports";
            lblRecentHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblRecentHeader.Location = new Point(20, 320);
            lblRecentHeader.Size = new Size(150, 20);
            this.Controls.Add(lblRecentHeader);

            // Recent reports grid
            dgvRecentReports = new DataGridView();
            dgvRecentReports.Location = new Point(20, 350);
            dgvRecentReports.Size = new Size(900, 120);
            dgvRecentReports.ReadOnly = true;
            dgvRecentReports.AllowUserToAddRows = false;
            dgvRecentReports.AllowUserToDeleteRows = false;
            dgvRecentReports.AllowUserToResizeRows = false;
            dgvRecentReports.RowHeadersVisible = false;
            dgvRecentReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentReports.BackgroundColor = Color.White;
            dgvRecentReports.BorderStyle = BorderStyle.Fixed3D;
            dgvRecentReports.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRecentReports.RowTemplate.Height = 30;
            dgvRecentReports.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);

            // Create columns for reports grid
            dgvRecentReports.Columns.Add("ReportName", "Report Name");
            dgvRecentReports.Columns.Add("Generated", "Generated");
            dgvRecentReports.Columns.Add("By", "By");
            dgvRecentReports.Columns.Add("Format", "Format");

            // Set column widths
            dgvRecentReports.Columns["ReportName"].Width = 350;
            dgvRecentReports.Columns["Generated"].Width = 150;
            dgvRecentReports.Columns["By"].Width = 150;
            dgvRecentReports.Columns["Format"].Width = 100;

            // Set up double-click handler
            dgvRecentReports.CellDoubleClick += (s, e) => {
                if (e.RowIndex >= 0)
                {
                    string reportName = dgvRecentReports.Rows[e.RowIndex].Cells["ReportName"].Value.ToString();
                    string format = dgvRecentReports.Rows[e.RowIndex].Cells["Format"].Value.ToString();
                    MessageBox.Show($"Opening {reportName} in {format} format", "View Report");
                }
            };

            this.Controls.Add(dgvRecentReports);
        }

        private void CreateChartSection()
        {
            // Chart panel
            Panel pnlChart = new Panel();
            pnlChart.Location = new Point(20, 480);
            pnlChart.Size = new Size(900, 150);
            pnlChart.BorderStyle = BorderStyle.FixedSingle;

            // Chart title panel for formatting
            Panel pnlChartTitle = new Panel();
            pnlChartTitle.Dock = DockStyle.Top;
            pnlChartTitle.Height = 25;
            pnlChartTitle.BackColor = Color.FromArgb(240, 240, 240);

            // Chart title centered
            Label lblChartTitle = new Label();
            lblChartTitle.Text = "Server Uptime - Last 30 Days";
            lblChartTitle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblChartTitle.Dock = DockStyle.Fill;
            lblChartTitle.TextAlign = ContentAlignment.MiddleCenter;

            pnlChartTitle.Controls.Add(lblChartTitle);

            // Chart area (mock)
            Label lblChartMock = new Label();
            lblChartMock.Text = "[Chart: Server Uptime - Last 30 Days]";
            lblChartMock.Font = new Font("Segoe UI", 11);
            lblChartMock.Size = new Size(900, 124);
            lblChartMock.Location = new Point(0, 25);
            lblChartMock.TextAlign = ContentAlignment.MiddleCenter;

            pnlChart.Controls.Add(pnlChartTitle);
            pnlChart.Controls.Add(lblChartMock);

            this.Controls.Add(pnlChart);
        }

        private void CreateFooterLabels()
        {
            // Create date/time label
            lblDateTime = new Label();
            lblDateTime.Location = new Point(20, 640);
            lblDateTime.Size = new Size(500, 20);
            lblDateTime.ForeColor = Color.Gray;
            lblDateTime.Font = new Font("Segoe UI", 8);

            // Get current date/time and format it
            string formattedDateTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            lblDateTime.Text = $"Current Date and Time (UTC - YYYY-MM-DD HH:MM:SS formatted): {formattedDateTime}";

            // Create user login label
            lblUser = new Label();
            lblUser.Location = new Point(600, 640);
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
            // Load recent reports data
            if (dgvRecentReports != null)
            {
                dgvRecentReports.Rows.Clear();

                dgvRecentReports.Rows.Add("Monthly Uptime - March", "2025-03-23", "System", "PDF");
                dgvRecentReports.Rows.Add("Security Audit Q1", "2025-03-15", "Deep-Axe", "PDF");
                dgvRecentReports.Rows.Add("Incident Summary Feb", "2025-03-01", "jsmith", "XLSX");
                dgvRecentReports.Rows.Add("User Activity - Q1", "2025-03-01", "Deep-Axe", "PDF");
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
        }
    }

    // Report Generator Form
    public class ReportGeneratorForm : Form
    {
        public ReportGeneratorForm()
        {
            // Set form properties
            this.Text = "Generate Report";
            this.Size = new Size(600, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Create the report generator UI
            CreateReportGeneratorUI();
        }

        private void CreateReportGeneratorUI()
        {
            // ========== REPORT TYPE SECTION ==========
            GroupBox grpReportType = new GroupBox();
            grpReportType.Location = new Point(20, 20);
            grpReportType.Size = new Size(540, 50);
            grpReportType.Text = string.Empty; // No title

            Label lblReportType = new Label();
            lblReportType.Text = "Report Type:";
            lblReportType.Location = new Point(15, 20);
            lblReportType.Size = new Size(100, 20);
            lblReportType.Font = new Font("Segoe UI", 9);

            ComboBox cboReportType = new ComboBox();
            cboReportType.Text = "Server Performance Trend";
            cboReportType.Location = new Point(120, 17);
            cboReportType.Size = new Size(400, 25);
            cboReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboReportType.Items.AddRange(new object[] {
                "Server Performance Trend",
                "Monthly Uptime Report",
                "Incident Resolution Time Analysis",
                "Security Audit Report",
                "Resource Utilization by Server Group",
                "User Activity Report"
            });
            cboReportType.SelectedIndex = 0;

            grpReportType.Controls.AddRange(new Control[] {
                lblReportType, cboReportType
            });

            // ========== PARAMETERS SECTION ==========
            Label lblParameters = new Label();
            lblParameters.Text = "Parameters:";
            lblParameters.Location = new Point(20, 80);
            lblParameters.Size = new Size(100, 20);
            lblParameters.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            GroupBox grpParameters = new GroupBox();
            grpParameters.Location = new Point(20, 100);
            grpParameters.Size = new Size(540, 200);
            grpParameters.Text = string.Empty; // No title

            // Server Group dropdown
            Label lblServerGroup = new Label();
            lblServerGroup.Text = "Server Group:";
            lblServerGroup.Location = new Point(15, 20);
            lblServerGroup.Size = new Size(100, 20);
            lblServerGroup.Font = new Font("Segoe UI", 9);

            ComboBox cboServerGroup = new ComboBox();
            cboServerGroup.Text = "Production Servers";
            cboServerGroup.Location = new Point(175, 17);
            cboServerGroup.Size = new Size(350, 25);
            cboServerGroup.Items.AddRange(new object[] {
                "Production Servers",
                "Development Servers",
                "Database Servers",
                "Web Servers",
                "Application Servers",
                "All Servers"
            });

            // Date Range dropdown
            Label lblDateRange = new Label();
            lblDateRange.Text = "Date Range:";
            lblDateRange.Location = new Point(15, 50);
            lblDateRange.Size = new Size(100, 20);
            lblDateRange.Font = new Font("Segoe UI", 9);

            ComboBox cboDateRange = new ComboBox();
            cboDateRange.Text = "Last 30 Days";
            cboDateRange.Location = new Point(175, 47);
            cboDateRange.Size = new Size(350, 25);
            cboDateRange.Items.AddRange(new object[] {
                "Last 7 Days",
                "Last 30 Days",
                "Last 90 Days",
                "Last 12 Months",
                "Custom Range"
            });

            // Metrics to Include label
            Label lblMetrics = new Label();
            lblMetrics.Text = "Metrics to Include:";
            lblMetrics.Location = new Point(15, 80);
            lblMetrics.Size = new Size(120, 20);
            lblMetrics.Font = new Font("Segoe UI", 9);

            // CPU Usage checkbox
            CheckBox chkCPU = new CheckBox();
            chkCPU.Text = "CPU Usage";
            chkCPU.Location = new Point(175, 80);
            chkCPU.Size = new Size(150, 20);
            chkCPU.Checked = true;

            // Memory Usage checkbox
            CheckBox chkMemory = new CheckBox();
            chkMemory.Text = "Memory Usage";
            chkMemory.Location = new Point(175, 105);
            chkMemory.Size = new Size(150, 20);
            chkMemory.Checked = true;

            // Disk Space checkbox
            CheckBox chkDisk = new CheckBox();
            chkDisk.Text = "Disk Space";
            chkDisk.Location = new Point(175, 130);
            chkDisk.Size = new Size(150, 20);
            chkDisk.Checked = true;

            // Network Traffic checkbox
            CheckBox chkNetwork = new CheckBox();
            chkNetwork.Text = "Network Traffic";
            chkNetwork.Location = new Point(175, 155);
            chkNetwork.Size = new Size(150, 20);
            chkNetwork.Checked = true;

            // Load Average checkbox
            CheckBox chkLoad = new CheckBox();
            chkLoad.Text = "Load Average";
            chkLoad.Location = new Point(175, 180);
            chkLoad.Size = new Size(150, 20);
            chkLoad.Checked = false;

            // Format dropdown
            Label lblFormat = new Label();
            lblFormat.Text = "Format:";
            lblFormat.Location = new Point(340, 105);
            lblFormat.Size = new Size(70, 20);
            lblFormat.Font = new Font("Segoe UI", 9);

            ComboBox cboFormat = new ComboBox();
            cboFormat.Text = "PDF";
            cboFormat.Location = new Point(410, 102);
            cboFormat.Size = new Size(115, 25);
            cboFormat.Items.AddRange(new object[] { "PDF", "XLSX", "HTML", "CSV" });

            // Include Recommendations checkbox
            CheckBox chkRecommendations = new CheckBox();
            chkRecommendations.Text = "Include Recommendations";
            chkRecommendations.Location = new Point(340, 130);
            chkRecommendations.Size = new Size(200, 20);
            chkRecommendations.Checked = true;

            grpParameters.Controls.AddRange(new Control[] {
                lblServerGroup, cboServerGroup,
                lblDateRange, cboDateRange,
                lblMetrics, chkCPU, chkMemory, chkDisk, chkNetwork, chkLoad,
                lblFormat, cboFormat, chkRecommendations
            });

            // ========== SCHEDULING SECTION ==========
            Label lblScheduling = new Label();
            lblScheduling.Text = "Scheduling:";
            lblScheduling.Location = new Point(20, 310);
            lblScheduling.Size = new Size(100, 20);
            lblScheduling.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            GroupBox grpScheduling = new GroupBox();
            grpScheduling.Location = new Point(20, 330);
            grpScheduling.Size = new Size(540, 100);
            grpScheduling.Text = string.Empty; // No title

            // Schedule recurring report checkbox
            CheckBox chkScheduleRecurring = new CheckBox();
            chkScheduleRecurring.Text = "Schedule recurring report";
            chkScheduleRecurring.Location = new Point(15, 20);
            chkScheduleRecurring.Size = new Size(200, 20);
            chkScheduleRecurring.Checked = false;

            // Frequency dropdown
            Label lblFrequency = new Label();
            lblFrequency.Text = "Frequency:";
            lblFrequency.Location = new Point(15, 50);
            lblFrequency.Size = new Size(70, 20);
            lblFrequency.Font = new Font("Segoe UI", 9);
            lblFrequency.Enabled = false;

            ComboBox cboFrequency = new ComboBox();
            cboFrequency.Text = "Weekly";
            cboFrequency.Location = new Point(90, 47);
            cboFrequency.Size = new Size(100, 25);
            cboFrequency.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly", "Quarterly" });
            cboFrequency.Enabled = false;

            // Day dropdown
            Label lblDay = new Label();
            lblDay.Text = "Day:";
            lblDay.Location = new Point(205, 50);
            lblDay.Size = new Size(40, 20);
            lblDay.Font = new Font("Segoe UI", 9);
            lblDay.Enabled = false;

            ComboBox cboDay = new ComboBox();
            cboDay.Text = "Monday";
            cboDay.Location = new Point(250, 47);
            cboDay.Size = new Size(100, 25);
            cboDay.Items.AddRange(new object[] {
                "Monday", "Tuesday", "Wednesday", "Thursday",
                "Friday", "Saturday", "Sunday"
            });
            cboDay.Enabled = false;

            // Time picker
            Label lblTime = new Label();
            lblTime.Text = "Time:";
            lblTime.Location = new Point(365, 50);
            lblTime.Size = new Size(40, 20);
            lblTime.Font = new Font("Segoe UI", 9);
            lblTime.Enabled = false;

            DateTimePicker dtpTime = new DateTimePicker();
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.ShowUpDown = true;
            dtpTime.Value = DateTime.Parse("06:00");
            dtpTime.Location = new Point(410, 47);
            dtpTime.Size = new Size(115, 25);
            dtpTime.Enabled = false;

            // Email field
            Label lblEmail = new Label();
            lblEmail.Text = "Email to:";
            lblEmail.Location = new Point(15, 80);
            lblEmail.Size = new Size(70, 20);
            lblEmail.Font = new Font("Segoe UI", 9);
            lblEmail.Enabled = false;

            TextBox txtEmail = new TextBox();
            txtEmail.Text = "deep@company.com";
            txtEmail.Location = new Point(90, 77);
            txtEmail.Size = new Size(435, 25);
            txtEmail.Enabled = false;

            // Enable/disable scheduling controls based on checkbox
            chkScheduleRecurring.CheckedChanged += (s, e) => {
                bool enabled = chkScheduleRecurring.Checked;
                lblFrequency.Enabled = enabled;
                cboFrequency.Enabled = enabled;
                lblDay.Enabled = enabled;
                cboDay.Enabled = enabled;
                lblTime.Enabled = enabled;
                dtpTime.Enabled = enabled;
                lblEmail.Enabled = enabled;
                txtEmail.Enabled = enabled;
            };

            grpScheduling.Controls.AddRange(new Control[] {
                chkScheduleRecurring,
                lblFrequency, cboFrequency,
                lblDay, cboDay,
                lblTime, dtpTime,
                lblEmail, txtEmail
            });

            // ========== ACTION BUTTONS ==========
            Button btnGenerateNow = new Button();
            btnGenerateNow.Text = "Generate Now";
            btnGenerateNow.Location = new Point(90, 450);
            btnGenerateNow.Size = new Size(120, 30);
            btnGenerateNow.Click += (s, e) => {
                MessageBox.Show("Report is being generated. You will be notified when it's ready.", "Report Generation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            };

            Button btnSchedule = new Button();
            btnSchedule.Text = "Schedule";
            btnSchedule.Location = new Point(240, 450);
            btnSchedule.Size = new Size(120, 30);
            btnSchedule.Click += (s, e) => {
                MessageBox.Show("Report has been scheduled.", "Report Scheduled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            };

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(390, 450);
            btnCancel.Size = new Size(120, 30);
            btnCancel.Click += (s, e) => this.Close();

            // Add all controls to the form
            this.Controls.AddRange(new Control[] {
                grpReportType,
                lblParameters,
                grpParameters,
                lblScheduling,
                grpScheduling,
                btnGenerateNow,
                btnSchedule,
                btnCancel
            });
        }
    }
}