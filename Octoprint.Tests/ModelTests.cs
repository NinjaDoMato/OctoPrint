using Microsoft.VisualStudio.TestTools.UnitTesting;
using OctoPrint.API.Models.Responses;
using OctoPrint.API.Models.Responses.Server;

namespace Octoprint.Tests
{
    [TestClass]
    public class ModelTests : BaseTest
    {
        [TestMethod]
        public void ValidResponseCreate()
        {
            var response = new Response<PrinterStateResponse>();

            Assert.IsTrue(response.Type == typeof(PrinterStateResponse));
        }
    }
}
