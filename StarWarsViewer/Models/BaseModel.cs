using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsViewer.Models
{
    public class BaseModel : JsonModel
    {
        public string count;
        public string next;
        public string previous;
        public List<MovieModel> results;

        public new List<string> DisplayList
        {
            get
            {
                return (from item in results
                        select item.title).ToList();
            }
        }

        public override JsonModel ExpandItem(string item)
        {
            throw new NotImplementedException();
        }
    }
}
