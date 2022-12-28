using Collections.Entities;
using System.Xml.Serialization;

namespace Collections
{
	public class Program
	{
		static void Main(string[] args)
		{
			string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

			// All information about all vehicles an engine capacity of which is more than 1.5 liters
			CarPark parkofAll = new()
			{
				Vehicles = ProgramHelpers.Vehicles.Where(v => v.Engine.Volume > 1.5f).ToList(),
			};
			string filepath1 = projectDirectory + @"\Files\AllVehicles.xml";
			ConvertListOfVehiclesToXml(parkofAll, filepath1);

			// Engine type, serial number and power rating for all buses and trucks
			CarPark parkofBusAndTrucks = new()
			{
				Vehicles = ProgramHelpers.Vehicles.Where(x => x is Bus || x is Truck)
					.OrderBy(v => v.Engine.Type)
					.ThenBy(x => x.Engine.SerialNumber)
					.ThenBy(x => x.Engine.Power).ToList(),
			};
			string filepath2 = projectDirectory + @"\Files\SortedByEngine.xml";
			ConvertListOfVehiclesToXml(parkofBusAndTrucks, filepath2);

			// All information about all vehicles, grouped by transmission type.
			var car = ProgramHelpers.Vehicles.GroupBy(v => v.Transmission.Type,
				(selector, group) => new ParkList()
				{
					GroupType = selector,
					Vehicles = group.ToList(),
				})
				.ToList();


			string filepath3 = projectDirectory + @"\Files\GroupedByTrasmission.xml";

			using (TextWriter streamWriter = new StreamWriter(filepath3))
			{
				XmlSerializer serializer = new(typeof(List<ParkList>));
				serializer.Serialize(streamWriter, car);
			}
		}

		public static void ConvertListOfVehiclesToXml(CarPark listOfVehicles, string filepath)
		{
			using (TextWriter streamWriter = new StreamWriter(filepath))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(CarPark));
				serializer.Serialize(streamWriter, listOfVehicles);
			}
		}
	}
}