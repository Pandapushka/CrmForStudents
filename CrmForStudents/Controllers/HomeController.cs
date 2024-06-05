using CrmForStudents.Data.Repository;
using CrmForStudents.Models;
using CrmForStudents.Models.DTO;
using CrmForStudents.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrmForStudents.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        public HomeController(IServiceRepository serviceRepository)
        {
             _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(DateTime  dateTime)
        {
            var i = dateTime;
            var q = await _serviceRepository.GetSortedLisrServices(i);
            var r = new DataAndServiceVM();
            r.DateTime = dateTime;
            r.Service = new List<Service>(q);
            return  View(r);
        }


    }
}
