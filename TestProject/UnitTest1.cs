using CSVLibrary;
using System.Collections.Generic;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            List<List<string>> myList = new List<List<string>>();
            myList.Add(new List<string> { "ime, familia, \"adres na choveka\"" });
            myList.Add(new List<string> { "ime, familia, \"adres na choveka\"" });
            myList.Add(new List<string> { "ime, familia, \"adres na choveka\"" });
            myList.Add(new List<string> { "ime, familia, \"adres na choveka\"" });
            int max = myList.Max(x => x.Count);
            string output = string.Join(Environment.NewLine, myList[max].ToArray());
            //
            CSVparsing.Parsing(output, myList);
        }
    }
}