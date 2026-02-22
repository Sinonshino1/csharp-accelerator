using GymMemberManager.Services;
using Xunit;
// Getting the dependancies

namespace GymMemberManager.Tests;    // Create the local namespace

public class MemberServiceTests
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

        Assert.Throws<ArgumentException>(() => 
            service.AddMember("", 25));
    }

    [Fact]
    public void AddMember_Underage_ThrowsArgumentException()
    {
        var service = new MemberService();

        Assert.Throws<ArgumentException>(() => 
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