using OOP.Parts;
using System.Reflection;
using System.Text;

namespace OOP.Entities
{
	public class Vehicle
	{
		public Engine Engine { get; set; }
		public Chassis Chassis { get; set; }
		public Transmission Transmission { get; set; }

		public string GetFullInformation()
		{
			StringBuilder stringBuilder = new StringBuilder();
			var type = GetType().Name + ":";
			stringBuilder.AppendLine(type);
			stringBuilder.AppendLine(Engine.ToString());
			stringBuilder.AppendLine(Chassis.ToString());
			stringBuilder.AppendLine(Transmission.ToString());
			stringBuilder.AppendLine("--- ---");
			return stringBuilder.ToString();
		}
	}
}
