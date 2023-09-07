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
        public static List<List<string>> FileParsing(StreamReader Reader)
        {
            List<List<string>> fileList = new List<List<string>>();
            while (!Reader.EndOfStream)
            {
                var line = Reader.ReadLine();
                Parsing(line, fileList);

            }
            return fileList;
        }
        public static void Parsing(string line, List<List<string>> fileList)
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
                    fileList.Add(newList);
                }
            }

        }
        public static void ListPrint(List<List<string>> fileList)
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                for (int j = 0; j < fileList[i].Count; j++)
                {
                    Console.Write($"{fileList[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}