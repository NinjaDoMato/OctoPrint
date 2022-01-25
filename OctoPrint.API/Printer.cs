using OctoPrint.API.Models;
using OctoPrint.API.Services;

namespace OctoPrint.API
{
    public class Printer
    {
        private readonly IJobService _jobService;
        private readonly IFileService _fileService;
        private string _apiUrl { get; set; }
        private string _accessToken { get; set; }

        public PrintHead PrintHead { get; set; }
        public Self Self { get; set; }
        public Bed Bed { get; set; }
        public Sd Sd { get; set; }

        public Printer(string apiUrl, string accessToken)
        {
            _apiUrl = apiUrl;
            _accessToken = accessToken;

            Self = new Self(_apiUrl, _accessToken);
            PrintHead = new PrintHead(_apiUrl, _accessToken);
            Bed = new Bed(_apiUrl, _accessToken);
            Sd = new Sd(_apiUrl, _accessToken);

            _jobService = new JobService(apiUrl, accessToken);
            _fileService = new FileService(apiUrl, accessToken);
        }
    }
}
