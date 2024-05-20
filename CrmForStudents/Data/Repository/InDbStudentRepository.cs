using CrmForStudents.Helpers;
using CrmForStudents.Models.Entities;
using CrmForStudents.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CrmForStudents.Data.Repository
{
    public class InDbStudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public InDbStudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(AddStudentViewModels studentViewModel)
        {
            var student = ViewModelHelper.ToStudent(studentViewModel);
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Student> > GetAll()
        {
            return await _dbContext.Students.ToListAsync();
        }
        public async Task<Student> GetById(Guid id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Edit(Student studentVM)
        {
            var student = await GetById(studentVM.Id);
            if (student != null)
            {
                student.Name = studentVM.Name;
                student.Email = studentVM.Email;
                student.Phone = studentVM.Phone;

                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteById(Guid id)
        {
            var student = await GetById(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
