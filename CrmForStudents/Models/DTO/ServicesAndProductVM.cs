﻿using CrmForStudents.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrmForStudents.Models.DTO
{
    public class ServicesAndProductVM
    {
        public Guid StudentId { get; set; }
        public List<SelectListItem> Products { get; set; }
        public Guid ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}