using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsViewer.Models
{
    public class CharacterModel : JsonModel
    {
        public string name;
        public string height;
        public string mass;
        public string hair_color;
        public string skin_color;
        public string eye_color;
        public string birth_year;
        public string gender;
        public string homeworld;
        public List<string> species;
        public List<string> vehicles;
        public List<string> starships;
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
                if (Homeworld == null)
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
                display.Add("Height: " + height);
                display.Add("Mass: " + mass);
                display.Add("Hair Color: " + hair_color);
                display.Add("Skin Color: " + skin_color);
                display.Add("Eye Color: " + eye_color);
                display.Add("Birth Year: " + birth_year);
                display.Add("Gender: " + gender);
                display.Add("Homeworld: " + HomeworldName);
                display.Add("Films");
                display.Add("Species");
                display.Add("Vehicles");
                display.Add("Starships");

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
                case "Vehicles":
                    return new ListModel(Summary + " Vehicles", vehicles, typeof(VehicleModel));
                case "Starships":
                    return new ListModel(Summary + " Starships", starships, typeof(StarshipModel));
                case "Species":
                    return new ListModel(Summary + " Species", species, typeof(SpeciesModel));
            }
            if (item.Contains("Homeworld"))
            {
                return Homeworld;
            }

            return null;
        }
    }
}
