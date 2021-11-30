using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringUnits
{
	class IEngineeringUnits
	{
		public static void Conversion(double x, string f_unit, string t_unit) {

			// (x * (dic[f_unit][0] / dic[f_unit][1])) / (dic[t_unit][0] / dic[t_unit][1])
			var a = Units.getObject("kilobyte");
			Console.WriteLine("{0}", a);


		}

		static void CreateUnits() { 
		
		}

		static void ListModule() { 
		
		}

	}
}
