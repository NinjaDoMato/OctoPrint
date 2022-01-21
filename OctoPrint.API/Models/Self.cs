using Flurl;
using Flurl.Http;
using OctoPrint.API.Models.Responses;
using OctoPrint.API.Models.Responses.Server;
using System;
using System.Threading.Tasks;

namespace OctoPrint.API.Models
{
    public class Self : PrinterPart
    {
        public Self(string apiUrl, string accessToken) : base(apiUrl, accessToken) { }

        /// <summary>
        /// Retrieves the current state of the printer.
        /// </summary>
        /// <param name="limit">Limit to history data.</param>
        /// <param name="history">Retrieve history data.</param>
        /// <returns>IResponse with types: PrinterStateResponse, Exception.</returns>
        public async Task<IResponse> GetState(int limit = 5, bool history = true)
        {
            try
            {
                var request = _apiURL.AppendPathSegment("/api/printer")
                    .WithHeader("X-Api-Key", _accessToken);

                var result = await request.GetJsonAsync<PrinterStateResponse>();

                return new Response<PrinterStateResponse>
                {
                    Data = result,
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
