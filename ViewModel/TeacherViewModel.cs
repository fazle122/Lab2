using Common.ViewModel;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class TeacherViewModel:BaseViewModel<Teacher>
    {
        public TeacherViewModel(Teacher teacher) : base(teacher)
        {
            Name = teacher.Name;
            Phone = teacher.Phone;
            Courses = teacher.Courses;
            TotalCredit = teacher.TotalCredit;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Courses { get; set; }
        public double TotalCredit { get; set; }
    }
}
