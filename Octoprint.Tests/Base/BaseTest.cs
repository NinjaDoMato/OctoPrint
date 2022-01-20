using Microsoft.VisualStudio.TestTools.UnitTesting;
using OctoPrint.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoprint.Tests
{
    [TestClass]
    public class BaseTest
    {
        public readonly Printer _printer = new Printer("", "");

    }
}
