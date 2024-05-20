namespace CrmForStudents.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public List<Service> Services { get; set;}
        public Product()
        {
            Services = new List<Service>();
        }
    }
}
