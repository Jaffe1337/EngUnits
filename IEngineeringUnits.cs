using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringUnits
{
	class IEngineeringUnits
	{
		// (e)
		public static List<string> Conversion(double x, string f_unit, string t_unit)
		{
			List<string> result = new List<string>();

			// get unit objects
			var fromUnitVar = Units.getObject(f_unit);
			var toUnitVar = Units.getObject(t_unit);

			if (fromUnitVar == null || toUnitVar == null)
			{
				// Error, invalid object
				result.Add("Error: Invalid object");
				return result;
			}
			else if (fromUnitVar["ConversionToBaseUnit"]["_baseUnit"].ToString() != toUnitVar["ConversionToBaseUnit"]["_baseUnit"].ToString()) {
				// Error, not of same unit of measurement
				result.Add("Error: not of same unit of measurement");
				return result;
			} 

			List<double> unitValues = Calculations(fromUnitVar, toUnitVar);

			result.Add(((x * unitValues[0]) / unitValues[1]).ToString());
			result.Add(t_unit);
			//result.Add(toUnitVar["_annotation"].ToString());

			return result;

		}

		private static List<double> Calculations(Newtonsoft.Json.Linq.JObject f_unit, Newtonsoft.Json.Linq.JObject t_unit)
		{
			Newtonsoft.Json.Linq.JObject[] units = { f_unit, t_unit };
			List<double> conversionUnits = new List<double>();

			// get unit values
			foreach (var unit in units)
			{
				if (unit["ConversionToBaseUnit"]["Factor"] != null)
				{
					conversionUnits.Add(Convert.ToDouble(unit["ConversionToBaseUnit"]["Factor"]));
				}
				else
				{
					double numerator = Convert.ToDouble(unit["ConversionToBaseUnit"]["Fraction"]["Numerator"]);
					double denominator = Convert.ToDouble(unit["ConversionToBaseUnit"]["Fraction"]["Denominator"]);
					conversionUnits.Add(numerator / denominator);
				}
			}
			return conversionUnits;
		}


		// List all uom fro a given quantity type (d)
		public static List<string> ListModule(bool is_quantity, string entry)
		{
			List<string> result = new List<string>();

			switch (is_quantity) {
				case true:
					result = ListQuantity(entry);
					break;
				case false:
					result = ListDimensions(entry);
					break;
			}

			return result;
		}


		private static List<string> ListQuantity(string q_type) {

			var units = Units.ReadJson();
			List<string> quantityTypes = new List<string>();

			foreach (var item in units["UnitOfMeasureDictionary"]["UnitsDefinition"]["UnitOfMeasure"])
			{
				if (item["QuantityType"] != null)
				{
					foreach (var type in item["QuantityType"])
					{
						if (q_type == type.ToString())
						{
							quantityTypes.Add(item["Name"].ToString());
						}
					}
				}
			}

			return quantityTypes;
		}


		private static List<string> ListDimensions(string d_class) {

			var units = Units.ReadJson();
			List<string> dimensionClass = new List<string>();
			bool key = true;

			foreach (var item in units["UnitOfMeasureDictionary"]["UnitsDefinition"]["UnitOfMeasure"])
			{
				if (item["DimensionalClass"] != null && item["DimensionalClass"].ToString() == d_class)
				{
					key = false;
					dimensionClass.Add(item["Name"].ToString());						
				}
			}

			if (key)
				dimensionClass.Add("Did not find any units of measurements consisting with your entry.");

			return dimensionClass;
		}


		private static List<string> ListClasses(string q_type)
		{

			List<string> classList = new List<string>();


			return classList;
		}
	}
}
