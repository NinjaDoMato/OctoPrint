using OctoPrint.API.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Models
{
    public internal class PrintHead
    {
        public PrintHead()
        {

        }

        /// <summary>
        /// Set the position of the printer head
        /// </summary>
        /// <param name="x">X axis position</param>
        /// <param name="y">Y axis postion</param>
        /// <param name="z">Z axis position</param>
        /// <param name="speed">Movement speed id mm/s</param>
        /// <param name="absolute">Determines if the position is absolute or relative to the current position</param>
        public void SetPosition(int x, int y, int z, int speed = 30, bool absolute = true)
        {

        }
    }
}
