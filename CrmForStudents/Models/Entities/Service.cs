namespace CrmForStudents.Models.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Student Student { get; set; }
    }
}
