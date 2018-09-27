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

			// form header
			Text = sentData[0][0].hostname + " | " + Convert.ToString(sentData[0][0].scantime) + " | " + sentData[1][0].fullname;

			// os group labels
			os_systemLabel.Text = sentData[0][0].os_system;
			os_archLabel.Text = sentData[0][0].os_arch;
			os_buildLabel.Text = Convert.ToString(sentData[0][0].os_build);
			os_langLabel.Text = sentData[0][0].os_lang;

			// mobo group labels
			mobo_vendorLabel.Text = sentData[0][0].mobo_vendor;
			mobo_modelLabel.Text = sentData[0][0].mobo_model;
			mobo_revLabel.Text = sentData[0][0].mobo_rev;

			// bios group labels
			bios_vendorLabel.Text = sentData[0][0].bios_vendor;
			bios_nameLabel.Text = sentData[0][0].bios_name;
			bios_verLabel.Text = sentData[0][0].bios_ver;

			// ram group labels
			ram_occslotsLabel.Text = Convert.ToString(sentData[0][0].ram_occslots);
			ram_totalslotsLabel.Text = Convert.ToString(sentData[0][0].ram_totalslots);
			ram_totalLabel.Text = Convert.ToString(sentData[0][0].ram_total) + " GB";
			ram_maxLabel.Text = Convert.ToString(sentData[0][0].ram_max) + " GB";
		}

		private void ViewAssetForm_Load(object sender, EventArgs e)
		{
			
		}
	}
}
