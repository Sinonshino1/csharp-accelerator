// IMPORTANT NOTE, C# REQUIRES LINES TO END WITH A SEMI COLON!!!

using System;
using System.Collections.Generic;   // Imports this so we can access the namespace in order to use specific funtions

class Program      // Creates the Program class, which is used as an entry point by the console application
{
    static List<Member> members = new List<Member>();       // creates a new, static list which can be accesssed by the whole program, static replaces Class instance name.

    static void Main(string[] args)         // Creating the overarching program which will be being run, args refers to command line arguments

    {
        bool running = true;       // Create a bool variable and set it to true

        while (running)     // Whilst the running variable is set to true, the while loop is running
        {
            Console.WriteLine("\n--- Gym Member Manager ---");      // Console.WriteLine acts similar to Python's print function to display text to the terminal
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. List Members");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();      // Create a variable called input with a string datatype equal to the output of Console.ReadLine

            switch (input)     // Creating a switch statement to find the result for the input variable
            {
                case "1":
                    AddMember();                    // Case 1 runs the AddMember function
                    break;
                case "2":
                    ListMembers();                   // Case 2 runs the ListMember function
                    break;
                case "3":
                    running = false;                // Case 3 sest the running variable to false, ending the while loop (closes the program)
                    break;
                default:
                    Console.WriteLine("Invalid option.");       // A default set to catch any error if user inputs anything which doesn't fit the expected results
                    break;
            }
        }
    }

    static void AddMember()     // Creating the AddMember function
    {
        Console.Write("Enter name: ");      // Writes this line to the terminal
        string name = Console.ReadLine();   // creates a variable with type string which reads the written line on the terminal, which in this context is the users input for the name variable

        Console.Write("Enter age: ");       //Writes this line to the terminal
        int age = int.Parse(Console.ReadLine());       // creates a new variable of type int, I do not currently understand how it sets the value.

        members.Add(new Member(name, age));             // Adds a new member to the members list using the name and age variable seen in this function above.
        Console.WriteLine("Member successfully added!");    // Verification for the user that the new member was added successfully
    }

    static void ListMembers()      // Creating the ListMember function
    {
        if (members.Count == 0)     // Runs an if statement and checks if the amount of members in the members list is equal to 0
        {
            Console.WriteLine("No members found.");     // If the if statement is true, shows the text No members found. in the terminal
            return;
        }

        foreach (var member in members)      // Iterates through the members list and runs the following code on each instance within the list. Var used to infer the datatype as we have more than one datatype in the list
        {
            Console.WriteLine(member);       // Writes the member object information to the terminal
        }
    }
}

class Member        // Creates the Member class, so we can have member objects to list in the other methods / store member objects
{
    public string Name { get; }     // Set a public scope, string property called Name. I do not understand the { get; } part
    public int Age { get; }     // Set a public scope, int property called Age. Takes the string value submitted in the console and converts it to an int value.

    public Member(string name, int age)     // Set a public scope Object called Member with attributes name and int, with no methods
    {
        Name = name;
        Age = age;
    }

    public override string ToString()       // Replaces the default ToString function
    {
        return $"{Name}, Age {Age}";        // This is a return statement the string, with F strings being used to directly pull the objects attributes into the text
    }
}
