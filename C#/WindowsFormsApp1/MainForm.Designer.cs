namespace Assets
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
			this.searchResultsBox = new System.Windows.Forms.ListBox();
			this.searchBox = new System.Windows.Forms.TextBox();
			this.searchButton = new System.Windows.Forms.Button();
			this.loadEntryButton = new System.Windows.Forms.Button();
			this.settingsButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// searchResultsBox
			// 
			this.searchResultsBox.FormattingEnabled = true;
			this.searchResultsBox.IntegralHeight = false;
			this.searchResultsBox.ItemHeight = 17;
			this.searchResultsBox.Location = new System.Drawing.Point(15, 77);
			this.searchResultsBox.Margin = new System.Windows.Forms.Padding(0);
			this.searchResultsBox.Name = "searchResultsBox";
			this.searchResultsBox.Size = new System.Drawing.Size(161, 131);
			this.searchResultsBox.TabIndex = 4;
			this.searchResultsBox.SelectedIndexChanged += new System.EventHandler(this.searchResultsBox_SelectedIndexChanged);
			this.searchResultsBox.DoubleClick += new System.EventHandler(this.searchResultsBox_DoubleClick);
			this.searchResultsBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchResultsBox_KeyDown);
			// 
			// searchBox
			// 
			this.searchBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.searchBox.Location = new System.Drawing.Point(15, 15);
			this.searchBox.Margin = new System.Windows.Forms.Padding(0);
			this.searchBox.Name = "searchBox";
			this.searchBox.Size = new System.Drawing.Size(161, 25);
			this.searchBox.TabIndex = 0;
			this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyDown);
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(15, 44);
			this.searchButton.Margin = new System.Windows.Forms.Padding(0);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(124, 25);
			this.searchButton.TabIndex = 1;
			this.searchButton.Text = "Search";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// loadEntryButton
			// 
			this.loadEntryButton.Enabled = false;
			this.loadEntryButton.Location = new System.Drawing.Point(15, 211);
			this.loadEntryButton.Margin = new System.Windows.Forms.Padding(0);
			this.loadEntryButton.Name = "loadEntryButton";
			this.loadEntryButton.Size = new System.Drawing.Size(161, 25);
			this.loadEntryButton.TabIndex = 9;
			this.loadEntryButton.Text = "Load entry";
			this.loadEntryButton.UseVisualStyleBackColor = true;
			this.loadEntryButton.Click += new System.EventHandler(this.loadEntryButton_Click);
			// 
			// settingsButton
			// 
			this.settingsButton.Location = new System.Drawing.Point(151, 44);
			this.settingsButton.Margin = new System.Windows.Forms.Padding(0);
			this.settingsButton.Name = "settingsButton";
			this.settingsButton.Size = new System.Drawing.Size(25, 25);
			this.settingsButton.TabIndex = 10;
			this.settingsButton.UseVisualStyleBackColor = true;
			this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(192, 251);
			this.Controls.Add(this.settingsButton);
			this.Controls.Add(this.searchBox);
			this.Controls.Add(this.searchResultsBox);
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.loadEntryButton);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Assets";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ListBox searchResultsBox;
		private System.Windows.Forms.TextBox searchBox;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.Button loadEntryButton;
		private System.Windows.Forms.Button settingsButton;
	}
}

