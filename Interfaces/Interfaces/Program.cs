using Interfaces.Entities;

namespace Interfaces
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Coordinate point = new()
			{
				X= 150f,
				Y= 510f,
				Z= 0,
			};

			// Bird
			Bird bird = new();
			string birdTime = bird.GetFlyTime(point);
			Console.WriteLine("Bird speed: " + bird.Speed);
			Console.WriteLine(bird.GetDistance(bird.CurrentPosition, point));
			Console.WriteLine("Bird time: " + birdTime +"\n");

			//Drone
			Drone drone = new();
			string droneTime = drone.GetFlyTime(point);
			Console.WriteLine(drone.GetDistance(drone.CurrentPosition, point));
			Console.WriteLine("drone time: " + droneTime + "\n");

			// Airplane
			Airplane airplane = new();
			Console.WriteLine(airplane.GetDistance(airplane.CurrentPosition, point));
			Console.WriteLine("Airplane time: " + airplane.GetFlyTime(point));
		}
	}
}