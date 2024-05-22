using CrmForStudents.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace CrmForStudents.Models.ViewModels
{
    public class AddStudentViewModels
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Значение имя не может быть пустым!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Значение почта не может быть пустым!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Значение телефон не может быть пустым!")]
        public string Phone { get; set; }
        public List<Service> Services { get; set; }
        public AddStudentViewModels()
        {
            Services = new List<Service>();
        }
    }
}
