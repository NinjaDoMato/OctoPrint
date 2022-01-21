using System.Collections.Generic;

namespace OctoPrint.API.Models.Responses.Server
{
    public class PrinterBedResponse
    {
        public ToolTempData Bed { get; set; }
        public IList<TempData> History { get; set; }
    }
}
