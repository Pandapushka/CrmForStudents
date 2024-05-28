using CrmForStudents.Data.Repository;
using CrmForStudents.Helpers;
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
                var product = ViewModelHelper.ToProduct(productViewModel);
                await _productRepository.Add(product);
                return RedirectToAction("GetProducts", "Products");
            }
            return View(productViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAll();
            var productsVM = ViewModelHelper.ToListProductVM(products);
            return View(productsVM);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetById(id);
            var producttVM = ViewModelHelper.ToProductVM(product);
            return View(producttVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AddProductViewModel productVM)
        {
            await _productRepository.Edit(ViewModelHelper.ToProduct(productVM));
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
