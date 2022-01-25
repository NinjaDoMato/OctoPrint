using Flurl;
using Flurl.Http;
using OctoPrint.API.Models.Requests;
using OctoPrint.API.Models.Responses;
using System;
using System.Net;
using System.Threading.Tasks;

namespace OctoPrint.API.Models
{
    public class PrintHead : Configurable
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
        /// <returns>IResponse with types: string, Exception.</returns>
        public async Task<IResponse> SetPosition(int x, int y, int z, int speed = 30, bool absolute = true)
        {
            try
            {
                var requestBody = new PrintHeadCommand
                {
                    X = x,
                    Y = y,
                    Z = z,
                    Speed = speed * 60,
                    Absolute = absolute,
                    Axes = new System.Collections.Generic.List<string> { "x", "y", "z" },
                    Command = "jog",
                };

                var request = _apiURL.AppendPathSegment("/api/printer/printhead")
                    .WithHeader("X-Api-Key", _accessToken);

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
        /// Home the print head
        /// </summary>
        /// <param name="homeAll"> Home all axis, if false will home only Y and X ax</param>
        /// <returns>IResponse with types: string, Exception.</returns>
        public async Task<IResponse> Home(bool homeAll = true)
        {
            try
            {
                var requestBody = new PrintHeadCommand
                {
                    Axes = new System.Collections.Generic.List<string> { "x", "y"},
                    Command = "home",
                };

                if (homeAll)
                    requestBody.Axes.Add("z");

                var request = _apiURL.AppendPathSegment("/api/printer/printhead")
                    .WithHeader("X-Api-Key", _accessToken);

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
    }
}
