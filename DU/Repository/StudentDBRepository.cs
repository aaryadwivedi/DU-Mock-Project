using DU.Model;
using Microsoft.EntityFrameworkCore;

namespace DU.Repository
{
    public class StudentDBRepository : iStudentRepository
    {
        private readonly ADBContext context;
        public StudentDBRepository(ADBContext context) { 
            this.context = context;
        }
        public async Task<List<Student>> GetStudents()
        {
            return await this.context.Students.Include(s=>s.course).ToListAsync();
        }
        public async Task<Student> GetStudentById(int Id)
        {
            return await this.context.Students.Include(s => s.course).SingleOrDefaultAsync(s=>s.Id==Id);
        }

        public async Task<Student> AddStudent(Student student)
        {
            student.DOB=student.DOB.Replace("-", "/");
            await this.context.Students.AddAsync(student);
            await this.context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> EditStudent(Student student)
        {
            student.DOB = student.DOB.Replace("-", "/");
            this.context.Students.Update(student);
            await this.context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudent(int Id)
        {
            Student student= await this.context.Students.SingleOrDefaultAsync(s=>s.Id==Id);
            if (student!=null)
            {
                this.context.Students.Remove(student);
                await this.context.SaveChangesAsync();
            }
            return student;
        }
    }
}
