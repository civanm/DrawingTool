using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DrawinLibrary
{
    public class Canvas
    {
        /// <summary>
        /// "2D array that represents the drawing
        /// </summary>
        public string[,] Matrix { get; set; }

        /// <summary>
        /// Elements added to the canvas, each of them inherit from IElement interface
        /// </summary>
        public List<IElement> Elements { get; set; }

        /// <summary>
        /// Creates a New Canvas object,  With a matrix of string representing the drawing
        /// </summary>
        /// <param name="width">Width of the canvas</param>
        /// <param name="height">Height of the canvas</param>
        public Canvas(int width, int height)
        {
            int padding = 1;
            this.Matrix = new string[width + padding, height + padding];
            this.Elements = new List<IElement>();
        }
      
        /// <summary>
        /// Draws the canvas to string format and add it a border output. Usage: canvas.Draw(\r);
        /// </summary>
        /// <param name="lineBreak">linebreack for every row </param>
        /// <returns></returns>
        public string Draw(string lineBreak = "")
        {
            StringBuilder output = new StringBuilder();

            //fills the matrix with the elements added
            FillMatrix();

            // Get the bounds before looping.
            int boundX = Matrix.GetLength(0);
            int boundY = Matrix.GetLength(1);

            for (int y = 0; y <= boundY; y++)
            {
                for (int x = 0; x <= boundX; x++)
                {
                    if (y == 0 || y == boundY) //top / bottom border
                    {
                        output.Append("-");
                    }
                    else if (x == 0 || x == boundX) //left / right border
                    {
                        output.Append("|");
                    }
                    else
                    {
                        if (x < boundX && y < boundY) //matrix content
                            output.Append(Matrix.GetValue(x, y) ?? " ");
                    }
                }

                //appends a new row
                output.Append(lineBreak);
            }

            return output.ToString();
        }

        /// <summary>
        /// fills the canvas Matrix with the elements added to it, calls DrawToCanvas of each elements
        /// </summary>
        private void FillMatrix()
        {
            foreach (var element in this.Elements)
            {
                this.Matrix = element.DrawToCanvas(this.Matrix);
            }
        }
    }
}