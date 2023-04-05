using System.ComponentModel.DataAnnotations;

namespace DU.Model
{
    public class Course
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
