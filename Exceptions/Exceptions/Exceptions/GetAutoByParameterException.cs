namespace Exceptions.Exceptions
{
    [Serializable]
    public class GetAutoByParameterException : Exception
    {
        public GetAutoByParameterException() : base() { }
        public GetAutoByParameterException(string message) : base(message) { }
        public GetAutoByParameterException(string message, Exception inner) : base(message, inner) { }
    }
}
