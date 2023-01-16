namespace CommandPattern.IO.Contracts
{
    interface IWriter
    {
        void Write(object value);
        void WriteLine(object value);
    }
}
