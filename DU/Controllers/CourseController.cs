using DU.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private iCourseRepository _courseRepository;
        public CourseController(iCourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        [Route("getcourses")]
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await this._courseRepository.GetCourses();
            return Ok(courses);
        }
    }
}
