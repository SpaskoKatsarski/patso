using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T02._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> destinations = new List<string>();

            string input = Console.ReadLine();

            string pattern = @"(\=|\/)(?<name>[A-Z][A-Za-z]{2,})\1";
            MatchCollection validDestinations = Regex.Matches(input, pattern);

            int points = 0;
            foreach (Match destination in validDestinations)
            {
                string currentDestination = destination.Groups["name"].Value;

                destinations.Add(currentDestination);
                points += currentDestination.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}
