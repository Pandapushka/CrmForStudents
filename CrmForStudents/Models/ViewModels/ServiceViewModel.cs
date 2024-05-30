using System.ComponentModel.DataAnnotations;

namespace CrmForStudents.Models.ViewModels
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Значение не может быть пустым!")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Значение не может быть пустым!")]
        public DateTime FinishDate { get; set; }

        public int StudentId { get; set; }
        public int ProductId { get; set; }
    }
}
