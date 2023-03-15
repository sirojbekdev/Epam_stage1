using Exceptions;
using Exceptions.Entities;

void Start()
{
    Console.WriteLine("\n1.InitializationException " +
        "\n2.AddException " +
        "\n3.GetAutoByParameterException" +
        "\n4.UpdateAutoException" +
        "\n5.RemoveAutoException");
    var key = Convert.ToInt32(Console.ReadLine());
    if (key == 1)
    {
        try
        {
            var bus = new Bus(-10)
            {
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
            };

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Start();
        }
    }
    else if (key == 2)
    {
        try
        {
            var bus = new Bus(101)
            {
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
            };

            ProgramHelpers.AddVehicle(bus);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Start();
        }
    }
    else if (key == 3)
    {
        try
        {
            var parameter = "Color";
            var value = "red";
            var vehicle = ProgramHelpers.GetAutoByParameterException(parameter, value);
            Console.WriteLine(vehicle);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Start();
        }
    }
    else if (key == 4)
    {
        try
        {
            var bus = new Bus(201)
            {
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
            };

            ProgramHelpers.UpdateVehicle(bus);
            Console.WriteLine($"{bus.Id} was updated");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Start();
        }
    }
    else if (key == 5)
    {
        try
        {
            var id = 202;
            ProgramHelpers.RomoveVehicle(id);
            Console.WriteLine($"Vehicle with Id {id} was deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Start();
        }
    }
    else
    {
        Console.WriteLine("Wrong input");
    }
}
Start();