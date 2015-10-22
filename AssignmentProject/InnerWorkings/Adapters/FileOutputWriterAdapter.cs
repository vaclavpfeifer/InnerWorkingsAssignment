using System;

namespace InnerWorkings.Adapters
{
    public class FileOutputWriterAdapter : IOutputWriter
    {
        public void WriteLine(string line)
        {
            throw new NotImplementedException();
        }

        public void Write(string text)
        {
            throw new NotImplementedException();
        }
    }
}