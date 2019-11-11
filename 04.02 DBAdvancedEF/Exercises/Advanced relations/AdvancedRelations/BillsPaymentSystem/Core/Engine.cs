using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;

namespace BillsPaymentSystem.App.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreteur comanInterpreteur;

        public Engine(ICommandInterpreteur commandInterpreteur)
        {
            this.comanInterpreteur = comanInterpreteur;
        }

        public void Run()
        {
            while (true)
            {
                string[] inputParams = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
                {
                    string result = this.comanInterpreteur.Read(inputParams,context);
                    Console.WriteLine(result);

                }

            }
        }
    }
}
