namespace InnerWorkings.Adapters
{
    public interface IOutputWriter
    {
        void WriteLine(string line);

        void Write(string text);
    }
}