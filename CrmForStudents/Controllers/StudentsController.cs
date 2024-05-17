using CrmForStudents.Data;
using CrmForStudents.Data.Repository;
using CrmForStudents.Helpers;
using CrmForStudents.Models.Entities;
using CrmForStudents.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmForStudents.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModels studentViewModel)
        {
            await _studentRepository.Add(studentViewModel);
            return RedirectToAction("GetStudents", "Students");
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentRepository.GetAll();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _studentRepository.GetById(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student studentVM)
        { 
            await _studentRepository.Edit(studentVM);
            return RedirectToAction("GetStudents", "Students");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _studentRepository.DeleteById(id);
            return RedirectToAction("GetStudents", "Students");
        }
    }
}
