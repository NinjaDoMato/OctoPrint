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

namespace OctoPrint.API.Models
{
    public class PrintHead : PrinterPart
    {
        public PrintHead(string apiUrl, string accessToken) : base(apiUrl, accessToken)
        {
        }

        /// <summary>
        /// Set the position of the printer head
        /// </summary>
        /// <param name="x">X axis position</param>
        /// <param name="y">Y axis postion</param>
        /// <param name="z">Z axis position</param>
        /// <param name="speed">Movement speed id mm/s</param>
        /// <param name="absolute">Determines if the position is absolute or relative to the current position</param>
        public async Task<IResponse> SetPosition(int x, int y, int z, int speed = 30, bool absolute = true)
        {
            try
            {
                var requestBody = new PrintHeadCommand
                {
                    X = x,
                    Y = y,
                    Z = z,
                    Speed = speed,
                    Absolute = absolute,
                    Command = "Jog",
                };

                var request = _apiURL.AppendPathSegment("/api/printer/printhead");

                var result = await request.PostJsonAsync(requestBody);

                if (result.StatusCode == (int)HttpStatusCode.NoContent)
                {
                    return new Response<object>
                    {
                        Code = (int)HttpStatusCode.NoContent
                    };
                }
                else
                {
                    return new Error
                    {
                        Code = (int)result.StatusCode,
                        ErrorMessage = GetErrorMessage(result.StatusCode)
                    };
                }
            }
            catch(Exception ex)
            {
                return new Error
                {
                    Code = 500,
                    ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message,
                };
            }
        }
    }
}
