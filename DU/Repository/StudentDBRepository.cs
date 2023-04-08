using DU.DTO;
using DU.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DU.Repository
{
    public class StudentDBRepository : iStudentRepository
    {
        private readonly ADBContext context;
        public StudentDBRepository(ADBContext context) { 
            this.context = context;
        }
        public async Task<List<StudentFull>> GetStudents()
        {
            List<StudentFull> students = new List<StudentFull>();
            List<Student> student=await this.context.Students.Include(s=>s.course).ToListAsync();
            for(int i=0;i<student.Count;i++)
            {
                StudentFull item = new StudentFull();
                item.student = student[i];
                item.hobby = getHobbyById(student[i].Id); 
                students.Add(item);
            }
            return students;
        }
        private List<Hobby> getHobbyById(int id)
        {
            var students = this.context.StudentHobbys.Include(s=>s.hobby).Where(s=>s.S_Id== id).ToList();   
            List<Hobby> hobbies= new List<Hobby>();
            foreach(var i in students)
            {
                hobbies.Add(i.hobby);
            }
            return hobbies;
        }
        public async Task<StudentFull> GetStudentById(int Id)
        {
            Student stu= await this.context.Students.Include(s => s.course).SingleOrDefaultAsync(s=>s.Id==Id);
            List<Hobby> hobbies = getHobbyById(Id);
            StudentFull stdf= new StudentFull();
            stdf.hobby = hobbies;
            stdf.student = stu;
            return stdf;
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
            student = fetchStudentId(student);
            this.context.Students.Update(student);
            await this.context.SaveChangesAsync();
            return student;
        }
        private Student fetchStudentId(Student student)
        {
            Student s = this.context.Students.SingleOrDefault(s=> s.FirstName==student.FirstName && s.LastName==student.LastName && s.DOB==student.DOB);
            return s;
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
        public StudentHobby addHobbies(int hobby, int id)
        {
           StudentHobby entry = new StudentHobby();
           entry.H_Id = hobby;
           entry.S_Id = id;
           this.context.StudentHobbys.Add(entry);
           this.context.SaveChanges();
           return entry;
        }
        public int DeleteHobbies(int id)
        {
            int count = 0;
            List<StudentHobby> TBD= this.context.StudentHobbys.Where(s=>s.S_Id==id).ToList();
            foreach( var i in TBD)
            {
                this.context.StudentHobbys.Remove(i);
                this.context.SaveChanges();
                count++;
            }
            return count;
        }
    }
}
