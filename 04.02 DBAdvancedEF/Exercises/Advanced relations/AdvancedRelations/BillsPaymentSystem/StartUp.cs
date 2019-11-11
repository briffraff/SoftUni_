
using BillsPaymentSystem.App.Core;
using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;

namespace BillsPaymentSystem.App
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //using (BillsPaymentSystemContext context = new  BillsPaymentSystemContext())
            //{
            //    DBInitializer.Seed(context);
            //}

            ICommandInterpreteur commandInterpreteur = new CommandInterpreteur();
            Engine engine = new Engine(commandInterpreteur);
            engine.Run();

        }
    }
}
