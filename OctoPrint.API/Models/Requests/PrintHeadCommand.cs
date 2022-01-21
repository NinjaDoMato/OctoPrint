using System.Collections.Generic;

namespace OctoPrint.API.Models.Requests
{
    internal class PrintHeadCommand : BaseCommand
    {
        public List<string> Axes { get; set; }
        public bool Absolute { get; set; }
        public int Speed { get; set; }
        public int Factor { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
