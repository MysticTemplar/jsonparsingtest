using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsViewer.Models
{
    public class MovieModel : JsonModel
    {
        public string title;
        public string episode_id;
        public string opening_crawl;
        public string director;
        public string producer;
        public List<string> characters;
        public List<string> planets;
        public List<string> starships;
        public List<string> vehicles;
        public List<string> species;
        public string created;
        public string edited;
        public string url;

        public new List<string> DisplayList
        {
            get
            {
                List<string> display = new List<string>();
                display.Add("Title: " + title);
                display.Add("Episode: " + episode_id);
                display.Add("Opening Crawl: " + opening_crawl);
                display.Add("Director: " + director);
                display.Add("Characters");
                display.Add("Planets");
                display.Add("Starships");
                display.Add("Vehicles");
                display.Add("Species");

                return display;
            }
        }

        public new string Summary
        {
            get
            {
                return title;
            }
        }

        public override JsonModel ExpandItem(string item)
        {
            switch (item)
            {
                case "Characters":
                    return new ListModel(Summary + " Characters", characters, typeof(CharacterModel));
                case "Planets":
                    return new ListModel(Summary + " Planets", planets, typeof(PlanetModel));
                case "Vehicles":
                    return new ListModel(Summary + " Vehicles", vehicles, typeof(VehicleModel));
                case "Starships":
                    return new ListModel(Summary + " Starships", starships, typeof(StarshipModel));
                case "Species":
                    return new ListModel(Summary + " Species", species, typeof(SpeciesModel));
                default:
                    return null;
            }
              
        }
    }
}
