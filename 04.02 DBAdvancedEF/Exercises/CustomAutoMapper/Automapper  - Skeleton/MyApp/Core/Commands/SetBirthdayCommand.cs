using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using System;
using System.Globalization;
using System.Linq;

namespace MyApp.Core.Commands
{
    public class SetBirthdayCommand : ICommand
    {

        private readonly MyAppContext context;

        public SetBirthdayCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] inputArgs)
        {

            int employeeId = int.Parse(inputArgs[0]);
            var employee = this.context.Employees.Find(employeeId);

            string[] dateSplit = inputArgs.Skip(1).ToArray();
            var concatResults = string.Join("", dateSplit);
            string[] dates = concatResults.Split("-/.,_=".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).ToArray();
            string datesConcat = "";

            foreach (var s in dates)
            {
                datesConcat += s;
            }

            int day = int.Parse(datesConcat.Substring(0,2));
            int month = int.Parse(datesConcat.Substring(2,2));
            int year = int.Parse(datesConcat.Substring(4,4));
            
            string datePattern = "dd-MM-yyyy";
            var birthday = new DateTime(year,month,day).ToString(datePattern);

            DateTime parsedDate;

            string result = "";
            
            if (DateTime.TryParseExact(birthday, datePattern, null, DateTimeStyles.None, out parsedDate))
            {
                employee.Birthday = DateTime.Parse(parsedDate.ToShortDateString());
                result = "Birthday set successfully!";
                this.context.SaveChanges();
            }
            else
            {
                result = "Birthday did not set!";
            }

            return result;
        }
    }
}
