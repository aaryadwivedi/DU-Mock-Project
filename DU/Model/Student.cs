using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DU.Model
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required] 
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public int Course_Id { get; set;}
        [ForeignKey("Course_Id")]
        public Course course { get; set; }
    }
}
