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
        private readonly IProductRepository _productRepository;
        public StudentsController(IStudentRepository studentRepository, IServiceRepository serviceRepository, IProductRepository productRepository)
        {
            _studentRepository = studentRepository;
            _serviceRepository = serviceRepository;
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModels studentViewModel)
        {
            if (await _studentRepository.GetByPhone(studentViewModel.Phone) != null)
            {
                ModelState.AddModelError("", "Клиент с таким телефоном уже сущствует");
            }
            if (ModelState.IsValid)
            {
                var student = ViewModelHelper.ToStudent(studentViewModel);
                await _studentRepository.Add(student);
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
            var studentVM = ViewModelHelper.ToStudentVMLite(student);
            return View(studentVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AddStudentViewModels studentVM)
        {
            var student = ViewModelHelper.ToStudent(studentVM);
            await _studentRepository.Edit(student);
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
            var studentVM = ViewModelHelper.ToStudentViewModel(student);
            return View(studentVM);
        }
        
    }
}
