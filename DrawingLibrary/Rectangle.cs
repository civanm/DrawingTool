using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace DrawinLibrary
{
    public class Rectangle : IElement
    {
        public Rectangle(int x1, int y1, int x2, int y2)
        {
            this.Properties = new ElementProperties(x1, y1, x2, y2);
        }

        public Rectangle(ElementProperties properties)
        {
            this.Properties = properties;
        }

        public string[,] DrawToCanvas(string[,] canvas)
        {
            if (this.IsValid(canvas))
            {
                Line lineLeft = new Line(new ElementProperties()
                {
                    X1 = this.Properties.X1,
                    Y1 = this.Properties.Y1,
                    X2 = this.Properties.X1,
                    Y2 = this.Properties.Y2
                });
                Line lineTop = new Line(new ElementProperties()
                {
                    X1 = this.Properties.X1,
                    Y1 = this.Properties.Y1,
                    X2 = this.Properties.X2,
                    Y2 = this.Properties.Y1
                });
                Line lineBottom = new Line(new ElementProperties()
                {
                    X1 = this.Properties.X1,
                    Y1 = this.Properties.Y2,
                    X2 = this.Properties.X2,
                    Y2 = this.Properties.Y2
                });
                Line lineRight = new Line(new ElementProperties()
                {
                    X1 = this.Properties.X2,
                    Y1 = this.Properties.Y1,
                    X2 = this.Properties.X2,
                    Y2 = this.Properties.Y2
                });

                canvas = lineLeft.DrawToCanvas(canvas);
                canvas = lineTop.DrawToCanvas(canvas);
                canvas = lineBottom.DrawToCanvas(canvas);
                canvas = lineRight.DrawToCanvas(canvas);
            }

            return canvas;
        }

        public ElementProperties Properties { get; set; }



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