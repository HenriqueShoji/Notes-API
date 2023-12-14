namespace NoteAPI.Exceptions
{
    [Serializable]
    public class EmptyNoteException : Exception
    {
        public EmptyNoteException() { }
        public EmptyNoteException(string message) : base(message) { }
    }
}
