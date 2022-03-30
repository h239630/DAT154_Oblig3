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
    /// <summary>
    /// Interaction logic for Courses.xaml
    /// </summary>
    public partial class Courses : Window
    {
        private dat154Entities dbContext = new dat154Entities();
        private DbSet<course> course;
        public Courses()
        {
            InitializeComponent();
        }

        public Courses(dat154Entities context) : this()
        {
            dbContext = context;
            course = dbContext.course;

            course.Load();
            courseList.DataContext = course.Local;
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            if (SearchField.Text == "")
            {
                if (course != null)
                    courseList.DataContext = course.Local;
            }
            else
            {
                courseList.DataContext = course.Local.Where(course => course.coursename.Contains(SearchField.Text));
            }
        }
    }
}
