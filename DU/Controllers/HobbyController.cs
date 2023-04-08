using DU.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : Controller
    {
        private iHobbyRepository _hobbyRepository;
        public HobbyController(iHobbyRepository hobbyRepository)
        {
            _hobbyRepository = hobbyRepository;
        }

        [Route("getHobbies")]
        [HttpGet]
        public async Task<IActionResult> getHobbies()
        {
            var hobbies = await this._hobbyRepository.getHobbies();
            return Ok(hobbies);
        }
        [Route("hobbybyid/{Id}")]
        [HttpGet]
        public async Task<IActionResult> hobbyById(int Id)
        {
            var hobby = await this._hobbyRepository.getHobbiesById(Id);
            return Ok(hobby);
        }
    }
}
