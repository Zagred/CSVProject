using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSVLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVLibrary.Tests
{
    [TestClass()]
    public class CSVparsingTests
    {
        [TestMethod()]
        public void ParsingTest()
        {
            var csv = new CSVparsing();
            string text = File.ReadAllText("ime,\"fami,lia\",\"adres na \r\nchoveka\"");
            var result = csv.ParseFile(text);
            Assert.IsNotNull(result);
            Assert.IsTrue(result[0][0] == "ime");
            Assert.IsTrue(result[0][1] == "\"fami,lia\"");
            Assert.IsTrue(result[0][2] == "\"adres na choveka\"");

        }
    }
}