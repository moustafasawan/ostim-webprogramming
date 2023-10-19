using System.ComponentModel.DataAnnotations;

namespace Ostim.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }


    }
}
