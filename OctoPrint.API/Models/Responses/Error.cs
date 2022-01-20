using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Models.Responses
{
    public class Error : IResponse
    {
        public int Code { get; set; }
        public string ErrorMessage { get; set; }
    }
}
