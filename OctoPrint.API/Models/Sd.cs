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
    public class Sd : Configurable
    {

        public Sd(string apiUrl, string accessToken) : base(apiUrl, accessToken)
        {
        }

        /// <summary>
        /// Retrieves the current state of the state.
        /// </summary>
        /// <returns>IResponse with types: SdStateResponse, Exception.</returns>
        public async Task<IResponse> GetState()
        {
            try
            {
                var request = _apiURL.AppendPathSegment("/api/printer/sd")
                    .WithHeader("X-Api-Key", _accessToken);

                var result = await request.GetJsonAsync<SdStateResponse>();

                return new Response<SdStateResponse>
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

        /// <summary>
        /// Init the sd.
        /// </summary>
        /// <returns>IResponse with types: string, Exception.</returns>
        public async Task<IResponse> Init()
        {
            try
            {
                var requestBody = new BaseCommand
                {
                    Command = "init",
                };

                var request = _apiURL.AppendPathSegment("/api/printer/sd")
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
        /// Release the sd from the printer.
        /// </summary>
        /// <returns>IResponse with types: string, Exception.</returns>
        public async Task<IResponse> Release()
        {
            try
            {
                var requestBody = new BaseCommand
                {
                    Command = "release",
                };

                var request = _apiURL.AppendPathSegment("/api/printer/sd")
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
        /// Refresh the sd.
        /// </summary>
        /// <returns>IResponse with types: string, Exception.</returns>
        public async Task<IResponse> Refresh()
        {
            try
            {
                var requestBody = new BaseCommand
                {
                    Command = "refresh",
                };

                var request = _apiURL.AppendPathSegment("/api/printer/sd")
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
