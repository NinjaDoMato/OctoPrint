using Microsoft.VisualStudio.TestTools.UnitTesting;
using OctoPrint.API;
using OctoPrint.API.Models.Responses;
using OctoPrint.API.Models.Responses.Server;
using System.Net;
using System.Threading.Tasks;

namespace Octoprint.Tests
{
    [TestClass]
    public class SdTests
    {
        private Printer _printer = new Printer("http://raspberrypi.local", "E0F37A2615CE4F1E9BE28BFBB4E5A8E6");

        [TestMethod]
        public async Task ValidInit()
        {
            var response = await _printer.Sd.Init();

            Assert.IsTrue(response.Type == typeof(string));
            Assert.IsTrue(response.Code == (int)HttpStatusCode.NoContent);
        }

        [TestMethod]
        public async Task ValidRefresh()
        {
            var response = await _printer.Sd.Refresh();

            Assert.IsTrue(response.Type == typeof(string));
            Assert.IsTrue(response.Code == (int)HttpStatusCode.NoContent);
        }

        [TestMethod]
        public async Task ValidRelease()
        {
            var response = await _printer.Sd.Release();

            Assert.IsTrue(response.Type == typeof(string));
            Assert.IsTrue(response.Code == (int)HttpStatusCode.NoContent);
        }
    }
}
