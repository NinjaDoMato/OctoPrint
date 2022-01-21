using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OctoPrint.API.Models.Requests
{
    internal class PrintHeadCommand : BaseCommand
    {
        [JsonProperty("axes")]
        public List<string> Axes { get; set; }
        [JsonProperty("absolute")]
        public bool Absolute { get; set; }
        [JsonProperty("speed")]
        public int Speed { get; set; }
        //public int Factor { get; set; }
        [JsonProperty("x")]
        public int X { get; set; }
        [JsonProperty("y")]
        public int Y { get; set; }
        [JsonProperty("z")]
        public int Z { get; set; }
    }
}
