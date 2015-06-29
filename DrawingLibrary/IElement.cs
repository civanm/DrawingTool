using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary
{
    /// <summary>
    /// Interface for Elements that can be added to the canvas
    /// </summary>
    public interface IElement
    {
        ElementProperties Properties { get; set; }

        bool IsValid(string[,] canvas = null);

        string[,] DrawToCanvas(string[,] canvas);
    }

    /// <summary>
    /// shared Properties among Elements
    /// </summary>
    public class ElementProperties
    {
        public ElementProperties()
        {

        }
        public ElementProperties(int x1, int y1, string brushChar = "x")
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.BrushChar = brushChar;
        }
        public ElementProperties(int x1, int y1, int x2, int y2, string brushChar = "x")
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
            this.BrushChar = brushChar;
        }

        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public string BrushChar { get; set; }
    }
}
