using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace DrawingLibrary
{
    public class Rectangle : IElement
    {
        /// <summary>
        /// Rectangles Properties
        /// </summary>
        public ElementProperties Properties { get; set; }

        /// <summary>
        /// Creates a new rectangle, whose upper left corner is (x1,y1) and lower right corner is (x2,y2). Horizontal and vertical
        /// lines will be drawn using the 'x' character by default.
        /// </summary>
        /// <param name="x1">Starting point for X</param>
        /// <param name="y1">Starting pint for Y</param>
        /// <param name="x2">Ending Point for X</param>
        /// <param name="y2">Ending Point for Y</param>
        public Rectangle(int x1, int y1, int x2, int y2)
        {
            this.Properties = new ElementProperties(x1, y1, x2, y2);
        }

        /// <summary>
        /// Draws the Rectangle to a given canvas
        /// </summary>
        /// <param name="canvas">Canvas to draw</param>
        /// <returns>A drawn canvas</returns>
        public string[,] DrawToCanvas(string[,] canvas)
        {
            if (this.IsValid(canvas))
            {
                //uses four lines to make the rectangle
                Line lineTop = new Line(
                    this.Properties.X1,
                    this.Properties.Y1,
                    this.Properties.X2,
                    this.Properties.Y1
                );

                Line lineLeft = new Line(
                    this.Properties.X1,
                    this.Properties.Y1,
                    this.Properties.X1,
                    this.Properties.Y2
                );

                Line lineBottom = new Line(
                    this.Properties.X1,
                    this.Properties.Y2,
                    this.Properties.X2,
                    this.Properties.Y2
                );

                Line lineRight = new Line(
                    this.Properties.X2,
                    this.Properties.Y1,
                    this.Properties.X2,
                    this.Properties.Y2
                    );

                canvas = lineLeft.DrawToCanvas(canvas);
                canvas = lineTop.DrawToCanvas(canvas);
                canvas = lineBottom.DrawToCanvas(canvas);
                canvas = lineRight.DrawToCanvas(canvas);
            }

            return canvas;
        }

        /// <summary>
        /// Indicates if Element can be draw
        /// </summary>
        /// <param name="canvas">Canvas to draw</param>
        /// <returns>bool indicating if it can be drawn</returns>
        public bool IsValid(string[,] canvas = null)
        {
            if (canvas != null
                  && (Util.IsOutCanvas(this.Properties.X1, this.Properties.Y1, canvas)
                      || Util.IsOutCanvas(this.Properties.X2, this.Properties.Y2, canvas)))
            {
                return false;
            }

            return true;
        }
    }
}