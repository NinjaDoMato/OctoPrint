using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Models.Responses.Server
{
    public class PrinterBedResponse
    {
        public ToolTempData Bed { get; set; }
        public IList<TempData> History { get; set; }
    }
}
