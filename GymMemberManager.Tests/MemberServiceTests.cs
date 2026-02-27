using GymMemberManager.Services;        // We need access to our service in ordeer to run the tests against it, but we do not require our UI
using Xunit;        // Use Xunit for unit tests

using GymMemberManager.Domain.Exceptions;    // Provides access to the domain exceptions
// Getting the dependancies

namespace GymMemberManager.Tests;    // Create the local namespace

public class MemberServiceTests     // We create a class which will contain all of the tests we are going to use
{
    [Fact]
    public void AddMember_ValidInput_AddsMemberSuccessfully()
    {
        // Arrange
        var service = new MemberService();      // Create a new service to run tests

        // Act
        service.AddMember("Ben", 25);       // Create a member to run tests on

        // Assert
        Assert.Single(service.GetAllMembers());     // Run the results, see if it is what we expect.
    }

    [Fact]
    public void AddMember_BlankName_ThrowsArgumentException()
    {
        var service = new MemberService();

        Assert.Throws<InvalidMemberNameException>(() => 
            service.AddMember("", 25));
    }

    [Fact]
    public void AddMember_Underage_ThrowsArgumentException()
    {
        var service = new MemberService();

        Assert.Throws<InvalidMemberAgeException>(() => 
            service.AddMember("Ben", 15));
    }

    [Fact]
    public void AddMember_NameIsTrimmedBeforeStoring()
    {
        var service = new MemberService();

        service.AddMember("Ben", 25);

        var member = service.GetAllMembers().First();

        Assert.Equal("Ben", member.Name);
    }

    [Fact]
    public void AddMember_ReturnsId()
    {
        var service = new MemberService();

        var id = service.AddMember("Ben", 25);

        Assert.NotEqual(Guid.Empty, id);
    }

    [Fact]
    public void RemoveMember_ExistingId_ReturnsTrueAndRemoves()
    {
        var service = new MemberService();

        var id = service.AddMember("Ben", 25);

        var removed = service.RemoveMember(id);

        Assert.True(removed);

        Assert.Empty(service.GetAllMembers());
    }

    [Fact]
    public void RemoveMember_UnknownId_ReturnsFalse()
    {
        var service = new MemberService();

        var removed = service.RemoveMember(Guid.NewGuid());

        Assert.False(removed);
    }

    [Fact]
    public void FindMembersByName_IsCaseInsensitiveAndPartial()
    {
        var service = new MemberService();

        service.AddMember("Ben Field", 25);
        service.AddMember("Benny", 30);
        service.AddMember("Alice", 22);

        var results = service.FindMembersByName("ben");

        Assert.Equal(2, results.Count);
    }
}