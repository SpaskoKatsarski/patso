using System;
using System.Text.RegularExpressions;

namespace T02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\#|\|)(?<item>[A-Za-z ]+)\1(?<expirationDate>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";

            string input = Console.ReadLine();

            MatchCollection food = Regex.Matches(input, pattern);

            int totalCal = 0;
            foreach (Match match in food)
            {
                totalCal += int.Parse(match.Groups["calories"].Value);
            }

            int daysToSurvive = totalCal /= 2000;

            Console.WriteLine($"You have food to last you for: {daysToSurvive} days!");
            foreach (Match match in food)
            {
                Console.WriteLine($"Item: {match.Groups["item"].Value}, Best before: {match.Groups["expirationDate"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}
