using System;

class Program
{
    static void Main(string[] args)
    {
        // Call the functions to run the program logic
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    // Function to display the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to ask for and return the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function to ask for and return the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Function to square a number and return the result
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    // Function to display the final result back to the user
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}