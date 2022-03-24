using System;
using System.Text;

namespace T01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] cmdArgs = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "Move")
                {
                    int count = int.Parse(cmdArgs[1]);
                    string lettersToMove = message.Substring(0, count);
                    message = message.Remove(0, lettersToMove.Length);
                    message += lettersToMove;
                }
                else if (action == "Insert")
                {
                    // Insert 2 ":D"
                    // "Hello"
                    //  012
                    // He:Dllo

                    int index = int.Parse(cmdArgs[1]);
                    string value = cmdArgs[2];

                    StringBuilder replica = new StringBuilder(message);
                    replica.Insert(index, value);
                    message = replica.ToString();
                }
                else if (action == "ChangeAll")
                {
                    string messageToChange = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    message = message.Replace(messageToChange, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
