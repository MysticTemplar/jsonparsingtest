using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsViewer.Models
{
    class StarshipModel : VehicleModel
    {
        public string hyperdrive_rating;
        public string MGLT;
        public string starship_class;

        public new List<string> DisplayList
        {
            get
            {
                List<string> display = new List<string>();
                display.Add("Name: " + name);
                display.Add("Model: " + model);
                display.Add("Manufacturer: " + manufacturer);
                display.Add("Cost in Credits: " + cost_in_credits);
                display.Add("Length: " + length);
                display.Add("Max Atmosphering Speed: " + max_atmosphering_speed);
                display.Add("Crew: " + crew);
                display.Add("Passengers: " + passengers);
                display.Add("Cargo Capacity: " + cargo_capacity);
                display.Add("Consumables: " + consumables);
                display.Add("Hyperdrive Rating: " + hyperdrive_rating);
                display.Add("MGLT: " + MGLT);
                display.Add("Starship Class: " + starship_class);
                display.Add("Pilots");
                display.Add("Films");

                return display;
            }
        }
    }
}
