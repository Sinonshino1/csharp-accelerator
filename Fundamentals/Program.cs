// IMPORTANT NOTE, C# REQUIRES LINES TO END WITH A SEMI COLON!!!

using System;
using System.Collections.Generic;   // Imports this so we can access the namespace in order to use specific functions

class Program      // Creates the Program class, which is used as an entry point by the console application
{
    // static MemberService memberService = new MemberService();       // Unsure        // Old code using static, now transitioned into using namespaces

    static void Main(string[] args)         // Creating the overarching program which will be being run, args refers to command line arguments

    {
        var memberService = new MemberService();    // This creates a new variable object within the Program class called MemberService


        bool running = true;       // Create a bool variable and set it to true

        while (running)     // Whilst the running variable is set to true, the while loop is running
        {
            Console.WriteLine("\n--- Gym Member Manager ---");      // Console.WriteLine acts similar to Python's print function to display text to the terminal
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. List Members");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            string input = (Console.ReadLine() ?? "").Trim();      // Create a variable called input with a string datatype equal to the output of Console.ReadLine, also has the ?? "".Trim() to deal with CS8600 warnings

            switch (input)     // Creating a switch statement to find the result for the input variable
            {
                case "1":
                    AddMember(memberService);                    // Case 1 runs the AddMember function
                    break;
                case "2":
                    ListMembers(memberService);                   // Case 2 runs the ListMember function
                    break;
                case "3":
                    running = false;                // Case 3 sest the running variable to false, ending the while loop (closes the program)
                    break;
                default:
                    Console.WriteLine("Invalid option.");       // A default set to catch any error if user inputs anything which doesn't fit the expected results
                    break;
                                                    // Added a memberService argument to each the AddMember and ListMember methods
            }
        }
    }

    static void AddMember(MemberService memberService)     // Creating the AddMember function, added the argument memberSerice after removing static
    {
        Console.Write("Enter name: ");      // Writes this line to the terminal
        string name = (Console.ReadLine() ?? "").Trim();   // creates a variable with type string which reads the written line on the terminal, which in this context is the users input for the name variable
                                                        // Added ?? "" .Trim() to deal with null values by only accepting non null values to deal with edge cases
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty.");
            return;
        }


        int age;
        while (true)
        {
            Console.Write("Enter age: ");       // Writes this line to the terminal 
            string ageInput = (Console.ReadLine() ?? "").Trim();  // Reads the user input in the terminal and saves it in ageInput

            if (int.TryParse(ageInput, out age) && age >= 0)  // Tries to Parse the string into an int, provided age >= 0
            break;

            Console.WriteLine("Please enter a valid age (0 or above).");    // Provides a custom error message to user stating they did not enter a valid age
        }                                                            

        memberService.AddMember(name, age);               // Unsure
        Console.WriteLine("Member successfully added!");    // Verification for the user that the new member was added successfully
    }

    static void ListMembers(MemberService memberService)      // Creating the ListMember function, added the argument memberSerice after removing static
    {
        var members = memberService.GetAllMembers();

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


