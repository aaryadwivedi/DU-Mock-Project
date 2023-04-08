using DU.Model;

namespace DU.DTO
{
    public class StudentFull
    {
        public Student student { get; set; }
        public List<Hobby> hobby { get; set; }
    }
}
