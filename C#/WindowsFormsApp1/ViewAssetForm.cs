using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientAppNamespace
{
	public partial class ViewAssetForm : Form
	{
		public ViewAssetForm(List<List<dboTable>> sentData)
		{
			InitializeComponent();

			// header labels
			hostnameLabel.Text = sentData[0][0].hostname;
			scantimeLabel.Text = Convert.ToString(sentData[0][0].scantime);

			// os tab labels
			os_systemLabel.Text = sentData[0][0].os_system;
			os_archLabel.Text = sentData[0][0].os_arch;
			os_buildLabel.Text = Convert.ToString(sentData[0][0].os_build);
			os_langLabel.Text = sentData[0][0].os_lang;

			// usr tab labels

		}

		private void ViewAssetForm_Load(object sender, EventArgs e)
		{
			

		}
	}
}
