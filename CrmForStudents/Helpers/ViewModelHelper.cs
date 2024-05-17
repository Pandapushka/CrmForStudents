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
                Id = student.Id,
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
                Id= student.Id,
                Name = student.Name,
                Phone = student.Phone,
                Email = student.Email,
            };
            return newStudent;
        }
        public static List<AddStudentViewModels> ToListStudentViewModel(List<Student> students)
        {
            List<AddStudentViewModels> studentViewModels = new List<AddStudentViewModels>();
            foreach (var student in students) 
            {
                var studentVM = new AddStudentViewModels();
                studentVM = ToStudentViewModel(student);
                studentViewModels.Add(studentVM);
            }
            return studentViewModels;
        }
    }
}
