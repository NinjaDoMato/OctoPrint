using OctoPrint.API.Models;
using OctoPrint.API.Models.Responses;
using OctoPrint.API.Models.Responses.Server;
using System;

namespace OctoPrint.API
{
    public class Printer
    {
        private string _apiUrl { get;set;}
        private string _accessToken { get; set; }

        public PrintHead PrintHead { get; set; }
        public Self Self { get; set; }

        public Printer(string apiUrl, string accessToken)
        {
            _apiUrl = apiUrl;
            _accessToken = accessToken;
        }
    }
}
