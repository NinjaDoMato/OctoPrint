using System.Collections.Generic;

namespace OctoPrint.API.Models.Responses.Server
{
    public class Temperature
    {
        public TempData Tool0 { get; set; }
        public TempData Tool1 { get; set; }
        public TempData Bed { get; set; }
        public IList<History> History { get; set; }
    }

    public class TempData
    {
        public decimal Actual { get; set; }
        public decimal Target { get; set; }
    }

    public class ToolTempData : TempData
    {
        public decimal Offset { get; set; }
    }

    public class History
    {
        public int Time { get; set; }
        public TempData Tool0 { get; set; }
        public TempData Tool1 { get; set; }
        public TempData Bed { get; set; }
    }

    public class SdState
    {
        public bool Ready { get; set; }
    }

    public class State
    {
        public string Text { get; set; }
        public Flags Flags { get; set; }
    }

    public class Flags
    {
        public bool Operational { get; set; }
        public bool Paused { get; set; }
        public bool Printing { get; set; }
        public bool Cancelling { get; set; }
        public bool Pausing { get; set; }
        public bool SdReady { get; set; }
        public bool Error { get; set; }
        public bool Ready { get; set; }
        public bool ClosedOrError { get; set; }
    }

    public class BedHistory
    {
        public int Time { get; set; }
        public TempData Bed { get; set; }
    }
}
