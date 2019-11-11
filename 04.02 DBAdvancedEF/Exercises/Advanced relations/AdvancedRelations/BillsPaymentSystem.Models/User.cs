using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace BillsPaymentSystem.Models
{
    public class User
    {
        public User()
        {
            this.PaymentMethods = new HashSet<PaymentMethod>();
        }
        public int UserId { get; set; }

        [Required]
        [MinLength(3),MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }

        [Required]
        [MinLength(3),MaxLength(25)]
        public string Password { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}
