using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsViewer.Models
{
    class VehicleModel : JsonModel
    {
        public string name;
        public string model;
        public string manufacturer;
        public string cost_in_credits;
        public string length;
        public string max_atmosphering_speed;
        public string crew;
        public string passengers;
        public string cargo_capacity;
        public string consumables;
        public string vehicle_class;
        public List<string> pilots;
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
                display.Add("Model: " + model);
                display.Add("Manufacturer: " + manufacturer);
                display.Add("Cost in Credits: " + cost_in_credits);
                display.Add("Length: " + length);
                display.Add("Max Atmosphering Speed: " + max_atmosphering_speed);
                display.Add("Crew: " + crew);
                display.Add("Passengers: " + passengers);
                display.Add("Cargo Capacity: " + cargo_capacity);
                display.Add("Consumables: " + consumables);
                display.Add("Vehicle Class: " + vehicle_class);
                display.Add("Pilots");
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
                case "Pilots":
                    return new ListModel(Summary + " Pilots", pilots, typeof(CharacterModel));
                case "Films":
                    return new ListModel(Summary + " Films", films, typeof(MovieModel));
                default:
                    return null;
            }

        }
    }
}
