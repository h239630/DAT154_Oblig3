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
        private dat154Entities dbContext = new dat154Entities();
        private DbSet<grade> grade;
        private bool showFailed = false;

        public Grades()
        {
            InitializeComponent();
        }

        public Grades(dat154Entities context) : this()
        {
            dbContext = context;
            grade = dbContext.grade;

            grade.Load();
            gradeList.DataContext = grade.Local;
        }

        public Grades(dat154Entities context, grade grade) : this()
        {
            dbContext = context;


        }

        public void Search(object sender, TextChangedEventArgs e)
        {
            if (FilterField != null)
            {
                if (SearchField.Text == "")
                {
                    if (grade != null)
                        gradeList.DataContext = grade.Local
                        .Where(grade => char.Parse(grade.grade1.ToLower()) <= char.Parse(FilterField.Text.Substring(0, 1).ToLower()));
                }
                else
                {
                    gradeList.DataContext = grade.Local
                        .Where(grade => char.Parse(grade.grade1.ToLower()) <= char.Parse(FilterField.Text.Substring(0, 1).ToLower()))
                        .Where(grade => grade.studentid.Equals(int.Parse(SearchField.Text)));
                }
            }
            else
            {
                if (SearchField.Text == "")
                {
                    if (grade != null)
                        gradeList.DataContext = grade.Local;
                }
                else
                {
                    gradeList.DataContext = grade.Local.Where(grade => grade.studentid.Equals(int.Parse(SearchField.Text)));
                }
            }
            
        }

        private void Filter(object sender, TextChangedEventArgs e)
        {
            // Can filter grades on a spesific student
            if (SearchField.Text != "")
            {
                if (FilterField.Text == "")
                {
                    if (grade != null)
                        gradeList.DataContext = grade.Local.Where(grade => grade.studentid.Equals(int.Parse(SearchField.Text)));
                }
                else
                {
                    char g = char.Parse(FilterField.Text.Substring(0, 1).ToLower());
                    gradeList.DataContext = grade.Local
                        .Where(grade => grade.studentid.Equals(int.Parse(SearchField.Text)))
                        .Where(grade => char.Parse(grade.grade1.ToLower()) <= g);
                }
            } 
            // Filter grades on all students
            else
            {
                if (FilterField.Text == "")
                {
                    if (grade != null)
                        gradeList.DataContext = grade.Local;
                }
                else
                {
                    char g = char.Parse(FilterField.Text.Substring(0, 1).ToLower());
                    gradeList.DataContext = grade.Local.Where(grade => char.Parse(grade.grade1.ToLower()) <= g);
                }
            }
                
            
        }

        private void Failed_Click(object sender, RoutedEventArgs e)
        {
            if (!showFailed)
            {
                Failed.Content = "Show all students";
                gradeList.DataContext = grade.Local.Where(grade => char.Parse(grade.grade1) == 'F');
                showFailed = true;
            } 
            else
            {
                Failed.Content = "Show failed students";
                gradeList.DataContext = grade.Local;
                showFailed = false;
            }
            
        }
    }
}
