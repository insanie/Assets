namespace ClientAppNamespace
{
	partial class MainForm
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
			this.errorLabel = new System.Windows.Forms.Label();
			this.searchResultsBox = new System.Windows.Forms.ListBox();
			this.testLabel = new System.Windows.Forms.Label();
			this.searchBox = new System.Windows.Forms.TextBox();
			this.searchButton = new System.Windows.Forms.Button();
			this.searchPanel = new System.Windows.Forms.Panel();
			this.errorPanel = new System.Windows.Forms.Panel();
			this.searchResulsLabel = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.loadEntryButton = new System.Windows.Forms.Button();
			this.searchPanel.SuspendLayout();
			this.errorPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// errorLabel
			// 
			this.errorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.errorLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.errorLabel.ForeColor = System.Drawing.Color.Red;
			this.errorLabel.Location = new System.Drawing.Point(0, 0);
			this.errorLabel.Margin = new System.Windows.Forms.Padding(0);
			this.errorLabel.Name = "errorLabel";
			this.errorLabel.Size = new System.Drawing.Size(256, 34);
			this.errorLabel.TabIndex = 2;
			this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// searchResultsBox
			// 
			this.searchResultsBox.FormattingEnabled = true;
			this.searchResultsBox.IntegralHeight = false;
			this.searchResultsBox.ItemHeight = 17;
			this.searchResultsBox.Location = new System.Drawing.Point(3, 25);
			this.searchResultsBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
			this.searchResultsBox.Name = "searchResultsBox";
			this.searchResultsBox.Size = new System.Drawing.Size(265, 107);
			this.searchResultsBox.TabIndex = 4;
			this.searchResultsBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			this.searchResultsBox.DoubleClick += new System.EventHandler(this.searchResultsBox_DoubleClick);
			this.searchResultsBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchResultsBox_KeyDown);
			// 
			// testLabel
			// 
			this.testLabel.AutoSize = true;
			this.testLabel.Location = new System.Drawing.Point(131, 133);
			this.testLabel.Name = "testLabel";
			this.testLabel.Size = new System.Drawing.Size(43, 17);
			this.testLabel.TabIndex = 5;
			this.testLabel.Text = "label2";
			// 
			// searchBox
			// 
			this.searchBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.searchBox.Location = new System.Drawing.Point(3, 7);
			this.searchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.searchBox.Name = "searchBox";
			this.searchBox.Size = new System.Drawing.Size(202, 25);
			this.searchBox.TabIndex = 0;
			this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyDown);
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(211, 4);
			this.searchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(87, 30);
			this.searchButton.TabIndex = 1;
			this.searchButton.Text = "Search";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// searchPanel
			// 
			this.searchPanel.Controls.Add(this.errorPanel);
			this.searchPanel.Controls.Add(this.searchBox);
			this.searchPanel.Controls.Add(this.searchButton);
			this.searchPanel.Location = new System.Drawing.Point(12, 12);
			this.searchPanel.Name = "searchPanel";
			this.searchPanel.Size = new System.Drawing.Size(300, 80);
			this.searchPanel.TabIndex = 6;
			// 
			// errorPanel
			// 
			this.errorPanel.Controls.Add(this.errorLabel);
			this.errorPanel.Location = new System.Drawing.Point(21, 41);
			this.errorPanel.Name = "errorPanel";
			this.errorPanel.Size = new System.Drawing.Size(256, 34);
			this.errorPanel.TabIndex = 7;
			// 
			// searchResulsLabel
			// 
			this.searchResulsLabel.AutoSize = true;
			this.searchResulsLabel.Location = new System.Drawing.Point(87, 4);
			this.searchResulsLabel.Name = "searchResulsLabel";
			this.searchResulsLabel.Size = new System.Drawing.Size(103, 17);
			this.searchResulsLabel.TabIndex = 7;
			this.searchResulsLabel.Text = "Available entries";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.loadEntryButton);
			this.panel1.Controls.Add(this.searchResulsLabel);
			this.panel1.Controls.Add(this.searchResultsBox);
			this.panel1.Location = new System.Drawing.Point(319, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(271, 168);
			this.panel1.TabIndex = 8;
			// 
			// loadEntryButton
			// 
			this.loadEntryButton.Enabled = false;
			this.loadEntryButton.Location = new System.Drawing.Point(3, 135);
			this.loadEntryButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.loadEntryButton.Name = "loadEntryButton";
			this.loadEntryButton.Size = new System.Drawing.Size(265, 30);
			this.loadEntryButton.TabIndex = 9;
			this.loadEntryButton.Text = "Load entry";
			this.loadEntryButton.UseVisualStyleBackColor = true;
			this.loadEntryButton.Click += new System.EventHandler(this.loadEntryButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(602, 192);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.searchPanel);
			this.Controls.Add(this.testLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.searchPanel.ResumeLayout(false);
			this.searchPanel.PerformLayout();
			this.errorPanel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label errorLabel;
		private System.Windows.Forms.ListBox searchResultsBox;
		private System.Windows.Forms.Label testLabel;
		private System.Windows.Forms.TextBox searchBox;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.Panel searchPanel;
		private System.Windows.Forms.Panel errorPanel;
		private System.Windows.Forms.Label searchResulsLabel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button loadEntryButton;
	}
}

