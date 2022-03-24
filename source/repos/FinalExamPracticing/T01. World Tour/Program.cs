using System;

namespace T01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] cmdArgs = command.Split(':', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "Add Stop")
                {
                    int index = int.Parse(cmdArgs[1]);

                    if (index < 0 || index >= message.Length)
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    string newLocation = cmdArgs[2];

                    message = message.Insert(index, newLocation);
                }
                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    if ((startIndex < 0 || startIndex >= message.Length) || (endIndex < 0 || endIndex >= message.Length))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    message = message.Remove(startIndex, endIndex - startIndex + 1);
                }
                else if (action == "Switch")
                {
                    string oldString = cmdArgs[1];

                    if (message.Contains(oldString))
                    {
                        message = message.Replace(oldString, cmdArgs[2]);
                    }
                }

                Console.WriteLine(message);
                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {message}");
        }
    }
}
