using Newtonsoft.Json;

namespace OctoPrint.API.Models.Requests
{
    public class JobCommand : BaseCommand
    {
        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
