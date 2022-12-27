using Interfaces.Interfaces;

namespace Interfaces.Entities
{
	public class Airplane : BaseModel, IFlyable
	{
		private readonly float _initialSpeed = 210f;
		private readonly float _maxSpeed = 500f; // Maximum speed the airplane can reach

		public void FlyTo(Coordinate newPoint)
		{
			CurrentPosition = newPoint;
		}

		public string GetFlyTime(Coordinate newPoint)
		{
			var currentSpeed = _initialSpeed;
			var distance = GetDistance(CurrentPosition, newPoint);
			var timePassed = 0f;

			/* 
				if plane reaches maximum speed or distance is less than 10 km
				it stops adding speed and rest of the distance calculated with current speed
			*/
			while (currentSpeed < _maxSpeed || distance <= 10f)
			{
				timePassed += (10f / currentSpeed);
				distance -= 10f;
				currentSpeed += 10f;
			}
			var time = distance / currentSpeed;
			time += timePassed;
			TimeSpan timeSpan = TimeSpan.FromHours(time);
			return timeSpan.ToString();
		}
	}
}
