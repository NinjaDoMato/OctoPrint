using Flurl;
using Flurl.Http;
using OctoPrint.API.Models.Responses;
using OctoPrint.API.Models.Responses.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Models
{
    public class Self : PrinterPart
    {
        public Self(string apiUrl, string accessToken) : base(apiUrl, accessToken) { }

        /// <summary>
        /// Retrieves the current state of the printer.
        /// </summary>
        /// <returns>IResponse with types: PrinterStateResponse, Exception.</returns>
        public async Task<IResponse> GetState(bool teste)
        {
            try
            {
                var request = _apiURL.AppendPathSegment("/api/printer/printhead");

                var result = await request.GetJsonAsync<PrinterStateResponse>();

                return new Response<PrinterStateResponse>
                {
                    Data = new PrinterStateResponse(),
                    Code = 200,
                };    
            }
            catch (Exception ex)
            {
                return new Response<Exception>
                {
                    Code = 500,
                    Data = ex,
                };
            }
        }
    }
}
