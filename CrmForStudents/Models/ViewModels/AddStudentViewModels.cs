using System.ComponentModel.DataAnnotations;

namespace CrmForStudents.Models.ViewModels
{
    public class AddStudentViewModels
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Значение имя не может быть пустым!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Значение почта не может быть пустым!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Значение телефон не может быть пустым!")]
        public string Phone { get; set; }
    }
}
