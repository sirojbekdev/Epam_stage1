using Interfaces.Interfaces;

namespace Interfaces.Entities
{
	public class Drone : BaseModel, IFlyable
	{
		private readonly float _speed = 50f;

		public void FlyTo(Coordinate newPoint)
		{
			CurrentPosition = newPoint;
		}

		public string GetFlyTime(Coordinate newPoint)
		{
			var time = GetDistance(CurrentPosition, newPoint) / _speed;
			TimeSpan timeSpan = TimeSpan.FromHours(time);
			var overallHoverTime = timeSpan.TotalMinutes / 10f; // takes time of hovering from every 10 min 
			var overallTime = timeSpan.TotalMinutes + (int)overallHoverTime; // adds time spent on hovering
			TimeSpan newTime = TimeSpan.FromMinutes(overallTime); // treats time as hours and formats it
			return newTime.ToString();
		}
	}
}
