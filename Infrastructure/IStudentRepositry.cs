using Domain;
using System;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IStudentRepositry
    {
        Task<Student> AddStudent(Student student);
        Task<Student> GetStudentAsync(int studentid);
    }
}
