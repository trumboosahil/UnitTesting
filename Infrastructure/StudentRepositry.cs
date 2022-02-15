using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class StudentRepositry : IStudentRepositry
    {
        private readonly DBContext dbContext;
        public StudentRepositry(DBContext dBContext)
        {
            this.dbContext = dBContext;
        }
        public async Task<Student> AddStudent(Student student)
        {
            dbContext.Add(student);
            var result = await dbContext.SaveChangesAsync();
            return student;

        }

        public async Task<Student> GetStudentAsync(int studentid)
        {
            var result = await dbContext.Students.FindAsync(studentid);
            return result;
        }
    }
}
