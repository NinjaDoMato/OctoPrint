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
        /// Start a job for the currentselected file, returns 409 if a job is already running
        /// </summary>
        /// <returns>IResponse with types: JobDetails, Exception.</returns>
        Task<IResponse> StartJob();
    }

    public class JobService : Configurable, IJobService
    {
        public JobService(string apiURL, string accessToken) : base(apiURL, accessToken)
        { }

        public async Task<IResponse> GetCurrentJob()
        {
            try
            {
                var request = _apiURL
                    .AppendPathSegment("/api/job")
                    .WithHeader("X-Api-Key", _accessToken);

                var response = await request.PostJsonAsync(new BaseCommand { Command = "start" });

                return new Response<JobDetails>
                {
                    Data = JsonConvert.DeserializeObject<JobDetails>(response.ResponseMessage.Content.ReadAsStringAsync().Result),
                    Code = response.StatusCode
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

        public async Task<IResponse> StartJob()
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
