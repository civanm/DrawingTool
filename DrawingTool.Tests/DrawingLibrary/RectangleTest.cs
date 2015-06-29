using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawinLibrary;

namespace DrawingTool.Tests.Models
{
    [TestClass]
    public class RectangleTest
    {
        [TestMethod]
        public void ShouldFillPropertiesFromConstructor()
        {
            Rectangle rectangle = new Rectangle(1, 2, 3, 4);

            Assert.IsNotNull(rectangle.Properties);
            Assert.AreEqual(rectangle.Properties.X1, 1);
            Assert.AreEqual(rectangle.Properties.Y1, 2);
            Assert.AreEqual(rectangle.Properties.X2, 3);
            Assert.AreEqual(rectangle.Properties.Y2, 4);
        }

        [TestMethod]
        public void ShouldHaveADefaultBrush()
        {
            Rectangle rectangle = new Rectangle(1, 2, 3, 4);
            Assert.AreEqual(rectangle.Properties.BrushChar, "x");
        }

        [TestMethod]
        public void ShouldNotAllowIfXIsOutOfCanvas()
        {
            string[,] canvas = new string[5, 5];
            Rectangle rectangle = new Rectangle(6, 3, 6, 4);

            Assert.IsFalse(rectangle.IsValid(canvas));
        }

        [TestMethod]
        public void ShouldNotAllowIfYIsOutOfCanvas()
        {
            var canvas = new string[5, 5];
            Rectangle rectangle = new Rectangle(1, 8, 1, 4);

            Assert.IsFalse(rectangle.IsValid(canvas));
        }

        [TestMethod]
        public void ShouldDrawARectangle()
        {
            var canvas = new string[5, 5];
            Rectangle rectangle = new Rectangle(1, 1, 3, 3);

            Assert.IsTrue(rectangle.IsValid(canvas));

            var drawnCanvas = rectangle.DrawToCanvas(canvas);

            Assert.IsNotNull(drawnCanvas);
            Assert.AreEqual(null, drawnCanvas.GetValue(0, 0));
            Assert.AreEqual("x", drawnCanvas.GetValue(1, 1));
            Assert.AreEqual("x", drawnCanvas.GetValue(1, 2));
            Assert.AreEqual("x", drawnCanvas.GetValue(1, 3));
            Assert.AreEqual(null, drawnCanvas.GetValue(1, 4));

            Assert.AreEqual(null, drawnCanvas.GetValue(2, 0));
            Assert.AreEqual("x", drawnCanvas.GetValue(2, 1));
            Assert.AreEqual(null, drawnCanvas.GetValue(2, 2));
            Assert.AreEqual("x", drawnCanvas.GetValue(2, 3));
            Assert.AreEqual(null, drawnCanvas.GetValue(2, 4));

            Assert.AreEqual(null, drawnCanvas.GetValue(3, 0));
            Assert.AreEqual("x", drawnCanvas.GetValue(3, 1));
            Assert.AreEqual("x", drawnCanvas.GetValue(3, 2));
            Assert.AreEqual("x", drawnCanvas.GetValue(3, 3));
            Assert.AreEqual(null, drawnCanvas.GetValue(3, 4));
        }
    }
}
