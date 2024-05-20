﻿using CrmForStudents.Models.Entities;
using CrmForStudents.Models.ViewModels;

namespace CrmForStudents.Data.Repository
{
    public interface IProductRepository
    {
        Task Add(AddProductViewModel productViewModel);
        Task<List<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task Edit(Product product);
        Task DeleteById(Guid id);
    }
}
