﻿// The first line of the input will be your raw activation key. It will consist of letters and numbers only. 
// After that, until the "Generate" command is given, you will be receiving strings with instructions
// for different operations that need to be performed upon the raw activation key.
// There are several types of instructions, split by ">>>":
// •	"Contains>>>{substring}":
// o If the raw activation key contains the given substring, prints: "{raw activation key} contains {substring}".
// o Otherwise, prints: "Substring not found!"
// •	"Flip>>>Upper/Lower>>>{startIndex}>>>{endIndex}":
// o Changes the substring between the given indices (the end index is exclusive) to upper or lower case and then prints the activation key.
// o	All given indexes will be valid.
// •	"Slice>>>{startIndex}>>>{endIndex}":
// o Deletes the characters between the start and end indices (the end index is exclusive) and prints the activation key.
// o	Both indices will be valid.
// Input
// •	The first line of the input will be a string consisting of letters and numbers only. 
// •	After the first line, until the "Generate" command is given, you will be receiving strings.
// Output
// •	After the "Generate" command is received, print:
// o   "Your activation key is: {activation key}"

//     Input
// abcdefghijklmnopqrstuvwxyz
// Slice>>>2>>>6
// Flip>>>Upper>>>3>>>14
// Flip>>>Lower>>>5>>>7
// Contains>>>def
// Contains>>>deF
// Generate
//     Output
// abghijklmnopqrstuvwxyz
// abgHIJKLMNOPQRstuvwxyz
// abgHIjkLMNOPQRstuvwxyz
// Substring not found!
// Substring not found!
// Your activation key is: abgHIjkLMNOPQRstuvwxyz

namespace ActivationKey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] command = input.Split(">>>").ToArray();
                string operation = command[0];
                if (operation == "Contains")
                {
                    string substring = command[1];
                    if (!rawActivationKey.Contains(substring))
                    {
                        Console.WriteLine("Substring not found!");
                        continue;
                    }
                    Console.WriteLine($"{rawActivationKey} contains {substring}");
                }
                else if (operation == "Flip")
                {
                    string lowerOrUpper = command[1];
                    int startIndex = int.Parse(command[2]);
                    int endIndex = int.Parse(command[3]);
                    if (lowerOrUpper == "Upper")
                    {
                        string prefix = rawActivationKey.Substring(0, startIndex);
                        string middle = rawActivationKey
                            .Substring(startIndex, endIndex - startIndex)
                            .ToUpper();
                        string suffix = rawActivationKey.Substring(endIndex, rawActivationKey.Length - endIndex);
                        rawActivationKey = prefix + middle + suffix;
                        Console.WriteLine(rawActivationKey);

                    }
                    else
                    {
                        string prefix = rawActivationKey.Substring(0, startIndex);
                        string middle = rawActivationKey
                            .Substring(startIndex, endIndex - startIndex)
                            .ToLower();
                        string suffix = rawActivationKey.Substring(endIndex, rawActivationKey.Length - endIndex);
                        rawActivationKey = prefix + middle + suffix;
                        Console.WriteLine(rawActivationKey);
                    }
                }
                else //operation == "Slice"
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    rawActivationKey = rawActivationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(rawActivationKey);
                }
            }
            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }
    }
}
