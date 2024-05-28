using CrmForStudents.Models.Entities;
using CrmForStudents.Models.ViewModels;

namespace CrmForStudents.Data.Repository
{
    public interface IStudentRepository
    {
        Task Add(Student student);
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Task Edit(Student student);
        Task DeleteById(int id);
    }
}
