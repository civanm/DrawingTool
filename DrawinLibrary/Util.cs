﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawinLibrary
{
    public static class Util
    {
        /// <summary>
        /// indicates if point is out of given canvas
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="canvas"></param>
        /// <returns>bool</returns>
        public static bool IsOutCanvas(int x, int y, string[,] canvas)
        {
            return (x < 1 || x > canvas.GetUpperBound(0)) || (y < 1 || y > canvas.GetUpperBound(1));
        }
    }
}