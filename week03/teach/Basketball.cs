/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (players.ContainsKey(playerId))
            {
                players[playerId] += points; // Add points if player is already in dictionary
            }
            else
            {
                players[playerId] = points; // Set point to current points if player is not in dictionary
            }
        }

        // Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");
        var sortedPlayers = players.OrderByDescending(p => p.Value).ToList();

        var topPlayers = sortedPlayers.Take(10).ToList();

        Console.WriteLine("\nTop 10 Players by Total Points:\n");
        foreach (var player in topPlayers)
        {
            Console.WriteLine($"Player ID: {player.Key}, Total Points: {player.Value}");
        }
    }
}