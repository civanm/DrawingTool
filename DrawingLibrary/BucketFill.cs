using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawingLibrary
{
    public class BucketFill : IElement
    {
        public ElementProperties Properties { get; set; }

        /// <summary>
        /// fills the entire area connected to (x,y) with "colour" c.
        /// The behaviour of this is the same as that of the "bucket fill" tool in paint programs
        /// </summary>
        /// <param name="x1">x point to start filling</param>
        /// <param name="y1">y point to start filling</param>
        /// <param name="brushChar"></param>
        public BucketFill(int x1, int y1, string brushChar = "o")
        {
            this.Properties = new ElementProperties(x1, y1, brushChar);
        }

        /// <summary>
        /// Draws the element to the given canvas
        /// </summary>
        /// <param name="canvas">canvas to draw</param>
        /// <returns>drawn canvas</returns>
        public string[,] DrawToCanvas(string[,] canvas)
        {
            localCanvas = canvas;
            if (this.IsValid(canvas))
            {
                fillCanvas(Properties.X1, Properties.Y1);
            }
            return localCanvas;
        }

        private string[,] localCanvas;
        /// <summary>
        /// makes a recursive call to food fill the canvas
        /// </summary>
        /// <param name="x">x point in canvas</param>
        /// <param name="y">y point in canvas</param>
        /// <returns>bool</returns>
        private bool fillCanvas(int x, int y)
        {
            if (Util.IsOutCanvas(x, y, localCanvas) || localCanvas.GetValue(x, y) != null)
            {
                return false;
            }

            localCanvas.SetValue(this.Properties.BrushChar, x, y);

            //recursively goes to the points and fill them
            fillCanvas(x + 1, y);
            fillCanvas(x - 1, y);
            fillCanvas(x, y + 1);
            fillCanvas(x, y - 1);

            return true;
        }

        /// <summary>
        /// Indicates if the element is valid to draw
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public bool IsValid(string[,] canvas = null)
        {
            if (canvas != null
                 && (Util.IsOutCanvas(this.Properties.X1, this.Properties.Y1, canvas)))
            {
                return false;
            }

            return true;
        }
    }
}