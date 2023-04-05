using Microsoft.EntityFrameworkCore;

namespace DU.Model
{
    public class ADBContext : DbContext
    {
        public ADBContext(DbContextOptions<ADBContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Hobby> Hobbys { get; set;}
        public DbSet<StudentHobby> StudentHobbys { get;set; }
    }
}
