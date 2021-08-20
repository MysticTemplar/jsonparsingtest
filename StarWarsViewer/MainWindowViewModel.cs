using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StarWarsViewer
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private DisplayWindow.MovieListView MainView;

        private DisplayWindow.MovieDisplay MovieView;

        private UserControl currentView;

        public UserControl CurrentView
        {
            get => currentView;
            set
            {
                if (currentView == value)
                    return;
                currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        private bool showBack = false;
        public bool ShowBack
        {
            get => showBack;
            set
            {
                if (showBack == value)
                    return;
                showBack = value;
                OnPropertyChanged("ShowBack");
            }
        }

        public MainWindowViewModel()
        {
            MainView = new DisplayWindow.MovieListView();
            MainView.ListClicked += DisplayDetails;
            CurrentView = MainView;

        }

        public void DisplayDetails(Models.MovieModel movie)
        {
            MovieView = new DisplayWindow.MovieDisplay(movie);
            CurrentView = MovieView;
            ShowBack = true;
        }

        public void Back()
        {
            if (!MovieView.ViewModel.Back())
            {
                CurrentView = MainView;
                ShowBack = false;
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

    }
}
