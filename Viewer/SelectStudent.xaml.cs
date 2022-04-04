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
    public partial class SelectStudent : Window
    {
        private dat154Entities dbContext = new dat154Entities();
        private DbSet<student> student;
        private course course;

        public SelectStudent()
        {
            InitializeComponent();
        }

        public SelectStudent(dat154Entities context, course SelectedCourse) : this()
        {
            dbContext = context;
            student = dbContext.student;
            student.Load();
            studentList.DataContext = student.Local;
            course = SelectedCourse;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            student student = (student)studentList.SelectedItem;
            //dbContext.course.
            //dbContext.SaveChanges();
        }
    }
}
