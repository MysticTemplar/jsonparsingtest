using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsViewer.Models
{
    public abstract class JsonModel : INotifyPropertyChanged
    {
        public string Summary;

        public List<String> DisplayList;

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract JsonModel ExpandItem(string item);

        protected void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}
