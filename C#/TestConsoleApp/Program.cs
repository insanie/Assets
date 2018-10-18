using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			for (Byte i = 1; i <= 5; i++)
			{
				System.Threading.Thread.Sleep(DateTime.Now.AddSeconds(5) - DateTime.Now);
				Console.WriteLine("Tick {0} happened", i);
			}
		}
	}
}
