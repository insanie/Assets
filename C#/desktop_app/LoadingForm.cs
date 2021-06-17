using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AssetsClientApp
{
	public partial class LoadingForm : Form
	{
		// declaring 2d list for storing data to send to view assets form
		public List<List<dboTable>> sentData { get; set; }
		private Int64 id { get; }
		private String connectionLine { get; }
		// list of table names
		private String[] tablesList = {"main", "usr", "cpu", "drv", "vol", "ram", "net", "gpu", "mon", "prn", "soft"};
		private String currentTable { get; set; }

		public LoadingForm(Int64 sentId, String sentConnectionLine)
		{
			InitializeComponent();
			id = sentId;
			connectionLine = sentConnectionLine;
			backgroundSqlQuerying.WorkerReportsProgress = true;
		}
		
		private void LoadingForm_Load(object sender, EventArgs e)
		{

		}

		private void LoadingForm_Shown(object sender, EventArgs e)
		{
			backgroundSqlQuerying.RunWorkerAsync();
		}

		private void backgroundSqlQuerying_DoWork(object sender, DoWorkEventArgs e)
		{
			List<List<dboTable>> tmp = new List<List<dboTable>>();
			BackgroundWorker worker = sender as BackgroundWorker;
			Byte count = 1;
			foreach (String tableName in tablesList)
			{
				if (tableName == "main")
				{
					tmp.Add(dboTable.getFromSql($"SELECT * FROM dbo.{tableName} WHERE id = {id};", connectionLine, $"{tableName}"));
				}
				else
				{
					tmp.Add(dboTable.getFromSql($"SELECT * FROM dbo.{tableName} WHERE id_parent = {id};", connectionLine, $"{tableName}"));
				}
				currentTable = tableName;
				worker.ReportProgress(100/11*count);
				count++;
			}
			sentData = tmp;
		}

		private void backgroundSqlQuerying_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// updating labels and progress bar values
			loadingPercentLabel.Text = (e.ProgressPercentage.ToString() + "%");
			loadingProgressBar.Value = e.ProgressPercentage;
			sqlQueryLabel.Text = $"Querying {currentTable} table...";
		}

		private void backgroundSqlQuerying_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// final update and form closing
			loadingPercentLabel.Text = ("100%");
			loadingProgressBar.Value = 100;
			sqlQueryLabel.Text = "All queries finished";
			Close();
		}
	}
}
