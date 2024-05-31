using CrmForStudents.Helpers;
using CrmForStudents.Models.Entities;
using CrmForStudents.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CrmForStudents.Data.Repository
{
    public class InDbStudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public InDbStudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Student> > GetAll()
        {
            return await _dbContext.Students.ToListAsync();
        }
        public async Task<Student> GetById(int id)
        {
            return await _dbContext.Students
                .Include(c => c.Services)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Student> GetByIdLite(int id)
        {
            return await _dbContext.Students
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Edit(Student studentVM)
        {
            var student = await GetByIdLite(studentVM.Id);
            if (student != null)
            {
                student.Name = studentVM.Name;
                student.Email = studentVM.Email;
                student.Phone = studentVM.Phone;

                await _dbContext.SaveChangesAsync();
            }
        }
        
        public async Task DeleteById(int id)
        {
            var student = await GetByIdLite(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<Student> GetByPhone(string phone)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(x => x.Phone == phone);
        }

    }
}
