using System;
using System.Collections.Generic;    // Imported to access the namespace in order to use specific functions
                                     // Used for List and IReadOnlyList

public class MemberService      // Create the MemberService class
{
    private readonly List<Member> _members = new();     // Create a new, private, read-only members list, meaning they cannot be reassigned to a new list, but can be modified

    public void AddMember(string name, int age)     // Create a, public, AddMember method with two attributes being name and int
    {
        _members.Add(new Member(name, age));       // Returns the list so other methods can read it, but they cannot add to the list using this. Example of encapsulation to protect data structure
    }

    public IReadOnlyList<Member> GetAllMembers()    // Create a, public, list which conatains all members
    {
        return _members.AsReadOnly();       // Returns all members in a read only format
    }

    public bool HasMembers()        // Creates a public boolean value showing if there are any members
    {
        return _members.Count > 0;   // returns true if members count is more than 0
    }
}