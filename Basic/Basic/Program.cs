namespace Basic
{
	public class Program
	{
		static char ReValue(int num)
		{
			if (num >= 0 && num <= 9)
			{
				return (char)(num + '0');
			}
			else
			{
				return (char)(num - 10 + 'A');
			}
		}

		static string Reverse(string input)
		{
			char[] a = input.ToCharArray();
			int r = a.Length - 1;
			for ( int l = 0; l < r; l++, r--)
			{
				char temp = a[l];
				a[l] = a[r];
				a[r] = temp;
			}
			return new string(a);
		}

		static string FromDecimal(int basse, int inputNum)
		{

			string result = "";

			while (inputNum > 0)
			{
				result += ReValue(inputNum % basse);

				inputNum /= basse;
			}

			result = Reverse(result);

			return result;
		}

		public static void Main()
		{
			Console.WriteLine("Enter decimal number");
			int dec = Convert.ToInt32( Console.ReadLine());

			Console.WriteLine("Enter new base number between 2 and 20");
			int newBase = Convert.ToInt32(Console.ReadLine());

			if (newBase < 2 || newBase > 20) // restart if new base not in range
			{
				Console.WriteLine("Wrong input for new base !!!");
				Main();
			}
			else // otherwise convert the number to new base then restart
			{
				Console.WriteLine(FromDecimal(newBase, dec));
				Main();
			}
		}
	}
}