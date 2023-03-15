using Exceptions.Entities;
using Exceptions.Exceptions;

namespace Exceptions
{
    public class ProgramHelpers
    {
        public static List<Vehicle> Vehicles = new() {
        new Bus() {
            Id = 101,
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
            Id = 102,
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
            Id = 103,
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
            Id = 104,
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
            Id = 105,
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
            Id = 106,
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
            Id = 107,
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
            Id = 108,
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
            Id = 109,
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
            Id = 110,
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
            Id = 111,
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

        public static List<string> Parameters = new() { "EngineType", "TrasmissionType" };

        public static void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Any(x => x.Id == vehicle.Id))
            {
                throw new AddException($"Vehicle with Id {vehicle.Id} already exists");
            }
            Vehicles.Add(vehicle);
        }

        public static Vehicle? GetAutoByParameterException(string parameter, string value)
        {
            if (!Parameters.Contains(parameter))
            {
                throw new GetAutoByParameterException($"Vehicles with parameter : {parameter} do not exists");
            }

            var vehicle = (parameter) switch
            {
                "EnginePower" => Vehicles.Find(x => x.Engine.Type == value),
                "TrasmissionType" => Vehicles.Find(x => x.Transmission.Type == value),
                _ => null
            };
            return vehicle;
        }

        public static void UpdateVehicle(Vehicle vehicle)
        {
            if (!Vehicles.Any(x => x.Id == vehicle.Id))
            {
                throw new UpdateAutoException($"Vehicle with Id {vehicle.Id} does not exists");
            }

            int index = Vehicles.FindIndex(s => s.Id == vehicle.Id);

            if (index != -1)
            {
                Vehicles[index] = vehicle;
            }
        }

        public static void RomoveVehicle(int id)
        {
            var vehicle = Vehicles.Find(x => x.Id == id)
                ?? throw new RemoveAutoException($"Vehicle with Id {id} does not exists");

            Vehicles.Remove(vehicle);
        }
    }
}