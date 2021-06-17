using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AssetsClientApp
{
	public partial class MainForm : Form
	{
		// defining connection string based on settings
		private String connectionLine = $"Server = '{settings.getParameter("server")}'; Database = '{settings.getParameter("database")}'; Trusted_Connection = Yes; Integrated Security = SSPI;";
		// defining list for query results here so we can use it within almost all the classes
		private List<dboTable> queryResultsList { get; set; }

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			
		}

		private void searchButton_Click(object sender, EventArgs e)
		{
			// getting list of scan dates for searched hostname
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
			if ((searchResultsBox.GetItemText(searchResultsBox.SelectedItem)) != "No entries found")
			{
			loadEntryButton.Enabled = true;
			}
		}

		// preparing data here to transfer to AssetForm
		private void loadEntryButton_Click(object sender, EventArgs e)
		{
			LoadingForm LoadSplashForm = new LoadingForm(queryResultsList[searchResultsBox.SelectedIndex].id, connectionLine);
			LoadSplashForm.ShowDialog();
			ViewAssetForm AssetForm = new ViewAssetForm(LoadSplashForm.sentData);
			AssetForm.Show();
		}

		// keys and double clicks handlers below
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

		private void settingsButton_Click(object sender, EventArgs e)
		{
			SettingsForm Settings = new SettingsForm();
			Settings.ShowDialog();
			connectionLine = $"Server = '{settings.getParameter("server")}'; Database = '{settings.getParameter("database")}'; Trusted_Connection = Yes; Integrated Security = SSPI;";
			searchBox.Focus();
		}
	}
}
