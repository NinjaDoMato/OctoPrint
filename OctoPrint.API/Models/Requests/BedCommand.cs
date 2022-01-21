namespace OctoPrint.API.Models.Requests
{
    public class BedCommand : BaseCommand
    {
        public decimal Target { get; set; }
    }
}
