using Microsoft.VisualStudio.TestTools.UnitTesting;
using OctoPrint.API;
using OctoPrint.API.Models.Responses;
using OctoPrint.API.Models.Responses.Server;
using System.Net;
using System.Threading.Tasks;

namespace Octoprint.Tests
{
    [TestClass]
    public class BedTests
    {
        private Printer _printer = new Printer("http://raspberrypi.local", "E0F37A2615CE4F1E9BE28BFBB4E5A8E6");
         

        [TestMethod]
        public async Task ValidGetState()
        {
            var response = await _printer.Bed.GetState();

            Assert.IsTrue(response.Type == typeof(PrinterBedResponse));
            Assert.IsTrue(response.Code == (int)HttpStatusCode.OK);

            var responseContent = response.GetContent<PrinterBedResponse>();

            Assert.IsNotNull(responseContent);
            Assert.IsNotNull(responseContent.History);
            Assert.IsTrue(responseContent.History.Count > 0);
        }

        [TestMethod]
        public async Task ValidSetTemperature()
        {
            var response = await _printer.Bed.SetBedTemperature(0);

            Assert.IsTrue(response.Type == typeof(string));
            Assert.IsTrue(response.Code == (int)HttpStatusCode.NoContent);
        }
    }
}
