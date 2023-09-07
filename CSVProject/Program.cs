using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
using CSVLibrary;
public class Program
{
    static void Main(string[] args)
    {
        string filePath = args[0];
        try
        {
            using (var reader = new StreamReader(File.OpenRead(filePath)))
            {

                List<List<string>> student = CSVparsing.FileParsing(reader);
                CSVparsing.ListPrint(student);

            }
        }
        catch (Exception)
        {

            Console.WriteLine("Something went wrong.");
        }

    }
}