using OctoPrint.API.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System.Net;
using OctoPrint.API.Models.Responses;
using OctoPrint.API.Models.Responses.Server;

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
                        Code = (int)result.StatusCode,
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
        /// <returns>IResponse with types: PrinterBedResponse, Exception.</returns>
        public async Task<IResponse> GetState(bool teste)
        {
            try
            {
                var request = _apiURL.AppendPathSegment("/api/printer/bed");

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
