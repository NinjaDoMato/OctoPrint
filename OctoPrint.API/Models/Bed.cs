using Flurl;
using Flurl.Http;
using OctoPrint.API.Models.Requests;
using OctoPrint.API.Models.Responses;
using OctoPrint.API.Models.Responses.Server;
using System;
using System.Net;
using System.Threading.Tasks;

namespace OctoPrint.API.Models
{
    public class Bed : PrinterPart
    {
        public Bed(string apiUrl, string accessToken) : base(apiUrl, accessToken)
        {
        }


        /// <summary>
        /// Sets the temperature of the print bed
        /// </summary>
        /// <param name="temp"></param>
        /// <returns>IResponse with types: string, Exception.</returns>
        public async Task<IResponse> SetBedTemperature(decimal temp)
        {
            try
            {
                var requestBody = new BedCommand
                {
                    Command = "target",
                    Target = temp
                };

                var request = _apiURL.AppendPathSegment("/api/printer/bed");

                var result = await request.PostJsonAsync(requestBody);

                if (result.StatusCode == (int)HttpStatusCode.NoContent)
                {
                    return new Response<string>
                    {
                        Code = (int)HttpStatusCode.NoContent,
                        Data = "Command executed successfully."
                    };
                }
                else
                {
                    return new Response<Exception>
                    {
                        Code = result.StatusCode,
                        Data = new Exception(GetErrorMessage(result.StatusCode))
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response<Exception>
                {
                    Code = 500,
                    Data = ex
                };
            }
        }

        /// <summary>
        /// Retrieves the current state of the print bed.
        /// </summary>
        /// <param name="limit">Limit to history data.</param>
        /// <param name="history">Retrieve history data.</param>
        /// <returns>IResponse with types: PrinterBedResponse, Exception.</returns>
        public async Task<IResponse> GetState(int limit = 5, bool history = true)
        {
            try
            {
                var request = _apiURL.AppendPathSegment("/api/printer/bed")
                    .SetQueryParam("limit", limit)
                    .SetQueryParam("history", history);

                var result = await request.GetJsonAsync<PrinterBedResponse>();

                return new Response<PrinterBedResponse>
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
