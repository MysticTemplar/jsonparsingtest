using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StarWarsViewer
{
    public class MovieListViewModel : INotifyPropertyChanged
    {
        public MovieListViewModel()
        {
            Task task = new Task( new Action(GetData));
            task.Start();
        }

        private Models.BaseModel movieList;

        async void GetData()
        {
            try
            {
                MovieList = (Models.BaseModel)await Client.APIClient.GetInstance().GetJSONAsync("https://swapi.dev/api/films/", typeof(Models.BaseModel));
            }
            catch
            {

                MessageBox.Show("Unable to load the database.  No connection or cache found.");
            }
        }

        public Models.BaseModel MovieList { get => movieList;
            set
            {
                if (value == movieList)
                    return;
                movieList = value;
                OnPropertyChanged("MovieList");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
