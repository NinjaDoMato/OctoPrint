namespace OctoPrint.API.Models.Responses.Server
{
    public class PrinterStateResponse
    {
        public Temperature Temperature { get; set; }
        public SdState Sd { get; set; }
        public State State { get; set; }
    }
}
