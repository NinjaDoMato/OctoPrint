using Microsoft.VisualStudio.TestTools.UnitTesting;
using OctoPrint.API;
using OctoPrint.API.Models.Responses;
using OctoPrint.API.Models.Responses.Server;
using System.Threading.Tasks;

namespace Octoprint.Tests
{
    [TestClass]
    public class PrintHeadTests
    {
        private Printer _printer = new Printer("http://raspberrypi.local", "E0F37A2615CE4F1E9BE28BFBB4E5A8E6");

       
        [TestMethod]
        public async Task ValidSetPosition()
        {
            var response = await _printer.PrintHead.SetPosition(20, 20, 20);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Type == typeof(string));

            var responseContent = response.GetContent<string>();

            Assert.IsNotNull(responseContent);
            Assert.IsTrue(responseContent == "Command executed successfully.");
        }

        [TestMethod]
        public async Task ValidHome()
        {
            var response = await _printer.PrintHead.Home();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Type == typeof(string));

            var responseContent = response.GetContent<string>();

            Assert.IsNotNull(responseContent);
            Assert.IsTrue(responseContent == "Command executed successfully.");
        }
    }
}
