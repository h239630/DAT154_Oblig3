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
    /// Interaction logic for Grades.xaml
    /// </summary>
    public partial class Grades : Window
    {
        private dat154Entities entities = new dat154Entities();
        private DbSet<grade> grade;

        public Grades()
        {
            InitializeComponent();
        }

        public Grades(dat154Entities context) : this()
        {
            entities = context;
            grade = entities.grade;

            grade.Load();
            gradeList.DataContext = grade.Local;
        }

        public void Search(object sender, TextChangedEventArgs e)
        {
            if (SearchField.Text == "")
            {
                if (grade != null)
                    gradeList.DataContext = grade.Local;
            }
            else
            {
                gradeList.DataContext = grade.Local.Where(grade => grade.studentid.Equals(SearchField.Text));
            }
        }
    }
}
