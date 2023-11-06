using System.ComponentModel.DataAnnotations;

namespace Ostim.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surename is required.")]
        [MinLength(3)]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Position is required.")]
        [MinLength(3)]
        public string Position { get; set; }
        public string Image { get; set; }


    }
}
