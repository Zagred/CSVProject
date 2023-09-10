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
            while (!Reader.EndOfStream)
            {
                var line = Reader.ReadLine();
                fileList.Add(ParseLine(line));

            }
            return fileList;
        }
        public List<string> ParseLine(string line)
        {
            string words = null;
            List<string> newList = new List<string>();

            for (int i = 0; i < line.Length; i++)
            {
                words += line[i];

                if (line[i] == ',')
                {
                    words = words.Trim(',');
                    words = words.Trim(' ');
                    newList.Add(words);
                    words = null;
                }
                else if (line[i] == '"')
                {
                    for (int j = i + 1; j < line.Length; j++)
                    {
                        if (line[j] != '"')
                        {
                            words += line[j];
                        }
                        else
                        {
                            words += line[j];
                            newList.Add(words);

                            words = null;
                            i = j;
                            break;
                        }
                    }
                }
            }
            return newList;
        }
        public void ListPrint(List<List<string>> fileList)
        {
            foreach (List<string> line in fileList)
            {
                foreach (string token in line)
                {
                    Console.Write($"{token} ");
                }
                Console.WriteLine();
            }
        }
    }
}