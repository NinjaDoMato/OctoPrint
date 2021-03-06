using Microsoft.VisualStudio.TestTools.UnitTesting;
using OctoPrint.API;
using OctoPrint.API.Models.Responses;
using OctoPrint.API.Models.Responses.Server;
using System.Threading.Tasks;

namespace Octoprint.Tests
{
    [TestClass]
    public class PrinterTests
    {
        private Printer _printer = new Printer("http://raspberrypi.local", "E0F37A2615CE4F1E9BE28BFBB4E5A8E6");

        [TestMethod]
        public void ValidResponseCreate()
        {
            var response = new Response<PrinterStateResponse>();

            Assert.IsTrue(response.Type == typeof(PrinterStateResponse));
        }

        [TestMethod]
        public async Task ValidGetState()
        {
            var response = await _printer.Self.GetState();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Type == typeof(PrinterStateResponse));

            var printer = response.GetContent<PrinterStateResponse>();

            Assert.IsNotNull(printer);
        }
    }
}
