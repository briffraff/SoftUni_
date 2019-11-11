using System;
using System.Linq;
using System.Text;
using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Core.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public ListEmployeesOlderThanCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {

            var inputAge = int.Parse(inputArgs[0]);

            var employees = this.context.Employees
                .Select(s => new
                {
                    Age = DateTime.Now.Year - s.Birthday.Value.Year,
                    Salary = s.Salary,
                    FullName = s.FirstName + " " + s.LastName,
                    Manager = s.Manager.LastName

                })
                .Where(e => e.Age > inputAge)
                .OrderByDescending(e => e.Salary)
                .ToList();

            //var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employees);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                var manager = employee.Manager;

                if (manager != null)
                {
                    sb.AppendLine($"{employee.FullName} - ${employee.Salary} - Manager: {manager} ");
                }
                else
                {
                    sb.AppendLine($"{employee.FullName} - ${employee.Salary} - Manager: [no manager] ");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
