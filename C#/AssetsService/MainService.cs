using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace AssetsService
{
	public partial class MainService : ServiceBase
	{
		private Byte scheduledTimeHour { get; set; }
		private Byte scheduledTimeMin { get; set; }
		private Byte scheduledTimeSec { get; set; }
		private DateTime currentDate { get; set; }
		private DateTime scheduledDate { get; set; }
		private TimeSpan waitTime { get; set; }
		private Thread mainThread { get; set; }
		private Boolean plsStop = false;

		public MainService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			// writing to event log that the service has started
			assetsEventLog.WriteEntry("Assets service started", EventLogEntryType.Information, 0);

			/*currentDate = DateTime.Now;
			scheduledDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, scheduledTimeHour, scheduledTimeMin, 0);

			if (scheduledDate > currentDate)
			{
				waitTime = scheduledDate - currentDate;
			}
			else
			{
				waitTime = scheduledDate.AddDays(1) - currentDate;
			}*/

			mainThread = new Thread(scheduleLoop);
			mainThread.Start();
		}

		protected override void OnStop()
		{
			assetsEventLog.WriteEntry($"Stopping thread gently", EventLogEntryType.Information, 2);
			plsStop = true;
			mainThread.Join();
			// writing to event log that the service has stopped
			assetsEventLog.WriteEntry("Assets service stopped", EventLogEntryType.Information, 1);
		}

		private void scheduleLoop()
		{
			scheduledTimeHour = 0;
			scheduledTimeMin = 0;
			scheduledTimeSec = 10;

			while (true)
			{
				if (plsStop)
				{
					return;
				}
				else
				{
					Thread.Sleep(DateTime.Now.AddHours(scheduledTimeHour).AddMinutes(scheduledTimeMin).AddSeconds(scheduledTimeSec) - DateTime.Now);
					onSchedule();
				}
			}
		}

		private void onSchedule()
		{
			// scheduler event starts here
			assetsEventLog.WriteEntry($"Assets poller timer event starts, default writing to {EventLog.Log}, current writing to {EventLog.Log}", EventLogEntryType.Information, 3);

			// start of scan process

			// end of main scan process
		}
	}
}
