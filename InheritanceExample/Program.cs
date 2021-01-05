using InheritanceExample.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace InheritanceExample
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            Console.WriteLine("Enter the number of employees: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <=n; i++)
            {
                Console.WriteLine($"Employee {i} data:");
                Console.WriteLine($"Outsourced (y/n)?");
                char outsourced = char.Parse(Console.ReadLine().ToUpper());
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.WriteLine("Value per hours: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if(outsourced == 'Y')
                {
                    Console.WriteLine("Additional charge: ");
                    double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    employees.Add(new OutsourcedEmployee(name,hours,valuePerHour,additionalCharge));
                }
                else
                {
                    employees.Add(new Employee(name, hours, valuePerHour));
                }

                

            }
            Console.WriteLine("");
            Console.WriteLine("Payments: ");
            foreach (Employee e in employees)
            {
                Console.WriteLine(e.Name + " - $ " + e.Payment().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}