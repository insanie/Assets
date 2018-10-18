using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace AssetsService
{
	[RunInstaller(true)]
	public partial class ProjectInstaller : System.Configuration.Install.Installer
	{
		public ProjectInstaller()
		{
			InitializeComponent();
			
			// unsuccessful attempt to change default log list
			// fix it if you can pls

			/*EventLogInstaller logInstaller = findInstaller(Installers);
			if (logInstaller != null)
			{
				logInstaller.Log = mainInfo.logName; // enter your event log name here
			}
		}

		private EventLogInstaller findInstaller(InstallerCollection inputCollection)
		{
			foreach (Installer tmp1 in inputCollection)
			{
				if (tmp1 is EventLogInstaller)
				{
					return (EventLogInstaller)tmp1;
				}
				else
				{
					if (tmp1.Installers != null)
					{
						EventLogInstaller tmp2 = findInstaller(tmp1.Installers);
						if (tmp2 != null)
						{
							return tmp2;
						}
					}
					
				}
			}
			return null;*/
		}
	}
}
