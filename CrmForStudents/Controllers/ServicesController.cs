using CrmForStudents.Data;
using CrmForStudents.Data.Repository;
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
        private readonly ApplicationDbContext _dbContext;
        public ServicesController(IStudentRepository studentRepository, IProductRepository productRepository, ApplicationDbContext dbContext) 
        {
            _studentRepository = studentRepository;
            _productRepository = productRepository;
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            var products = await _productRepository.GetAll();
            var SAndPDTO = new ServicesAndProductDTO();
            SAndPDTO.StudentId = id;
            SAndPDTO.Products = new List<SelectListItem>();
            foreach (var prod in products)
            {
                SAndPDTO.Products.Add(new SelectListItem { Text = prod.Name, Value = prod.Id.ToString() });
            }
            return View(SAndPDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ServicesAndProductDTO SAndPDTO)
        {
            var i = SAndPDTO;
            var service = new Service();
            service.Product = await _productRepository.GetById(i.ProductId);
            service.Student = await _studentRepository.GetById(i.StudentId);
            service.StartDate = DateTime.Now;
            _dbContext.Services.Add(service);
            _dbContext.SaveChanges();
            return RedirectToAction("GetStudents", "Students");
        }

    }
}
