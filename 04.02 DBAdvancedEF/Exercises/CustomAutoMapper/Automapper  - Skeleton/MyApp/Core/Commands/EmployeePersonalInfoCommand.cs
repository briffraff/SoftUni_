using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using System.Text;

namespace MyApp.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeePersonalInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            var employee = this.context.Employees.Find(employeeId);

            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);
            var employeePersonalInfoDto = this.mapper.CreateMappedObject<EmployeePersonalInfoDto>(employee);

            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"ID: {employeeId} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:F2}");
            sb.AppendLine($"Birthday: {employeePersonalInfoDto.Birthday.Value.ToString("dd-MM-yyyy")}");
            sb.AppendLine($"Address: {employeePersonalInfoDto.Address}");

            return sb.ToString().TrimEnd();
        }
    }
}
