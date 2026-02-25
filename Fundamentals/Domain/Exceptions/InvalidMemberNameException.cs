namespace GymMemberManager.Domain.Exceptions;

public sealed class InvalidMemberNameException : Exception
{
    public InvalidMemberNameException() : base("Name cannot be empty.") { }
}