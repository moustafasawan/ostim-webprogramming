using System.ComponentModel.DataAnnotations;

namespace Ostim.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Zipcode must be 5 digits")]
        public string Zipcode { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(60)]
        public string Country { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
