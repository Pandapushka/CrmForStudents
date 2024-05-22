namespace CrmForStudents.Models.Entities
{
    public class Student
    {
        private ICollection<Service> _services;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Service> Services
        {
            get { return _services ?? (_services = new List<Service>()); }
            protected set { _services = value; }
        }

    }
}
