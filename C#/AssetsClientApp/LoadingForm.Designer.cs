namespace AssetsClientApp
{
	partial class LoadingForm
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
			this.sqlQueryLabel = new System.Windows.Forms.Label();
			this.loadingCommentLabel = new System.Windows.Forms.Label();
			this.loadingPercentLabel = new System.Windows.Forms.Label();
			this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
			this.backgroundSqlQuerying = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// sqlQueryLabel
			// 
			this.sqlQueryLabel.Location = new System.Drawing.Point(0, 0);
			this.sqlQueryLabel.Margin = new System.Windows.Forms.Padding(0);
			this.sqlQueryLabel.Name = "sqlQueryLabel";
			this.sqlQueryLabel.Size = new System.Drawing.Size(350, 25);
			this.sqlQueryLabel.TabIndex = 0;
			this.sqlQueryLabel.Text = "sqlQueryLabel";
			this.sqlQueryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// loadingCommentLabel
			// 
			this.loadingCommentLabel.Location = new System.Drawing.Point(9, 54);
			this.loadingCommentLabel.Margin = new System.Windows.Forms.Padding(0);
			this.loadingCommentLabel.Name = "loadingCommentLabel";
			this.loadingCommentLabel.Size = new System.Drawing.Size(150, 17);
			this.loadingCommentLabel.TabIndex = 1;
			this.loadingCommentLabel.Text = "Loading data...";
			this.loadingCommentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// loadingPercentLabel
			// 
			this.loadingPercentLabel.Location = new System.Drawing.Point(184, 54);
			this.loadingPercentLabel.Margin = new System.Windows.Forms.Padding(0);
			this.loadingPercentLabel.Name = "loadingPercentLabel";
			this.loadingPercentLabel.Size = new System.Drawing.Size(157, 17);
			this.loadingPercentLabel.TabIndex = 2;
			this.loadingPercentLabel.Text = "loadingPercentLabel";
			this.loadingPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// loadingProgressBar
			// 
			this.loadingProgressBar.Location = new System.Drawing.Point(12, 28);
			this.loadingProgressBar.Name = "loadingProgressBar";
			this.loadingProgressBar.Size = new System.Drawing.Size(325, 23);
			this.loadingProgressBar.TabIndex = 3;
			// 
			// backgroundSqlQuerying
			// 
			this.backgroundSqlQuerying.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundSqlQuerying_DoWork);
			this.backgroundSqlQuerying.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundSqlQuerying_ProgressChanged);
			this.backgroundSqlQuerying.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundSqlQuerying_RunWorkerCompleted);
			// 
			// LoadingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(350, 78);
			this.ControlBox = false;
			this.Controls.Add(this.loadingProgressBar);
			this.Controls.Add(this.loadingPercentLabel);
			this.Controls.Add(this.loadingCommentLabel);
			this.Controls.Add(this.sqlQueryLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoadingForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "LoadingForm";
			this.Load += new System.EventHandler(this.LoadingForm_Load);
			this.Shown += new System.EventHandler(this.LoadingForm_Shown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label sqlQueryLabel;
		private System.Windows.Forms.Label loadingCommentLabel;
		private System.Windows.Forms.Label loadingPercentLabel;
		private System.Windows.Forms.ProgressBar loadingProgressBar;
		private System.ComponentModel.BackgroundWorker backgroundSqlQuerying;
	}
}