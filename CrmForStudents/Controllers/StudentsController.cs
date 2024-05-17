using CrmForStudents.Data;
using CrmForStudents.Helpers;
using CrmForStudents.Models.Entities;
using CrmForStudents.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmForStudents.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModels studentViewModel)
        {
            var student = ViewModelHelper.ToStudent(studentViewModel);
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _dbContext.Students.ToListAsync();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student studentVM)
        {
            var student = await _dbContext.Students.FindAsync(studentVM.Id);
            if (student != null) 
            {
                student.Name = studentVM.Name;
                student.Email = studentVM.Email;
                student.Phone = studentVM.Phone;

                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("GetStudents", "Students");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("GetStudents", "Students");
        }
    }
}
