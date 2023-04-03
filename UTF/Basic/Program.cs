using System.Text.RegularExpressions;

namespace Basic
{
    public class Program
    {
        public char ReValue(int num)
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

        public string Reverse(string input)
        {
            char[] a = input.ToCharArray();
            int r = a.Length - 1;
            for (int l = 0; l < r; l++, r--)
            {
                char temp = a[l];
                a[l] = a[r];
                a[r] = temp;
            }
            return new string(a);
        }

        public string FromDecimal(string inputString, string newBaseString)
        {
            var inputNum = Convert.ToInt32(inputString);
            var newBase = Convert.ToInt32(newBaseString);

            if (!Enumerable.Range(2, 20).Contains(newBase))
            {
                return "New Base should be between 2 and 20";
            }

            string result = "";

            while (inputNum > 0)
            {
                result += ReValue(inputNum % newBase);

                inputNum /= newBase;
            }

            result = Reverse(result);

            return result;
        }

        public int MaxNumberOfDigit(string input)
        {
            var pattern = @"(\d)\1+";
            var regExp = new Regex(pattern);
            var matches = regExp.Matches(input);

            var result = matches.Count > 0 ? matches.Max(x => x.Value.Length) : 0;

            return result;
        }


        public int MaxNumberOfLetter(string input)
        {
            var pattern = @"([a-zA-Z])\1+";
            var regExp = new Regex(pattern);
            var matches = regExp.Matches(input);

            var result = matches.Count > 0 ? matches.Max(x => x.Value.Length) : 0;

            return result;
        }

        public static void Main()
        {
            Program program = new();
            Console.WriteLine("Enter decimal number");

            var input = Console.ReadLine();

            Console.WriteLine("Enter new base number between 2 and 20");
            var newBase = Console.ReadLine();

            Console.WriteLine(program.FromDecimal(input, newBase));
            Main();

        }
    }
}