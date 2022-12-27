using System.Reflection;
using System.Text;

namespace OOP.Parts
{
	public class Part
	{
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			var type = GetType().Name + ":"; // takes current class name of object 
			stringBuilder.AppendLine(type);

			var fields = GetType()
				.GetProperties(BindingFlags.Public |
							BindingFlags.NonPublic |
							BindingFlags.Instance); // get all property as a collection

			foreach (var field in fields)
			{
				var fieldInfo = $"{field.Name} : {field.GetValue(this)}"; // takes every property name and its value
				stringBuilder.AppendLine(fieldInfo);
			}

			return stringBuilder.ToString();
		}
	}
}
