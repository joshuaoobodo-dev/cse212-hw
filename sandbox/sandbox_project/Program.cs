using System;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        HangmanGame();
    }

    static void HangmanGame()
    {
        string[] words = { "apple", "banana", "cherry", "date", "elderberry" };

        var chances = 5;
        var word = words[new Random().Next(words.Length)];

        while (chances > 0)
        {
            Console.WriteLine($"You have {chances} chances left. Guess a letter:");
            var guess = Console.ReadLine();
            if (word.Contains(guess))
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Wrong!");
                chances--;
            }
        }
    }
}