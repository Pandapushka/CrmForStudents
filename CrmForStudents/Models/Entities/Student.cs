﻿namespace CrmForStudents.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Service> Services { get; set; }
        public Student()
        {
            Services = new List<Service>();
        }

    }
}
