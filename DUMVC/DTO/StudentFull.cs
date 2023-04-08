using DUMVC.Models;

namespace DUMVC.DTO
{
    public class StudentFull
    {
        public Student student { get; set; }
        public List<Hobby> hobby { get; set; }
    }
}
