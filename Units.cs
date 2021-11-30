using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EngineeringUnits
{
	class Units
	{
		private static Newtonsoft.Json.Linq.JObject ReadJson(string v_unit) {

			string json = "";

			using (StreamReader r = new StreamReader("poscUnits22.json"))
			{
				json = r.ReadToEnd();
			}

			dynamic array = JsonConvert.DeserializeObject(json);
			return array;
		}


		public static Newtonsoft.Json.Linq.JObject getObject(string v_unit) {

			dynamic array = ReadJson(v_unit);

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
