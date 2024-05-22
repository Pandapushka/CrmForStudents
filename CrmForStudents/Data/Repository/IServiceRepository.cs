using CrmForStudents.Models.DTO;
using CrmForStudents.Models.Entities;

namespace CrmForStudents.Data.Repository
{
    public interface IServiceRepository
    {
         Task Add(ServicesAndProductVM SAndPVM, Product product, Student student);

    }
}
