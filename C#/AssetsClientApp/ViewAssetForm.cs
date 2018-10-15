using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AssetsClientApp
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
			current.createStaticLabel(new[] {"Drive", "Filesystem", "Size", "Used", "Free", "Occupation"}, partitionsTab, "partitions");
			// value ones
			current.createLabel(sentData[4], partitionsTab, "partitions", "letter", 1);
			current.createLabel(sentData[4], partitionsTab, "partitions", "filesys", 21);
			current.createLabel(sentData[4], partitionsTab, "partitions", "size", 41, " GB");
			current.createLabel(sentData[4], partitionsTab, "partitions", "used", 61, " GB");
			current.createLabel(sentData[4], partitionsTab, "partitions", "free", 81, " GB");
			// creating progress bars
			Byte positionIncrement = 1;
			Dictionary<String, ProgressBar> names = new Dictionary<String, ProgressBar>();
			foreach (dboTable tmp in sentData[4])
			{
				String name = $"partitions_progressBar" + Convert.ToString(positionIncrement);
				names[name] = new ProgressBar();
				partitionsTab.Controls.Add(names[name]);
				names[name].Location = new Point(current.labelStaticWidth + 1 + current.labelWidth * (positionIncrement - 1) + 2, 101 + 2);
				names[name].Margin = new Padding(0);
				names[name].Name = name;
				names[name].Size = new Size(current.labelWidth / 2, current.labelHeight - 4);
				names[name].Value = Convert.ToInt32(tmp.used / tmp.size * 100);
				positionIncrement++;
			}

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

			// users tab list creating
			DataTable usersDataSource = new DataTable();
			usersDataSource.Columns.Add("Order");
			usersDataSource.Columns.Add("Name");
			usersDataSource.Columns.Add("Logontime");
			usersDataSource.Columns.Add("Company");
			usersDataSource.Columns.Add("Department");
			usersDataSource.Columns.Add("Account");
			foreach(dboTable tmp in sentData[1])
			{
				usersDataSource.Rows.Add(tmp.place, tmp.fullname, tmp.logontime, tmp.company, tmp.department, tmp.account);
			}
			usersGridView.DataSource = usersDataSource;
			usersGridView.Columns[0].Width = 50;
			usersGridView.Columns[1].Width = 190;
			usersGridView.Columns[2].Width = 150;
			usersGridView.Columns[3].Width = 170;
			usersGridView.Columns[4].Width = 181;
			usersGridView.Columns[5].Width = 90;
			usersGridView.Sort(usersGridView.Columns[0], ListSortDirection.Ascending);

			// software tab list creating
			DataTable softwareDataSource = new DataTable();
			softwareDataSource.Columns.Add("Name");
			softwareDataSource.Columns.Add("Version");
			softwareDataSource.Columns.Add("Path");
			foreach (dboTable tmp in sentData[10])
			{
				softwareDataSource.Rows.Add(tmp.name, tmp.ver, tmp.path);
			}
			softwareGridView.DataSource = softwareDataSource;
			softwareGridView.Columns[0].Width = 400;
			softwareGridView.Columns[1].Width = 179;
			softwareGridView.Columns[2].Width = 252;
			softwareGridView.Sort(softwareGridView.Columns[0], ListSortDirection.Ascending);
		}
		
		private void ViewAssetForm_Load(object sender, EventArgs e)
		{
			
		}

		// maintaining form size depending on active tab
		// is there any proper way to do that?
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
			Height = 411;
			tabPanel.Height = 168;
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
