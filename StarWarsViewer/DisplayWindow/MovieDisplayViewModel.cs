using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsViewer.DisplayWindow
{
    public class MovieDisplayViewModel : INotifyPropertyChanged
    {
        public MovieDisplayViewModel(Models.MovieModel movie)
        {
            previousDisplays = new Stack<Models.JsonModel>();
            CurrentDisplay = movie;

        }

        private Stack<Models.JsonModel> previousDisplays;

        private Models.JsonModel currentDisplay;

        public Models.JsonModel CurrentDisplay
        {
            get => currentDisplay;

            set
            {
                if (value == currentDisplay)
                    return;

                currentDisplay = value;
                OnPropertyChanged("CurrentDisplay");
            }
        }

        public void Click(string item)
        {
            if (item == null)
                return;

            var newItem = CurrentDisplay.ExpandItem(item);
            if (newItem != null)
            {
                previousDisplays.Push(currentDisplay);
                CurrentDisplay = newItem;
            }
        }

        public bool Back()
        {
            if (previousDisplays.Count != 0)
            {
                CurrentDisplay = previousDisplays.Pop();
                return true;
            }
            return false;
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
