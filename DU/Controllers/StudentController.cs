using AutoMapper;
using DU.DTO;
using DU.Model;
using DU.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private iStudentRepository _studentRepository;
        private IMapper _mapper;
        public StudentController(iStudentRepository _studentRepository, IMapper _mapper)
        {
           this._studentRepository = _studentRepository;
           this._mapper = _mapper;
        }
        [Route("getStudents")]
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            List<Student> student= await this._studentRepository.GetStudents();
            return Ok(student);
        }
        [Route("getStudentById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            Student student = await this._studentRepository.GetStudentById(Id);
            return Ok(student);
        }
        [Route("AddStudent")]
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDTO studentdto)
        {
            var student = _mapper.Map<Student>(studentdto);
            Student std = await this._studentRepository.AddStudent(student);
            return Ok(std);
        }
        [Route("DeleteStudent/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            Student std = await this._studentRepository.DeleteStudent(Id);
            return Ok(std);
        }
        [Route("EditStudent")]
        [HttpPut]
        public async Task<IActionResult> EditStudent(StudentDTO studentdto)
        {
            var student = _mapper.Map<Student>(studentdto);
            Student std = await this._studentRepository.EditStudent(student);
            return Ok(std);
        }
    }
}
