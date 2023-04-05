using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DU.Model
{
    public class StudentHobby
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int H_Id { get; set; }
        [ForeignKey("H_Id")]
        public Hobby hobby { get; set; }
        [Required]
        public int S_Id { get; set; }
        [ForeignKey("S_Id")]
        public Student student { get; set; }


    }
}
