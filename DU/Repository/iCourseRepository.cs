using DU.Model;

namespace DU.Repository
{
    public interface iCourseRepository
    {
        Task<List<Course>> GetCourses();
    }
}
