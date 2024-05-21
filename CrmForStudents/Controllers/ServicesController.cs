using Microsoft.AspNetCore.Mvc;

namespace CrmForStudents.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Add(Guid id)
        {
            var i = id;
            
            return View();
        }
    }
}
