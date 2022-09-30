using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine("----------Sum of numbers----------");
            int sum = numbers.Sum();
            Console.WriteLine(sum);

            //TODO: Print the Average of numbers
            Console.WriteLine("----------Average of numbers----------");
            var average = sum / numbers.Length;
            Console.WriteLine(average);

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("----------List lowest to highest----------");
            numbers.OrderBy(x => x)
                   .ToList()
                   .ForEach(x => Console.WriteLine(x));

            //TODO: Order numbers in decsending order and print to the console

            Console.WriteLine("----------List of highest to lowest----------");
            numbers.OrderByDescending(x => x)
                   .ToList()
                   .ForEach(x => Console.WriteLine(x));


            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("----------All numbers greater than 6----------");
            numbers.Where(x => x > 6)
                   .ToList()
                   .ForEach(x => Console.WriteLine(x));

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("----------Random 4 numbers ascending----------");

            var rng = new Random();
            var number = Enumerable.Range(rng.Next(0, 10), 4);

            foreach (var num in number)
            {
                Console.WriteLine(num);
            }


            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("----------descending order [4] = age----------");
            numbers[4] = 13;
            numbers.OrderByDescending(x => x)
                   .ToList()
                   .ForEach(x => Console.WriteLine(x));

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.
            Console.WriteLine("----------employees  names that start with s or c ascending----------");
            var filtered = employees.Where(person => person.FirstName.ToLower().StartsWith("c") || person.FirstName.ToLower().StartsWith("s"))
                                    .OrderBy(person => person.FirstName);
            foreach (var name in filtered)
            {
                Console.WriteLine(name.FullName);
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            Console.WriteLine("----------employees age over 26----------");
            var ageOver26 = employees.Where(person => person.Age > 26)
                                    .OrderBy(person => person.Age)
                                    .ThenBy(person => person.FirstName);
            foreach (var age in ageOver26)
            {
                Console.Write(age.FullName + " ");
                Console.WriteLine(age.Age);
            }

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35

            Console.WriteLine("----------average of employees with age > 35 and experience <= 10 work experience----------");
            var yrsOfExp = employees.Where(person => person.Age > 35 && person.YearsOfExperience <= 10);
            var avr = employees.Average(person => person.YearsOfExperience);
            Console.WriteLine(average);
            var SumOfAge = employees.Sum(person => person.Age);
            Console.WriteLine("----------sum of employees with age > 35 and experience <= 10 age----------");
            Console.WriteLine(SumOfAge);






            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("---------- list of employees with new employee at bottom ----------");
            employees = employees.Append(new Employee("John", "Cena", 45, 7)).ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FullName);
            }


            

            
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}