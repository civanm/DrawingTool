using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingTool;
using DrawingLibrary;

namespace DrawingTool.Tests.Models
{
    [TestClass]
    public class CanvasTest
    {
        IElement lineHorizontal = new Line(1, 2, 6, 2),
            lineVertical = new Line(6, 2, 6, 4),
            rectangle = new Rectangle(16, 1, 20, 3);

        [TestMethod]
        public void ShouldCreateACanvasWithParams()
        {
            int x = 10, y = 100;
            Canvas canvas = new Canvas(x, y);

            Assert.IsNotNull(canvas.Matrix);
        }

        [TestMethod]
        public void ShouldDrawAnEmptyCanvas()
        {
            Canvas canvas = new Canvas(20, 4);

            var drawing = canvas.Draw();
            var expected = "----------------------" +
                           "|                    |" +
                           "|                    |" +
                           "|                    |" +
                           "|                    |" +
                           "----------------------";

            Assert.AreEqual(expected, drawing);
        }

        [TestMethod]
        public void ShouldDrawALine()
        {
            Canvas canvas = new Canvas(20, 4);

            //adds a horizontal Line to canvas
            canvas.Elements.Add(lineHorizontal);

            //draws the canvas
            var drawing = canvas.Draw();

            //expected result
            var expected = "----------------------" +
                           "|                    |" +
                           "|xxxxxx              |" +
                           "|                    |" +
                           "|                    |" +
                           "----------------------";

            Assert.AreEqual(expected, drawing);

            //adds a vertical line
            canvas.Elements.Add(lineVertical);

            //draws the canvas
            drawing = canvas.Draw();

            //expected result
            expected = "----------------------" +
                       "|                    |" +
                       "|xxxxxx              |" +
                       "|     x              |" +
                       "|     x              |" +
                       "----------------------";

            Assert.AreEqual(expected, drawing);
        }

        [TestMethod]
        public void ShouldDrawARectangle()
        {
            Canvas canvas = new Canvas(20, 4);

            //adds the rectangle to the canvas
            canvas.Elements.Add(rectangle);

            //draws the canvas
            var drawing = canvas.Draw();

            //expected result
            var expected = "----------------------" +
                           "|               xxxxx|" +
                           "|               x   x|" +
                           "|               xxxxx|" +
                           "|                    |" +
                           "----------------------";

            Assert.AreEqual(expected, drawing);
        }

        [TestMethod]
        public void ShouldBucketFillAllCanvas()
        {
            Canvas canvas = new Canvas(20, 4);

            canvas.Elements.Add(new BucketFill(10, 3, "*"));

            var drawing = canvas.Draw();

            var expected = "----------------------" +
                           "|********************|" +
                           "|********************|" +
                           "|********************|" +
                           "|********************|" +
                           "----------------------";

            Assert.AreEqual(expected, drawing);
        }

        [TestMethod]
        public void ShouldBucketFillButRectangleArea()
        {
            Canvas canvas = new Canvas(20, 4);

            //rectangle
            canvas.Elements.Add(rectangle);

            //bucket fill
            canvas.Elements.Add(new BucketFill(10, 3, "o"));

            var drawing = canvas.Draw();

            var expected = "----------------------" +
                            "|oooooooooooooooxxxxx|" +
                            "|ooooooooooooooox   x|" +
                            "|oooooooooooooooxxxxx|" +
                            "|oooooooooooooooooooo|" +
                            "----------------------";

            Assert.AreEqual(expected, drawing);
        }

        [TestMethod]
        public void ShouldBucketFillButInsideRectangleAreaOnly()
        {
            Canvas canvas = new Canvas(20, 4);

            //rectangle
            canvas.Elements.Add(new Rectangle(5, 1, 15, 4));

            //bucket fill
            canvas.Elements.Add(new BucketFill(6, 3, "o"));

            var drawing = canvas.Draw();

            //expected result
            var expected = "----------------------" +
                           "|    xxxxxxxxxxx     |" +
                           "|    xooooooooox     |" +
                           "|    xooooooooox     |" +
                           "|    xxxxxxxxxxx     |" +
                           "----------------------";

            Assert.AreEqual(expected, drawing);
        }

        [TestMethod]
        public void ShouldNotFillBetweenLines()
        {
            Canvas canvas = new Canvas(20, 4);

            //adds element to canvas
            canvas.Elements.Add(lineVertical);
            canvas.Elements.Add(lineHorizontal);

            //bucket fill
            canvas.Elements.Add(new BucketFill(1, 1, "o"));

            var drawing = canvas.Draw();
            //expected result    
            var expected = "----------------------" +
                           "|oooooooooooooooooooo|" +
                           "|xxxxxxoooooooooooooo|" +
                           "|     xoooooooooooooo|" +
                           "|     xoooooooooooooo|" +
                           "----------------------";

            Assert.AreEqual(expected, drawing); ;
        }

        [TestMethod]
        public void ShouldBeTheSameAsSample()
        {
            Canvas canvas = new Canvas(20, 4);

            //adds element to canvas
            canvas.Elements.Add(lineVertical);
            canvas.Elements.Add(lineHorizontal);
            canvas.Elements.Add(rectangle);

            //bucket fill
            canvas.Elements.Add(new BucketFill(10, 3, "o"));

            var drawing = canvas.Draw();

            //expected result    
            var expected = "----------------------" +
                           "|oooooooooooooooxxxxx|" +
                           "|xxxxxxooooooooox   x|" +
                           "|     xoooooooooxxxxx|" +
                           "|     xoooooooooooooo|" +
                           "----------------------";

            Assert.AreEqual(expected, drawing);
        }
    }
}
