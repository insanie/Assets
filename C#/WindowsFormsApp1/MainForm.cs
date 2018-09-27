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

		public MainForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			String query = $"SELECT * FROM dbo.main WHERE hostname = '{searchBox.Text}' ORDER BY id DESC;";
			List<object> searchResultsList = dboMain.getFromSql(query, connectionLine);
			if (searchResultsList.Count != 0)
			{
				List<string> ololo = new List<string>();
				foreach (dboMain tmp in searchResultsList)
				{
					ololo.Add(Convert.ToString(tmp.scantime));
				}
				searchResultsBox.DataSource = ololo;
				loadEntryButton.Enabled = true;
				errorLabel.Text = null;
			}
			else
			{
				searchResultsBox.DataSource = null;
				loadEntryButton.Enabled = false;
				errorLabel.Text = "No entries found";
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			testLabel.Text = Convert.ToString(searchResultsBox.SelectedItem);
			loadEntryButton.Enabled = true;
		}

		private void searchBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				button1_Click(this, new EventArgs());
			}
		}

		private void loadEntryButton_Click(object sender, EventArgs e)
		{
			
			ViewAssetForm AssetForm = new ViewAssetForm();
			AssetForm.Show();
		}

		private void searchResultsBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				loadEntryButton_Click(this, new EventArgs());
			}
		}

		private void searchResultsBox_DoubleClick(object sender, EventArgs e)
		{
			loadEntryButton_Click(this, new EventArgs());
		}
	}
}
