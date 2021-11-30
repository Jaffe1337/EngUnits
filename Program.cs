using System;
using EngineeringUnits;

namespace EngineeringUnits
{
	class Program
	{
		static void Main(string[] args)
		{
			// var a = IEngineeringUnits.Conversion(1, "kilobyte", "bit");
			// Console.WriteLine("{0}", a);

			Console.WriteLine("Hello World!");

			var b = IEngineeringUnits.ListQuantityTypes("electric charge");

			foreach (var item in b)				
				Console.WriteLine("{0}", item);
		}
	}
}
