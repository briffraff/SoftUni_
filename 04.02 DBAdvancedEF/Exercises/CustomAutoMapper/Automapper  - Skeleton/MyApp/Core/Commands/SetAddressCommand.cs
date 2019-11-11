using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using System.Linq;

namespace MyApp.Core.Commands
{
    public class SetAddressCommand : ICommand
    {

        private readonly MyAppContext context;

        public SetAddressCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            var employee = this.context.Employees.Find(employeeId);

            string[] addressSplit = inputArgs.Skip(1).ToArray();

            string address = string.Join(" ", addressSplit);
            string result = "";

            if (address.Length != 0)
            {
                employee.Address = address;
                this.context.SaveChanges();
                result = "Address added successfully!";
            }
            else
            {
                result = "Address too short!";
            }

            return result;
        }
    }
}
