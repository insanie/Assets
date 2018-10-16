using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace AssetsPoller
{
	public partial class MainService : ServiceBase
	{


		public MainService()
		{
			InitializeComponent();

			assetsEventLog = new EventLog();
			if (!EventLog.SourceExists("AssetsServiceSource"))
			{
				EventLog.CreateEventSource("AssetsServiceSource", "AssetsServiceLog");
			}
			assetsEventLog.Source = "AssetsServiceSource";
			assetsEventLog.Log = "AssetsServiceLog";
		}

		protected override void OnStart(string[] args)
		{
			// writing to event log that the service has started
			assetsEventLog.WriteEntry("Assets service started", EventLogEntryType.Information, 0);
			// Set up a timer that triggers every minute.
			System.Timers.Timer timer = new System.Timers.Timer();
			timer.Interval = 60000; // 60 seconds
			timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
			timer.Start();
		}

		protected override void OnStop()
		{
			// writing to event log that the service has stopped
			assetsEventLog.WriteEntry("Assets service stopped", EventLogEntryType.Information, 1);
		}

		public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
		{
			// TODO: Insert monitoring activities here.
			assetsEventLog.WriteEntry("Assets timer elapsed", EventLogEntryType.Information, 2);
		}
	}
}
