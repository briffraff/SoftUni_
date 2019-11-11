using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003.Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double id = double.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Name: {0}",name);
            Console.WriteLine("Age: {0}" ,age);
            Console.WriteLine("Employee ID: {0:00000000}" ,id);
            Console.WriteLine("Salary: {0:f2}" ,salary);
            Console.WriteLine();


        }
    }
}
