using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using OctoPrint.API.Models;
using OctoPrint.API.Models.Requests;
using OctoPrint.API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OctoPrint.API.Services
{
    public interface IJobService
    {
        /// <summary>
        /// Returns the current job details
        /// </summary>
        /// <returns>IResponse with types: JobDetails, Exception.</returns>
        Task<IResponse> GetCurrentJob();

        /// <summary>
        /// Pauses the current running job
        /// </summary>
        /// <returns>IResponse with types: JobDetails, Exception.</returns>
        Task<IResponse> Pause();

        /// <summary>
        /// Cancel the current running job
        /// </summary>
        /// <returns>IResponse with types: JobDetails, Exception.</returns>
        Task<IResponse> Cancel();

        /// <summary>
        /// Resume the current paused job
        /// </summary>
        /// <returns>IResponse with types: JobDetails, Exception.</returns>
        Task<IResponse> Resume();


        /// <summary>
        /// Start the job for the current selected file
        /// </summary>
        /// <returns>IResponse with types: JobDetails, Exception.</returns>
        Task<IResponse> Start();
    }

    public class JobService : Configurable, IJobService
    {
        public JobService(string apiURL, string accessToken) : base(apiURL, accessToken)
        { }

        public async Task<IResponse> Start()
        {
            try
            {
                var request = _apiURL
                    .AppendPathSegment("/api/job")
                    .WithHeader("X-Api-Key", _accessToken);

                var response = await request.PostJsonAsync(new BaseCommand { Command = "start" });

                if (response.StatusCode == (int)HttpStatusCode.NoContent)
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
                        Code = response.StatusCode,
                        Data = new Exception(GetErrorMessage(response.StatusCode))
                    };
                }
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

        public async Task<IResponse> Pause()
        {
            try
            {
                var request = _apiURL
                    .AppendPathSegment("/api/job")
                    .WithHeader("X-Api-Key", _accessToken);

                var response = await request.PostJsonAsync(new JobCommand { Command = "pause", Action = "pause" });

                if (response.StatusCode == (int)HttpStatusCode.NoContent)
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
                        Code = response.StatusCode,
                        Data = new Exception(GetErrorMessage(response.StatusCode))
                    };
                }
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

        public async Task<IResponse> Cancel()
        {
            try
            {
                var request = _apiURL
                    .AppendPathSegment("/api/job")
                    .WithHeader("X-Api-Key", _accessToken);

                var response = await request.PostJsonAsync(new BaseCommand { Command = "cancel" });

                if (response.StatusCode == (int)HttpStatusCode.NoContent)
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
                        Code = response.StatusCode,
                        Data = new Exception(GetErrorMessage(response.StatusCode))
                    };
                }
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

        public async Task<IResponse> Resume()
        {
            try
            {
                var request = _apiURL
                    .AppendPathSegment("/api/job")
                    .WithHeader("X-Api-Key", _accessToken);

                var response = await request.PostJsonAsync(new JobCommand { Command = "pause", Action = "resume" });

                if (response.StatusCode == (int)HttpStatusCode.NoContent)
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
                        Code = response.StatusCode,
                        Data = new Exception(GetErrorMessage(response.StatusCode))
                    };
                }
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

        public async Task<IResponse> GetCurrentJob()
        {
            try
            {
                var request = _apiURL
                    .AppendPathSegment("/api/job")
                    .WithHeader("X-Api-Key", _accessToken);

                var response = await request.GetJsonAsync<JobDetails>();

                return new Response<JobDetails>
                {
                    Data = response,
                    Code = 200
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
