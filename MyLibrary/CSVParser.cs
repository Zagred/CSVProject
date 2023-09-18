using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace CSVLibrary
{
    public class CSVparsing
    {
        public List<List<string>> ParseFile(StreamReader Reader)
        {
            List<List<string>> fileList = new List<List<string>>();
            List<string> newList = new List<string>();
            while (!Reader.EndOfStream)
            {
                var line = Reader.ReadLine();
                bool inQuotes = false;
                string words = null;

                for (int i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case ',':
                            if (inQuotes == true)
                            {
                                words += line[i];
                            }
                            else
                            {
                                if (words != null)
                                {
                                    newList.Add(words);
                                    if (newList.Count == 3)
                                    {
                                        fileList.Add(newList);
                                        newList = new List<string>();
                                    }
                                    words = null;
                                }
                            }
                            break;
                        case '"':
                            if (inQuotes == true)
                            {
                                words += line[i];
                                newList.Add(words);
                                if(newList.Count == 3)
                                {
                                    fileList.Add(newList);
                                    newList = new List<string>();
                                }
                                words = null;
                                inQuotes = false;
                            }
                            else
                            {
                                inQuotes = true;
                                words += line[i];
                            }
                            break;
                        default:
                            words += line[i];
                            break;

                    }

                }
            }
            
            return fileList;
        }
        public void ListPrint(List<List<string>> fileList)
        {
            foreach (List<string> line in fileList)
            {
                foreach (string token in line)
                {
                    Console.Write($"{token}|");
                }
                Console.WriteLine();
            }
        }
    }
}