using CrmForStudents.Helpers;
using CrmForStudents.Models.Entities;
using CrmForStudents.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CrmForStudents.Data.Repository
{
    public class InDbProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public InDbProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(AddProductViewModel productViewModel)
        {
            var product = ViewModelHelper.ToProduct(productViewModel);
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }
        public async Task<Product> GetById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Edit(Product productVM)
        {
            var product = await GetById(productVM.Id);
            if (product != null)
            {
                product.Name = productVM.Name;
                product.Price = productVM.Price;
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteById(int id)
        {
            var product = await GetById(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
