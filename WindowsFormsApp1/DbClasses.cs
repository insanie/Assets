using System;
using System.Data.SqlClient;

namespace ClientAppNamespace
{
	public class dboMain
	{
		public Int32 id { get; set; }
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
		public dboMain(SqlDataReader inputObj)
		{
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
		}
	}
	public class dboUsr
	{
		public Int32 id { get; set; }
		public Int32 id_parent { get; set; }
		public String fullname { get; set; }
		public Byte place { get; set; }
		public DateTime logontime { get; set; }
		public String account { get; set; }
		public String company { get; set; }
		public String department { get; set; }
		public String job { get; set; }
		public dboUsr(SqlDataReader inputObj)
		{
			id = inputObj.GetInt32(0);
			id_parent = inputObj.GetInt32(1);
			fullname = inputObj.GetString(2);
			place = inputObj.GetByte(3);
			logontime = inputObj.GetDateTime(4);
			account = inputObj.GetString(5);
			company = inputObj.GetString(6);
			department = inputObj.GetString(7);
			job = inputObj.GetString(8);
		}
	}
	public class dboCpu
	{
		public Int32 id { get; set; }
		public Int32 id_parent { get; set; }
		public String model { get; set; }
		public Int16 freq { get; set; }
		public Byte cores { get; set; }
		public Byte threads { get; set; }
		public String socket { get; set; }
		public dboCpu(SqlDataReader inputObj)
		{
			id = inputObj.GetInt32(0);
			id_parent = inputObj.GetInt32(1);
			model = inputObj.GetString(2);
			freq = inputObj.GetInt16(3);
			cores = inputObj.GetByte(4);
			threads = inputObj.GetByte(5);
			socket = inputObj.GetString(6);
		}
	}
	public class dboDrv
	{
		public Int32 id { get; set; }
		public Int32 id_parent { get; set; }
		public String model { get; set; }
		public Single size { get; set; }
		public dboDrv(SqlDataReader inputObj)
		{
			id = inputObj.GetInt32(0);
			id_parent = inputObj.GetInt32(1);
			model = inputObj.GetString(2);
			size = inputObj.GetFloat(3);
		}
	}
	public class dboVol
	{
		public Int32 id { get; set; }
		public Int32 id_parent { get; set; }
		public String letter { get; set; }
		public String filesys { get; set; }
		public Single size { get; set; }
		public Single used { get; set; }
		public Single free { get; set; }
		public dboVol(SqlDataReader inputObj)
		{
			id = inputObj.GetInt32(0);
			id_parent = inputObj.GetInt32(1);
			letter = inputObj.GetString(2);
			filesys = inputObj.GetString(3);
			size = inputObj.GetFloat(4);
			used = inputObj.GetFloat(5);
			free = inputObj.GetFloat(6);
		}
	}
	public class dboRam
	{
		public Int32 id { get; set; }
		public Int32 id_parent { get; set; }
		public String slot { get; set; }
		public Int16 freq { get; set; }
		public Single size { get; set; }
		public String vendor { get; set; }
		public String model { get; set; }
		public dboRam(SqlDataReader inputObj)
		{
			id = inputObj.GetInt32(0);
			id_parent = inputObj.GetInt32(1);
			slot = inputObj.GetString(2);
			freq = inputObj.GetInt16(3);
			size = inputObj.GetFloat(4);
			vendor = inputObj.GetString(5);
			model = inputObj.GetString(6);
		}
	}
	public class dboNet
	{
		public Int32 id { get; set; }
		public Int32 id_parent { get; set; }
		public String model { get; set; }
		public String conname { get; set; }
		public String mac { get; set; }
		public Boolean ena { get; set; }
		public Boolean dhcp { get; set; }
		public String ip { get; set; }
		public String mask { get; set; }
		public String gate { get; set; }
		public String dns { get; set; }
		public dboNet(SqlDataReader inputObj)
		{
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
		}
	}
	public class dboGpu
	{
		public Int32 id { get; set; }
		public Int32 id_parent { get; set; }
		public String model { get; set; }
		public String driver { get; set; }
		public dboGpu(SqlDataReader inputObj)
		{
			id = inputObj.GetInt32(0);
			id_parent = inputObj.GetInt32(1);
			model = inputObj.GetString(2);
			driver = inputObj.GetString(3);
		}
	}
	public class dboMon
	{
		public Int32 id { get; set; }
		public Int32 id_parent { get; set; }
		public String vendor { get; set; }
		public String model { get; set; }
		public String sn { get; set; }
		public dboMon(SqlDataReader inputObj)
		{
			id = inputObj.GetInt32(0);
			id_parent = inputObj.GetInt32(1);
			vendor = inputObj.GetString(2);
			model = inputObj.GetString(3);
			sn = inputObj.GetString(4);
		}
	}
	public class dboPrn
	{
		public Int32 id { get; set; }
		public Int32 id_parent { get; set; }
		public String name { get; set; }
		public Boolean def { get; set; }
		public Boolean shared { get; set; }
		public String port { get; set; }
		public dboPrn(SqlDataReader inputObj)
		{
			id = inputObj.GetInt32(0);
			id_parent = inputObj.GetInt32(1);
			name = inputObj.GetString(2);
			def = inputObj.GetBoolean(3);
			shared = inputObj.GetBoolean(4);
			port = inputObj.GetString(5);
		}
	}
	public class dboSoft
	{
		public Int64 id { get; set; }
		public Int32 id_parent { get; set; }
		public String name { get; set; }
		public String ver { get; set; }
		public String path { get; set; }
		public dboSoft(SqlDataReader inputObj)
		{
			id = inputObj.GetInt64(0);
			id_parent = inputObj.GetInt32(1);
			name = inputObj.GetString(2);
			ver = inputObj.GetString(3);
			path = inputObj.GetString(4);
		}
	}
	public class dboLog
	{
		public Int32 id { get; set; }
		public String hostname { get; set; }
		public DateTime scantime { get; set; }
		public Boolean stat { get; set; }
		public Int32 session_local { get; set; }
		public Int32 session_global { get; set; }
		public dboLog(SqlDataReader inputObj)
		{
			id = inputObj.GetInt32(0);
			hostname = inputObj.GetString(1);
			scantime = inputObj.GetDateTime(2);
			stat = inputObj.GetBoolean(3);
			session_local = inputObj.GetInt32(4);
			session_global = inputObj.GetInt32(5);
		}
	}
}
