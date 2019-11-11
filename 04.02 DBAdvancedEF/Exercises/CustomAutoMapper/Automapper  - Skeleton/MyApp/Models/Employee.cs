
using System.Collections;
using System.Collections.Generic;

namespace MyApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public Employee()
        {
            this.ManagerTeamCollection = new List<Employee>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335M")]
        public decimal Salary { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> ManagerTeamCollection { get; set; }
    }
}
