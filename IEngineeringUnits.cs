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

			if (entry != null)
			{
				switch (is_quantity)
				{
					case true:
						result = ListQuantity(entry);
						break;
					case false:
						result = ListDimensions(entry);
						break;
				}
			}
			else {
				result = ListAll(is_quantity);
			}
			

			return result;
		}


		private static List<string> ListQuantity(string q_type) {

			var units = Units.ReadJson();
			List<string> quantityTypes = new List<string>();

			bool key = true;
			foreach (var item in units["UnitOfMeasureDictionary"]["UnitsDefinition"]["UnitOfMeasure"])
			{
				if (item["QuantityType"] != null)
				{
					foreach (var type in item["QuantityType"])
					{
						if (q_type == type.ToString())
						{
							key = false;
							quantityTypes.Add(item["Name"].ToString());
						}
					}
				}
			}

			if (key)
				quantityTypes.Add("Did not find any units of measurements consisting with your entry.");

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


		private static bool checkList(List<string> type, string newEntry) {

			bool value = true;
			foreach (var entry in type) {
				if (entry == newEntry)
					value = false;
			}
			return value;
		}


		private static List<string> ListAll(bool type) {				

			var units = Units.ReadJson();
			List<string> resultingList = new List<string>();

			foreach (var item in units["UnitOfMeasureDictionary"]["UnitsDefinition"]["UnitOfMeasure"]) {

				switch (type) {
					// DimensionClass
					case true:

						if (item["DimensionalClass"] != null)
						{
							if (checkList(resultingList, item["DimensionalClass"].ToString()))
							{
								resultingList.Add(item["DimensionalClass"].ToString());
							}
						}

						break;

					// QuantityType
					case false:
						if (item["QuantityType"] != null)
						{
							foreach (var qType in item["QuantityType"])
							{
								if (checkList(resultingList, qType.ToString()))
								{
									resultingList.Add(qType.ToString());
								}
							}
						}

						break;
				}	
			}
			return resultingList;
		}
	}
}
