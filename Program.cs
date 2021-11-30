using System;
using EngineeringUnits;

namespace EngineeringUnits
{
	class Program
	{
		static void Main(string[] args)
		{
			IEngineeringUnits.Conversion(1, "a", "b");
			// var a = Units.Read("bit");
			// var b = Units.Read("kilobyte");
			Console.WriteLine("Hello World!");
			// Console.WriteLine("{0}", a);
			// Console.WriteLine("{0}", b);
		}
	}
}
