namespace AssetsService
{
	partial class ProjectInstaller
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
			this.Installers.Clear();
			
			this.assetsServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			this.assetsServiceInstaller = new System.ServiceProcess.ServiceInstaller();
			// 
			// assetsServiceProcessInstaller
			// 
			this.assetsServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.assetsServiceProcessInstaller.Password = null;
			this.assetsServiceProcessInstaller.Username = null;
			// 
			// assetsServiceInstaller
			// 
			this.assetsServiceInstaller.DisplayName = mainInfo.serviceName;
			this.assetsServiceInstaller.Description = "A simple test service";
			this.assetsServiceInstaller.ServiceName = mainInfo.serviceName;
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.assetsServiceProcessInstaller,
            this.assetsServiceInstaller});

		}

		#endregion
		
		private System.ServiceProcess.ServiceProcessInstaller assetsServiceProcessInstaller;
		private System.ServiceProcess.ServiceInstaller assetsServiceInstaller;
	}
}