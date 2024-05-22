using CrmForStudents.Data;
using CrmForStudents.Data.Repository;
using CrmForStudents.Helpers;
using CrmForStudents.Models.DTO;
using CrmForStudents.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrmForStudents.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IProductRepository _productRepository;
        private readonly IServiceRepository _serviceRepository;
        public ServicesController(IStudentRepository studentRepository, IProductRepository productRepository, IServiceRepository serviceRepository) 
        {
            _studentRepository = studentRepository;
            _productRepository = productRepository;
            _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            var products = await _productRepository.GetAll();
            var SAndPVM = MaperToSelectListItem.ToSelectListItem(products, id);
            return View(SAndPVM);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ServicesAndProductVM SAndPVM)
        {
            var product = await _productRepository.GetById(SAndPVM.ProductId);
            var student = await _studentRepository.GetById(SAndPVM.StudentId);
            await _serviceRepository.Add(SAndPVM, product, student);
            return RedirectToAction("GetStudents", "Students");
        }

    }
}
