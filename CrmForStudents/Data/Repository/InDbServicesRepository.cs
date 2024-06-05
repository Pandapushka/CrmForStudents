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
        public async Task<Service> GetById(int id)
        {
            return await _dbContext.Services.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task DeleteById(int id)
        {
            var service = await GetById(id);
            if (service != null)
            {
                _dbContext.Services.Remove(service);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task Edit(ServiceViewModel serviceVM)
        {
            var service = await GetById(serviceVM.Id);
            if (service != null)
            {
                service.StartDate = serviceVM.StartDate;
                service.FinishDate = serviceVM.FinishDate;
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<Service>> GetSortedLisrServices(DateTime dateTime)
        {
            return await _dbContext.Services.Where(x => x.StartDate == dateTime).Include(x => x.Product).Include(x => x.Student).ToListAsync();
        }

    }
}
