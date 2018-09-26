namespace ClientAppNamespace
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
			this.hostnameStaticLabel = new System.Windows.Forms.Label();
			this.hostnameLabel = new System.Windows.Forms.Label();
			this.ipStaticLabel = new System.Windows.Forms.Label();
			this.ipLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// hostnameStaticLabel
			// 
			this.hostnameStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.hostnameStaticLabel.Location = new System.Drawing.Point(0, 0);
			this.hostnameStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.hostnameStaticLabel.Name = "hostnameStaticLabel";
			this.hostnameStaticLabel.Size = new System.Drawing.Size(90, 20);
			this.hostnameStaticLabel.TabIndex = 0;
			this.hostnameStaticLabel.Text = "Hostname";
			// 
			// hostnameLabel
			// 
			this.hostnameLabel.Location = new System.Drawing.Point(90, 0);
			this.hostnameLabel.Margin = new System.Windows.Forms.Padding(0);
			this.hostnameLabel.Name = "hostnameLabel";
			this.hostnameLabel.Size = new System.Drawing.Size(120, 20);
			this.hostnameLabel.TabIndex = 1;
			this.hostnameLabel.Text = "label2";
			// 
			// ipStaticLabel
			// 
			this.ipStaticLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ipStaticLabel.Location = new System.Drawing.Point(210, 0);
			this.ipStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ipStaticLabel.Name = "ipStaticLabel";
			this.ipStaticLabel.Size = new System.Drawing.Size(90, 20);
			this.ipStaticLabel.TabIndex = 2;
			this.ipStaticLabel.Text = "IP Address";
			// 
			// ipLabel
			// 
			this.ipLabel.Location = new System.Drawing.Point(300, 0);
			this.ipLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ipLabel.Name = "ipLabel";
			this.ipLabel.Size = new System.Drawing.Size(120, 20);
			this.ipLabel.TabIndex = 3;
			this.ipLabel.Text = "label2";
			// 
			// ViewAssetForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(966, 480);
			this.Controls.Add(this.ipLabel);
			this.Controls.Add(this.ipStaticLabel);
			this.Controls.Add(this.hostnameLabel);
			this.Controls.Add(this.hostnameStaticLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ViewAssetForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.ViewAssetForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label hostnameStaticLabel;
		private System.Windows.Forms.Label hostnameLabel;
		private System.Windows.Forms.Label ipStaticLabel;
		private System.Windows.Forms.Label ipLabel;
	}
}