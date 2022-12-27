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
			var overallHoverTime = timeSpan.TotalMinutes / 10f;
			var overallTime = timeSpan.TotalMinutes + (int)overallHoverTime;
			TimeSpan newTime = TimeSpan.FromMinutes(overallTime);
			return newTime.ToString();
		}
	}
}
