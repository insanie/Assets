using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

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
	}
}
