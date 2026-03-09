using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trigonometrija.App_Code
{
    public class Rectangle
    {
        public string Name { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }

        public Rectangle(string name, double x1, double y1, double x2, double y2)
        {
            this.Name = name;
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }
        public double GetArea()
        {
            return Math.Abs(X2 - X1) * Math.Abs(Y2 - Y1);
        }
        public bool ContainsPoint(double px, double py)
        {
            double minX = Math.Min(X1, X2);
            double maxX = Math.Max(X1, X2);
            double minY = Math.Min(Y1, Y2);
            double maxY = Math.Max(Y1, Y2);
            return px >= minX && px <= maxX && py >= minY && py <= maxY;
        }
    }
}