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
    public partial class DashBoard : Form
    {
        private Panel pnlNotifications;
        private bool notificationPanelVisible = false;
        private Button btnUserProfile;
        private ContextMenuStrip userProfileMenu;
        public DashBoard()
        {
            InitializeComponent();
            SetupNotificationPanel();
            SetupUserDropdown();
        }

        private void server_but_Click(object sender, EventArgs e)
        {
            using (ServerSelectionDialog selectDialog = new ServerSelectionDialog())
            {
                // Show the dialog and wait for result
                DialogResult result = selectDialog.ShowDialog();

                // If user clicked OK and a server was selected
                if (result == DialogResult.OK && !string.IsNullOrEmpty(selectDialog.SelectedServerName))
                {
                    // Open a new form with server details
                    Servers detailsForm = new Servers(
                        selectDialog.SelectedServerID,
                        selectDialog.SelectedServerName);

                    detailsForm.Show();
                }
            }

        }

        private void users_but_Click(object sender, EventArgs e)
        {
            Users userForm = new Users();
            userForm.Show();
        }

        private void alerts_but_Click(object sender, EventArgs e)
        {
            Alerts alertForm = new Alerts();
            alertForm.Show();
        }

        private void incident_but_Click(object sender, EventArgs e)
        {
            Incidents incidentForm = new Incidents();
            incidentForm.Show();
        }

        private void config_but_Click(object sender, EventArgs e)
        {
            Configuration configForm = new Configuration();
            configForm.Show();
        }

        private void reports_but_Click(object sender, EventArgs e)
        {
            Reports reportForm = new Reports();
            reportForm.Show();
        }

        private void setting_but_Click(object sender, EventArgs e)
        {
            Settings settingForm = new Settings();
            settingForm.Show();
        }
        private void SetupNotificationPanel()
        {
            // Create the notification panel
            pnlNotifications = new Panel();
            pnlNotifications.Size = new Size(350, 300);
            pnlNotifications.BorderStyle = BorderStyle.FixedSingle;
            pnlNotifications.BackColor = Color.White;
            pnlNotifications.Visible = false; // Hidden by default

            // Create header
            Panel pnlHeader = new Panel();
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 30;
            pnlHeader.BackColor = Color.FromArgb(240, 240, 240);

            Label lblTitle = new Label();
            lblTitle.Text = "Notifications";
            lblTitle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblTitle.Location = new Point(10, 7);
            lblTitle.AutoSize = true;

            Button btnClose = new Button();
            btnClose.Text = "X";
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Size = new Size(25, 25);
            btnClose.Location = new Point(pnlNotifications.Width - 30, 3);
            btnClose.Click += (s, e) =>
            {
                pnlNotifications.Visible = false;
                notificationPanelVisible = false;
            };

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnClose);

            // Create content panel for scrollable content
            Panel pnlContent = new Panel();
            pnlContent.Location = new Point(0, 30);
            pnlContent.Size = new Size(350, 230);
            pnlContent.AutoScroll = true;

            // Today section
            Label lblToday = new Label();
            lblToday.Text = "Today";
            lblToday.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblToday.Location = new Point(10, 10);
            lblToday.Size = new Size(100, 20);

            Label lblNotif1 = new Label();
            lblNotif1.Text = "• CPU Alert on APP-03 (10 min ago)";
            lblNotif1.Font = new Font("Segoe UI", 8.5f);
            lblNotif1.Location = new Point(10, 35);
            lblNotif1.Size = new Size(320, 20);

            Label lblNotif2 = new Label();
            lblNotif2.Text = "• New incident assigned to you: #145 (35 min)";
            lblNotif2.Font = new Font("Segoe UI", 8.5f);
            lblNotif2.Location = new Point(10, 60);
            lblNotif2.Size = new Size(320, 20);

            Label lblNotif3 = new Label();
            lblNotif3.Text = "• Security update available for DB-01 (2 hrs)";
            lblNotif3.Font = new Font("Segoe UI", 8.5f);
            lblNotif3.Location = new Point(10, 85);
            lblNotif3.Size = new Size(320, 20);

            // Yesterday section
            Label lblYesterday = new Label();
            lblYesterday.Text = "Yesterday";
            lblYesterday.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblYesterday.Location = new Point(10, 120);
            lblYesterday.Size = new Size(100, 20);

            Label lblNotif4 = new Label();
            lblNotif4.Text = "• Incident #142 resolved by tchen";
            lblNotif4.Font = new Font("Segoe UI", 8.5f);
            lblNotif4.Location = new Point(10, 145);
            lblNotif4.Size = new Size(320, 20);

            Label lblNotif5 = new Label();
            lblNotif5.Text = "• Scheduled maintenance completed";
            lblNotif5.Font = new Font("Segoe UI", 8.5f);
            lblNotif5.Location = new Point(10, 170);
            lblNotif5.Size = new Size(320, 20);

            Label lblNotif6 = new Label();
            lblNotif6.Text = "• 2 new users added by agarcia";
            lblNotif6.Font = new Font("Segoe UI", 8.5f);
            lblNotif6.Location = new Point(10, 195);
            lblNotif6.Size = new Size(320, 20);

            // Add all notification elements to content panel
            pnlContent.Controls.AddRange(new Control[] {
                lblToday, lblNotif1, lblNotif2, lblNotif3,
                lblYesterday, lblNotif4, lblNotif5, lblNotif6
            });

            // Create footer with action buttons
            Panel pnlFooter = new Panel();
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Height = 40;
            pnlFooter.BackColor = Color.FromArgb(245, 245, 245);

            Button btnViewAll = new Button();
            btnViewAll.Text = "View All Notifications";
            btnViewAll.Location = new Point(10, 8);
            btnViewAll.Size = new Size(160, 25);
            btnViewAll.FlatStyle = FlatStyle.Flat;
            btnViewAll.Click += (s, e) => MessageBox.Show("Would navigate to all notifications", "View All");

            Button btnMarkRead = new Button();
            btnMarkRead.Text = "Mark All as Read";
            btnMarkRead.Location = new Point(180, 8);
            btnMarkRead.Size = new Size(160, 25);
            btnMarkRead.FlatStyle = FlatStyle.Flat;
            btnMarkRead.Click += (s, e) =>
            {
                MessageBox.Show("All notifications marked as read", "Mark Read");

                // Visual indication that notifications were read (could change background color, etc.)
                lblNotif1.ForeColor = Color.Gray;
                lblNotif2.ForeColor = Color.Gray;
                lblNotif3.ForeColor = Color.Gray;
            };

            pnlFooter.Controls.Add(btnViewAll);
            pnlFooter.Controls.Add(btnMarkRead);

            // Add all sections to notification panel
            pnlNotifications.Controls.Add(pnlHeader);
            pnlNotifications.Controls.Add(pnlContent);
            pnlNotifications.Controls.Add(pnlFooter);

            // Add the panel to the form
            this.Controls.Add(pnlNotifications);

            // Ensure it's on top of other controls
            pnlNotifications.BringToFront();
        }
        private void notif_but_Click(object sender, EventArgs e)
        {
            if (!notificationPanelVisible)
            {
                // Position the panel below the notification bell button
                Point location = notif_but.PointToScreen(new Point(0, notif_but.Height));
                location = this.PointToClient(location);

                // Adjust position to align with the right edge of the button
                location.X = notif_but.Location.X + notif_but.Width - pnlNotifications.Width;

                pnlNotifications.Location = location;
                pnlNotifications.Visible = true;
                notificationPanelVisible = true;

                // Bring to front to ensure it's above other controls
                pnlNotifications.BringToFront();
            }
            else
            {
                pnlNotifications.Visible = false;
                notificationPanelVisible = false;
            }
        }
        private void SetupUserDropdown()
        {
            // Clear existing items
            userdropdownBox1.Items.Clear();

            // Add the dropdown items according to the mockup
            userdropdownBox1.Items.Add("Deep-Axe");
            userdropdownBox1.Items.Add("• My Profile");
            userdropdownBox1.Items.Add("• Account Settings");
            userdropdownBox1.Items.Add("• Preferences");
            userdropdownBox1.Items.Add("• API Keys");
            userdropdownBox1.Items.Add("──────────────────────────────");
            userdropdownBox1.Items.Add("• Help");
            userdropdownBox1.Items.Add("• About");
            userdropdownBox1.Items.Add("──────────────────────────────");
            userdropdownBox1.Items.Add("• Log Out");

            // Set the selected item to show "Deep-Axe" initially
            userdropdownBox1.SelectedIndex = 0;

            // If you want to make the dropdown width match content
            userdropdownBox1.DropDownWidth = 250;
        }
        private void userdropdownBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = userdropdownBox1.SelectedItem.ToString();

            // Handle the action based on selection
            switch (selectedItem)
            {
                case "• My Profile":
                    MessageBox.Show("My Profile selected", "Profile");
                    break;

                case "• Account Settings":
                    MessageBox.Show("Account Settings selected", "Account");
                    break;

                case "• Preferences":
                    MessageBox.Show("Preferences selected", "Preferences");
                    break;

                case "• API Keys":
                    MessageBox.Show("API Keys selected", "API Keys");
                    break;

                case "• Help":
                    MessageBox.Show("Help selected", "Help");
                    break;

                case "• About":
                    MessageBox.Show("About selected", "About");
                    break;

                case "• Log Out":
                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to log out?",
                        "Confirm Logout",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    break;
            }

            // Always set the selected index back to 0 to show "Deep-Axe"
            // This needs to be done after handling the selection to avoid recursion
            if (userdropdownBox1.SelectedIndex != 0)
            {
                userdropdownBox1.SelectedIndex = 0;
            }
        }
    }
    public class ServerSelectionDialog : Form
    {
        private ComboBox cboServers;
        private Button btnOK;
        private Button btnCancel;

        public int SelectedServerID { get; private set; }
        public string SelectedServerName { get; private set; }

        public ServerSelectionDialog()
        {
            InitializeComponents();
            LoadServers();
        }

        private void InitializeComponents()
        {
            // Configure the form
            this.Text = "Select Server";
            this.Size = new Size(350, 170);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Create and configure the label
            Label lblPrompt = new Label
            {
                Text = "Select a server:",
                Location = new Point(20, 20),
                Size = new Size(300, 20)
            };

            // Create and configure the ComboBox
            cboServers = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(20, 45),
                Size = new Size(300, 25)
            };

            // Create and configure the OK button
            btnOK = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(160, 80),
                Size = new Size(75, 25)
            };
            btnOK.Click += BtnOK_Click;

            // Create and configure the Cancel button
            btnCancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(245, 80),
                Size = new Size(75, 25)
            };

            // Add controls to the form
            this.Controls.Add(lblPrompt);
            this.Controls.Add(cboServers);
            this.Controls.Add(btnOK);
            this.Controls.Add(btnCancel);

            // Set default button behaviors
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

        private void LoadServers()
        {
            // This would normally fetch data from a database
            // For now, we'll use sample data

            // Create a DataTable to store server information
            DataTable servers = new DataTable();
            servers.Columns.Add("ServerID", typeof(int));
            servers.Columns.Add("ServerName", typeof(string));

            // Add sample servers
            servers.Rows.Add(1, "DB-01");
            servers.Rows.Add(2, "APP-03");
            servers.Rows.Add(3, "WEB-02");
            servers.Rows.Add(4, "CACHE-01");
            servers.Rows.Add(5, "BACKUP-01");

            // Bind the ComboBox to the data
            cboServers.DisplayMember = "ServerName";
            cboServers.ValueMember = "ServerID";
            cboServers.DataSource = servers;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (cboServers.SelectedIndex != -1)
            {
                // Store the selected server information
                SelectedServerID = Convert.ToInt32(cboServers.SelectedValue);
                SelectedServerName = cboServers.Text;

                // Close the dialog with OK result
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a server.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
