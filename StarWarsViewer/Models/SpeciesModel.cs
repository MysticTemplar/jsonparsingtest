using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsViewer.Models
{
    class SpeciesModel : JsonModel
    {
        public string name;
        public string classification;
        public string designation;
        public string average_height;
        public string skin_colors;
        public string hair_colors;
        public string eye_colors;
        public string average_lifespan;
        public string homeworld;
        public string language;
        public List<string> people;
        public List<string> films;
        public string created;
        public string edited;
        public string url;

        public new string Summary
        {
            get => name;
        }

        public new List<String> DisplayList
        {
            get
            {
                if (HomeworldName == null)
                {
                    if (homeworld == null)
                        HomeworldName = "";
                    else
                    {
                        HomeworldName = "Determining";
                        Task NameTask = new Task(new Action(GetHomeworldName));
                        NameTask.Start();
                    }

                }
                List<string> display = new List<string>();
                display.Add("Name: " + name);
                display.Add("Classification: " + classification);
                display.Add("Designation: " + designation);
                display.Add("Average Height: " + average_height);
                display.Add("Skin Colors: " + skin_colors);
                display.Add("Hair Colors: " + hair_colors);
                display.Add("Eye Colors: " + eye_colors);
                display.Add("Average Lifespan: " + average_lifespan);
                display.Add("Language: " + language);
                display.Add("Homeworld: " + HomeworldName);
                display.Add("Films");
                display.Add("People");

                return display;

            }
        }

        private string HomeworldName;

        private Models.PlanetModel Homeworld;

        private async void GetHomeworldName()
        {
            try
            {
                Homeworld = (PlanetModel)await Client.APIClient.GetInstance().GetJSONAsync(homeworld, typeof(Models.PlanetModel));
                HomeworldName = Homeworld.Summary;
            }
            catch
            {
                Homeworld = null;
                HomeworldName = "Unable to Find";
            }
            OnPropertyChanged("DisplayList");
        }

        public override JsonModel ExpandItem(string item)
        {
            switch (item)
            {
                case "Films":
                    return new ListModel(Summary + " Films", films, typeof(MovieModel));
                case "People":
                    return new ListModel(Summary + " Vehicles", people, typeof(CharacterModel));
            }
            if (item.Contains("Homeworld"))
            {
                return Homeworld;
            }

            return null;
        }
    }
}
