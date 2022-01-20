using OctoPrint.API.Models;
using System;

namespace OctoPrint.API
{
    public class Printer
    {
        private string _apiUrl { get;set;}
        private string _accessToken { get; set; }

        public PrintHead PrintHead { get; set; }

        public Printer(string apiUrl, string accessToken)
        {
            _apiUrl = apiUrl;
            _accessToken = accessToken;
        }


    }
}
