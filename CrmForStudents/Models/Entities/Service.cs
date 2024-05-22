using System.ComponentModel.DataAnnotations.Schema;

namespace CrmForStudents.Models.Entities
{
    public class Service
    {
        public int Id { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
