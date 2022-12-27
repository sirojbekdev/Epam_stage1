using Interfaces.Interfaces;

namespace Interfaces.Entities
{
	public class Bird : BaseModel, IFlyable
	{
		public readonly double Speed;

		public Bird()
		{
			Random random= new();
			Speed = random.Next(1, 20); // set random speed in km/h
		}

		public void FlyTo(Coordinate newPoint)
		{
			CurrentPosition = newPoint;
		}

		public string GetFlyTime(Coordinate newPoint)
		{
			var time = GetDistance(CurrentPosition, newPoint) / Speed;
			TimeSpan timeSpan= TimeSpan.FromHours(time); // treats time as hours and formats it
			return timeSpan.ToString();
		}
	}
}
