using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BillsPaymentSystem.App.Core.Commands.Contracts;
using BillsPaymentSystem.Data;

namespace BillsPaymentSystem.App.Core.Commands
{
    public class UserInfoCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public UserInfoCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);

            var user = this.context.Users.FirstOrDefault(x => x.UserId == userId);

            if (user == null)
            {
                throw new ArgumentException("User not found!");
            }

            return "";
        }
    }
}
