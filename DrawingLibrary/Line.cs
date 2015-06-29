using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawingLibrary
{
    public class Line : IElement
    {
        /// <summary>
        /// Element Properties
        /// </summary>
        public ElementProperties Properties { get; set; }

        /// <summary>
        /// Creates a new line from point (x1,y1) to (x2, y2),
        /// only Horizontal and Vertical lines are supported
        /// </summary>
        /// <param name="x1">Starting point for X</param>
        /// <param name="y1">Starting pint for Y</param>
        /// <param name="x2">Ending Point for X</param>
        /// <param name="y2">Ending Point for Y</param>
        /// <param name="brush">character to be draw default is 'x'</param>
        public Line(int x1, int y1, int x2, int y2, string brush = "x")
        {
            this.Properties = new ElementProperties(x1, y1, x2, y2, brush);
        }

        #region Public Methods

        /// <summary>
        /// Draws a line in a given canvas matrix
        /// </summary>
        /// <param name="canvas">Canvas to draw</param>
        /// <returns>Canvas drawn</returns>
        public string[,] DrawToCanvas(string[,] canvas)
        {
            if (this.IsValid(canvas))
            {
                //horizontal
                if (this.IsHorizontal())
                {
                    for (int x = Properties.X1; x <= Properties.X2; x++)
                        canvas[x, Properties.Y1] = this.Properties.BrushChar ?? "x";
                }
                //vertical 
                else if (this.IsVertical())
                {
                    for (int y = Properties.Y1; y <= Properties.Y2; y++)
                        canvas[Properties.X1, y] = this.Properties.BrushChar ?? "x";
                }
            }
            return canvas;
        }

        /// <summary>
        /// idicates if line is allowed to draw
        /// </summary>
        /// <returns>bool if it is allowed</returns>
        public bool IsValid(string[,] canvas = null)
        {

            if (this.Properties == null)
            {
                return false;
            }
            if (!this.IsVertical() && !IsHorizontal())
            {
                return false;
            }

            if (canvas != null
                && (Util.IsOutCanvas(this.Properties.X1, this.Properties.Y1, canvas)
                    || Util.IsOutCanvas(this.Properties.X2, this.Properties.Y2, canvas)))
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// indicates if the line is Vertical
        /// </summary>
        /// <returns>bool</returns>
        public bool IsVertical()
        {
            return (this.Properties.X1 == this.Properties.X2);
        }
        /// <summary>
        /// indicates if line is horizontal
        /// </summary>
        /// <returns></returns>
        public bool IsHorizontal()
        {
            return (this.Properties.Y1 == this.Properties.Y2);
        }
        #endregion
    }
}