using DU.DTO;
using DU.Model;
using Microsoft.AspNetCore.Mvc;

namespace DU.Repository
{
    public interface iStudentRepository
    {
        Task<List<StudentFull>> GetStudents();
        Task<StudentFull> GetStudentById(int Id);
        Task<Student> AddStudent(Student student);
        Task<Student> EditStudent(Student student);
        Task<Student> DeleteStudent(int Id);
        StudentHobby addHobbies(int hobbies, int id);
        int DeleteHobbies(int id);
    }
}
