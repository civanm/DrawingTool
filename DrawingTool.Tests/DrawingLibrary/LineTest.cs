using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingLibrary;

namespace DrawingTool.Tests.Models
{
    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void ShouldFillPropertiesFromConstructor()
        {
            Line line = new Line(1, 2, 3, 4);

            Assert.IsNotNull(line.Properties);
            Assert.AreEqual(line.Properties.X1, 1);
            Assert.AreEqual(line.Properties.Y1, 2);
            Assert.AreEqual(line.Properties.X2, 3);
            Assert.AreEqual(line.Properties.Y2, 4);
        }

        [TestMethod]
        public void ShouldHaveADefaultBrush()
        {
            Line line = new Line(1, 2, 3, 4);
            Assert.AreEqual(line.Properties.BrushChar, "x");
        }

        [TestMethod]
        public void ShouldSayLineIsHorizontal()
        {
            Line line = new Line(1, 2, 6, 2);
            Assert.IsTrue(line.IsHorizontal());
            Assert.IsFalse(line.IsVertical());
        }

        [TestMethod]
        public void ShouldSayLineIsVertical()
        {
            Line line = new Line(6, 3, 6, 4);
            Assert.IsTrue(line.IsVertical());
            Assert.IsFalse(line.IsHorizontal());
        }

        [TestMethod]
        public void ShouldNotAllowDiagonals()
        {
            Line line = new Line(1, 2, 3, 4);
            Assert.IsFalse(line.IsValid());
        }

        [TestMethod]
        public void ShouldAllowHorizontals()
        {
            Line line = new Line(1, 2, 6, 2);
            Assert.IsTrue(line.IsValid());
        }

        [TestMethod]
        public void ShouldAllowVerticals()
        {
            Line line = new Line(6, 3, 6, 4);
            Assert.IsTrue(line.IsValid());
        }

        [TestMethod]
        public void ShouldNotAllowIfXIsOutOfCanvas()
        {
            string[,] canvas = new string[5, 5];
            Line line = new Line(6, 3, 6, 4);

            Assert.IsFalse(line.IsValid(canvas));
        }

        [TestMethod]
        public void ShouldNotAllowIfYIsOutOfCanvas()
        {
            var canvas = new string[5, 5];
            Line line = new Line(1, 8, 1, 4);

            Assert.IsFalse(line.IsValid(canvas));
        }

        [TestMethod]
        public void ShouldDrawTheLine()
        {
            var canvas = new string[5, 5];
            Line line = new Line(1, 1, 1, 4);

            Assert.IsTrue(line.IsValid(canvas));

            var drawnCanvas = line.DrawToCanvas(canvas);

            Assert.IsNotNull(drawnCanvas);
            Assert.IsNull(drawnCanvas.GetValue(0, 0));
            Assert.AreEqual("x", drawnCanvas.GetValue(1, 1));
            Assert.AreEqual("x", drawnCanvas.GetValue(1, 2));
            Assert.AreEqual("x", drawnCanvas.GetValue(1, 3));
            Assert.AreEqual("x", drawnCanvas.GetValue(1, 4));
        }
        [TestMethod]
        public void ShouldDrawAVerticalLine()
        {
            var canvas = new string[5, 5];
            Line line = new Line(1, 1, 4, 1);

            Assert.IsTrue(line.IsValid(canvas));

            var drawnCanvas = line.DrawToCanvas(canvas);

            Assert.IsNotNull(drawnCanvas);
            Assert.IsNull(drawnCanvas.GetValue(0, 0));
            Assert.AreEqual("x", drawnCanvas.GetValue(1, 1));
            Assert.AreEqual("x", drawnCanvas.GetValue(2, 1));
            Assert.AreEqual("x", drawnCanvas.GetValue(3, 1));
            Assert.AreEqual("x", drawnCanvas.GetValue(4, 1));
        }
    }
}
