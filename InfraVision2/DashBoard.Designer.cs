namespace InfraVision2
{
    partial class DashBoard
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
            header = new Panel();
            faq_but = new Button();
            setting_but = new Button();
            notif_but = new Button();
            userdropdownBox1 = new ComboBox();
            infravision_desc = new Label();
            left = new Panel();
            reports_but = new Button();
            config_but = new Button();
            incident_but = new Button();
            alerts_but = new Button();
            users_but = new Button();
            server_but = new Button();
            body = new Panel();
            dataGridView1 = new DataGridView();
            ServerName = new DataGridViewTextBoxColumn();
            IPAddress = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            OperatingSystem = new DataGridViewTextBoxColumn();
            Metrics = new DataGridViewTextBoxColumn();
            ActionPanel = new Panel();
            refresh_button = new Button();
            manage_button = new Button();
            GroupButton = new Button();
            add_serverbut = new Button();
            server_grpBox = new GroupBox();
            searchServerTB = new TextBox();
            filtercomboBox = new ComboBox();
            Show_Servers = new Button();
            header.SuspendLayout();
            left.SuspendLayout();
            body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ActionPanel.SuspendLayout();
            server_grpBox.SuspendLayout();
            SuspendLayout();
            // 
            // header
            // 
            header.Controls.Add(faq_but);
            header.Controls.Add(setting_but);
            header.Controls.Add(notif_but);
            header.Controls.Add(userdropdownBox1);
            header.Controls.Add(infravision_desc);
            header.Location = new Point(0, 1);
            header.Name = "header";
            header.Size = new Size(800, 62);
            header.TabIndex = 0;
            // 
            // faq_but
            // 
            faq_but.Location = new Point(750, 17);
            faq_but.Name = "faq_but";
            faq_but.Size = new Size(32, 29);
            faq_but.TabIndex = 4;
            faq_but.Text = "❓";
            faq_but.UseVisualStyleBackColor = true;
            // 
            // setting_but
            // 
            setting_but.Location = new Point(707, 16);
            setting_but.Name = "setting_but";
            setting_but.Size = new Size(37, 29);
            setting_but.TabIndex = 3;
            setting_but.Text = "⚙️";
            setting_but.UseVisualStyleBackColor = true;
            setting_but.Click += setting_but_Click;
            // 
            // notif_but
            // 
            notif_but.Location = new Point(672, 16);
            notif_but.Name = "notif_but";
            notif_but.Size = new Size(29, 29);
            notif_but.TabIndex = 2;
            notif_but.Text = "🔔";
            notif_but.UseVisualStyleBackColor = true;
            notif_but.Click += notif_but_Click;
            // 
            // userdropdownBox1
            // 
            userdropdownBox1.FormattingEnabled = true;
            userdropdownBox1.Location = new Point(574, 17);
            userdropdownBox1.Name = "userdropdownBox1";
            userdropdownBox1.Size = new Size(92, 28);
            userdropdownBox1.TabIndex = 1;
            userdropdownBox1.SelectedIndexChanged += userdropdownBox1_SelectedIndexChanged;
            // 
            // infravision_desc
            // 
            infravision_desc.AutoSize = true;
            infravision_desc.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            infravision_desc.Location = new Point(13, 20);
            infravision_desc.Name = "infravision_desc";
            infravision_desc.Size = new Size(102, 25);
            infravision_desc.TabIndex = 0;
            infravision_desc.Text = "InfraVision";
            // 
            // left
            // 
            left.Controls.Add(reports_but);
            left.Controls.Add(config_but);
            left.Controls.Add(incident_but);
            left.Controls.Add(alerts_but);
            left.Controls.Add(users_but);
            left.Controls.Add(server_but);
            left.Location = new Point(0, 69);
            left.Name = "left";
            left.Size = new Size(155, 380);
            left.TabIndex = 1;
            // 
            // reports_but
            // 
            reports_but.Location = new Point(22, 301);
            reports_but.Name = "reports_but";
            reports_but.Size = new Size(94, 29);
            reports_but.TabIndex = 5;
            reports_but.Text = "Reports";
            reports_but.UseVisualStyleBackColor = true;
            reports_but.Click += reports_but_Click;
            // 
            // config_but
            // 
            config_but.Location = new Point(22, 246);
            config_but.Name = "config_but";
            config_but.Size = new Size(94, 29);
            config_but.TabIndex = 4;
            config_but.Text = "Config";
            config_but.UseVisualStyleBackColor = true;
            config_but.Click += config_but_Click;
            // 
            // incident_but
            // 
            incident_but.Location = new Point(22, 194);
            incident_but.Name = "incident_but";
            incident_but.Size = new Size(94, 29);
            incident_but.TabIndex = 3;
            incident_but.Text = "Incidents";
            incident_but.UseVisualStyleBackColor = true;
            incident_but.Click += incident_but_Click;
            // 
            // alerts_but
            // 
            alerts_but.Location = new Point(22, 140);
            alerts_but.Name = "alerts_but";
            alerts_but.Size = new Size(94, 29);
            alerts_but.TabIndex = 2;
            alerts_but.Text = "Alerts";
            alerts_but.UseVisualStyleBackColor = true;
            alerts_but.Click += alerts_but_Click;
            // 
            // users_but
            // 
            users_but.Location = new Point(22, 89);
            users_but.Name = "users_but";
            users_but.Size = new Size(93, 29);
            users_but.TabIndex = 1;
            users_but.Text = "Users";
            users_but.UseVisualStyleBackColor = true;
            users_but.Click += users_but_Click;
            // 
            // server_but
            // 
            server_but.Location = new Point(22, 27);
            server_but.Name = "server_but";
            server_but.Size = new Size(94, 29);
            server_but.TabIndex = 0;
            server_but.Text = "Servers";
            server_but.UseVisualStyleBackColor = true;
            server_but.Click += server_but_Click;
            // 
            // body
            // 
            body.Controls.Add(dataGridView1);
            body.Controls.Add(ActionPanel);
            body.Controls.Add(server_grpBox);
            body.Location = new Point(161, 69);
            body.Name = "body";
            body.Size = new Size(639, 380);
            body.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ServerName, IPAddress, Status, OperatingSystem, Metrics });
            dataGridView1.Location = new Point(10, 169);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(616, 188);
            dataGridView1.TabIndex = 2;
            // 
            // ServerName
            // 
            ServerName.HeaderText = "Name";
            ServerName.MinimumWidth = 6;
            ServerName.Name = "ServerName";
            ServerName.Width = 105;
            // 
            // IPAddress
            // 
            IPAddress.HeaderText = "IP Address";
            IPAddress.MinimumWidth = 6;
            IPAddress.Name = "IPAddress";
            IPAddress.Width = 120;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 120;
            // 
            // OperatingSystem
            // 
            OperatingSystem.HeaderText = "OS";
            OperatingSystem.MinimumWidth = 6;
            OperatingSystem.Name = "OperatingSystem";
            OperatingSystem.Width = 105;
            // 
            // Metrics
            // 
            Metrics.HeaderText = "Metrics";
            Metrics.MinimumWidth = 6;
            Metrics.Name = "Metrics";
            Metrics.Width = 120;
            // 
            // ActionPanel
            // 
            ActionPanel.Controls.Add(refresh_button);
            ActionPanel.Controls.Add(manage_button);
            ActionPanel.Controls.Add(GroupButton);
            ActionPanel.Controls.Add(add_serverbut);
            ActionPanel.Location = new Point(9, 98);
            ActionPanel.Name = "ActionPanel";
            ActionPanel.Size = new Size(612, 59);
            ActionPanel.TabIndex = 1;
            // 
            // refresh_button
            // 
            refresh_button.Location = new Point(468, 21);
            refresh_button.Name = "refresh_button";
            refresh_button.Size = new Size(94, 29);
            refresh_button.TabIndex = 3;
            refresh_button.Text = "[↻] Refresh";
            refresh_button.UseVisualStyleBackColor = true;
            // 
            // manage_button
            // 
            manage_button.Location = new Point(304, 21);
            manage_button.Name = "manage_button";
            manage_button.Size = new Size(134, 29);
            manage_button.TabIndex = 2;
            manage_button.Text = "[⚙️] Manage";
            manage_button.UseVisualStyleBackColor = true;
            // 
            // GroupButton
            // 
            GroupButton.Location = new Point(164, 21);
            GroupButton.Name = "GroupButton";
            GroupButton.Size = new Size(109, 29);
            GroupButton.TabIndex = 1;
            GroupButton.Text = "[≡] Group";
            GroupButton.UseVisualStyleBackColor = true;
            // 
            // add_serverbut
            // 
            add_serverbut.Location = new Point(18, 21);
            add_serverbut.Name = "add_serverbut";
            add_serverbut.Size = new Size(124, 29);
            add_serverbut.TabIndex = 0;
            add_serverbut.Text = "[+] Add Server";
            add_serverbut.UseVisualStyleBackColor = true;
            // 
            // server_grpBox
            // 
            server_grpBox.Controls.Add(searchServerTB);
            server_grpBox.Controls.Add(filtercomboBox);
            server_grpBox.Controls.Add(Show_Servers);
            server_grpBox.Location = new Point(3, 14);
            server_grpBox.Name = "server_grpBox";
            server_grpBox.Size = new Size(618, 71);
            server_grpBox.TabIndex = 0;
            server_grpBox.TabStop = false;
            server_grpBox.Text = "Servers";
            // 
            // searchServerTB
            // 
            searchServerTB.Location = new Point(392, 31);
            searchServerTB.Name = "searchServerTB";
            searchServerTB.PlaceholderText = "Search servers... ";
            searchServerTB.Size = new Size(203, 27);
            searchServerTB.TabIndex = 2;
            // 
            // filtercomboBox
            // 
            filtercomboBox.FormattingEnabled = true;
            filtercomboBox.Items.AddRange(new object[] { "All", "Active", "Warning", "Down" });
            filtercomboBox.Location = new Point(181, 27);
            filtercomboBox.Name = "filtercomboBox";
            filtercomboBox.Size = new Size(151, 28);
            filtercomboBox.TabIndex = 1;
            // 
            // Show_Servers
            // 
            Show_Servers.Location = new Point(6, 26);
            Show_Servers.Name = "Show_Servers";
            Show_Servers.Size = new Size(126, 29);
            Show_Servers.TabIndex = 0;
            Show_Servers.Text = "Show Servers";
            Show_Servers.UseVisualStyleBackColor = true;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 445);
            Controls.Add(body);
            Controls.Add(left);
            Controls.Add(header);
            Name = "DashBoard";
            Text = "DashBoard";
            header.ResumeLayout(false);
            header.PerformLayout();
            left.ResumeLayout(false);
            body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ActionPanel.ResumeLayout(false);
            server_grpBox.ResumeLayout(false);
            server_grpBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel header;
        private Panel left;
        private Panel body;
        private Label infravision_desc;
        private ComboBox userdropdownBox1;
        private Button notif_but;
        private Button setting_but;
        private Button faq_but;
        private Button server_but;
        private Button users_but;
        private Button alerts_but;
        private Button incident_but;
        private Button config_but;
        private Button reports_but;
        private GroupBox server_grpBox;
        private Button Show_Servers;
        private ComboBox filtercomboBox;
        private TextBox searchServerTB;
        private Panel ActionPanel;
        private Button add_serverbut;
        private Button GroupButton;
        private Button manage_button;
        private Button refresh_button;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ServerName;
        private DataGridViewTextBoxColumn IPAddress;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn OperatingSystem;
        private DataGridViewTextBoxColumn Metrics;
    }
}