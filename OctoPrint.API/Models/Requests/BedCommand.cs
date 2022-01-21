using Newtonsoft.Json;

namespace OctoPrint.API.Models.Requests
{
    public class BedCommand : BaseCommand
    {
        [JsonProperty("target")]
        public decimal Target { get; set; }
    }
}
