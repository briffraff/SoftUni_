using System;

namespace ActionPoint
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            Action<string[]> print = 
                n => Console.WriteLine(string.Join(Environment.NewLine,n));

            string[] inputNames = Console.ReadLine()
                .Split(new []{' '},StringSplitOptions.RemoveEmptyEntries);

            print(inputNames);
        }
    }
}
