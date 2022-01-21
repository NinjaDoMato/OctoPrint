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
        public Bed Bed { get; set; }

        public Printer(string apiUrl, string accessToken)
        {
            _apiUrl = apiUrl;
            _accessToken = accessToken;

            Self = new Self(_apiUrl, _accessToken);
            PrintHead = new PrintHead(_apiUrl, _accessToken);
            Bed = new Bed(_apiUrl, _accessToken);
        }
    }
}
