using Collections.Parts;
using System.Text;
using System.Xml.Serialization;

namespace Collections.Entities
{
	[XmlInclude(typeof(PassengerCar)),
		XmlInclude(typeof(Bus)),
		XmlInclude(typeof(Truck)),
		XmlInclude(typeof(Scooter))]
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

			// append information of all properties
			stringBuilder.AppendLine(Engine.ToString());
			stringBuilder.AppendLine(Chassis.ToString());
			stringBuilder.AppendLine(Transmission.ToString());
			stringBuilder.AppendLine("--- ---");

			return stringBuilder.ToString();
		}
	}
}
