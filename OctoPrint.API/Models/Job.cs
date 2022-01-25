using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Models
{
    public class JobDetails
    {
        public JobData Job { get; set; }
        public Progress Progress { get; set; }
        public string State { get; set; }
        public string Error { get; set; }
    }
    public class JobData
    {
        public File File { get; set; }
        public int EstimatedPrintTime { get; set; }
        public Filament Filament { get; set; }
    }

    public class File
    {
        public string Name { get; set; }
        public string Origin { get; set; }
        public int Size { get; set; }
        public int Date { get; set; }
    }

    public class Filament
    {
        public ToolData Tool0 { get; set; }
    }

    public class ToolData
    {
        public int Length { get; set; }
        public float Volume { get; set; }
    }

    public class Progress
    {
        public decimal Completion { get; set; }
        public int Filepos { get; set; }
        public int PrintTime { get; set; }
        public int PrintTimeLeft { get; set; }
    }
}
