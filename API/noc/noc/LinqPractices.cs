using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noc
{
    public class LinqPractices
    {
        public static void Main4(string[] args)
        {
            string[] names = { "Alice", "Bob", "Anna", "Mike", "anamika", "ankita" };

            var namesStartsWithAIs = names.Where(n => n.StartsWith("A", StringComparison.CurrentCultureIgnoreCase)).ToList();

            foreach (var n in namesStartsWithAIs) { Console.WriteLine(n); }


            int[] nums = { 3, 4, 7, 8, 10 };

            var evenNums = nums.Where(n => n % 2 == 0).ToList().Sum();


            Console.WriteLine(evenNums);

            string[] words = { "hello", "world", "amazing", "C#", "developer" };
            var coubtWordsMoreThanFiveAlphabets = words.Where(n => n.Length > 5).ToList();
            foreach (var n in coubtWordsMoreThanFiveAlphabets) { Console.WriteLine(n); }


            int[] numbers = { 4, 2, 9, 1, 5 };
            var obdesc = numbers.OrderByDescending(n => n).ToList();
            foreach (var n in obdesc) { Console.WriteLine(n); }

            string[] los = { "hello", "world", "lambda" };
            var convertlosToUpperCase = los.Select(l => l.ToUpper()).ToList();
            foreach (var n in convertlosToUpperCase) { Console.WriteLine(n); }


            int[] gnFifty = { 10, 25, 51, 80, 32 };
            var FirstNumbersGreaterThanFifty = gnFifty.FirstOrDefault(g => g > 50);
            Console.WriteLine(FirstNumbersGreaterThanFifty);

            int[] numbersAll = { -5, 10, -3, 7, -2 };
            var removeNegNumber = numbersAll.Where(n => n > 0).ToList();
            foreach (var n in removeNegNumber) { Console.WriteLine(n); }

            string[] firstNames = { "John", "Jane", "Steve" };
            string[] lastNames = { "Doe", "Smith", "Jobs" };

            var fullNames = firstNames.Select((f, index) => $"{f} {lastNames[index]}").ToList();
            foreach (var n in fullNames) { Console.WriteLine(n); }

            List<Employee2> employee = new List<Employee2>()
            {
                new Employee2{ Name="Mrinmoy" , Salary=200000},
                new Employee2{ Name="test" , Salary=100000},
                new Employee2{ Name="Suchitra" , Salary=150000}
            };

            var secondHighestSalary = employee.OrderByDescending(e => e.Salary).Distinct().Skip(1).FirstOrDefault();
            Console.WriteLine(secondHighestSalary.Salary);





        }
    }

    class Employee2
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
