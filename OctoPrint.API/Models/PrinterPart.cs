using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Models
{
    public class PrinterPart
    {
        protected string _apiURL { get; set; }
        protected string _accessToken { get; set; }

        public PrinterPart(string apiURL, string accessToken)
        {
            _accessToken = accessToken;
            _apiURL = apiURL;
        }

        protected string GetErrorMessage(int code)
        {
            var message = string.Empty;

            switch (code)
            {
                case (int)HttpStatusCode.Conflict:
                    message = "The printer was not available at the moment of request.";
                    break;

                case (int)HttpStatusCode.NotFound:
                    message = "The printer API was not found";
                    break;
            }

            return message;
        }
    }
}
