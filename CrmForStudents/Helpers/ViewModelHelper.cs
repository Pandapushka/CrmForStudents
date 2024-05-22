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

        public static AddStudentViewModels ToStudentViewModel(Student student, List<Service> servicesAll)
        {
            var newStudent = new AddStudentViewModels
            {
                Id = student.Id,
                Name = student.Name,
                Phone = student.Phone,
                Email = student.Email,
            };
            foreach (var item in servicesAll.Where(x => x.StudentId == student.Id))
            {
                newStudent.Services.Add(item);
            }
            return newStudent;
        }
    }
}
