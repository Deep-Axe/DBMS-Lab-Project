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
    public partial class AlertDetailsForm : Form
    {
        public AlertDetailsForm(string alertName, string server, string severity, string timeAgo, string status)
        {
            // Set form properties
            this.Text = $"Alert Details: {alertName}";
            this.Size = new Size(650, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Create the alert details UI with the layout from the mockup
            CreateAlertDetailsUI(alertName, server, severity, timeAgo, status);
        }
        private void AlertDetailsForm_Load(object sender, EventArgs e)
        {
        }
        private void CreateAlertDetailsUI(string alertName, string server, string severity, string timeAgo, string status)
        {
            // ========== ALERT INFORMATION PANEL (LEFT) ==========
            GroupBox grpAlertInfo = new GroupBox();
            grpAlertInfo.Text = "Alert Information";
            grpAlertInfo.Location = new Point(20, 20);
            grpAlertInfo.Size = new Size(260, 180);

            // Server information
            Label lblServer = new Label();
            lblServer.Text = $"Server: {server}";
            lblServer.Location = new Point(15, 30);
            lblServer.Size = new Size(230, 20);
            lblServer.Font = new Font("Segoe UI", 9);

            // Severity
            Label lblSeverity = new Label();
            lblSeverity.Text = $"Severity: {severity.Replace("🔴 ", "").Replace("🟠 ", "").Replace("🟡 ", "")}";
            lblSeverity.Location = new Point(15, 55);
            lblSeverity.Size = new Size(230, 20);
            lblSeverity.Font = new Font("Segoe UI", 9);
            if (severity.Contains("CRIT"))
            {
                lblSeverity.ForeColor = Color.Red;
                lblSeverity.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
            else if (severity.Contains("WARN"))
            {
                lblSeverity.ForeColor = Color.DarkOrange;
            }

            // Triggered time (mock data based on timeAgo)
            DateTime now = DateTime.Now;
            DateTime triggeredTime = now.AddMinutes(-ParseTimeAgo(timeAgo));
            Label lblTriggered = new Label();
            lblTriggered.Text = $"Triggered: {triggeredTime.ToString("HH:mm:ss")}";
            lblTriggered.Location = new Point(15, 80);
            lblTriggered.Size = new Size(230, 20);
            lblTriggered.Font = new Font("Segoe UI", 9);

            // Current value and threshold (mock data based on alert type)
            string currentValue = "97%";
            string threshold = "95%";
            if (alertName.Contains("Disk Space"))
            {
                currentValue = "4%";
                threshold = "5%";
            }
            else if (alertName.Contains("Memory"))
            {
                currentValue = "92%";
                threshold = "90%";
            }

            Label lblCurrentValue = new Label();
            lblCurrentValue.Text = $"Current Value: {currentValue}";
            lblCurrentValue.Location = new Point(15, 105);
            lblCurrentValue.Size = new Size(230, 20);
            lblCurrentValue.Font = new Font("Segoe UI", 9);

            Label lblThreshold = new Label();
            lblThreshold.Text = $"Threshold: {threshold}";
            lblThreshold.Location = new Point(15, 130);
            lblThreshold.Size = new Size(230, 20);
            lblThreshold.Font = new Font("Segoe UI", 9);

            Label lblStatus = new Label();
            lblStatus.Text = $"Status: {status}";
            lblStatus.Location = new Point(15, 155);
            lblStatus.Size = new Size(230, 20);
            lblStatus.Font = new Font("Segoe UI", 9);

            // Add labels to the group box
            grpAlertInfo.Controls.AddRange(new Control[] {
                lblServer, lblSeverity, lblTriggered, lblCurrentValue, lblThreshold, lblStatus
            });

            // ========== METRIC HISTORY PANEL (RIGHT) ==========
            GroupBox grpMetricHistory = new GroupBox();
            grpMetricHistory.Text = "Metric History";
            grpMetricHistory.Location = new Point(300, 20);
            grpMetricHistory.Size = new Size(310, 180);

            // Mock chart (actually just a label with placeholder text)
            Label lblChartPlaceholder = new Label();
            lblChartPlaceholder.Text = "[Chart showing CPU trend over the last 24 hours]";
            lblChartPlaceholder.Location = new Point(15, 30);
            lblChartPlaceholder.Size = new Size(280, 100);
            lblChartPlaceholder.BorderStyle = BorderStyle.FixedSingle;
            lblChartPlaceholder.TextAlign = ContentAlignment.MiddleCenter;
            lblChartPlaceholder.Font = new Font("Segoe UI", 9);

            // Peak and average values
            Label lblPeak = new Label();
            lblPeak.Text = "Peak: 98% at 14:12:45";
            lblPeak.Location = new Point(15, 140);
            lblPeak.Size = new Size(280, 20);
            lblPeak.Font = new Font("Segoe UI", 9);

            Label lblAverage = new Label();
            lblAverage.Text = "Average: 92%";
            lblAverage.Location = new Point(15, 160);
            lblAverage.Size = new Size(280, 20);
            lblAverage.Font = new Font("Segoe UI", 9);

            // Add controls to metric history group
            grpMetricHistory.Controls.AddRange(new Control[] {
                lblChartPlaceholder, lblPeak, lblAverage
            });

            // ========== RELATED INCIDENTS PANEL ==========
            GroupBox grpRelatedIncidents = new GroupBox();
            grpRelatedIncidents.Text = "Related Incidents";
            grpRelatedIncidents.Location = new Point(20, 210);
            grpRelatedIncidents.Size = new Size(590, 120);

            // No related incidents message
            Label lblNoIncidents = new Label();
            lblNoIncidents.Text = "• None currently associated";
            lblNoIncidents.Location = new Point(15, 30);
            lblNoIncidents.Size = new Size(560, 30);
            lblNoIncidents.Font = new Font("Segoe UI", 9);

            // Create incident button
            Button btnCreateIncident = new Button();
            btnCreateIncident.Text = "Create Incident from Alert";
            btnCreateIncident.Location = new Point(15, 70);
            btnCreateIncident.Size = new Size(200, 30);
            btnCreateIncident.Click += (s, e) => MessageBox.Show("Create incident dialog would open here", "Create Incident");

            // Add controls to related incidents group
            grpRelatedIncidents.Controls.AddRange(new Control[] {
                lblNoIncidents, btnCreateIncident
            });

            // ========== ACTION BUTTONS ==========
            Button btnAcknowledge = new Button();
            btnAcknowledge.Text = "Acknowledge";
            btnAcknowledge.Location = new Point(20, 350);
            btnAcknowledge.Size = new Size(120, 30);
            btnAcknowledge.Click += (s, e) =>
            {
                MessageBox.Show("Alert has been acknowledged", "Acknowledge Alert");
                this.Close();
            };

            Button btnSuppress = new Button();
            btnSuppress.Text = "Suppress for 1hr";
            btnSuppress.Location = new Point(150, 350);
            btnSuppress.Size = new Size(120, 30);
            btnSuppress.Click += (s, e) =>
            {
                MessageBox.Show("Alert will be suppressed for 1 hour", "Suppress Alert");
                this.Close();
            };

            Button btnViewServer = new Button();
            btnViewServer.Text = "View Server";
            btnViewServer.Location = new Point(280, 350);
            btnViewServer.Size = new Size(120, 30);
            btnViewServer.Click += (s, e) => MessageBox.Show($"Would navigate to server details for {server}", "View Server");

            Button btnEditDefinition = new Button();
            btnEditDefinition.Text = "Edit Alert Definition";
            btnEditDefinition.Location = new Point(410, 350);
            btnEditDefinition.Size = new Size(200, 30);
            btnEditDefinition.Click += (s, e) => MessageBox.Show("Edit alert definition dialog would open here", "Edit Definition");

            // Add all controls to the form
            this.Controls.AddRange(new Control[] {
                grpAlertInfo,
                grpMetricHistory,
                grpRelatedIncidents,
                btnAcknowledge,
                btnSuppress,
                btnViewServer,
                btnEditDefinition
            });
        }

        // Helper method to parse time ago strings into minutes
        private int ParseTimeAgo(string timeAgo)
        {
            if (timeAgo.Contains("min"))
            {
                int minutes;
                int.TryParse(timeAgo.Split(' ')[0], out minutes);
                return minutes;
            }
            else if (timeAgo.Contains("hr"))
            {
                int hours;
                int.TryParse(timeAgo.Split(' ')[0], out hours);
                return hours * 60;
            }
            else if (timeAgo.Contains("day"))
            {
                int days;
                int.TryParse(timeAgo.Split(' ')[0], out days);
                return days * 24 * 60;
            }

            return 10; // Default 10 minutes if parsing fails
        }
    }
}
