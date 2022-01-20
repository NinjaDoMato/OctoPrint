using Microsoft.VisualStudio.TestTools.UnitTesting;
using OctoPrint.API.Models.Responses.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoprint.Tests
{
    [TestClass]
    public class RequestTests : BaseTest
    {
        [TestMethod]
        public void ValidPrinterStateResponse()
        {
            var response = _printer.Self.GetState().Result;

            Assert.IsTrue(response.Type == typeof(PrinterStateResponse));
            Assert.IsInstanceOfType(response.GetContent<PrinterStateResponse>(), response.Type);
        }
    }
}
