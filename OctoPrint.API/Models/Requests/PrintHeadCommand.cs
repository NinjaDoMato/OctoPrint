using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Models.Requests
{
    internal class PrintHeadCommand
    {
        public string Command { get; set; }
        public List<string> Axes { get; set; }
        public bool Absolute { get; set; }
        public int Speed { get; set; }
        public int Factor { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
