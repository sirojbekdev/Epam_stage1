using Collections.Entities;

public class ProgramHelpers
{
	public static readonly List<Vehicle> Vehicles = new() {
		new Bus() {
			Engine = new()
			{
				Power = 1900,
				SerialNumber = "W1566A",
				Type = "W",
				Volume = 4.5f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 6,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "automatic",
				Manufacturer = "Volvo",
				NumberOfGears = 10
			}
		},
		new Bus() {
			Engine = new()
			{
				Power = 1805f,
				SerialNumber = "W1566A",
				Type = "W",
				Volume = 3.8f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 6,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "manual",
				Manufacturer = "Volvo",
				NumberOfGears = 10
			}
		},
		new Bus() {
			Engine = new()
			{
				Power = 1750f,
				SerialNumber = "W1566A",
				Type = "W",
				Volume = 4.2f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 6,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "manual",
				Manufacturer = "Volvo",
				NumberOfGears = 10
			}
		},
		new Bus() {
			Engine = new()
			{
				Power = 1845,
				SerialNumber = "W1566A",
				Type = "W",
				Volume = 4.3f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 6,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "manual",
				Manufacturer = "Volvo",
				NumberOfGears = 10
			}
		},
		new Truck()
		{
			Engine = new()
			{
				Power = 1900f,
				SerialNumber = "W1566A",
				Type = "V",
				Volume = 3.5f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 8,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "manual",
				Manufacturer = "Man",
				NumberOfGears = 20
			}
		},
		new Truck()
		{
			Engine = new()
			{
				Power = 2849f,
				SerialNumber = "W1566A",
				Type = "V",
				Volume = 5.5f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 8,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "manual",
				Manufacturer = "Man",
				NumberOfGears = 20
			}
		},
		new Scooter()
		{
			Engine = new()
			{
				Power = 105f,
				SerialNumber = "W1566A",
				Type = "W",
				Volume = 0.5f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 2,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "manual",
				Manufacturer = "Honda",
				NumberOfGears = 5
			},
		},
		new Scooter()
		{
			Engine = new()
			{
				Power = 250f,
				SerialNumber = "W1566A",
				Type = "W",
				Volume = 0.6f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 2,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "manual",
				Manufacturer = "Honda",
				NumberOfGears = 5
			},
		},
		new PassengerCar()
		{
			Engine = new()
			{
				Power = 350f,
				SerialNumber = "W1566A",
				Type = "W",
				Volume = 1.8f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 4,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "manumatic",
				Manufacturer = "BMW",
				NumberOfGears = 10
			},
		},
		new PassengerCar()
		{
			Engine = new()
			{
				Power = 256f,
				SerialNumber = "W1566A",
				Type = "W",
				Volume = 1.4f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 4,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "automatic",
				Manufacturer = "BMW",
				NumberOfGears = 10
			},
		},
		new PassengerCar()
		{
			Engine = new()
			{
				Power = 256f,
				SerialNumber = "W1566A",
				Type = "W",
				Volume = 1.4f
			},
			Chassis = new()
			{
				Number = 426,
				NumberOFWheels = 4,
				PermissibleLoad = 400
			},
			Transmission = new()
			{
				Type = "manual",
				Manufacturer = "BMW",
				NumberOfGears = 10
			},
		}
	};
}