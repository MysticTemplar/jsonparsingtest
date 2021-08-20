using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsViewer.Models
{
    public class PlanetModel : JsonModel
    {
        public string name;
        public string rotation_period;
        public string orbital_period;
        public string diameter;
        public string climate;
        public string gravity;
        public string terrain;
        public string surface_water;
        public string population;
        public List<string> residents;
        public List<string> films;
        public string created;
        public string edited;
        public string url;

        public new List<string> DisplayList
        {
            get
            {
                List<string> display = new List<string>();
                display.Add("Name: " + name);
                display.Add("Rotation Period: " + rotation_period);
                display.Add("Orbital Period: " + orbital_period);
                display.Add("Diameter: " + diameter);
                display.Add("Climate: " + climate);
                display.Add("Gravity: " + gravity);
                display.Add("Terrain: " + terrain);
                display.Add("Surface Water: " + surface_water);
                display.Add("Population: " + population);
                display.Add("Residents");
                display.Add("Films");

                return display;
            }
        }

        public new string Summary
        {
            get
            {
                return name;
            }
        }

        public override JsonModel ExpandItem(string item)
        {
            switch (item)
            {
                case "Residents":
                    return new ListModel(Summary + " Residents", residents, typeof(CharacterModel));
                default:
                    return null;
            }

        }
    }
}
