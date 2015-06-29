using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DrawinLibrary;

namespace DrawingTool.Models
{
    public class Draw
    {
        static Canvas workingCanvas = null;
        public Draw()
        {
        }

        public string ReadLines(string input = "")
        {
            string output = "";
            string[] lines = input.Split(',');
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                    output = string.Concat(output, ProcessCommands(line));
            }
            return output;
        }

        string ProcessCommands(string input)
        {
            string output = "";
            try
            {
                var allowedCommands = new string[] { "C", "L", "R", "B", "FILE" };
                string[] commands = input.Trim().Split(' ');
                string elementComand = commands.Length > 0 ? commands[0].ToUpper() : " ";

                if (allowedCommands.Contains(elementComand))
                {
                    if (elementComand == "C")
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
                        output = string.Concat("Sorry, you need to create a canvas first. <br/>");
                    }

                    if (workingCanvas != null)
                    {
                        output = workingCanvas.Draw("<br/>");
                    }
                }
                else
                {
                    output = string.Concat("Sorry, command: ", elementComand, " is not allowed. <br/>");
                }
            }
            catch (Exception ex)
            {
                output = string.Concat("Sorry, something is wrong with the command input. <br/>");
            }

            return output;
        }
    }
}