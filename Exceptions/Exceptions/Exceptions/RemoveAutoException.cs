namespace Exceptions.Exceptions
{
    [Serializable]
    public class RemoveAutoException : Exception
    {
        public RemoveAutoException() : base() { }
        public RemoveAutoException(string message) : base(message) { }
        public RemoveAutoException(string message, Exception inner) : base(message, inner) { }
    }
}
