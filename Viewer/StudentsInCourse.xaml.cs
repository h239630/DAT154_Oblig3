using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Viewer
{
   
    public partial class StudentsInCourse : Window
    {
        private dat154Entities dbContext = new dat154Entities();
        private DbSet<student> student;
        private DbSet<grade> grade;
        private course course;


        public StudentsInCourse()
        {
            InitializeComponent();
        }
        public StudentsInCourse(dat154Entities context) : this()
        {
            dbContext = context;

        }
        public StudentsInCourse(dat154Entities context, course SelectedCourse) : this()
        {
            dbContext = context;
            grade = dbContext.grade;
            student = dbContext.student;
            grade.Load();
            student.Load();
            course = SelectedCourse;

            if (SelectedCourse != null)
            {
                studentGradeList.DataContext = grade.Local.Where(course => course.coursecode.Equals(SelectedCourse.coursecode));
            }
        }


            private void Search(object sender, TextChangedEventArgs e)
        {
            
            if (SearchField.Text == "")
            {
                if (student != null)
                    studentGradeList.DataContext = grade.Local;
            }
            else
            {
                studentGradeList.DataContext = grade.Local.Where(grade => grade.student.studentname.Contains(SearchField.Text));
            }
        }


        private void Add_Student(object sender, RoutedEventArgs e)
        {
            new SelectStudent(dbContext, course);
        }

        private void Remove_Student(object sender, RoutedEventArgs e)
        {
            // student student = (student)studentList.SelectedItem;

        }
    }
}
