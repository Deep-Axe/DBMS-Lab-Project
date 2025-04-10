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
    public partial class Incidents : Form
    {
        private DataGridView dgvIncidents;
        private DataGridView dgvIncidentTypes;
        private Label lblDateTime;
        private Label lblUser;

        public Incidents()
        {
            InitializeComponent();

            // Set form properties
            this.Text = "Server Management System";
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Create all UI elements
            CreateIncidentsHeader();
            CreateTabsAndSearch();
            CreateFilterSection();
            CreateIncidentsTable();
            CreateIncidentTypesSection();
            CreateFooterLabels();

            // Load sample data
            LoadSampleData();

            // Set up a timer to update the date/time periodically
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += (s, e) => UpdateDateTime();
            timer.Start();
        }

        private void CreateIncidentsHeader()
        {
            // Header label for the Incidents section
            Label lblHeader = new Label();
            lblHeader.Text = "INCIDENTS";
            lblHeader.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblHeader.Location = new Point(20, 20);
            lblHeader.Size = new Size(150, 25);
            this.Controls.Add(lblHeader);
        }

        private void CreateTabsAndSearch()
        {
            // Tabs for Active and Resolved incidents
            Button btnActive = new Button();
            btnActive.Text = "Active (15)";
            btnActive.Location = new Point(20, 60);
            btnActive.Size = new Size(150, 35);
            btnActive.BackColor = Color.FromArgb(240, 240, 240);
            btnActive.FlatStyle = FlatStyle.Flat;
            btnActive.Click += (s, e) => {
                LoadActiveIncidents();
            };

            Button btnResolved = new Button();
            btnResolved.Text = "Resolved (32)";
            btnResolved.Location = new Point(180, 60);
            btnResolved.Size = new Size(150, 35);
            btnResolved.FlatStyle = FlatStyle.Flat;
            btnResolved.Click += (s, e) => {
                LoadResolvedIncidents();
            };

            // Search box
            TextBox txtSearch = new TextBox();
            txtSearch.Text = "Search incidents...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(600, 60);
            txtSearch.Size = new Size(250, 25);

            // Events for placeholder text behavior
            txtSearch.Enter += (s, e) => {
                if (txtSearch.Text == "Search incidents...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search incidents...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            this.Controls.AddRange(new Control[] { btnActive, btnResolved, txtSearch });
        }

        private void CreateFilterSection()
        {
            // Filter panel
            Panel pnlFilter = new Panel();
            pnlFilter.Location = new Point(20, 110);
            pnlFilter.Size = new Size(900, 50);
            pnlFilter.BorderStyle = BorderStyle.FixedSingle;

            // Create Incident button
            Button btnCreateIncident = new Button();
            btnCreateIncident.Text = "[+] Create Incident";
            btnCreateIncident.Location = new Point(10, 10);
            btnCreateIncident.Size = new Size(150, 30);
            btnCreateIncident.Click += (s, e) => {
                // You could launch a separate form for creating an incident here
                MessageBox.Show("Create incident form would open here");
            };

            // Priority filter
            Label lblPriority = new Label();
            lblPriority.Text = "Priority:";
            lblPriority.Location = new Point(200, 15);
            lblPriority.Size = new Size(70, 20);

            ComboBox cboPriority = new ComboBox();
            cboPriority.Text = "All";
            cboPriority.Location = new Point(270, 12);
            cboPriority.Size = new Size(120, 25);
            cboPriority.Items.AddRange(new object[] { "All", "Critical", "High", "Medium", "Low" });

            // Type filter
            Label lblType = new Label();
            lblType.Text = "Type:";
            lblType.Location = new Point(420, 15);
            lblType.Size = new Size(50, 20);

            ComboBox cboType = new ComboBox();
            cboType.Text = "All";
            cboType.Location = new Point(470, 12);
            cboType.Size = new Size(120, 25);
            cboType.Items.AddRange(new object[] { "All", "Database", "Application", "Network", "Security" });

            pnlFilter.Controls.AddRange(new Control[] {
                btnCreateIncident, lblPriority, cboPriority, lblType, cboType
            });

            this.Controls.Add(pnlFilter);
        }

        private void CreateIncidentsTable()
        {
            // DataGridView for incidents
            dgvIncidents = new DataGridView();
            dgvIncidents.Location = new Point(20, 170);
            dgvIncidents.Size = new Size(900, 180);
            dgvIncidents.ReadOnly = true;
            dgvIncidents.AllowUserToAddRows = false;
            dgvIncidents.AllowUserToDeleteRows = false;
            dgvIncidents.AllowUserToResizeRows = false;
            dgvIncidents.RowHeadersVisible = false;
            dgvIncidents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIncidents.BackgroundColor = Color.White;
            dgvIncidents.BorderStyle = BorderStyle.Fixed3D;
            dgvIncidents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvIncidents.RowTemplate.Height = 30;
            dgvIncidents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);

            // Create columns for incidents grid
            dgvIncidents.Columns.Add("ID", "ID");
            dgvIncidents.Columns.Add("Title", "Title");
            dgvIncidents.Columns.Add("Server", "Server");
            dgvIncidents.Columns.Add("Priority", "Priority");
            dgvIncidents.Columns.Add("Status", "Status");
            dgvIncidents.Columns.Add("Assigned", "Assigned");

            // Set column widths
            dgvIncidents.Columns["ID"].Width = 80;
            dgvIncidents.Columns["Title"].Width = 250;
            dgvIncidents.Columns["Server"].Width = 150;
            dgvIncidents.Columns["Priority"].Width = 100;
            dgvIncidents.Columns["Status"].Width = 100;
            dgvIncidents.Columns["Assigned"].Width = 150;

            // Set up click handler for incidents
            dgvIncidents.CellClick += DgvIncidents_CellClick;

            this.Controls.Add(dgvIncidents);
        }

        private void DgvIncidents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected incident's information
                string id = dgvIncidents.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                string title = dgvIncidents.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                string server = dgvIncidents.Rows[e.RowIndex].Cells["Server"].Value.ToString();
                string priority = dgvIncidents.Rows[e.RowIndex].Cells["Priority"].Value.ToString();
                string status = dgvIncidents.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                string assigned = dgvIncidents.Rows[e.RowIndex].Cells["Assigned"].Value.ToString();

                // Show confirmation dialog
                DialogResult result = MessageBox.Show(
                    $"Would you like to see details for Incident {id}: {title}?",
                    "Show Incident Details",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // If user clicks Yes, open the details form
                if (result == DialogResult.Yes)
                {
                    ShowIncidentDetailsForm(id, title, server, priority, status, assigned);
                }
            }
        }

        private void ShowIncidentDetailsForm(string id, string title, string server, string priority, string status, string assigned)
        {
            // Create and show the incident details form
            using (IncidentDetailsForm detailsForm = new IncidentDetailsForm(id, title, server, priority, status, assigned))
            {
                detailsForm.ShowDialog(this);
            }
        }

        private void CreateIncidentTypesSection()
        {
            // Incident Types header
            Label lblTypesHeader = new Label();
            lblTypesHeader.Text = "Incident Types";
            lblTypesHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTypesHeader.Location = new Point(20, 360);
            lblTypesHeader.Size = new Size(150, 20);
            this.Controls.Add(lblTypesHeader);

            // Action buttons panel
            Panel pnlTypeActions = new Panel();
            pnlTypeActions.Location = new Point(20, 390);
            pnlTypeActions.Size = new Size(900, 40);
            pnlTypeActions.BorderStyle = BorderStyle.FixedSingle;

            Button btnAddType = new Button();
            btnAddType.Text = "[+] Add Type";
            btnAddType.Location = new Point(10, 5);
            btnAddType.Size = new Size(120, 30);
            btnAddType.Click += (s, e) => MessageBox.Show("Add Type dialog would open here");

            Button btnEditSelected = new Button();
            btnEditSelected.Text = "[✏️] Edit Selected";
            btnEditSelected.Location = new Point(140, 5);
            btnEditSelected.Size = new Size(150, 30);
            btnEditSelected.Click += (s, e) => {
                if (dgvIncidentTypes.SelectedRows.Count > 0)
                {
                    MessageBox.Show("Edit Type dialog would open here");
                }
                else
                {
                    MessageBox.Show("Please select a type to edit", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            Button btnRefresh = new Button();
            btnRefresh.Text = "[↻] Refresh";
            btnRefresh.Location = new Point(300, 5);
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.Click += (s, e) => {
                LoadSampleData();
                MessageBox.Show("Data refreshed", "Refresh");
            };

            pnlTypeActions.Controls.AddRange(new Control[] {
                btnAddType, btnEditSelected, btnRefresh
            });

            this.Controls.Add(pnlTypeActions);

            // DataGridView for incident types
            dgvIncidentTypes = new DataGridView();
            dgvIncidentTypes.Location = new Point(20, 440);
            dgvIncidentTypes.Size = new Size(900, 150);
            dgvIncidentTypes.ReadOnly = true;
            dgvIncidentTypes.AllowUserToAddRows = false;
            dgvIncidentTypes.AllowUserToDeleteRows = false;
            dgvIncidentTypes.AllowUserToResizeRows = false;
            dgvIncidentTypes.RowHeadersVisible = false;
            dgvIncidentTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIncidentTypes.BackgroundColor = Color.White;
            dgvIncidentTypes.BorderStyle = BorderStyle.Fixed3D;
            dgvIncidentTypes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvIncidentTypes.RowTemplate.Height = 30;
            dgvIncidentTypes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250);

            // Create columns for types grid
            dgvIncidentTypes.Columns.Add("TypeName", "Type Name");
            dgvIncidentTypes.Columns.Add("DefaultSeverity", "Default Severity");
            dgvIncidentTypes.Columns.Add("SLA", "SLA (hrs)");
            dgvIncidentTypes.Columns.Add("Description", "Description");

            // Set column widths
            dgvIncidentTypes.Columns["TypeName"].Width = 150;
            dgvIncidentTypes.Columns["DefaultSeverity"].Width = 150;
            dgvIncidentTypes.Columns["SLA"].Width = 100;
            dgvIncidentTypes.Columns["Description"].Width = 450;

            this.Controls.Add(dgvIncidentTypes);
        }

        private void CreateFooterLabels()
        {
            // Create date/time label
            lblDateTime = new Label();
            lblDateTime.Location = new Point(20, 600);
            lblDateTime.Size = new Size(500, 20);
            lblDateTime.ForeColor = Color.Gray;
            lblDateTime.Font = new Font("Segoe UI", 8);

            // Get current date/time and format it
            string formattedDateTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            lblDateTime.Text = $"Current Date and Time (UTC - YYYY-MM-DD HH:MM:SS formatted): {formattedDateTime}";

            // Create user login label
            lblUser = new Label();
            lblUser.Location = new Point(600, 600);
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
            // Load active incidents
            LoadActiveIncidents();

            // Load incident types data
            if (dgvIncidentTypes != null)
            {
                dgvIncidentTypes.Rows.Clear();

                dgvIncidentTypes.Rows.Add("Database", "High", "4", "DB issues");
                dgvIncidentTypes.Rows.Add("Application", "Medium", "8", "App issues");
                dgvIncidentTypes.Rows.Add("Network", "Medium", "6", "Network");
                dgvIncidentTypes.Rows.Add("Security", "Critical", "2", "Security");

                // Style critical types
                foreach (DataGridViewRow row in dgvIncidentTypes.Rows)
                {
                    if (row.Cells["DefaultSeverity"].Value.ToString() == "Critical")
                    {
                        row.Cells["DefaultSeverity"].Style.ForeColor = Color.Red;
                        row.Cells["DefaultSeverity"].Style.Font = new Font(dgvIncidentTypes.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void LoadActiveIncidents()
        {
            // Load active incidents data
            if (dgvIncidents != null)
            {
                dgvIncidents.Rows.Clear();

                dgvIncidents.Rows.Add("#145", "Database Outage", "DB-01", "High", "Open", "Deep-Axe");
                dgvIncidents.Rows.Add("#144", "Memory Leak", "APP-03", "Medium", "Open", "jsmith");
                dgvIncidents.Rows.Add("#143", "Network Latency", "WEB-02", "Low", "Open", "agarcia");
                dgvIncidents.Rows.Add("#142", "CPU Throttling", "APP-02", "High", "In Progress", "tchen");
                dgvIncidents.Rows.Add("#141", "Config Mismatch", "CACHE-01", "Medium", "In Progress", "Deep-Axe");

                // Style high priority rows
                foreach (DataGridViewRow row in dgvIncidents.Rows)
                {
                    if (row.Cells["Priority"].Value.ToString() == "High")
                    {
                        row.Cells["Priority"].Style.ForeColor = Color.DarkRed;
                        row.Cells["Priority"].Style.Font = new Font(dgvIncidents.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void LoadResolvedIncidents()
        {
            // Load resolved incidents data
            if (dgvIncidents != null)
            {
                dgvIncidents.Rows.Clear();

                dgvIncidents.Rows.Add("#140", "Failed Backup", "DB-02", "Medium", "Resolved", "Deep-Axe");
                dgvIncidents.Rows.Add("#139", "DNS Issue", "WEB-01", "High", "Resolved", "agarcia");
                dgvIncidents.Rows.Add("#138", "Certificate Expiry", "WEB-02", "Critical", "Resolved", "tchen");
                dgvIncidents.Rows.Add("#137", "Disk Full", "APP-01", "High", "Resolved", "jsmith");
                dgvIncidents.Rows.Add("#136", "Service Crash", "CACHE-01", "Medium", "Resolved", "Deep-Axe");

                // Style high priority rows
                foreach (DataGridViewRow row in dgvIncidents.Rows)
                {
                    if (row.Cells["Priority"].Value.ToString() == "High" ||
                        row.Cells["Priority"].Value.ToString() == "Critical")
                    {
                        row.Cells["Priority"].Style.ForeColor = Color.DarkRed;
                        row.Cells["Priority"].Style.Font = new Font(dgvIncidents.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void Incidents_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
        }
    }

    // Incident Details Form
    public class IncidentDetailsForm : Form
    {
        public IncidentDetailsForm(string id, string title, string server, string priority, string status, string assigned)
        {
            // Set form properties
            this.Text = $"Incident {id}: {title}";
            this.Size = new Size(650, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Create the incident details UI
            CreateIncidentDetailsUI(id, title, server, priority, status, assigned);
        }

        private void CreateIncidentDetailsUI(string id, string title, string server, string priority, string status, string assigned)
        {
            // ========== LEFT INFO PANEL ==========
            GroupBox grpInfo = new GroupBox();
            grpInfo.Location = new Point(20, 20);
            grpInfo.Size = new Size(260, 180);
            grpInfo.Text = string.Empty; // No title for this group

            // Status
            Label lblStatus = new Label();
            lblStatus.Text = $"Status: {status}";
            lblStatus.Location = new Point(15, 20);
            lblStatus.Size = new Size(230, 20);
            lblStatus.Font = new Font("Segoe UI", 9);

            // Priority
            Label lblPriority = new Label();
            lblPriority.Text = $"Priority: {priority}";
            lblPriority.Location = new Point(15, 45);
            lblPriority.Size = new Size(230, 20);
            lblPriority.Font = new Font("Segoe UI", 9);
            if (priority == "High" || priority == "Critical")
            {
                lblPriority.ForeColor = Color.Red;
                lblPriority.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }

            // Type - use Database as default for demo
            string type = "Database";
            if (title.Contains("Memory") || title.Contains("CPU"))
                type = "Application";
            else if (title.Contains("Network") || title.Contains("DNS"))
                type = "Network";

            Label lblType = new Label();
            lblType.Text = $"Type: {type}";
            lblType.Location = new Point(15, 70);
            lblType.Size = new Size(230, 20);
            lblType.Font = new Font("Segoe UI", 9);

            // SLA
            string sla = "4 hours";
            if (type == "Application") sla = "8 hours";
            else if (type == "Network") sla = "6 hours";

            Label lblSLA = new Label();
            lblSLA.Text = $"SLA: {sla}";
            lblSLA.Location = new Point(15, 95);
            lblSLA.Size = new Size(230, 20);
            lblSLA.Font = new Font("Segoe UI", 9);

            // Due by (mock data)
            DateTime dueBy = DateTime.Now.AddHours(4);
            Label lblDueBy = new Label();
            lblDueBy.Text = $"Due by: {dueBy.ToString("HH:mm:ss")}";
            lblDueBy.Location = new Point(15, 120);
            lblDueBy.Size = new Size(230, 20);
            lblDueBy.Font = new Font("Segoe UI", 9);

            // Server
            Label lblServer = new Label();
            lblServer.Text = $"Server: {server}";
            lblServer.Location = new Point(15, 145);
            lblServer.Size = new Size(230, 20);
            lblServer.Font = new Font("Segoe UI", 9);

            // Assigned
            Label lblAssigned = new Label();
            lblAssigned.Text = $"Assigned: {assigned}";
            lblAssigned.Location = new Point(15, 170);
            lblAssigned.Size = new Size(230, 20);
            lblAssigned.Font = new Font("Segoe UI", 9);

            // Add all labels to the group
            grpInfo.Controls.AddRange(new Control[] {
                lblStatus, lblPriority, lblType, lblSLA, lblDueBy, lblServer, lblAssigned
            });

            // ========== RIGHT TIMELINE PANEL ==========
            GroupBox grpTimeline = new GroupBox();
            grpTimeline.Text = "Timeline";
            grpTimeline.Location = new Point(300, 20);
            grpTimeline.Size = new Size(310, 180);

            // Timeline entries
            Label lblTimeline = new Label();
            lblTimeline.Text = $"• Created - 2025-03-23 13:40:22\r\n" +
                              $"  by {assigned}\r\n" +
                              $"• Comment - 2025-03-23 13:55:10\r\n" +
                              $"  \"Investigating root cause\"\r\n" +
                              $"• Status Change - 14:10:32\r\n" +
                              $"  \"In Progress\" by {assigned}";
            lblTimeline.Location = new Point(15, 20);
            lblTimeline.Size = new Size(280, 150);
            lblTimeline.Font = new Font("Segoe UI", 9);

            grpTimeline.Controls.Add(lblTimeline);

            // ========== DESCRIPTION SECTION ==========
            Label lblDescTitle = new Label();
            lblDescTitle.Text = "Description:";
            lblDescTitle.Location = new Point(20, 210);
            lblDescTitle.Size = new Size(100, 20);
            lblDescTitle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Description text (generate based on title)
            string description = "Database server showing high latency and intermittent connection failures. Multiple applications affected.";

            if (title.Contains("Memory"))
                description = "Memory leak detected in application process. Server performance degrading over time.";
            else if (title.Contains("Network"))
                description = "Increased latency on all network connections. Users reporting slow response times.";
            else if (title.Contains("CPU"))
                description = "CPU throttling detected. Server performance impacted during peak hours.";
            else if (title.Contains("Config"))
                description = "Configuration mismatch between production and staging environments. Deployment failures occurring.";

            Label lblDescription = new Label();
            lblDescription.Text = description;
            lblDescription.Location = new Point(20, 230);
            lblDescription.Size = new Size(590, 40);
            lblDescription.Font = new Font("Segoe UI", 9);

            // ========== COMMENT SECTION ==========
            GroupBox grpComment = new GroupBox();
            grpComment.Text = "Add Comment:";
            grpComment.Location = new Point(20, 280);
            grpComment.Size = new Size(590, 100);

            TextBox txtComment = new TextBox();
            txtComment.Location = new Point(15, 25);
            txtComment.Size = new Size(560, 30);
            txtComment.Multiline = true;

            CheckBox chkInternal = new CheckBox();
            chkInternal.Text = "Internal Only";
            chkInternal.Location = new Point(15, 65);
            chkInternal.Size = new Size(120, 20);

            Button btnAddComment = new Button();
            btnAddComment.Text = "Add Comment";
            btnAddComment.Location = new Point(440, 60);
            btnAddComment.Size = new Size(130, 30);
            btnAddComment.Click += (s, e) => {
                if (!string.IsNullOrWhiteSpace(txtComment.Text))
                {
                    MessageBox.Show("Comment added", "Success");
                    txtComment.Text = "";
                }
                else
                {
                    MessageBox.Show("Please enter a comment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            grpComment.Controls.AddRange(new Control[] {
                txtComment, chkInternal, btnAddComment
            });

            // ========== ACTION BUTTONS ==========
            ComboBox cboChangeStatus = new ComboBox();
            cboChangeStatus.Text = "Change Status ▼";
            cboChangeStatus.Location = new Point(20, 400);
            cboChangeStatus.Size = new Size(130, 30);
            cboChangeStatus.Items.AddRange(new object[] { "Open", "In Progress", "On Hold", "Resolved", "Closed" });
            cboChangeStatus.SelectedIndexChanged += (s, e) => {
                if (cboChangeStatus.SelectedIndex >= 0)
                {
                    MessageBox.Show($"Status changed to {cboChangeStatus.SelectedItem}", "Status Change");
                    cboChangeStatus.Text = "Change Status";
                }
            };

            Button btnReassign = new Button();
            btnReassign.Text = "Reassign";
            btnReassign.Location = new Point(160, 400);
            btnReassign.Size = new Size(120, 30);
            btnReassign.Click += (s, e) => MessageBox.Show("Reassign dialog would open here", "Reassign");

            Button btnLinkRelated = new Button();
            btnLinkRelated.Text = "Link Related";
            btnLinkRelated.Location = new Point(290, 400);
            btnLinkRelated.Size = new Size(120, 30);
            btnLinkRelated.Click += (s, e) => MessageBox.Show("Link related items dialog would open here", "Link Items");

            Button btnResolve = new Button();
            btnResolve.Text = "Resolve";
            btnResolve.Location = new Point(420, 400);
            btnResolve.Size = new Size(120, 30);
            btnResolve.Click += (s, e) => {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to resolve this incident?",
                    "Confirm Resolution",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Incident has been resolved", "Resolved");
                    this.Close();
                }
            };

            // Add all controls to the form
            this.Controls.AddRange(new Control[] {
                grpInfo,
                grpTimeline,
                lblDescTitle,
                lblDescription,
                grpComment,
                cboChangeStatus,
                btnReassign,
                btnLinkRelated,
                btnResolve
            });
        }
    }
}