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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StarWarsViewer.DisplayWindow
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MovieListView : UserControl
    {
        private MovieListViewModel ViewModel;

        public event Action<Models.MovieModel> ListClicked;

        public MovieListView()
        {
            InitializeComponent();

            ViewModel = new MovieListViewModel();
            DataContext = ViewModel;
        }

        private void MovieList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ListClicked != null)
                ListClicked(ViewModel.MovieList.results[MovieList.SelectedIndex]);
        }
    }
}
