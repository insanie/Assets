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

			// creating drawer object
			drawer current = new drawer(20, 220, 120);

			// cpu tab labels creating
			// static ones
			current.createStaticLabel(new[] {"Model", "Frequency", "Cores", "Threads", "Socket"}, cpuTab, "cpu");
			// value ones
			current.createLabel(sentData[2], cpuTab, "cpu", "model", 1);
			current.createLabel(sentData[2], cpuTab, "cpu", "freq", 21, " MHz");
			current.createLabel(sentData[2], cpuTab, "cpu", "cores", 41);
			current.createLabel(sentData[2], cpuTab, "cpu", "threads", 61);
			current.createLabel(sentData[2], cpuTab, "cpu", "socket", 81);

			// dimm tab labels creating
			// static ones
			current.createStaticLabel(new[] {"Slot", "Frequency", "Size", "Vendor", "Model"}, dimmTab, "dimm");
			// value ones
			current.createLabel(sentData[5], dimmTab, "dimm", "slot", 1);
			current.createLabel(sentData[5], dimmTab, "dimm", "freq", 21, " MHz");
			current.createLabel(sentData[5], dimmTab, "dimm", "size", 41, " GB");
			current.createLabel(sentData[5], dimmTab, "dimm", "vendor", 61);
			current.createLabel(sentData[5], dimmTab, "dimm", "model", 81);

			// drive tab labels creating
			// static ones
			current.createStaticLabel(new[] {"Model", "Size"}, drivesTab, "drives");
			// value ones
			current.createLabel(sentData[3], drivesTab, "drives", "model", 1);
			current.createLabel(sentData[3], drivesTab, "drives", "size", 21, " GB");

			// partitions tab labels creating
			// static ones
			current.createStaticLabel(new[] {"Drive", "Filesystem", "Size", "Used", "Free"}, partitionsTab, "partitions");
			// value ones
			current.createLabel(sentData[4], partitionsTab, "partitions", "letter", 1);
			current.createLabel(sentData[4], partitionsTab, "partitions", "filesys", 21);
			current.createLabel(sentData[4], partitionsTab, "partitions", "size", 41, " GB");
			current.createLabel(sentData[4], partitionsTab, "partitions", "used", 61, " GB");
			current.createLabel(sentData[4], partitionsTab, "partitions", "free", 81, " GB");

			// networking tab labels creating
			// static ones
			current.createStaticLabel(new[] {"Model", "Connection name", "MAC address", "Adapter enabled", "DHCP enabled", "IP address", "Netmask", "Gateway", "DNS servers"}, networkingTab, "partitions");
			// value ones
			current.createLabel(sentData[6], networkingTab, "networking", "model", 1);
			current.createLabel(sentData[6], networkingTab, "networking", "conname", 21);
			current.createLabel(sentData[6], networkingTab, "networking", "mac", 41);
			current.createLabel(sentData[6], networkingTab, "networking", "ena", 61);
			current.createLabel(sentData[6], networkingTab, "networking", "dhcp", 81);
			current.createLabel(sentData[6], networkingTab, "networking", "ip", 101);
			current.createLabel(sentData[6], networkingTab, "networking", "mask", 121);
			current.createLabel(sentData[6], networkingTab, "networking", "gate", 141);
			current.createLabel(sentData[6], networkingTab, "networking", "dns", 161);

			// gpu tab labels creating
			// static ones
			current.createStaticLabel(new[] {"Model", "Driver"}, gpuTab, "gpu");
			// value ones
			current.createLabel(sentData[7], gpuTab, "gpu", "model", 1);
			current.createLabel(sentData[7], gpuTab, "gpu", "driver", 21);

			// monitors tab labels creating
			// static ones
			current.createStaticLabel(new[] {"Vendor", "Model", "Serial number"}, monitorsTab, "partitions");
			// value ones
			current.createLabel(sentData[8], monitorsTab, "monitors", "vendor", 1);
			current.createLabel(sentData[8], monitorsTab, "monitors", "model", 21);
			current.createLabel(sentData[8], monitorsTab, "monitors", "sn", 41);

			// printers tab labels creating
			// static ones
			current.createStaticLabel(new[] {"Name", "Default", "Shared", "Port"}, printersTab, "partitions");
			// value ones
			current.createLabel(sentData[9], printersTab, "printers", "name", 1);
			current.createLabel(sentData[9], printersTab, "printers", "def", 21);
			current.createLabel(sentData[9], printersTab, "printers", "shared", 41);
			current.createLabel(sentData[9], printersTab, "printers", "port", 61);
		}
		private void ViewAssetForm_Load(object sender, EventArgs e)
		{
			
		}
		private void cpuTab_Enter(object sender, EventArgs e)
		{
			Height = 391;
			tabPanel.Height = 148;
		}
		private void dimmTab_Enter(object sender, EventArgs e)
		{
			Height = 391;
			tabPanel.Height = 148;
		}
		private void drivesTab_Enter(object sender, EventArgs e)
		{
			Height = 331;
			tabPanel.Height = 88;
		}
		private void partitionsTab_Enter(object sender, EventArgs e)
		{
			Height = 391;
			tabPanel.Height = 148;
		}
		private void networkingTab_Enter(object sender, EventArgs e)
		{
			Height = 471;
			tabPanel.Height = 228;
		}
		private void gpuTab_Enter(object sender, EventArgs e)
		{
			Height = 331;
			tabPanel.Height = 88;
		}
		private void monitorsTab_Enter(object sender, EventArgs e)
		{
			Height = 351;
			tabPanel.Height = 108;
		}
		private void printersTab_Enter(object sender, EventArgs e)
		{
			Height = 371;
			tabPanel.Height = 128;
		}
		private void usersTab_Enter(object sender, EventArgs e)
		{
			Height = 471;
			tabPanel.Height = 228;
		}
		private void softwareTab_Enter(object sender, EventArgs e)
		{
			Height = 471;
			tabPanel.Height = 228;
		}
	}
}
