using System;
using EngineeringUnits;

namespace EngineeringUnits
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			var a = IEngineeringUnits.Conversion(1, "kilobyte", "bit");
			foreach (var item in a)
				Console.WriteLine("{0}", item); */

			Console.WriteLine("Hello World!");

			// "electric charge"
			var b = IEngineeringUnits.ListModule(false, "1");

			foreach (var item in b)				
				Console.WriteLine("{0}", item); 
		}
	}
}
