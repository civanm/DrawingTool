using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingLibrary;

namespace DrawingTool.Tests.Models
{
    [TestClass]
    public class BucketFillTest
    {
        [TestMethod]
        public void ShouldFillPropertiesFromConstructor()
        {
            BucketFill bucket = new BucketFill(1, 2, "+");

            Assert.IsNotNull(bucket.Properties);
            Assert.AreEqual(bucket.Properties.X1, 1);
            Assert.AreEqual(bucket.Properties.Y1, 2);

            Assert.AreEqual("+", bucket.Properties.BrushChar);
        }

        [TestMethod]
        public void ShouldHaveADefaultBrush()
        {
            BucketFill bucket = new BucketFill(1, 2);
            Assert.AreEqual("o", bucket.Properties.BrushChar);
        }

        [TestMethod]
        public void ShouldNotAllowIfXIsOutOfCanvas()
        {
            string[,] canvas = new string[5, 5];
            BucketFill bucket = new BucketFill(6, 3);

            Assert.IsFalse(bucket.IsValid(canvas));
        }

        [TestMethod]
        public void ShouldNotAllowIfYIsOutOfCanvas()
        {
            var canvas = new string[5, 5];
            BucketFill bucket = new BucketFill(1, 10);

            Assert.IsFalse(bucket.IsValid(canvas));
        }

        [TestMethod]
        public void ShouldDrawABucket()
        {
            var canvas = new string[5, 5];
            BucketFill bucket = new BucketFill(1, 1);

            Assert.IsTrue(bucket.IsValid(canvas));

            var drawnCanvas = bucket.DrawToCanvas(canvas);

            Assert.IsNotNull(drawnCanvas);
            Assert.AreEqual("o", drawnCanvas.GetValue(1, 1));
            Assert.AreEqual("o", drawnCanvas.GetValue(1, 2));
            Assert.AreEqual("o", drawnCanvas.GetValue(1, 3));
            Assert.AreEqual("o", drawnCanvas.GetValue(1, 4));

            Assert.AreEqual("o", drawnCanvas.GetValue(2, 1));
            Assert.AreEqual("o", drawnCanvas.GetValue(2, 2));
            Assert.AreEqual("o", drawnCanvas.GetValue(2, 3));
            Assert.AreEqual("o", drawnCanvas.GetValue(2, 4));

            Assert.AreEqual("o", drawnCanvas.GetValue(3, 1));
            Assert.AreEqual("o", drawnCanvas.GetValue(3, 2));
            Assert.AreEqual("o", drawnCanvas.GetValue(3, 3));
            Assert.AreEqual("o", drawnCanvas.GetValue(3, 4));

            Assert.AreEqual("o", drawnCanvas.GetValue(4, 1));
            Assert.AreEqual("o", drawnCanvas.GetValue(4, 2));
            Assert.AreEqual("o", drawnCanvas.GetValue(4, 3));
            Assert.AreEqual("o", drawnCanvas.GetValue(4, 4));
        }
    }
}
