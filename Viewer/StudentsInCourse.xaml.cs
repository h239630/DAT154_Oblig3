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
        public StudentsInCourse()
        {
            InitializeComponent();
        }
        public StudentsInCourse(dat154Entities context) : this()
        {
            dbContext = context;

            student = dbContext.student;
            grade = dbContext.grade;

            student.Load();
            grade.Load();

            student stud = new student();

            stud.grade = grade.Local;

            studentGradeList.DataContext = student.Local;
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            if (SearchField.Text == "")
            {
                if (student != null)
                    studentGradeList.DataContext = student.Local;
            }
            else
            {
                studentGradeList.DataContext = student.Local.Where(student => student.studentname.Contains(SearchField.Text));
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            student student = (student)studentGradeList.SelectedItem;
            new Editor(dbContext, student).ShowDialog();
        }
    }
}
