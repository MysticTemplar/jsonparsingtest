using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace StarWarsViewer.Client
{
    public class APIClient
    {
        private static APIClient netClient;

        public static APIClient GetInstance()
        {
            if (netClient == null)
                netClient = new APIClient();

            return netClient;
        }

        private HttpClient client;
        private Dictionary<string, object> Cache;

        private APIClient()
        {
            client = new HttpClient();
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "StarWarsViewer", "cache.json")))
                try
                {
                    Cache = (Dictionary<string, object>)JsonConvert.DeserializeObject(File.ReadAllText(Path.Combine(
                                                                                                        Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                                                                                                        "StarWarsViewer", "cache.json")), 
                                                                                                        typeof(Dictionary<string, object>));
                }
                catch //Cache file is corrupted, start a new cache.
                {
                    Cache = new Dictionary<string, object>();
                }
            else
                Cache = new Dictionary<string, object>();
            
        }

        ~APIClient()
        {
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "StarWarsViewer")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "StarWarsViewer"));

            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "StarWarsViewer", "cache.json"), 
                                JsonConvert.SerializeObject(Cache));
        }

        

        public async Task<object> GetJSONAsync(string url, Type type)
        {
            string value;
            if (Cache.ContainsKey(url))
                value = JsonConvert.SerializeObject(Cache[url]);
            else
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    value = await response.Content.ReadAsStringAsync();

                }
                else
                {
                    throw new Exception("Error querrying " + response.ReasonPhrase);
                }
            }
            var result = JsonConvert.DeserializeObject(value, type);
            Cache[url] = result;
            return result;

        }


    }
}
