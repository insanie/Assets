using System;
using System.Windows.Forms;

namespace AssetsClientApp
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
			// filling the textboxes with values from conf file
			serverSettingsTextBox.Text = settings.getParameter("server");
			databaseSettingsTextBox.Text = settings.getParameter("database");
			//serverSettingsTextBox.Focus();
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{

		}

		private void saveSettingsButton_Click(object sender, EventArgs e)
		{
			// writing values from textboxes to the conf file
			settings.setParameter("server", serverSettingsTextBox.Text);
			settings.setParameter("database", databaseSettingsTextBox.Text);
			Close();
		}

		private void serverSettingsTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				saveSettingsButton_Click(this, new EventArgs());
			}
		}

		private void databaseSettingsTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				saveSettingsButton_Click(this, new EventArgs());
			}
		}
	}
}
