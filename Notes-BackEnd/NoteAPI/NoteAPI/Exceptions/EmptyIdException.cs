namespace NoteAPI.Exceptions
{
    [Serializable]
    public class EmptyIdException : Exception
    {
        public EmptyIdException() { }
        public EmptyIdException(string message) : base(message) { }
    }
}
