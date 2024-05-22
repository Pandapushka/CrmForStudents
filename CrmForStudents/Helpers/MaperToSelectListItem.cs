using CrmForStudents.Models.DTO;
using CrmForStudents.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrmForStudents.Helpers
{
    public class MaperToSelectListItem
    {
        public static ServicesAndProductVM ToSelectListItem(List<Product> products, int id)
        {
            var SAndPVM = new ServicesAndProductVM();
            SAndPVM.StudentId = id;
            SAndPVM.Products = new List<SelectListItem>();
            foreach (var prod in products)
            {
                SAndPVM.Products.Add(new SelectListItem { Text = prod.Name, Value = prod.Id.ToString() });
            }
            return SAndPVM;
        }
    }
}
