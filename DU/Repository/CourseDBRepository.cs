using DU.Model;
using Microsoft.EntityFrameworkCore;

namespace DU.Repository
{
    public class CourseDBRepository : iCourseRepository
    {
        private readonly ADBContext context;
        public CourseDBRepository(ADBContext context)
        {
            this.context = context;
        }
        public async Task<List<Course>> GetCourses()
        {
            var cours = await this.context.Courses.ToListAsync();
            return cours;

        }
    }
}
