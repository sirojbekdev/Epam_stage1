using OOP.Entities;

public static class ProgramHelpers
{
	public static List<Vehicle> Vehicles = new() {
		new Bus() {
			Engine = new()
			{
				Power = 4.5f,
				SerialNumber = "W1566A",
				Type = "W",
				Volume = 1900f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 6,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "New Type for bus",
				Manufacturer = "Volvo",
				NumberOfGears = 10
			}
		},
		new Truck()
		{
			Engine = new()
			{
				Power = 6.5f,
				SerialNumber = "W1566A",
				Type = "V",
				Volume = 2900f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 8,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "New Type for truck",
				Manufacturer = "Man",
				NumberOfGears = 20
			}
		},
		new Scooter()
		{
			Engine = new()
			{
				Power = 0.5f,
				SerialNumber = "W1566A",
				Type = "W",
				Volume = 500f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 2,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "New Type for scooter",
				Manufacturer = "Honda",
				NumberOfGears = 5
			},
		},
		new PassengerCar()
		{
			Engine = new()
			{
				Power = 1.8f,
				SerialNumber = "W1566A",
				Type = "W",
				Volume = 900f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 4,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "New Type for car",
				Manufacturer = "BMW",
				NumberOfGears = 10
			},
		}
	};
}