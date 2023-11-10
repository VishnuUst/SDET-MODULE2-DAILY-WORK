using System.Runtime.Serialization;

[Serializable]
internal class AssertionExceptions : Exception
{
    public AssertionExceptions()
    {
    }

    public AssertionExceptions(string? message) : base(message)
    {
    }

    public AssertionExceptions(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected AssertionExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}