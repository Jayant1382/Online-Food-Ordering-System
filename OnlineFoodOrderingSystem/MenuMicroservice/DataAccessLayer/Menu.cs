using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrderingSystem.MenuMicroservice.DataAccessLayer
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
