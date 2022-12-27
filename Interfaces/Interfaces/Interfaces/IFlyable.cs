using Interfaces.Entities;

namespace Interfaces.Interfaces
{
	public interface IFlyable
	{
		void FlyTo(Coordinate newPoint);
		string GetFlyTime(Coordinate newPoint);
	}
}
