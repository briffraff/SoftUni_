using System;
using System.Collections.Generic;

namespace trainingFile
{
    class trainingFile
    {
        static void Main(string[] args)
        {
            int countUsers = int.Parse(Console.ReadLine());

            Dictionary<string,string> users = new Dictionary<string, string>();

            for (int i = 0; i < countUsers; i++)
            {
                string inputUser = Console.ReadLine();

                users[inputUser] = "";
            }

            foreach (var user in users)
            {
                Console.WriteLine(user.Key);
            }
        }
    }
}
