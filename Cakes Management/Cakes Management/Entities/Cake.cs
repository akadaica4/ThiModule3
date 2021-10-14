using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cakes_Management.Entities
{
    public class Cake
    {
        [Key]
        public int cakeId { get; set; }
        [Required]
        public string CakeName { get; set; }
        [Required]
        public string Ingredient { get; set; }
        [Required]
        public DateTime Expiry { get; set; }
        [Required]
        public DateTime DateOfManufacture { get; set; }
        [Required]
        public int Price { get; set; }
        public bool Status { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
