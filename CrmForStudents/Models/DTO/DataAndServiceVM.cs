using CrmForStudents.Models.Entities;

namespace CrmForStudents.Models.DTO
{
    public class DataAndServiceVM
    {
        public DateTime DateTime { get; set; }
        public List<Service> Service { get; set; }
    }
}
