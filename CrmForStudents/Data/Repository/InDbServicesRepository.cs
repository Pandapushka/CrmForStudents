using CrmForStudents.Models.DTO;
using CrmForStudents.Models.Entities;
using CrmForStudents.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CrmForStudents.Data.Repository
{
    public class InDbServicesRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public InDbServicesRepository(ApplicationDbContext dbContext)
        {
                _dbContext = dbContext;
        }

        public async Task Add(ServicesAndProductVM SAndPVM, Product product, Student student)
        {
            var service = new Service();
            service.Product = product;
            service.Student = student;
            service.StartDate = SAndPVM.StartDate;
            service.FinishDate = SAndPVM.FinishDate;
            await _dbContext.Services.AddAsync(service);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Service>> Get()
        {
            return await _dbContext.Services.ToListAsync();
        }

    }
}
