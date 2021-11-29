using System;
using EngineeringUnits;

namespace EngineeringUnits
{
	class Program
	{
		static void Main(string[] args)
		{
			var a = Units.Read("kilobyte");
			Console.WriteLine("Hello World!");
			Console.WriteLine("{0}", a);
		}
	}
}
