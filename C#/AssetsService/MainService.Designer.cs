namespace AssetsService
{
	partial class MainService
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// MainService
			// 
			this.ServiceName = "Assets Service";
			// 
			// assetsEventLog
			// 
			this.assetsEventLog = new System.Diagnostics.EventLog();
			((System.ComponentModel.ISupportInitialize)(this.assetsEventLog)).BeginInit();
			this.assetsEventLog.Log = mainInfo.logName;
			this.assetsEventLog.Source = mainInfo.logSource;
			if (!System.Diagnostics.EventLog.SourceExists(mainInfo.logSource))
			{
				System.Diagnostics.EventLog.CreateEventSource(mainInfo.logSource, mainInfo.logName);
			}
			((System.ComponentModel.ISupportInitialize)(this.assetsEventLog)).EndInit();

		}

		#endregion

		private System.Diagnostics.EventLog assetsEventLog;
	}
}
