using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Tests
{
	public class DataReader
	{
		public static T GetSection<T>(string fileName, string property)
		{
			string jsonString = File.ReadAllText(fileName);
			var document = JsonDocument.Parse(jsonString);
			//retrieve the value
			var data = document.RootElement
							  .GetProperty(property);
			return data.Deserialize<T>()!;
		}

	}
}
