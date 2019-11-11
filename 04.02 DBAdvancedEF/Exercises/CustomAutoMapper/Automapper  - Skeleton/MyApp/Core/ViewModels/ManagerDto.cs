
namespace MyApp.Core.ViewModels
{
    using System.Collections.Generic;

    public class ManagerDto
    {
        public ManagerDto()
        {
            this.ManagerTeamCollection = new List<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> ManagerTeamCollection { get; set; }
    }
}
