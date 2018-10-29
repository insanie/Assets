using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

// all classes that are used anywhere in the code are stored here
namespace AssetsClientApp
{
	// class for regular output from tables
	// contains all possible properties to store values from every possible REGULAR table (for example 'SELECT *', not 'SELECT some_field_1, some_field_2')
	public class dboTable
	{
		public Int64 id { get; set; }
		public String hostname { get; set; }
		public Int32 session_local { get; set; }
		public Int32 session_global { get; set; }
		public DateTime scantime { get; set; }
		public String os_system { get; set; }
		public String os_arch { get; set; }
		public Int32 os_build { get; set; }
		public String os_lang { get; set; }
		public String mobo_vendor { get; set; }
		public String mobo_model { get; set; }
		public String mobo_rev { get; set; }
		public String bios_vendor { get; set; }
		public String bios_name { get; set; }
		public String bios_ver { get; set; }
		public Byte ram_totalslots { get; set; }
		public Byte ram_occslots { get; set; }
		public Single ram_total { get; set; }
		public Single ram_max { get; set; }
		public Int32 id_parent { get; set; }
		public String fullname { get; set; }
		public Byte place { get; set; }
		public DateTime? logontime { get; set; }
		public String account { get; set; }
		public String company { get; set; }
		public String department { get; set; }
		public String job { get; set; }
		public String model { get; set; }
		public Int16 freq { get; set; }
		public Byte cores { get; set; }
		public Byte threads { get; set; }
		public String socket { get; set; }
		public Single size { get; set; }
		public String letter { get; set; }
		public String filesys { get; set; }
		public Single used { get; set; }
		public Single free { get; set; }
		public String slot { get; set; }
		public String vendor { get; set; }
		public String conname { get; set; }
		public String mac { get; set; }
		public Boolean ena { get; set; }
		public Boolean dhcp { get; set; }
		public String ip { get; set; }
		public String mask { get; set; }
		public String gate { get; set; }
		public String dns { get; set; }
		public String driver { get; set; }
		public String sn { get; set; }
		public String name { get; set; }
		public Boolean def { get; set; }
		public Boolean shared { get; set; }
		public String port { get; set; }
		public String ver { get; set; }
		public String path { get; set; }
		public Boolean stat { get; set; }
		// constructor function, requires SqlDataReader object to parse and fill the properties
		public dboTable(SqlDataReader inputObj, String tableType)
		{
			switch (tableType)
			{
				// filling particular field depending on specific table output
				// properties that left null will stay null
				case "main":
					id = inputObj.GetInt32(0);
					hostname = inputObj.GetString(1);
					session_local = inputObj.GetInt32(2);
					session_global = inputObj.GetInt32(3);
					scantime = inputObj.GetDateTime(4);
					os_system = inputObj.GetString(5);
					os_arch = inputObj.GetString(6);
					os_build = inputObj.GetInt32(7);
					os_lang = inputObj.GetString(8);
					mobo_vendor = inputObj.GetString(9);
					mobo_model = inputObj.GetString(10);
					mobo_rev = inputObj.GetString(11);
					bios_vendor = inputObj.GetString(12);
					bios_name = inputObj.GetString(13);
					bios_ver = inputObj.GetString(14);
					ram_totalslots = inputObj.GetByte(15);
					ram_occslots = inputObj.GetByte(16);
					ram_total = inputObj.GetFloat(17);
					ram_max = inputObj.GetFloat(18);
					break;
				case "usr":
					id = inputObj.GetInt32(0);
					id_parent = inputObj.GetInt32(1);
					fullname = inputObj.GetString(2);
					place = inputObj.GetByte(3);
					// in case db value is null, because cannot GetDateTime(null)
					if (!inputObj.IsDBNull(4))
					{
						logontime = inputObj.GetDateTime(4);
					}
					else
					{
						logontime = null;
					}
					account = inputObj.GetString(5);
					company = inputObj.GetString(6);
					department = inputObj.GetString(7);
					job = inputObj.GetString(8);
					break;
				case "cpu":
					id = inputObj.GetInt32(0);
					id_parent = inputObj.GetInt32(1);
					model = inputObj.GetString(2);
					freq = inputObj.GetInt16(3);
					cores = inputObj.GetByte(4);
					threads = inputObj.GetByte(5);
					socket = inputObj.GetString(6);
					break;
				case "drv":
					id = inputObj.GetInt32(0);
					id_parent = inputObj.GetInt32(1);
					model = inputObj.GetString(2);
					size = inputObj.GetFloat(3);
					break;
				case "vol":
					id = inputObj.GetInt32(0);
					id_parent = inputObj.GetInt32(1);
					letter = inputObj.GetString(2);
					filesys = inputObj.GetString(3);
					size = inputObj.GetFloat(4);
					used = inputObj.GetFloat(5);
					free = inputObj.GetFloat(6);
					break;
				case "ram":
					id = inputObj.GetInt32(0);
					id_parent = inputObj.GetInt32(1);
					slot = inputObj.GetString(2);
					freq = inputObj.GetInt16(3);
					size = inputObj.GetFloat(4);
					vendor = inputObj.GetString(5);
					model = inputObj.GetString(6);
					break;
				case "net":
					id = inputObj.GetInt32(0);
					id_parent = inputObj.GetInt32(1);
					model = inputObj.GetString(2);
					conname = inputObj.GetString(3);
					mac = inputObj.GetString(4);
					ena = inputObj.GetBoolean(5);
					dhcp = inputObj.GetBoolean(6);
					ip = inputObj.GetString(7);
					mask = inputObj.GetString(8);
					gate = inputObj.GetString(9);
					dns = inputObj.GetString(10);
					break;
				case "gpu":
					id = inputObj.GetInt32(0);
					id_parent = inputObj.GetInt32(1);
					model = inputObj.GetString(2);
					driver = inputObj.GetString(3);
					break;
				case "mon":
					id = inputObj.GetInt32(0);
					id_parent = inputObj.GetInt32(1);
					vendor = inputObj.GetString(2);
					model = inputObj.GetString(3);
					sn = inputObj.GetString(4);
					break;
				case "prn":
					id = inputObj.GetInt32(0);
					id_parent = inputObj.GetInt32(1);
					name = inputObj.GetString(2);
					def = inputObj.GetBoolean(3);
					shared = inputObj.GetBoolean(4);
					port = inputObj.GetString(5);
					break;
				case "soft":
					id = inputObj.GetInt64(0);
					id_parent = inputObj.GetInt32(1);
					name = inputObj.GetString(2);
					ver = inputObj.GetString(3);
					path = inputObj.GetString(4);
					break;
				case "log":
					id = inputObj.GetInt32(0);
					hostname = inputObj.GetString(1);
					scantime = inputObj.GetDateTime(2);
					stat = inputObj.GetBoolean(3);
					session_local = inputObj.GetInt32(4);
					session_global = inputObj.GetInt32(5);
					break;
				default:
					break;
			}

		}
		// gets list of objects of this class, establishes sql connection on its own, requires premade connection line, tableType defines table you want the output from
		// ofc you need the correct query that fits tableType and vice versa
		// having static function that uses its own constuctor is quite weird so that stuff has to be redesigned
		static public List<dboTable> getFromSql(String query, String connectionLine, String tableType)
		{
			List<dboTable> outputList = new List<dboTable>();
			using (SqlConnection connection = new SqlConnection(connectionLine))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				SqlDataReader sqlOutput = command.ExecuteReader();
				if (sqlOutput.HasRows)
				{
					while (sqlOutput.Read())
					{
						outputList.Add(new dboTable(sqlOutput, tableType));
					}
				}
				sqlOutput.Close();
			}
			return outputList;
		}
	}
	// class that drawes labels for multiple instances (e.g. dimms, hard drives, monitors, etc.)
	public class drawer
	{
		// parameters that must be set within the constructor
		public byte labelHeight { get; }
		public byte labelWidth { get; }
		public byte labelStaticWidth { get; }
		//public System.Drawing.Color backColor { get; }
		public drawer(byte height, byte width, byte staticWidth)
		{
			labelHeight = height;
			labelWidth = width;
			labelStaticWidth = staticWidth;
			//backColor = Control.DefaultBackColor;
		}
		// creates labels with data from a particular property of every element of the list, requires TabPage to work, tabType only defines the name of each label (see the loop)
		// ypos defines margin from the top (may be deprecated, I dunno), suffix lets you add a string to the labels text ('GB', 'MHz', etc.)
		public void createROTextBox(List<dboTable> data, TabPage panel, String tabType, String fieldName, Int16 ypos, String suffix = "")
		{
			Byte positionIncrement = 1;
			// using dictionary to name labels dynamically
			Dictionary<String, TextBox> names = new Dictionary<String, TextBox>();
			foreach (dboTable tmp in data)
			{
				String name = $"{tabType}_{fieldName}Label" + Convert.ToString(positionIncrement);
				names[name] = new TextBox();
				panel.Controls.Add(names[name]);
				names[name].Location = new System.Drawing.Point(labelStaticWidth + 1 + labelWidth * (positionIncrement - 1), ypos);
				names[name].Margin = new Padding(0);
				names[name].ReadOnly = true;
				names[name].BorderStyle = 0;
				names[name].BackColor = Control.DefaultBackColor;
				names[name].TabStop = false;
				names[name].WordWrap = true;
				names[name].Name = name;
				names[name].Size = new System.Drawing.Size(labelWidth, labelHeight);
				names[name].Text = Convert.ToString(typeof(dboTable).GetProperty(fieldName).GetValue(tmp, null) + suffix);
				positionIncrement++;
			}
		}
		// creates static labels (headers) with the text from array, requires TabPage to work, tabType only defines the name of each label (see the loop)
		public void createStaticLabel(String[] namesList, TabPage panel, String tabType)
		{
			Byte positionIncrement = 1;
			// using dictionary to name labels dynamically
			Dictionary<String, Label> names = new Dictionary<String, Label>();
			foreach (String tmp in namesList)
			{
				String name = $"{tabType}_{tmp}Label" + Convert.ToString(positionIncrement);
				names[name] = new Label();
				panel.Controls.Add(names[name]);
				names[name].BorderStyle = BorderStyle.Fixed3D;
				names[name].Location = new System.Drawing.Point(1, 1 + labelHeight * (positionIncrement - 1));
				names[name].Margin = new Padding(0);
				names[name].Name = name;
				names[name].Size = new System.Drawing.Size(labelStaticWidth, labelHeight);
				names[name].Text = tmp;
				positionIncrement++;
			}
		}
	}
	// class for static functions that get and set parameters from conf file
	// no particular object declaring is needed
	public class settings
	{
		public static string getParameter(string name)
		{
			var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			String value = config.AppSettings.Settings[name].Value;
			return value;
		}
		public static void setParameter(string name, string value)
		{
			var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			config.AppSettings.Settings[name].Value = value;
			config.Save(ConfigurationSaveMode.Modified);
		}
	}
}
