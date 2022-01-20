using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Models.Responses
{
    public class NoContent : IResponse
    {
        public int Code { get; set; }
    }
}
