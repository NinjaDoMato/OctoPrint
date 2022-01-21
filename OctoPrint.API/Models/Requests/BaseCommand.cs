using Newtonsoft.Json;

namespace OctoPrint.API.Models.Requests
{
    public class BaseCommand
    {
        [JsonProperty("command")]
        public string Command { get; set; }
    }
}
