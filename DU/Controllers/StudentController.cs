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
            List<StudentFull> student= await this._studentRepository.GetStudents();
            return Ok(student);
        }
        [Route("getStudentById/{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            StudentFull stu = await this._studentRepository.GetStudentById(Id);
            var studentDTO = _mapper.Map<StudentDTO>(stu.student);
            var stud = new AddStudentDTO();
            stud.studentDTO = studentDTO;
            List<int> id = new List<int>();
            foreach(var i in stu.hobby)
            {
                id.Add(i.Id);
            }
            stud.hobby= id;
            return Ok(stud);
        }
        [Route("getStudentId/{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetStudentId(int Id)
        {
            StudentFull stu = await this._studentRepository.GetStudentById(Id);
            var student = stu.student;
            List<int> id = new List<int>();
            return Ok(student);
        }
        private Student studentmap(StudentDTO studentDTO)
        {
            Student stu = new Student();
            //stu.Id = studentDTO.Id;
            stu.FirstName= studentDTO.FirstName;
            stu.LastName= studentDTO.LastName;
            stu.DOB = studentDTO.DOB;
            stu.Course_Id = studentDTO.Course_Id;
            return stu;
        }
        [Route("AddStudent")]
        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentDTO addstudentdto)
        {
            var studentdto = addstudentdto.studentDTO;
            var student = _mapper.Map<Student>(studentdto);
            Student std = await this._studentRepository.AddStudent(student);
            var hobbies = addstudentdto.hobby;
            var Hob = AddHobbies(hobbies,student.Id);

            return Ok(std);
        }
        private int AddHobbies(List<int> hobbies, int Id)
        {
            int count = 0;
            for (int i = 0; i < hobbies.Count; i++)
            {
                var hob = this._studentRepository.addHobbies(hobbies[i], Id);
                count++;
            }
            return count;
        }
        [Route("DeleteStudent/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var del = this._studentRepository.DeleteHobbies(Id);
            Student std = await this._studentRepository.DeleteStudent(Id);
            return Ok(std);
        }
        [Route("EditStudent")]
        [HttpPut]
        public async Task<IActionResult> EditStudent(AddStudentDTO addstudentdto)
        {
            var studentdto = addstudentdto.studentDTO;
            var student = _mapper.Map<Student>(studentdto);
            Student std = await this._studentRepository.EditStudent(student);
            var hobbies =addstudentdto.hobby;
            var del = this._studentRepository.DeleteHobbies(std.Id);
            var hob = AddHobbies(hobbies, std.Id);
            return Ok(std);
        }
        
    }
}
