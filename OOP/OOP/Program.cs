using System.Text;

namespace OOP
{
	public class Program
	{
		static void Main(string[] args)
		{
			StringBuilder stringBuilder= new StringBuilder();

			foreach (var vehicle in ProgramHelpers.Vehicles)
			{
				stringBuilder.AppendLine(vehicle.GetFullInformation());
			}

			Console.WriteLine(stringBuilder.ToString());
			Console.ReadLine();
		}
	}
}