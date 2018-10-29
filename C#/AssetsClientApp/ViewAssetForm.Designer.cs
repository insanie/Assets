namespace AssetsClientApp
{
	partial class ViewAssetForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tabPanel = new System.Windows.Forms.TabControl();
			this.cpuTab = new System.Windows.Forms.TabPage();
			this.dimmTab = new System.Windows.Forms.TabPage();
			this.drivesTab = new System.Windows.Forms.TabPage();
			this.partitionsTab = new System.Windows.Forms.TabPage();
			this.networkingTab = new System.Windows.Forms.TabPage();
			this.gpuTab = new System.Windows.Forms.TabPage();
			this.monitorsTab = new System.Windows.Forms.TabPage();
			this.printersTab = new System.Windows.Forms.TabPage();
			this.usersTab = new System.Windows.Forms.TabPage();
			this.usersGridView = new System.Windows.Forms.DataGridView();
			this.softwareTab = new System.Windows.Forms.TabPage();
			this.softwareGridView = new System.Windows.Forms.DataGridView();
			this.os_langLabel = new System.Windows.Forms.TextBox();
			this.os_langStaticLabel = new System.Windows.Forms.Label();
			this.os_buildLabel = new System.Windows.Forms.TextBox();
			this.os_buildStaticLabel = new System.Windows.Forms.Label();
			this.os_archLabel = new System.Windows.Forms.TextBox();
			this.os_archStaticLabel = new System.Windows.Forms.Label();
			this.os_systemLabel = new System.Windows.Forms.TextBox();
			this.os_systemStaticLabel = new System.Windows.Forms.Label();
			this.osGroupBox = new System.Windows.Forms.GroupBox();
			this.ramGroupBox = new System.Windows.Forms.GroupBox();
			this.ram_maxLabel = new System.Windows.Forms.TextBox();
			this.ram_occslotsStaticLabel = new System.Windows.Forms.Label();
			this.ram_maxStaticLabel = new System.Windows.Forms.Label();
			this.ram_occslotsLabel = new System.Windows.Forms.TextBox();
			this.ram_totalLabel = new System.Windows.Forms.TextBox();
			this.ram_totalslotsStaticLabel = new System.Windows.Forms.Label();
			this.ram_totalStaticLabel = new System.Windows.Forms.Label();
			this.ram_totalslotsLabel = new System.Windows.Forms.TextBox();
			this.motherboardGroupBox = new System.Windows.Forms.GroupBox();
			this.mobo_vendorStaticLabel = new System.Windows.Forms.Label();
			this.mobo_vendorLabel = new System.Windows.Forms.TextBox();
			this.mobo_revLabel = new System.Windows.Forms.TextBox();
			this.mobo_modelStaticLabel = new System.Windows.Forms.Label();
			this.mobo_revStaticLabel = new System.Windows.Forms.Label();
			this.mobo_modelLabel = new System.Windows.Forms.TextBox();
			this.biosGroupBox = new System.Windows.Forms.GroupBox();
			this.bios_vendorStaticLabel = new System.Windows.Forms.Label();
			this.bios_vendorLabel = new System.Windows.Forms.TextBox();
			this.bios_verLabel = new System.Windows.Forms.TextBox();
			this.bios_nameStaticLabel = new System.Windows.Forms.Label();
			this.bios_verStaticLabel = new System.Windows.Forms.Label();
			this.bios_nameLabel = new System.Windows.Forms.TextBox();
			this.groupsPanel = new System.Windows.Forms.Panel();
			this.tabPanel.SuspendLayout();
			this.usersTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.usersGridView)).BeginInit();
			this.softwareTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.softwareGridView)).BeginInit();
			this.osGroupBox.SuspendLayout();
			this.ramGroupBox.SuspendLayout();
			this.motherboardGroupBox.SuspendLayout();
			this.biosGroupBox.SuspendLayout();
			this.groupsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPanel
			// 
			this.tabPanel.Controls.Add(this.cpuTab);
			this.tabPanel.Controls.Add(this.dimmTab);
			this.tabPanel.Controls.Add(this.drivesTab);
			this.tabPanel.Controls.Add(this.partitionsTab);
			this.tabPanel.Controls.Add(this.networkingTab);
			this.tabPanel.Controls.Add(this.gpuTab);
			this.tabPanel.Controls.Add(this.monitorsTab);
			this.tabPanel.Controls.Add(this.printersTab);
			this.tabPanel.Controls.Add(this.usersTab);
			this.tabPanel.Controls.Add(this.softwareTab);
			this.tabPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tabPanel.Location = new System.Drawing.Point(0, 204);
			this.tabPanel.Margin = new System.Windows.Forms.Padding(0);
			this.tabPanel.Name = "tabPanel";
			this.tabPanel.Padding = new System.Drawing.Point(0, 0);
			this.tabPanel.SelectedIndex = 0;
			this.tabPanel.Size = new System.Drawing.Size(857, 148);
			this.tabPanel.TabIndex = 2;
			// 
			// cpuTab
			// 
			this.cpuTab.AutoScroll = true;
			this.cpuTab.BackColor = System.Drawing.SystemColors.Control;
			this.cpuTab.Location = new System.Drawing.Point(4, 26);
			this.cpuTab.Margin = new System.Windows.Forms.Padding(0);
			this.cpuTab.Name = "cpuTab";
			this.cpuTab.Size = new System.Drawing.Size(849, 118);
			this.cpuTab.TabIndex = 2;
			this.cpuTab.Text = "CPU";
			this.cpuTab.Enter += new System.EventHandler(this.cpuTab_Enter);
			// 
			// dimmTab
			// 
			this.dimmTab.AutoScroll = true;
			this.dimmTab.BackColor = System.Drawing.SystemColors.Control;
			this.dimmTab.Location = new System.Drawing.Point(4, 26);
			this.dimmTab.Margin = new System.Windows.Forms.Padding(0);
			this.dimmTab.Name = "dimmTab";
			this.dimmTab.Size = new System.Drawing.Size(849, 118);
			this.dimmTab.TabIndex = 6;
			this.dimmTab.Text = "DIMM";
			this.dimmTab.Enter += new System.EventHandler(this.dimmTab_Enter);
			// 
			// drivesTab
			// 
			this.drivesTab.AutoScroll = true;
			this.drivesTab.BackColor = System.Drawing.SystemColors.Control;
			this.drivesTab.Location = new System.Drawing.Point(4, 26);
			this.drivesTab.Margin = new System.Windows.Forms.Padding(0);
			this.drivesTab.Name = "drivesTab";
			this.drivesTab.Size = new System.Drawing.Size(849, 118);
			this.drivesTab.TabIndex = 4;
			this.drivesTab.Text = "Drives";
			this.drivesTab.Enter += new System.EventHandler(this.drivesTab_Enter);
			// 
			// partitionsTab
			// 
			this.partitionsTab.AutoScroll = true;
			this.partitionsTab.BackColor = System.Drawing.SystemColors.Control;
			this.partitionsTab.Location = new System.Drawing.Point(4, 26);
			this.partitionsTab.Margin = new System.Windows.Forms.Padding(0);
			this.partitionsTab.Name = "partitionsTab";
			this.partitionsTab.Size = new System.Drawing.Size(849, 118);
			this.partitionsTab.TabIndex = 5;
			this.partitionsTab.Text = "Partitions";
			this.partitionsTab.Enter += new System.EventHandler(this.partitionsTab_Enter);
			// 
			// networkingTab
			// 
			this.networkingTab.AutoScroll = true;
			this.networkingTab.BackColor = System.Drawing.SystemColors.Control;
			this.networkingTab.Location = new System.Drawing.Point(4, 26);
			this.networkingTab.Margin = new System.Windows.Forms.Padding(0);
			this.networkingTab.Name = "networkingTab";
			this.networkingTab.Size = new System.Drawing.Size(849, 118);
			this.networkingTab.TabIndex = 7;
			this.networkingTab.Text = "Networking";
			this.networkingTab.Enter += new System.EventHandler(this.networkingTab_Enter);
			// 
			// gpuTab
			// 
			this.gpuTab.AutoScroll = true;
			this.gpuTab.BackColor = System.Drawing.SystemColors.Control;
			this.gpuTab.Location = new System.Drawing.Point(4, 26);
			this.gpuTab.Margin = new System.Windows.Forms.Padding(0);
			this.gpuTab.Name = "gpuTab";
			this.gpuTab.Size = new System.Drawing.Size(849, 118);
			this.gpuTab.TabIndex = 8;
			this.gpuTab.Text = "GPU";
			this.gpuTab.Enter += new System.EventHandler(this.gpuTab_Enter);
			// 
			// monitorsTab
			// 
			this.monitorsTab.AutoScroll = true;
			this.monitorsTab.BackColor = System.Drawing.SystemColors.Control;
			this.monitorsTab.Location = new System.Drawing.Point(4, 26);
			this.monitorsTab.Margin = new System.Windows.Forms.Padding(0);
			this.monitorsTab.Name = "monitorsTab";
			this.monitorsTab.Size = new System.Drawing.Size(849, 118);
			this.monitorsTab.TabIndex = 9;
			this.monitorsTab.Text = "Monitors";
			this.monitorsTab.Enter += new System.EventHandler(this.monitorsTab_Enter);
			// 
			// printersTab
			// 
			this.printersTab.AutoScroll = true;
			this.printersTab.BackColor = System.Drawing.SystemColors.Control;
			this.printersTab.Location = new System.Drawing.Point(4, 26);
			this.printersTab.Margin = new System.Windows.Forms.Padding(0);
			this.printersTab.Name = "printersTab";
			this.printersTab.Size = new System.Drawing.Size(849, 118);
			this.printersTab.TabIndex = 10;
			this.printersTab.Text = "Printers";
			this.printersTab.Enter += new System.EventHandler(this.printersTab_Enter);
			// 
			// usersTab
			// 
			this.usersTab.AutoScroll = true;
			this.usersTab.BackColor = System.Drawing.Color.Transparent;
			this.usersTab.Controls.Add(this.usersGridView);
			this.usersTab.Location = new System.Drawing.Point(4, 26);
			this.usersTab.Margin = new System.Windows.Forms.Padding(0);
			this.usersTab.Name = "usersTab";
			this.usersTab.Size = new System.Drawing.Size(849, 118);
			this.usersTab.TabIndex = 1;
			this.usersTab.Text = "Users";
			this.usersTab.UseVisualStyleBackColor = true;
			this.usersTab.Enter += new System.EventHandler(this.usersTab_Enter);
			// 
			// usersGridView
			// 
			this.usersGridView.AllowUserToAddRows = false;
			this.usersGridView.AllowUserToDeleteRows = false;
			this.usersGridView.AllowUserToOrderColumns = true;
			this.usersGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.usersGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.usersGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			this.usersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.usersGridView.DefaultCellStyle = dataGridViewCellStyle1;
			this.usersGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.usersGridView.Location = new System.Drawing.Point(0, 0);
			this.usersGridView.Margin = new System.Windows.Forms.Padding(0);
			this.usersGridView.MultiSelect = false;
			this.usersGridView.Name = "usersGridView";
			this.usersGridView.ReadOnly = true;
			this.usersGridView.RowHeadersVisible = false;
			this.usersGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.usersGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.usersGridView.RowTemplate.Height = 20;
			this.usersGridView.RowTemplate.ReadOnly = true;
			this.usersGridView.Size = new System.Drawing.Size(849, 118);
			this.usersGridView.TabIndex = 1;
			// 
			// softwareTab
			// 
			this.softwareTab.AutoScroll = true;
			this.softwareTab.Controls.Add(this.softwareGridView);
			this.softwareTab.Location = new System.Drawing.Point(4, 26);
			this.softwareTab.Margin = new System.Windows.Forms.Padding(0);
			this.softwareTab.Name = "softwareTab";
			this.softwareTab.Size = new System.Drawing.Size(849, 118);
			this.softwareTab.TabIndex = 11;
			this.softwareTab.Text = "Software";
			this.softwareTab.UseVisualStyleBackColor = true;
			this.softwareTab.Enter += new System.EventHandler(this.softwareTab_Enter);
			// 
			// softwareGridView
			// 
			this.softwareGridView.AllowUserToAddRows = false;
			this.softwareGridView.AllowUserToDeleteRows = false;
			this.softwareGridView.AllowUserToOrderColumns = true;
			this.softwareGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.softwareGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.softwareGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			this.softwareGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.softwareGridView.DefaultCellStyle = dataGridViewCellStyle2;
			this.softwareGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.softwareGridView.Location = new System.Drawing.Point(0, 0);
			this.softwareGridView.Margin = new System.Windows.Forms.Padding(0);
			this.softwareGridView.MultiSelect = false;
			this.softwareGridView.Name = "softwareGridView";
			this.softwareGridView.ReadOnly = true;
			this.softwareGridView.RowHeadersVisible = false;
			this.softwareGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.softwareGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.softwareGridView.RowTemplate.Height = 20;
			this.softwareGridView.RowTemplate.ReadOnly = true;
			this.softwareGridView.Size = new System.Drawing.Size(849, 118);
			this.softwareGridView.TabIndex = 0;
			// 
			// os_langLabel
			// 
			this.os_langLabel.Location = new System.Drawing.Point(124, 80);
			this.os_langLabel.Margin = new System.Windows.Forms.Padding(0);
			this.os_langLabel.ReadOnly = true;
			this.os_langLabel.BorderStyle = 0;
			this.os_langLabel.BackColor = this.BackColor;
			this.os_langLabel.TabStop = false;
			this.os_langLabel.WordWrap = true;
			this.os_langLabel.Name = "os_langLabel";
			this.os_langLabel.Size = new System.Drawing.Size(290, 20);
			this.os_langLabel.TabIndex = 8;
			this.os_langLabel.Text = "os_lang";
			// 
			// os_langStaticLabel
			// 
			this.os_langStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.os_langStaticLabel.Location = new System.Drawing.Point(4, 80);
			this.os_langStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.os_langStaticLabel.Name = "os_langStaticLabel";
			this.os_langStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.os_langStaticLabel.TabIndex = 7;
			this.os_langStaticLabel.Text = "Language";
			// 
			// os_buildLabel
			// 
			this.os_buildLabel.Location = new System.Drawing.Point(124, 60);
			this.os_buildLabel.Margin = new System.Windows.Forms.Padding(0);
			this.os_buildLabel.ReadOnly = true;
			this.os_buildLabel.BorderStyle = 0;
			this.os_buildLabel.BackColor = this.BackColor;
			this.os_buildLabel.TabStop = false;
			this.os_buildLabel.WordWrap = true;
			this.os_buildLabel.Name = "os_buildLabel";
			this.os_buildLabel.Size = new System.Drawing.Size(290, 20);
			this.os_buildLabel.TabIndex = 6;
			this.os_buildLabel.Text = "os_build";
			// 
			// os_buildStaticLabel
			// 
			this.os_buildStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.os_buildStaticLabel.Location = new System.Drawing.Point(4, 60);
			this.os_buildStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.os_buildStaticLabel.Name = "os_buildStaticLabel";
			this.os_buildStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.os_buildStaticLabel.TabIndex = 5;
			this.os_buildStaticLabel.Text = "Build";
			// 
			// os_archLabel
			// 
			this.os_archLabel.Location = new System.Drawing.Point(124, 40);
			this.os_archLabel.Margin = new System.Windows.Forms.Padding(0);
			this.os_archLabel.ReadOnly = true;
			this.os_archLabel.BorderStyle = 0;
			this.os_archLabel.BackColor = this.BackColor;
			this.os_archLabel.TabStop = false;
			this.os_archLabel.WordWrap = true;
			this.os_archLabel.Name = "os_archLabel";
			this.os_archLabel.Size = new System.Drawing.Size(290, 20);
			this.os_archLabel.TabIndex = 4;
			this.os_archLabel.Text = "os_arch";
			// 
			// os_archStaticLabel
			// 
			this.os_archStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.os_archStaticLabel.Location = new System.Drawing.Point(4, 40);
			this.os_archStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.os_archStaticLabel.Name = "os_archStaticLabel";
			this.os_archStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.os_archStaticLabel.TabIndex = 3;
			this.os_archStaticLabel.Text = "Architecture";
			// 
			// os_systemLabel
			// 
			this.os_systemLabel.Location = new System.Drawing.Point(124, 20);
			this.os_systemLabel.Margin = new System.Windows.Forms.Padding(0);
			this.os_systemLabel.ReadOnly = true;
			this.os_systemLabel.BorderStyle = 0;
			this.os_systemLabel.BackColor = this.BackColor;
			this.os_systemLabel.TabStop = false;
			this.os_systemLabel.WordWrap = true;
			this.os_systemLabel.Name = "os_systemLabel";
			this.os_systemLabel.Size = new System.Drawing.Size(290, 20);
			this.os_systemLabel.TabIndex = 2;
			this.os_systemLabel.Text = "os_system";
			// 
			// os_systemStaticLabel
			// 
			this.os_systemStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.os_systemStaticLabel.Location = new System.Drawing.Point(4, 20);
			this.os_systemStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.os_systemStaticLabel.Name = "os_systemStaticLabel";
			this.os_systemStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.os_systemStaticLabel.TabIndex = 1;
			this.os_systemStaticLabel.Text = "System";
			// 
			// osGroupBox
			// 
			this.osGroupBox.Controls.Add(this.os_langLabel);
			this.osGroupBox.Controls.Add(this.os_systemStaticLabel);
			this.osGroupBox.Controls.Add(this.os_langStaticLabel);
			this.osGroupBox.Controls.Add(this.os_systemLabel);
			this.osGroupBox.Controls.Add(this.os_buildLabel);
			this.osGroupBox.Controls.Add(this.os_archStaticLabel);
			this.osGroupBox.Controls.Add(this.os_buildStaticLabel);
			this.osGroupBox.Controls.Add(this.os_archLabel);
			this.osGroupBox.Location = new System.Drawing.Point(5, 5);
			this.osGroupBox.Margin = new System.Windows.Forms.Padding(0);
			this.osGroupBox.Name = "osGroupBox";
			this.osGroupBox.Padding = new System.Windows.Forms.Padding(0);
			this.osGroupBox.Size = new System.Drawing.Size(418, 105);
			this.osGroupBox.TabIndex = 5;
			this.osGroupBox.TabStop = false;
			this.osGroupBox.Text = "Operating system";
			// 
			// ramGroupBox
			// 
			this.ramGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ramGroupBox.Controls.Add(this.ram_maxLabel);
			this.ramGroupBox.Controls.Add(this.ram_occslotsStaticLabel);
			this.ramGroupBox.Controls.Add(this.ram_maxStaticLabel);
			this.ramGroupBox.Controls.Add(this.ram_occslotsLabel);
			this.ramGroupBox.Controls.Add(this.ram_totalLabel);
			this.ramGroupBox.Controls.Add(this.ram_totalslotsStaticLabel);
			this.ramGroupBox.Controls.Add(this.ram_totalStaticLabel);
			this.ramGroupBox.Controls.Add(this.ram_totalslotsLabel);
			this.ramGroupBox.Location = new System.Drawing.Point(434, 5);
			this.ramGroupBox.Margin = new System.Windows.Forms.Padding(0);
			this.ramGroupBox.Name = "ramGroupBox";
			this.ramGroupBox.Padding = new System.Windows.Forms.Padding(0);
			this.ramGroupBox.Size = new System.Drawing.Size(418, 105);
			this.ramGroupBox.TabIndex = 6;
			this.ramGroupBox.TabStop = false;
			this.ramGroupBox.Text = "RAM";
			// 
			// ram_maxLabel
			// 
			this.ram_maxLabel.Location = new System.Drawing.Point(124, 80);
			this.ram_maxLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ram_maxLabel.ReadOnly = true;
			this.ram_maxLabel.BorderStyle = 0;
			this.ram_maxLabel.BackColor = this.BackColor;
			this.ram_maxLabel.TabStop = false;
			this.ram_maxLabel.WordWrap = true;
			this.ram_maxLabel.Name = "ram_maxLabel";
			this.ram_maxLabel.Size = new System.Drawing.Size(290, 20);
			this.ram_maxLabel.TabIndex = 8;
			this.ram_maxLabel.Text = "ram_max";
			// 
			// ram_occslotsStaticLabel
			// 
			this.ram_occslotsStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ram_occslotsStaticLabel.Location = new System.Drawing.Point(4, 20);
			this.ram_occslotsStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ram_occslotsStaticLabel.Name = "ram_occslotsStaticLabel";
			this.ram_occslotsStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.ram_occslotsStaticLabel.TabIndex = 1;
			this.ram_occslotsStaticLabel.Text = "Slots occupied";
			// 
			// ram_maxStaticLabel
			// 
			this.ram_maxStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ram_maxStaticLabel.Location = new System.Drawing.Point(4, 80);
			this.ram_maxStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ram_maxStaticLabel.Name = "ram_maxStaticLabel";
			this.ram_maxStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.ram_maxStaticLabel.TabIndex = 7;
			this.ram_maxStaticLabel.Text = "Max RAM";
			// 
			// ram_occslotsLabel
			// 
			this.ram_occslotsLabel.Location = new System.Drawing.Point(124, 20);
			this.ram_occslotsLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ram_occslotsLabel.ReadOnly = true;
			this.ram_occslotsLabel.BorderStyle = 0;
			this.ram_occslotsLabel.BackColor = this.BackColor;
			this.ram_occslotsLabel.TabStop = false;
			this.ram_occslotsLabel.WordWrap = true;
			this.ram_occslotsLabel.Name = "ram_occslotsLabel";
			this.ram_occslotsLabel.Size = new System.Drawing.Size(290, 20);
			this.ram_occslotsLabel.TabIndex = 2;
			this.ram_occslotsLabel.Text = "ram_occslots";
			// 
			// ram_totalLabel
			// 
			this.ram_totalLabel.Location = new System.Drawing.Point(124, 60);
			this.ram_totalLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ram_totalLabel.ReadOnly = true;
			this.ram_totalLabel.BorderStyle = 0;
			this.ram_totalLabel.BackColor = this.BackColor;
			this.ram_totalLabel.TabStop = false;
			this.ram_totalLabel.WordWrap = true;
			this.ram_totalLabel.Name = "ram_totalLabel";
			this.ram_totalLabel.Size = new System.Drawing.Size(290, 20);
			this.ram_totalLabel.TabIndex = 6;
			this.ram_totalLabel.Text = "ram_total";
			// 
			// ram_totalslotsStaticLabel
			// 
			this.ram_totalslotsStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ram_totalslotsStaticLabel.Location = new System.Drawing.Point(4, 40);
			this.ram_totalslotsStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ram_totalslotsStaticLabel.Name = "ram_totalslotsStaticLabel";
			this.ram_totalslotsStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.ram_totalslotsStaticLabel.TabIndex = 3;
			this.ram_totalslotsStaticLabel.Text = "Slots total";
			// 
			// ram_totalStaticLabel
			// 
			this.ram_totalStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ram_totalStaticLabel.Location = new System.Drawing.Point(4, 60);
			this.ram_totalStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ram_totalStaticLabel.Name = "ram_totalStaticLabel";
			this.ram_totalStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.ram_totalStaticLabel.TabIndex = 5;
			this.ram_totalStaticLabel.Text = "Total RAM";
			// 
			// ram_totalslotsLabel
			// 
			this.ram_totalslotsLabel.Location = new System.Drawing.Point(124, 40);
			this.ram_totalslotsLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ram_totalslotsLabel.ReadOnly = true;
			this.ram_totalslotsLabel.BorderStyle = 0;
			this.ram_totalslotsLabel.BackColor = this.BackColor;
			this.ram_totalslotsLabel.TabStop = false;
			this.ram_totalslotsLabel.WordWrap = true;
			this.ram_totalslotsLabel.Name = "ram_totalslotsLabel";
			this.ram_totalslotsLabel.Size = new System.Drawing.Size(290, 20);
			this.ram_totalslotsLabel.TabIndex = 4;
			this.ram_totalslotsLabel.Text = "ram_totalslots";
			// 
			// motherboardGroupBox
			// 
			this.motherboardGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.motherboardGroupBox.Controls.Add(this.mobo_vendorStaticLabel);
			this.motherboardGroupBox.Controls.Add(this.mobo_vendorLabel);
			this.motherboardGroupBox.Controls.Add(this.mobo_revLabel);
			this.motherboardGroupBox.Controls.Add(this.mobo_modelStaticLabel);
			this.motherboardGroupBox.Controls.Add(this.mobo_revStaticLabel);
			this.motherboardGroupBox.Controls.Add(this.mobo_modelLabel);
			this.motherboardGroupBox.Location = new System.Drawing.Point(5, 111);
			this.motherboardGroupBox.Margin = new System.Windows.Forms.Padding(0);
			this.motherboardGroupBox.Name = "motherboardGroupBox";
			this.motherboardGroupBox.Padding = new System.Windows.Forms.Padding(0);
			this.motherboardGroupBox.Size = new System.Drawing.Size(418, 85);
			this.motherboardGroupBox.TabIndex = 7;
			this.motherboardGroupBox.TabStop = false;
			this.motherboardGroupBox.Text = "Motherboard";
			// 
			// mobo_vendorStaticLabel
			// 
			this.mobo_vendorStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.mobo_vendorStaticLabel.Location = new System.Drawing.Point(4, 20);
			this.mobo_vendorStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.mobo_vendorStaticLabel.Name = "modo_vendorStaticLabel";
			this.mobo_vendorStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.mobo_vendorStaticLabel.TabIndex = 1;
			this.mobo_vendorStaticLabel.Text = "Vendor";
			// 
			// mobo_vendorLabel
			// 
			this.mobo_vendorLabel.Location = new System.Drawing.Point(124, 20);
			this.mobo_vendorLabel.Margin = new System.Windows.Forms.Padding(0);
			this.mobo_vendorLabel.ReadOnly = true;
			this.mobo_vendorLabel.BorderStyle = 0;
			this.mobo_vendorLabel.BackColor = this.BackColor;
			this.mobo_vendorLabel.TabStop = false;
			this.mobo_vendorLabel.WordWrap = true;
			this.mobo_vendorLabel.Name = "mobo_vendorLabel";
			this.mobo_vendorLabel.Size = new System.Drawing.Size(290, 20);
			this.mobo_vendorLabel.TabIndex = 2;
			this.mobo_vendorLabel.Text = "mobo_vendor";
			// 
			// mobo_revLabel
			// 
			this.mobo_revLabel.Location = new System.Drawing.Point(124, 60);
			this.mobo_revLabel.Margin = new System.Windows.Forms.Padding(0);
			this.mobo_revLabel.ReadOnly = true;
			this.mobo_revLabel.BorderStyle = 0;
			this.mobo_revLabel.BackColor = this.BackColor;
			this.mobo_revLabel.TabStop = false;
			this.mobo_revLabel.WordWrap = true;
			this.mobo_revLabel.Name = "mobo_revLabel";
			this.mobo_revLabel.Size = new System.Drawing.Size(290, 20);
			this.mobo_revLabel.TabIndex = 6;
			this.mobo_revLabel.Text = "mobo_rev";
			// 
			// mobo_modelStaticLabel
			// 
			this.mobo_modelStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.mobo_modelStaticLabel.Location = new System.Drawing.Point(4, 40);
			this.mobo_modelStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.mobo_modelStaticLabel.Name = "mobo_modelStaticLabel";
			this.mobo_modelStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.mobo_modelStaticLabel.TabIndex = 3;
			this.mobo_modelStaticLabel.Text = "Model";
			// 
			// mobo_revStaticLabel
			// 
			this.mobo_revStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.mobo_revStaticLabel.Location = new System.Drawing.Point(4, 60);
			this.mobo_revStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.mobo_revStaticLabel.Name = "mobo_revStaticLabel";
			this.mobo_revStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.mobo_revStaticLabel.TabIndex = 5;
			this.mobo_revStaticLabel.Text = "Revision";
			// 
			// mobo_modelLabel
			// 
			this.mobo_modelLabel.Location = new System.Drawing.Point(124, 40);
			this.mobo_modelLabel.Margin = new System.Windows.Forms.Padding(0);
			this.mobo_modelLabel.ReadOnly = true;
			this.mobo_modelLabel.BorderStyle = 0;
			this.mobo_modelLabel.BackColor = this.BackColor;
			this.mobo_modelLabel.TabStop = false;
			this.mobo_modelLabel.WordWrap = true;
			this.mobo_modelLabel.Name = "mobo_modelLabel";
			this.mobo_modelLabel.Size = new System.Drawing.Size(290, 20);
			this.mobo_modelLabel.TabIndex = 4;
			this.mobo_modelLabel.Text = "mobo_model";
			// 
			// biosGroupBox
			// 
			this.biosGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.biosGroupBox.Controls.Add(this.bios_vendorStaticLabel);
			this.biosGroupBox.Controls.Add(this.bios_vendorLabel);
			this.biosGroupBox.Controls.Add(this.bios_verLabel);
			this.biosGroupBox.Controls.Add(this.bios_nameStaticLabel);
			this.biosGroupBox.Controls.Add(this.bios_verStaticLabel);
			this.biosGroupBox.Controls.Add(this.bios_nameLabel);
			this.biosGroupBox.Location = new System.Drawing.Point(434, 111);
			this.biosGroupBox.Margin = new System.Windows.Forms.Padding(0);
			this.biosGroupBox.Name = "biosGroupBox";
			this.biosGroupBox.Padding = new System.Windows.Forms.Padding(0);
			this.biosGroupBox.Size = new System.Drawing.Size(418, 85);
			this.biosGroupBox.TabIndex = 8;
			this.biosGroupBox.TabStop = false;
			this.biosGroupBox.Text = "BIOS";
			// 
			// bios_vendorStaticLabel
			// 
			this.bios_vendorStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.bios_vendorStaticLabel.Location = new System.Drawing.Point(4, 20);
			this.bios_vendorStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.bios_vendorStaticLabel.Name = "bios_vendorStaticLabel";
			this.bios_vendorStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.bios_vendorStaticLabel.TabIndex = 1;
			this.bios_vendorStaticLabel.Text = "Vendor";
			// 
			// bios_vendorLabel
			// 
			this.bios_vendorLabel.Location = new System.Drawing.Point(124, 20);
			this.bios_vendorLabel.Margin = new System.Windows.Forms.Padding(0);
			this.bios_vendorLabel.ReadOnly = true;
			this.bios_vendorLabel.BorderStyle = 0;
			this.bios_vendorLabel.BackColor = this.BackColor;
			this.bios_vendorLabel.TabStop = false;
			this.bios_vendorLabel.WordWrap = true;
			this.bios_vendorLabel.Name = "bios_vendorLabel";
			this.bios_vendorLabel.Size = new System.Drawing.Size(290, 20);
			this.bios_vendorLabel.TabIndex = 2;
			this.bios_vendorLabel.Text = "bios_vendor";
			// 
			// bios_verLabel
			// 
			this.bios_verLabel.Location = new System.Drawing.Point(124, 60);
			this.bios_verLabel.Margin = new System.Windows.Forms.Padding(0);
			this.bios_verLabel.ReadOnly = true;
			this.bios_verLabel.BorderStyle = 0;
			this.bios_verLabel.BackColor = this.BackColor;
			this.bios_verLabel.TabStop = false;
			this.bios_verLabel.WordWrap = true;
			this.bios_verLabel.Name = "bios_verLabel";
			this.bios_verLabel.Size = new System.Drawing.Size(290, 20);
			this.bios_verLabel.TabIndex = 6;
			this.bios_verLabel.Text = "bios_ver";
			// 
			// bios_nameStaticLabel
			// 
			this.bios_nameStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.bios_nameStaticLabel.Location = new System.Drawing.Point(4, 40);
			this.bios_nameStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.bios_nameStaticLabel.Name = "bios_nameStaticLabel";
			this.bios_nameStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.bios_nameStaticLabel.TabIndex = 3;
			this.bios_nameStaticLabel.Text = "Name";
			// 
			// bios_verStaticLabel
			// 
			this.bios_verStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.bios_verStaticLabel.Location = new System.Drawing.Point(4, 60);
			this.bios_verStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.bios_verStaticLabel.Name = "bios_verStaticLabel";
			this.bios_verStaticLabel.Size = new System.Drawing.Size(120, 20);
			this.bios_verStaticLabel.TabIndex = 5;
			this.bios_verStaticLabel.Text = "Version";
			// 
			// bios_nameLabel
			// 
			this.bios_nameLabel.Location = new System.Drawing.Point(124, 40);
			this.bios_nameLabel.Margin = new System.Windows.Forms.Padding(0);
			this.bios_nameLabel.ReadOnly = true;
			this.bios_nameLabel.BorderStyle = 0;
			this.bios_nameLabel.BackColor = this.BackColor;
			this.bios_nameLabel.TabStop = false;
			this.bios_nameLabel.WordWrap = true;
			this.bios_nameLabel.Name = "bios_nameLabel";
			this.bios_nameLabel.Size = new System.Drawing.Size(290, 20);
			this.bios_nameLabel.TabIndex = 4;
			this.bios_nameLabel.Text = "bios_name";
			// 
			// groupsPanel
			// 
			this.groupsPanel.Controls.Add(this.biosGroupBox);
			this.groupsPanel.Controls.Add(this.osGroupBox);
			this.groupsPanel.Controls.Add(this.ramGroupBox);
			this.groupsPanel.Controls.Add(this.motherboardGroupBox);
			this.groupsPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupsPanel.Location = new System.Drawing.Point(0, 0);
			this.groupsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.groupsPanel.Name = "groupsPanel";
			this.groupsPanel.Padding = new System.Windows.Forms.Padding(5);
			this.groupsPanel.Size = new System.Drawing.Size(857, 201);
			this.groupsPanel.TabIndex = 9;
			// 
			// ViewAssetForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(857, 352);
			this.Controls.Add(this.groupsPanel);
			this.Controls.Add(this.tabPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ViewAssetForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.ViewAssetForm_Load);
			this.tabPanel.ResumeLayout(false);
			this.usersTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.usersGridView)).EndInit();
			this.softwareTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.softwareGridView)).EndInit();
			this.osGroupBox.ResumeLayout(false);
			this.ramGroupBox.ResumeLayout(false);
			this.motherboardGroupBox.ResumeLayout(false);
			this.biosGroupBox.ResumeLayout(false);
			this.groupsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TabControl tabPanel;
		private System.Windows.Forms.TabPage usersTab;
		private System.Windows.Forms.TabPage cpuTab;
		private System.Windows.Forms.TabPage drivesTab;
		private System.Windows.Forms.TabPage partitionsTab;
		private System.Windows.Forms.TabPage dimmTab;
		private System.Windows.Forms.TabPage networkingTab;
		private System.Windows.Forms.TextBox os_systemLabel;
		private System.Windows.Forms.Label os_systemStaticLabel;
		private System.Windows.Forms.TextBox os_archLabel;
		private System.Windows.Forms.Label os_archStaticLabel;
		private System.Windows.Forms.TextBox os_langLabel;
		private System.Windows.Forms.Label os_langStaticLabel;
		private System.Windows.Forms.TextBox os_buildLabel;
		private System.Windows.Forms.Label os_buildStaticLabel;
		private System.Windows.Forms.GroupBox osGroupBox;
		private System.Windows.Forms.GroupBox ramGroupBox;
		private System.Windows.Forms.TextBox ram_maxLabel;
		private System.Windows.Forms.Label ram_occslotsStaticLabel;
		private System.Windows.Forms.Label ram_maxStaticLabel;
		private System.Windows.Forms.TextBox ram_occslotsLabel;
		private System.Windows.Forms.TextBox ram_totalLabel;
		private System.Windows.Forms.Label ram_totalslotsStaticLabel;
		private System.Windows.Forms.Label ram_totalStaticLabel;
		private System.Windows.Forms.TextBox ram_totalslotsLabel;
		private System.Windows.Forms.GroupBox motherboardGroupBox;
		private System.Windows.Forms.Label mobo_vendorStaticLabel;
		private System.Windows.Forms.TextBox mobo_vendorLabel;
		private System.Windows.Forms.TextBox mobo_revLabel;
		private System.Windows.Forms.Label mobo_modelStaticLabel;
		private System.Windows.Forms.Label mobo_revStaticLabel;
		private System.Windows.Forms.TextBox mobo_modelLabel;
		private System.Windows.Forms.GroupBox biosGroupBox;
		private System.Windows.Forms.Label bios_vendorStaticLabel;
		private System.Windows.Forms.TextBox bios_vendorLabel;
		private System.Windows.Forms.TextBox bios_verLabel;
		private System.Windows.Forms.Label bios_nameStaticLabel;
		private System.Windows.Forms.Label bios_verStaticLabel;
		private System.Windows.Forms.TextBox bios_nameLabel;
		private System.Windows.Forms.TabPage gpuTab;
		private System.Windows.Forms.TabPage monitorsTab;
		private System.Windows.Forms.TabPage printersTab;
		private System.Windows.Forms.TabPage softwareTab;
		private System.Windows.Forms.Panel groupsPanel;
		private System.Windows.Forms.DataGridView softwareGridView;
		private System.Windows.Forms.DataGridView usersGridView;
	}
}