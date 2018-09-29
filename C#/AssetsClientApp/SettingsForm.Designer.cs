namespace AssetsClientApp
{
	partial class SettingsForm
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
			this.saveSettingsButton = new System.Windows.Forms.Button();
			this.serverSettingsTextBox = new System.Windows.Forms.TextBox();
			this.databaseSettingsTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// saveSettingsButton
			// 
			this.saveSettingsButton.Location = new System.Drawing.Point(98, 123);
			this.saveSettingsButton.Name = "saveSettingsButton";
			this.saveSettingsButton.Size = new System.Drawing.Size(75, 23);
			this.saveSettingsButton.TabIndex = 0;
			this.saveSettingsButton.Text = "Save";
			this.saveSettingsButton.UseVisualStyleBackColor = true;
			this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
			// 
			// serverSettingsTextBox
			// 
			this.serverSettingsTextBox.Location = new System.Drawing.Point(125, 13);
			this.serverSettingsTextBox.Name = "serverSettingsTextBox";
			this.serverSettingsTextBox.Size = new System.Drawing.Size(100, 25);
			this.serverSettingsTextBox.TabIndex = 1;
			// 
			// databaseSettingsTextBox
			// 
			this.databaseSettingsTextBox.Location = new System.Drawing.Point(125, 61);
			this.databaseSettingsTextBox.Name = "databaseSettingsTextBox";
			this.databaseSettingsTextBox.Size = new System.Drawing.Size(100, 25);
			this.databaseSettingsTextBox.TabIndex = 2;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(279, 158);
			this.Controls.Add(this.databaseSettingsTextBox);
			this.Controls.Add(this.serverSettingsTextBox);
			this.Controls.Add(this.saveSettingsButton);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button saveSettingsButton;
		private System.Windows.Forms.TextBox serverSettingsTextBox;
		private System.Windows.Forms.TextBox databaseSettingsTextBox;
	}
}