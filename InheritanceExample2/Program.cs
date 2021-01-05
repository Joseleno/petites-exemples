using InheritanceExample2.Entities;
using InheritanceExample2.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace InheritanceExample2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            Console.WriteLine("Enter the number of shapes!");
            int x = int.Parse(Console.ReadLine());
            for (int i = 1; i <= x; i++)
            {
                Console.WriteLine($"Shape #{i} data: ");
                Console.Write("Rectangle or Circle (r/c)? ");
                char c = char.Parse(Console.ReadLine());
                Console.Write("Black, Blue or Red (1/2/3)? ");
                Color color = Enum.Parse<Color>(Console.ReadLine());
                if (c == 'r')
                {
                    Console.Write("Width: ");
                    double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Height: ");
                    double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    shapes.Add(new Rectangle(width, height, color));
                }
                else
                {
                    Console.Write("Radius: ");
                    double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    shapes.Add(new Circle(radius, color));
                }
            }

            Console.WriteLine("");
            Console.Write("SHAPE AREAS: ");

            foreach (Shape s in shapes)
            {
                Console.WriteLine(s.Area().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}