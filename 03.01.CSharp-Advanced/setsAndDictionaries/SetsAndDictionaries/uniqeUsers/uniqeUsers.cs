using System;
using System.Collections.Generic;

namespace uniqeUsers
{
    class uniqeUsers
    {
        static void Main(string[] args)
        {
            int countUsers = int.Parse(Console.ReadLine());

            Dictionary<string, string> users = new Dictionary<string, string>();

            for (int i = 0; i < countUsers; i++)
            {
                string inputUser = Console.ReadLine();

                if (users.ContainsKey(inputUser) == false)
                {
                    users.Add(inputUser, "");
                }

                users[inputUser] = "";
                //users[inputUser] += "a";
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}");
            }
        }
    }
}
