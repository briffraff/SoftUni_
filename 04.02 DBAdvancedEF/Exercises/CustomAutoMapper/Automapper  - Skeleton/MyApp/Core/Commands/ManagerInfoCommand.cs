using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using MyApp.Models;
using System.Linq;
using System.Text;

namespace MyApp.Core.Commands
{
    public class ManagerInfoCommand : ICommand
    {

        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public ManagerInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            int managerId = int.Parse(inputArgs[0]);

            Employee manager = this.context.Employees
                .Include(m => m.ManagerTeamCollection)
                .FirstOrDefault(x => x.Id == managerId);

            var managerDto = this.mapper.CreateMappedObject<ManagerDto>(manager);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.ManagerTeamCollection.Count}");

            foreach (var employee in managerDto.ManagerTeamCollection)
            {
                string employeeFullName = employee.FirstName + " " + employee.LastName;
                var employeeSalary = employee.Salary;

                sb.AppendLine($"- {employeeFullName} - ${employeeSalary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
