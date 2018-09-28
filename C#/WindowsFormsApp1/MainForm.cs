using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClientAppNamespace
{
	public partial class MainForm : Form
	{
		String connectionLine = "Server = dc-sql12-db\\db; Database = Inventory; Trusted_Connection = Yes; Integrated Security = SSPI;";
		List<dboTable> queryResultsList = new List<dboTable>();
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			
		}

		private void searchButton_Click(object sender, EventArgs e)
		{
			queryResultsList = dboTable.getFromSql($"SELECT * FROM dbo.main WHERE hostname = '{searchBox.Text}' ORDER BY id DESC;", connectionLine, "main");
			if (queryResultsList.Count != 0)
			{
				List<string> searchResulsList = new List<string>();
				foreach (dboTable tmp in queryResultsList)
				{
					searchResulsList.Add(Convert.ToString(tmp.scantime));
				}
				searchResultsBox.DataSource = searchResulsList;
				loadEntryButton.Enabled = true;
				searchResultsBox.Focus();
			}
			else
			{
				searchResultsBox.DataSource = new List<string> {"No entries found"};
				loadEntryButton.Enabled = false;
			}
		}

		private void searchResultsBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			loadEntryButton.Enabled = true;
		}

		private void loadEntryButton_Click(object sender, EventArgs e)
		{
			List<List<dboTable>> sentData = new List<List<dboTable>>();
			sentData.Add(dboTable.getFromSql($"SELECT * FROM dbo.main WHERE id = {queryResultsList[searchResultsBox.SelectedIndex].id};", connectionLine, "main"));
			sentData.Add(dboTable.getFromSql($"SELECT * FROM dbo.usr WHERE id_parent = {queryResultsList[searchResultsBox.SelectedIndex].id};", connectionLine, "usr"));
			sentData.Add(dboTable.getFromSql($"SELECT * FROM dbo.cpu WHERE id_parent = {queryResultsList[searchResultsBox.SelectedIndex].id};", connectionLine, "cpu"));
			sentData.Add(dboTable.getFromSql($"SELECT * FROM dbo.drv WHERE id_parent = {queryResultsList[searchResultsBox.SelectedIndex].id};", connectionLine, "drv"));
			sentData.Add(dboTable.getFromSql($"SELECT * FROM dbo.vol WHERE id_parent = {queryResultsList[searchResultsBox.SelectedIndex].id};", connectionLine, "vol"));
			sentData.Add(dboTable.getFromSql($"SELECT * FROM dbo.ram WHERE id_parent = {queryResultsList[searchResultsBox.SelectedIndex].id};", connectionLine, "ram"));
			sentData.Add(dboTable.getFromSql($"SELECT * FROM dbo.net WHERE id_parent = {queryResultsList[searchResultsBox.SelectedIndex].id};", connectionLine, "net"));
			sentData.Add(dboTable.getFromSql($"SELECT * FROM dbo.gpu WHERE id_parent = {queryResultsList[searchResultsBox.SelectedIndex].id};", connectionLine, "gpu"));
			sentData.Add(dboTable.getFromSql($"SELECT * FROM dbo.mon WHERE id_parent = {queryResultsList[searchResultsBox.SelectedIndex].id};", connectionLine, "mon"));
			sentData.Add(dboTable.getFromSql($"SELECT * FROM dbo.prn WHERE id_parent = {queryResultsList[searchResultsBox.SelectedIndex].id};", connectionLine, "prn"));
			sentData.Add(dboTable.getFromSql($"SELECT * FROM dbo.soft WHERE id_parent = {queryResultsList[searchResultsBox.SelectedIndex].id};", connectionLine, "soft"));
			ViewAssetForm AssetForm = new ViewAssetForm(sentData);
			AssetForm.Show();
		}

		// keys'n'double clicks hadlers below
		private void searchBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				searchButton_Click(this, new EventArgs());
			}
		}

		private void searchResultsBox_DoubleClick(object sender, EventArgs e)
		{
			if (loadEntryButton.Enabled)
			{
				loadEntryButton_Click(this, new EventArgs());
			}
		}

		private void searchResultsBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (loadEntryButton.Enabled)
				{
					loadEntryButton_Click(this, new EventArgs());
				}
			}
		}

		// test shit below
	}
}
