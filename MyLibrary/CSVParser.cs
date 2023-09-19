using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using System;

namespace CSVLibrary
{
    public class CSVparsing
    {
        public List<List<string>> ParseFile(string text)
        {
            List<List<string>> fileList = new List<List<string>>();
            List<string> newList = new List<string>();
            bool inQuotes = false;
            string token = null;
            

            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case ',':
                        if (inQuotes == true)
                        {
                            token += text[i];
                        }
                        else
                        {
                            if (token != null)
                            {
                                newList.Add(token);
                                token = null;
                            }
                        }
                        break;
                    case '"':
                        if (inQuotes == true)
                        {
                            token += text[i];
                            newList.Add(token);
                            token = null;
                            inQuotes = false;
                        }
                        else
                        {
                            inQuotes = true;
                            token += text[i];
                        }
                        break;
                    case '\r':
                        if (text[i + 1] == '\n' && inQuotes==true)
                        {
                            i++;
                        }
                        else if(text[i + 1] == '\n' && inQuotes == false)
                        {
                            i++;
                            fileList.Add(newList);
                            newList = new List<string>();
                        }

                        break;
                    default:
                        token += text[i];
                        break;

                }

            }
            return fileList;
        }
        public List<string> ParseLine(string line)
        {
            bool inQuotes = false;
            string token = null;
            List<string> newList = new List<string>();

            for (int i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case ',':
                        if (inQuotes == true)
                        {
                            token += line[i];
                        }
                        else
                        {
                            if (token != null)
                            {
                                newList.Add(token);
                                token = null;
                            }
                        }
                        break;
                    case '"':
                        if (inQuotes == true)
                        {
                            token += line[i];
                            newList.Add(token);
                            token = null;
                            inQuotes = false;
                        }
                        else
                        {
                            inQuotes = true;
                            token += line[i];
                        }
                        break;
                    case '\r':
                        if(inQuotes == true)
                        {
                            Console.WriteLine("xd");
                        }

                        break;
                    default:
                        token += line[i];
                        break;

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
                    Console.Write($"{token}|");
                }
                Console.WriteLine();
            }
        }
    }
}