using CrmForStudents.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace CrmForStudents.Models.ViewModels
{
    public class AddProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Значение имя не может быть пустым!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Значение имя не может быть пустым!")]
        public float Price { get; set; }
    }
}
