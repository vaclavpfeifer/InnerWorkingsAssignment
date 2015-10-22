using System;
using InnerWorkings.Processors;

namespace InnerWorkings.Adapters
{
    public class ConsoleWriterAdapter : IOutputWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void Write(string text)
        {
            Console.Write(text);
        }
    }
}