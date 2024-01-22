using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class StringMath
    {
        public static int Add(string numbers)
        {
            var delimiters = new List<string> { ",", "\n" };

            if (numbers.StartsWith("//"))
            {
                var sections = numbers.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                delimiters.Add(sections.FirstOrDefault().Replace("//", ""));
                numbers = sections.LastOrDefault();
            }

            var splitNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            int[] arrint = Array.ConvertAll(splitNumbers, s => int.Parse(s));
            var containsNeg = arrint.Any(n => n < 0);

            if (containsNeg == true)
            {
                throw new Exception("negative not allowed " + string.Join(',', arrint.Where(x => x < 0)));
            }

            var sum = 0;

            foreach (var n in splitNumbers)
            {
                if (int.Parse(n) < 1000)
                {
                    sum += int.Parse(n);
                }
                
            }

            return sum;
          



        }
    }
}
