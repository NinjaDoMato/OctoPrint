﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Models.Requests
{
    public class BedCommand : BaseCommand
    {
        public decimal Target { get; set; }
    }
}
