namespace GymMemberManager.Models;       // Creates the Models namespace, usually, the name takes after the .csproj name, however, Fundamentals is unclear context here

public class Member        // Creates the Member class, so we can have member objects to list in the other methods / store member objects
{                          // If being called from a public method, needs to have the same accessability, in this case public
    public Guid Id { get; }     // Adds a Guid allowing for safe remove and updating patterns
    public string Name { get; }     // Set a public scope, string property called Name. The { get } means that it is a read only variable, nad can't be adjusted outside of the constructor
    public int Age { get; }     // Set a public scope, int property called Age. Takes the string value submitted in the console and converts it to an int value.

    public Member(Guid id, string name, int age)     // Set a public scope Object called Member with attributes name and int, with no methods
    {
        Id = id;
        Name = name;
        Age = age;
    }

    /*public override string ToString()       // Replaces the default ToString function
    {
        return $"{Name}, Age {Age}";        // This is a return statement the string, with F strings being used to directly pull the objects attributes into the text
    }*/ // LEGACY CODE
    public override string ToString()      // Replaces the default ToString function
        => $"{Name} (Age {Age}) [{Id}]";   // updated return statement showing name, age and id using fstrings
}