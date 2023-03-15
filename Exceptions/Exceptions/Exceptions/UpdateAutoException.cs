namespace Exceptions.Exceptions
{
    [Serializable]
    public class UpdateAutoException : Exception
    {
        public UpdateAutoException() : base() { }
        public UpdateAutoException(string message) : base(message) { }
        public UpdateAutoException(string message, Exception inner) : base(message, inner) { }
    }
}
