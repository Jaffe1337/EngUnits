using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringUnits
{
	class IEngineeringUnits
	{
		public static double Conversion(double x, string f_unit, string t_unit) {

			// get unit objects
			var fromUnitVar = Units.getObject(f_unit);
			var toUnitVar = Units.getObject(t_unit);

			if (fromUnitVar == null || toUnitVar == null) {
				// Error, invalid object
				return 0;
			}
			/*
			else if (fromUnitVar["ConversionToBaseUnit"]["_baseUnit"] != toUnitVar["ConversionToBaseUnit"]["_baseUnit"]) {
				// Error, not of same unit of measurement
				return 0;
			} */

			List<double> unitValues = Calculations(fromUnitVar, toUnitVar);

			return (x * unitValues[0]) / unitValues[1];

		}

		private static List<double> Calculations(Newtonsoft.Json.Linq.JObject f_unit, Newtonsoft.Json.Linq.JObject t_unit)
		{
			Newtonsoft.Json.Linq.JObject[] units = { f_unit, t_unit };
			List<double> conversionUnits = new List<double>();

			// get unit values
			foreach (var unit in units) {
				if (unit["ConversionToBaseUnit"]["Factor"] != null)
				{
					conversionUnits.Add(Convert.ToDouble(unit["ConversionToBaseUnit"]["Factor"]));
				}
				else {
					double numerator = Convert.ToDouble(unit["ConversionToBaseUnit"]["Fraction"]["Numerator"]);
					double denominator = Convert.ToDouble(unit["ConversionToBaseUnit"]["Fraction"]["Denominator"]);
					conversionUnits.Add(numerator / denominator);
				}
			}
			return conversionUnits;
		}

		static void CreateUnits() { 
		
		}

		static void ListModule() { 
		
		}

	}
}
