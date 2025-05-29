using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noc
{
    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
    }
    class Program2
    {
        public static void Main2(string[] args)
        {

            int[] numbers = { 1, 2, 3, 4, 2, 5, 6, 3, 7, 8, 5 };

            var dup = numbers.GroupBy(y => y).Where(y => y.Count() > 1).Select(y => y.Key).ToList();
            foreach (var i in dup)
            {
                Console.WriteLine(i);

            }

            List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "A", Salary = 5000 },
            new Employee { Name = "B", Salary = 7000 },
            new Employee { Name = "C", Salary = 6000 },
            new Employee { Name = "D", Salary = 7000 }
        };

            var secondHighestSalary = employees.Select(y => y.Salary)  // Select all salaries
                                    .Distinct()             // Remove duplicates
                                    .OrderByDescending(y => y) // Sort in descending order
                                    .Skip(1)               // Skip the highest salary
                                    .FirstOrDefault();     // Get the second highest salary

            Console.WriteLine(secondHighestSalary);




        }


    }


}

