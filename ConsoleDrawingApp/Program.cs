using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawinLibrary;

namespace ConsoleDrawingApp
{
    class Program
    {
        static Canvas workingCanvas = null;

        static void Main(string[] args)
        {
            SayWelcome();
            string command = "";
            WriteInfoLine("Enter q to quit, ? for help");

            while (command.ToUpper() != "Q")
            {
                command = Console.ReadLine();

                if (command == "?")
                    PleaseHelp();
                else
                    ProcessCommands(command);
            }
        }

        static void ProcessCommands(string input)
        {
            try
            {
                var allowedCommands = new string[] { "C", "L", "R", "B", "FILE" };
                string[] commands = input.Trim().Split(' ');
                string elementComand = commands.Length > 0 ? commands[0].ToUpper() : " ";

                if (allowedCommands.Contains(elementComand))
                {
                    if (elementComand == "FILE")
                    {
                        ProcessFromFile(commands[1]);
                    }
                    else if (elementComand == "C")
                    {
                        workingCanvas = new Canvas(int.Parse(commands[1]), int.Parse(commands[2]));
                    }
                    else if (workingCanvas != null)
                    {
                        switch (elementComand)
                        {
                            case "L":
                                Line line = new Line(int.Parse(commands[1]), int.Parse(commands[2]), int.Parse(commands[3]), int.Parse(commands[4]));
                                workingCanvas.Elements.Add(line);
                                break;
                            case "R":
                                Rectangle rectangle = new Rectangle(int.Parse(commands[1]), int.Parse(commands[2]), int.Parse(commands[3]), int.Parse(commands[4]));
                                workingCanvas.Elements.Add(rectangle);
                                break;
                            case "B":
                                BucketFill bucket = new BucketFill(int.Parse(commands[1]), int.Parse(commands[2]), commands[3]);
                                workingCanvas.Elements.Add(bucket);
                                break;
                        }
                    }
                    else
                    {
                        WriteErrorLine(string.Concat("Sorry, you need to create a canvas first, enter ? for help."));
                    }

                    if (workingCanvas != null && elementComand != "FILE")
                    {
                        WriteResultLine(workingCanvas.Draw(Environment.NewLine));
                    }
                }
                else
                {
                    WriteErrorLine(string.Concat("Sorry, command: ", elementComand, " is not allowed, enter ? for help."));
                }
            }
            catch (Exception ex)
            {
                WriteErrorLine(string.Concat("Sorry, something is wrong with the command input, enter ? for help."));
            }
        }

        static void ProcessFromFile(string filePath)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                        ProcessCommands(line);
                }
            }
            catch (Exception ex)
            {
                WriteErrorLine(string.Concat("An errror ocurred when trying to read the file,", ex.Message, " enter ? for help."));
            }
        }

        #region Private Methods

        static void SayWelcome()
        {
            WriteColoredLine("---------------------------<->---------------------------");
            WriteColoredLine("  > Welcome to Drawing Tool command line -Huge test- <");
            WriteColoredLine("");
            WriteColoredLine("   Author: Carlos Iván Mercado");
            WriteColoredLine("   Email: civan.cim@gmail.com");
            WriteColoredLine("---------------------------<->---------------------------");
            Console.WriteLine("");
        }
        static void PleaseHelp()
        {
            WriteResultLine("---------------------------<Need help?>---------------------------");
            WriteInfoLine("C w h  -->  Create Canvas: creates a new canvas of width w and height h." + Environment.NewLine);
            WriteInfoLine(@"L x1 y1 x2 y2  --> Create Line: creates a new line from (x1,y1) to (x2,y2). Currently only horizontal or vertical lines are supported." + Environment.NewLine);
            WriteInfoLine(@"R x1 y1 x2 y2  --> Create Rectangle: creates a new rectangle, whose upper left corner is (x1,y1) and lower right corner is (x2,y2)" + Environment.NewLine);
            WriteInfoLine(@"B x y c --> Bucket Fill: fills the entire area connected to (x,y) with 'colour' c." + Environment.NewLine);
            WriteInfoLine(@"FILE inputPath --> Run From File: runs batch of commands from specified path file.txt" + Environment.NewLine);
            WriteResultLine("----------------------------------<->------------------------------");

        }

        static void WriteColoredLine(string value)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));

            Console.ResetColor();
        }
        static void WriteResultLine(string value)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(value);

            Console.ResetColor();
        }
        static void WriteInfoLine(string value)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(value);

            Console.ResetColor();
        }
        static void WriteErrorLine(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);

            Console.ResetColor();
        }
    }
        #endregion
}
