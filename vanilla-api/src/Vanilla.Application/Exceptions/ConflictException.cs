using System.Runtime.Serialization;

namespace Vanilla.Application.Exceptions;

[Serializable]
public class ConflictException : Exception
{
    public ConflictException()
    {
    }

    public ConflictException(string message) : base(message)
    {
    }
}