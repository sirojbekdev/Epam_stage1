namespace Interfaces.Entities
{
	public abstract class BaseModel
	{
		public Coordinate CurrentPosition { get; set; }

		protected BaseModel()
		{
			CurrentPosition = new()
			{
				X = 0,
				Y = 0,
				Z = 0
			};
	}
		public double GetDistance(Coordinate origin, Coordinate newPoint)
		{
			double distance = Math.Pow((Math.Pow(newPoint.X - origin.X, 2) +
						 Math.Pow(newPoint.Y - origin.Y, 2) +
						 Math.Pow(newPoint.Z - origin.Z, 2) *
								   1.0), 0.5);

			return distance;
		}
	}
}
