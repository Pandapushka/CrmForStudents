using CrmForStudents.Models.Entities;
using CrmForStudents.Models.ViewModels;

namespace CrmForStudents.Helpers
{
    public class ViewModelHelper
    {
        public static Student ToStudent(AddStudentViewModels student)
        {
            var newStudent = new Student
            {
                Name = student.Name,
                Phone = student.Phone,
                Email = student.Email,
            };
            return newStudent;
        }

        public static AddStudentViewModels ToStudentViewModel(Student student)
        {
            var newStudent = new AddStudentViewModels
            {
                Name = student.Name,
                Phone = student.Phone,
                Email = student.Email,
            };
            return newStudent;
        }
    }
}
