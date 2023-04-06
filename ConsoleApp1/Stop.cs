using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Stop
    {
        
        
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("lines")]
            public List<string> Lines { get; set; }

            [JsonProperty("lon")]
            public double Longitude { get; set; }

            [JsonProperty("lat")]
            public double Latitude { get; set; }

            [JsonProperty("zone")]
            public string Zone { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
        
    }
}
