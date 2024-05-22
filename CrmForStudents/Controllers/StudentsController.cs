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
        private readonly IServiceRepository _serviceRepository;
        public StudentsController(IStudentRepository studentRepository, IServiceRepository serviceRepository)
        {
            _studentRepository = studentRepository;
            _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModels studentViewModel)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.Add(studentViewModel);
                return RedirectToAction("GetStudents", "Students");
            }
            return View(studentViewModel);

        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentRepository.GetAll();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
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
        public async Task<IActionResult> Delete(int id)
        {
            await _studentRepository.DeleteById(id);
            return RedirectToAction("GetStudents", "Students");
        }
        [HttpGet]
        public async Task<IActionResult> GetInfo(int id)
        {
            var student = await _studentRepository.GetById(id);
            var services = await _serviceRepository.Get();
            var studentVM = ViewModelHelper.ToStudentViewModel(student, services);
            return View(studentVM);
        }
        
    }
}
