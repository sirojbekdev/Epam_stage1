namespace OODP.Commands
{
    public class Receiver
    {
        private static Receiver _instance = new();
        private List<Car> _cars = new();

        private Receiver() { }

        public static Receiver Instance => _instance;

        public void AddCar()
        {
            Car car = new();
            Console.WriteLine("Enter car brand");
            car.Brand = Console.ReadLine();
            Console.WriteLine("Enter car model");
            car.Model = Console.ReadLine();
            Console.WriteLine("Enter car quantity");
            car.Quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter car cost");
            car.Cost = Convert.ToInt32(Console.ReadLine());
            _cars.Add(car);
        }

        public void CountTypes()
        {
            var types = _cars.DistinctBy(c=>c.Brand).Count();
            Console.WriteLine(types);
        }

        public void CountAll()
        {
            var total = _cars.Sum(c => c.Quantity);
            Console.WriteLine(total);
        }

        public void AvaragePrice()
        {
            var avarage = _cars.Average(c => c.Cost);
            Console.WriteLine(avarage);
        }

        public void AvaragePriceForType()
        {

            Console.WriteLine("Enter car type");
            var type = Console.ReadLine();
            var avarage = _cars.Where(c=>c.Brand == type).Average(c=>c.Cost);
            Console.WriteLine(avarage);
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
