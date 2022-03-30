using System;
using System.Collections.Generic;
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
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        private dat154Entities entities = new dat154Entities();

        public Editor()
        {
            InitializeComponent();
        }

        public Editor(dat154Entities context) : this()
        {
            entities = context;
        }

        public Editor(dat154Entities context, student s) : this()
        {
            if (s != null)
            {
                id.Text = s.id.ToString();
                name.Text = s.studentname;
                age.Text = s.studentage.ToString();
            }
            
        }
    }
}
