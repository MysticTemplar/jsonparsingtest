using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsViewer.Models
{
    public class ListModel : JsonModel 
    { 

        private Dictionary<string, JsonModel> models;
        public Dictionary<string, JsonModel> Models
        {
            get => models;
            set
            {
                if (models == value)
                    return;
                models = value;
                OnPropertyChanged("DisplayList");
            }
        }

        private string emptyMessage = "Now Loading";

        public new List<String> DisplayList
        {
            get
            {
                if (models != null && models.Count != 0)
                    return models.Keys.ToList<string>();
                else
                    return new List<string> { emptyMessage };
            }
        }

        private string listTitle;

        public new String Summary
        {
            get => listTitle;
            set
            {
                if (listTitle == value)
                    return;
                listTitle = value;
                OnPropertyChanged("Summary");
            }
        }

        public ListModel(string summary, List<String> urls, Type type)
        {
            listTitle = summary;

            OnPropertyChanged("Summary");

            Task Populate = new Task(new Action(() => PopulateList(urls, type)));
            Populate.Start();

        }

        private async void PopulateList(List<string> urls, Type type)
        {
            Dictionary<string, JsonModel> results = new Dictionary<string, JsonModel>();

            try
            {
                foreach (var url in urls)
                {
                    dynamic model = Convert.ChangeType(await Client.APIClient.GetInstance().GetJSONAsync(url, type), type);
                    results[model.Summary] = (JsonModel)model;
                }

                if (results.Count == 0)
                    emptyMessage = "None";

                Models = results;
            }
            catch
            {
                emptyMessage = "Error loading " + Summary;
                OnPropertyChanged("DisplayList");
            }

            
        }

        public override JsonModel ExpandItem(string item)
        {
            if (Models.ContainsKey(item))
                return Models[item];
            return null;
        }
    }
}
