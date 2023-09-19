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

                var csv = new CSVparsing();
                string text=File.ReadAllText(filePath);
                List<List<string>> student = csv.ParseFile(text);
                csv.ListPrint(student);
            
        }
        catch (Exception)
        {
            Console.WriteLine("Something went wrong.");
        }

    }
}