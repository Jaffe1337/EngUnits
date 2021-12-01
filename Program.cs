using System;
using System.Net;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using EngineeringUnits;

namespace EngineeringUnits
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");


			var a = IEngineeringUnits.ListModule(false, null);
			foreach (var item in a)
				Console.WriteLine("{0}", item);

			var b = IEngineeringUnits.ListModule(false, null);
			foreach (var item in b)
				Console.WriteLine("{0}", item);

			var c = IEngineeringUnits.ListModule(true, "electric charge");
			foreach (var item in c)				
				Console.WriteLine("{0}", item);

			var d = IEngineeringUnits.ListModule(true, "electric charge");
			foreach (var item in d)
				Console.WriteLine("{0}", item);

			var e = IEngineeringUnits.Conversion(1, "kilobyte", "bit");
			foreach (var item in e)
				Console.WriteLine("{0}", item);
		}

        
    }
}
