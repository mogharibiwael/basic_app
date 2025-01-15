using System.ComponentModel.DataAnnotations;

namespace CQRS_Lib.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } = string.Empty;

        [Required]
        public double Price { get; set; } = 0.0;



    }
}

