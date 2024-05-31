using CrmForStudents.Models.Entities;
using CrmForStudents.Models.ViewModels;

namespace CrmForStudents.Helpers
{
    public class ViewModelHelper
    {
        public static Product ToProduct(AddProductViewModel productViewModel)
        {
            var newProduct = new Product
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
            };
            return newProduct;
        }
        public static AddProductViewModel ToProductVM(Product product)
        {
            var ProductVM = new AddProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
            return ProductVM;
        }

        public static Student ToStudent(AddStudentViewModels student)
        {
            var newStudent = new Student
            {
                Id = student.Id,
                Name = student.Name,
                Phone = student.Phone,
                Email = student.Email,
            };
            return newStudent;
        }
        public static AddStudentViewModels ToStudentVMLite(Student student)
        {
            var newStudent = new AddStudentViewModels
            {
                Id = student.Id,
                Name = student.Name,
                Phone = student.Phone,
                Email = student.Email,
            };
            return newStudent;
        }

        //public static AddStudentViewModels ToStudentViewModel(Student student, List<Service> servicesAll, List<Product> products)
        //{
        //    var newStudent = new AddStudentViewModels
        //    {
        //        Id = student.Id,
        //        Name = student.Name,
        //        Phone = student.Phone,
        //        Email = student.Email,
        //    };
        //    foreach (var item in servicesAll.Where(x => x.StudentId == student.Id))
        //    {
        //        item.Product = products.Find(x => x.Id == item.ProductId);
        //        newStudent.Services.Add(item);
        //    }
        //    return newStudent;
        //}
        public static AddStudentViewModels ToStudentViewModel(Student student)
        {
            var newStudent = new AddStudentViewModels
            {
                Id = student.Id,
                Name = student.Name,
                Phone = student.Phone,
                Email = student.Email,
                Services = new List<Service>(student.Services)
                
            };
            return newStudent;
        }

        public static List<AddProductViewModel> ToListProductVM(List<Product> products)
        {
            var productsVM = new List<AddProductViewModel>();
            foreach (var product in products) 
            {
                productsVM.Add(new AddProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                });
            }
            return productsVM;
        }

        public static ServiceViewModel ToServiceViewModel(Service service) 
        {
            return new ServiceViewModel
            {
                Id = service.Id,
                StartDate = service.StartDate,
                FinishDate = service.FinishDate,
                StudentId = service.StudentId,
                ProductId = service.ProductId,
            };
        }

        public static Service ToService(ServiceViewModel service)
        {
            return new Service
            {
                Id = service.Id,
                StartDate = service.StartDate,
                FinishDate = service.FinishDate,
                StudentId = service.StudentId,
                ProductId = service.ProductId,
            };
        }
    }
}
