namespace Palindrome
{

    public static class Program
    {
        public static void Main()
        {
            var dateStr = ReadDate();

            if (!DateTime.TryParse(dateStr, out var dateResult))
            {
                Console.WriteLine("Неверный формат даты");
                Console.WriteLine("===========================================================");
                Console.WriteLine("Нажмите любую клавишу, чтобы выйти.");
                Console.Read();
                return;
            }

            var yearsStr = ReadYears();
            
            if (!Int32.TryParse(yearsStr, out var yearsResult))
            {
                Console.WriteLine("Неверный формат кол-во лет");
                Console.WriteLine("===========================================================");
                Console.WriteLine("Нажмите любую клавишу, чтобы выйти.");
                Console.Read();
                return;
            }

            var result = GetDates(dateResult, yearsResult);

            foreach (var r in result)
            {
                Console.WriteLine($"{r.Key} - {r.Value.ToString("dd/MM/yyyy")}");
            }

            Console.ReadKey();
        }

        private static string ReadDate()
        {
            Console.WriteLine("Введите дату в формате dd/MM/yyyy ,");
            Console.WriteLine("где: dd текущий день, MM месяц в числовом формате, yyyy год");
            Console.WriteLine("===========================================================");
            return Console.ReadLine();
        }

        private static string ReadYears()
        {
            Console.WriteLine("Введите кол-во лет.");
            Console.WriteLine("===========================================================");
            return Console.ReadLine();
        }

        public static DateTime[] GetDatesArray(DateTime date, int yCount)
        {
            return GetDates(date, yCount).Select(s => s.Value).ToArray();
        }
        public static Dictionary<string, DateTime> GetDates(DateTime date, int yCount, string format = "ddMMyyyy")
        {
            int yearCap = date.Year + yCount;

            Dictionary<string, DateTime> result = new Dictionary<string, DateTime>();

            while (date.Year < yearCap)
            {
                var key = date.ToString(format);
                if (IsPalindrome(key) && result.ContainsKey(key) == false)
                {
                    result.Add(date.ToString(key), date);
                }


                date = date.AddDays(1);
            }

            return result;
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