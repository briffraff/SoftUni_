using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        //format "ID: {employeeId} - {firstName} {lastName} -  ${salary:f2}"

        private readonly MyAppContext context;

        public EmployeeInfoCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            var employee = this.context.Employees.Find(employeeId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID: {employeeId} - {employee.FirstName} {employee.LastName} -  ${employee.Salary:f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
