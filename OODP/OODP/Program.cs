using OODP.Commands;

Receiver receiver = Receiver.Instance;

Command addCar = new AddCarCommand(receiver);
Command avaragePrice = new AvaragePriceCommand(receiver);
Command avaragePriceType = new AvaragePriceTypeCommand(receiver);
Command countAll = new CountAllCommand(receiver);
Command countTypes = new CountTypesCommand(receiver);
Command exit = new ExitCommand(receiver);

Invoker invoker = new(addCar, avaragePrice, avaragePriceType, countAll, countTypes, exit);


void Run()
{
    Console.WriteLine("Menu" +
        "\n1.Add a car" +
        "\n2.Count the number of car brands" +
        "\n3.Count total number of cars" +
        "\n4.Average price, cost of the car" +
        "\n5.The average cost of cars for each brand");
    var command = Convert.ToInt32(Console.ReadLine());
    switch (command)
    {
        case 1:
            invoker.AddCar();
            Run();
            break;
        case 2:
            invoker.CountTypes();
            Run();
            break;
        case 3:
            invoker.CountAll();
            Run();
            break;
        case 4:
            invoker.AvaragePrice();
            Run();
            break;
        case 5:
            invoker.AvaragePriceType();
            Run();
            break;
        default: 
            Console.WriteLine("Wrong input");
            break;
    }
}

Run();