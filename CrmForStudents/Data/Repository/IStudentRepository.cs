using CrmForStudents.Models.Entities;
using CrmForStudents.Models.ViewModels;

namespace CrmForStudents.Data.Repository
{
    public interface IStudentRepository
    {
        Task Add(AddStudentViewModels studentViewModel);
        Task<List<Student>> GetAll();
        Task<Student> GetById(Guid id);
        Task Edit(Student student);
        Task DeleteById(Guid id);
    }
}
