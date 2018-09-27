using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

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
			List<dboTable> mainResults = dboTable.getFromSql($"SELECT * FROM dbo.main WHERE id = {queryResultsList[searchResultsBox.SelectedIndex].id};", connectionLine, "main");
			ViewAssetForm AssetForm = new ViewAssetForm();
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
			loadEntryButton_Click(this, new EventArgs());
		}

		private void searchResultsBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				loadEntryButton_Click(this, new EventArgs());
			}
		}

		// test shit below
	}
}
