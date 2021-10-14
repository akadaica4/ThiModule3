using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cakes_Management.Models.Cake
{
    public class CreateCake
    {
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
        public int CategoryId { get; set; }
    }
}
