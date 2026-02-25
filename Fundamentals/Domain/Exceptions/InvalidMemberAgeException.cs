namespace GymMemberManager.Domain.Exceptions;

public sealed class InvalidMemberAgeException : Exception
{
    public InvalidMemberAgeException() : base("Member must be at least 16 year old.") { }
}