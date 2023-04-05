using DU.Model;
using Microsoft.AspNetCore.Mvc;

namespace DU.Repository
{
    public interface iStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentById(int Id);
        Task<Student> AddStudent(Student student);
        Task<Student> EditStudent(Student student);
        Task<Student> DeleteStudent(int Id);
    }
}
