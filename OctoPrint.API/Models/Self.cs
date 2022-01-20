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

        public async Task<IResponse> GetState()
        {
            try
            {
                var request = _apiURL.AppendPathSegment("/api/printer/printhead");

                var result = await request.GetJsonAsync<PrinterStateResponse>();

                return new Response<PrinterStateResponse>
                {
                    Data = result,
                    Code = 200,
                };    
            }
            catch (Exception ex)
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
