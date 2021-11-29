using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EngineeringUnits
{
	class Units
	{
		public static Newtonsoft.Json.Linq.JObject Read(string v_unit) {

			string json = "";

			using (StreamReader r = new StreamReader("poscUnits22.json"))
			{
				json = r.ReadToEnd();
			}

			dynamic array = JsonConvert.DeserializeObject(json);			
			foreach (var item in array["UnitOfMeasureDictionary"]["UnitsDefinition"]["UnitOfMeasure"])
			{
				if (item["Name"] == v_unit)
					return item;
			}
			return null;
		}

		static void Write(){ 
		
		}

}
}
