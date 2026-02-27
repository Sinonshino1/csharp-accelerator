using System;
using System.Collections.Generic;    // Imported to access the namespace in order to use specific functions
                                     // Used for List and IReadOnlyList
using GymMemberManager.Models;       // Provides access to the Models namespace
using GymMemberManager.Domain.Exceptions;    // Provides access to all domain exceptions

namespace GymMemberManager.Services;  // Creates the Services namespace, // Usually, the name takes after the .csproj name, however, Fundamentals is unclear context here

public class MemberService      // Create the MemberService class
{
    private readonly List<Member> _members = new();     // Create a new, private, read-only members list, meaning they cannot be reassigned to a new list, but can be modified

    /*
    public void AddMember(string name, int age)     // Create a, public, AddMember method with two attributes being name and int
    {
        _members.Add(new Member(name, age));       // Returns the list so other methods can read it, but they cannot add to the list using this. Example of encapsulation to protect data structure
    }
      LEGACY_CODE   */
    
    public Guid AddMember(string name, int age)     // Creating a new AddMember method with filters, validation occurs before object generation in new version
                                                    // This way the service controls the domain integrity.
                                                    // Replace void with Guid
    {
        if (string.IsNullOrWhiteSpace(name))        // Prevents name being blank
        {
        // LEGACY    throw new ArgumentException("Name cannot be empty.");   // Throws a useful and readable exception
            throw new InvalidMemberNameException(); // Makes use of our new domain exception
        }

        if (age < 16)          // Age must be at least 16 or higher
        {
        // LEGACY    throw new ArgumentException("Member must be at least 16 years of age.");    // Throws a useful and readable exception
            throw new InvalidMemberAgeException(); // Makes use of our new domain exception
        }

        var member = new Member(Guid.NewGuid(), name.Trim(), age);   // added in function to generate a new user ID
        _members.Add(member);        // Returns the private member list for other methods to use
        return member.Id;             // Now returns the value of the new member's ID
    }

    public IReadOnlyList<Member> GetAllMembers()
    {
        return _members;
    }

    public IReadOnlyList<Member> FindMembersByName(string query)    // Create a public list which has a search filter input field
    {
        if (string.IsNullOrWhiteSpace(query))       // If earch bar is empty
        {
            return Array.Empty<Member>();       // Return an empty list
        }

        var q = query.Trim();       // Create a variable q to store the query search        
        return _members
            .Where(m => m.Name.Contains(q, StringComparison.OrdinalIgnoreCase))    // No idea what this does, why is it not in curly brackets?
            .ToList();      // No idea what this does
    }

    public bool RemoveMember(Guid Id)       // Add the method to remove members
    {
        var index = _members.FindIndex(m => m.Id == Id);    //creates a variable to store the member index
        if (index < 0) return false;

        _members.RemoveAt(index);
        return true;         // If the member removal worked as intended
    }

    public bool HasMembers()        // Creates a public boolean value showing if there are any members
    {
        return _members.Count > 0;   // returns true if members count is more than 0
    }
}