using System;

namespace Trigonometrija.App_Code
{
    public class Triangle : IComparable
    {
        public string Name { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double X3 { get; set; }
        public double Y3 { get; set; }

        public Triangle(string name, double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.Name = name;
            this.X1 = x1; this.Y1 = y1;
            this.X2 = x2; this.Y2 = y2;
            this.X3 = x3; this.Y3 = y3;
        }

        public double GetArea() => 0.5 * Math.Abs(X1 * (Y2 - Y3) + X2 * (Y3 - Y1) + X3 * (Y1 - Y2));

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Triangle other = obj as Triangle;
            return string.Compare(this.Name, other.Name);
        }
    }
}