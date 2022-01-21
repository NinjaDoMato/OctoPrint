using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Models.Responses.Server
{
    public class PrinterStateResponse
    {
        public Temperature Temperature { get; set; }
        public SdState Sd { get; set; }
        public State State { get; set; }
    }
}
