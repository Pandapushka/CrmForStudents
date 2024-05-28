namespace CrmForStudents.Models.ViewModels
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public int StudentId { get; set; }
        public int ProductId { get; set; }
    }
}
