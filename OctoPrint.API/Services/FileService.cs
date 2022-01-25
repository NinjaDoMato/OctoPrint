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
    public interface IFileService
    {
        Task<IResponse> GetAllFiles();
        Task<IResponse> GetFile();
        Task<IResponse> SelectFile(string file, string location);
        Task<IResponse> UnselectFile(string file, string location);
        Task<IResponse> DeleteFile(string file, string location);

    }

    public class FileService : Configurable, IFileService
    {
        public FileService(string apiURL, string accessToken) : base(apiURL, accessToken)
        { }

        public Task<IResponse> DeleteFile(string file, string location)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetAllFiles()
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetFile()
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> SelectFile(string file, string location)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> UnselectFile(string file, string location)
        {
            throw new NotImplementedException();
        }
    }
}
