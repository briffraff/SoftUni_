using System;
using System.Linq;

namespace Mankind
{
    public class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                string[] inputSplit = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string studentFirstName = inputSplit[0];
                string studentSecondName = inputSplit[1];
                string facultyNumber = inputSplit[2];

                string[] workerSplit = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string workerFirstName = workerSplit[0];
                string workersecondName = workerSplit[1];
                decimal salary = decimal.Parse(workerSplit[2]);
                int workingHours = int.Parse(workerSplit[3]);

                Student student = new Student(studentFirstName, studentSecondName, facultyNumber);
                Worker worker = new Worker(workerFirstName, workersecondName, salary, workingHours);

                Console.WriteLine();
                Console.WriteLine(student + Environment.NewLine);
                Console.WriteLine(worker);
                Console.WriteLine();

            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
    }
}
