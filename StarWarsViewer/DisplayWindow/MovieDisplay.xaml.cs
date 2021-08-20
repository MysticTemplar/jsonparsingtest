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

namespace StarWarsViewer.DisplayWindow
{
    /// <summary>
    /// Interaction logic for MovieDisplay.xaml
    /// </summary>
    public partial class MovieDisplay : UserControl
    {
        public MovieDisplayViewModel ViewModel;

        public MovieDisplay(Models.MovieModel movie)
        {
            InitializeComponent();

            ViewModel = new MovieDisplayViewModel(movie);
            DataContext = ViewModel;
        }

        private void ListView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel.Click((string)Display.SelectedItem);
        }

    
    }
}
