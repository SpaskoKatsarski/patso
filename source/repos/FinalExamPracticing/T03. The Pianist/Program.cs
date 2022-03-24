using System;
using System.Collections.Generic;

namespace T03._The_Pianist
{
    class Composer
    {
        public Composer(string name, string key)
        {
            this.Name = name;
            this.Key = key; 
        }

        public string Name { get; set; }

        public string Key { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // The key is the Piece.
            Dictionary<string, Composer> pieces = new Dictionary<string, Composer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string rawInput = Console.ReadLine();

                string[] arguments = rawInput.Split('|', StringSplitOptions.RemoveEmptyEntries);

                string piece = arguments[0];
                string composer = arguments[1];
                string key = arguments[2];

                pieces.Add(piece, new Composer(composer, key));
            }

            string command;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];
                string currentPiece = cmdArgs[1];

                if (action == "Add")
                {
                    string composerName = cmdArgs[2];
                    string key = cmdArgs[3];

                    if (pieces.ContainsKey(currentPiece))
                    {
                        Console.WriteLine($"{currentPiece} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(currentPiece, new Composer(composerName, key));
                        Console.WriteLine($"{currentPiece} by {composerName} in {key} added to the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    if (!pieces.ContainsKey(currentPiece))
                    {
                        Console.WriteLine($"Invalid operation! {currentPiece} does not exist in the collection.");
                    }
                    else
                    {
                        pieces.Remove(currentPiece);
                        Console.WriteLine($"Successfully removed {currentPiece}!");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string newKey = cmdArgs[2];

                    if (!pieces.ContainsKey(currentPiece))
                    {
                        Console.WriteLine($"Invalid operation! {currentPiece} does not exist in the collection.");
                    }
                    else
                    {
                        pieces[currentPiece].Key = newKey;
                        Console.WriteLine($"Changed the key of {currentPiece} to {newKey}!");
                    }
                }
            }

            foreach (KeyValuePair<string, Composer> kvp in pieces)
            {
                Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value.Name}, Key: {kvp.Value.Key}");
            }
        }
    }
}
