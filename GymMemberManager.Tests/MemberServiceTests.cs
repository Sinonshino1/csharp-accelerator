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
        var service = new MemberService();

        // Act
        service.AddMember("Ben", 25);

        // Assert
        Assert.Single(service.GetAllMembers());
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

        service.AddMember("   Ben   ", 25);

        var member = service.GetAllMembers().First();

        Assert.Equal("Ben", member.Name);
    }
}