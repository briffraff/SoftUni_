using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            this.CategoryProducts = new List<CategoryProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal),"0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public int SellerId { get; set; }
        public User Seller { get; set; }

        public int? BuyerId { get; set; }
        public User Buyer { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}