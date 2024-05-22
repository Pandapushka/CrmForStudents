using CrmForStudents.Data.Repository;
using CrmForStudents.Models.Entities;
using CrmForStudents.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrmForStudents.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;       
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.Add(productViewModel);
                return RedirectToAction("GetProducts", "Products");
            }
            return View(productViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAll();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _productRepository.GetById(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            await _productRepository.Edit(product);
            return RedirectToAction("GetProducts", "Products");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.DeleteById(id);
            return RedirectToAction("GetProducts", "Products");
        }

    }
}
