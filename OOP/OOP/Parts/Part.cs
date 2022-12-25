using System.Reflection;
using System.Text;

namespace OOP.Parts
{
	public class Part
	{
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			var type = GetType().Name + ":";
			stringBuilder.AppendLine(type);
			var fields = GetType()
				.GetProperties(BindingFlags.Public |
							BindingFlags.NonPublic |
							BindingFlags.Instance);
			foreach (var field in fields)
			{
				var fieldInfo = $"{field.Name} : {field.GetValue(this)}";
				stringBuilder.AppendLine(fieldInfo);
			}
			return stringBuilder.ToString();
		}
	}
}
