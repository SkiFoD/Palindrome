namespace Palindrome
{

    public class Program
    {
        public static void Main()
        {
            var result = GetDates(new DateTime(2020, 1, 1), 102);
        }

        public static DateTime[] GetDates(DateTime date, int yCount)
        {
            int yearCap = date.Year + yCount;

            List<DateTime> result = new List<DateTime>();

            // Для дебага
            //Dictionary<string, DateTime> dt = new Dictionary<string, DateTime>();

            while (date.Year < yearCap)
            {
                if (IsPalindrome(date.ToString("ddMMyyyy")))
                {
                    result.Add(date);
                    // Для дебага
                    //dt.Add(date.ToString("ddMMyyyy"), date);

                }

                date = date.AddDays(1);
            }

            return result.ToArray();
        }

        private static bool IsPalindrome(string s)
        {
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                if (s[i] != s[j]) return false;
                i++;
                j--;
            }
            return true;
        }
    }
}