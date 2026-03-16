using System;

namespace Trigonometrija.App_Code
{
    public class Rectangle : IComparable
    {
        /// <summary>
        /// Gets or sets the name associated with the object.
        /// </summary>
        public string Name { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> 
        /// class with the specified name and corner coordinates.
        /// </summary>
        public Rectangle(string name, double x1, double y1, double x2, double y2)
        {
            this.Name = name; this.X1 = x1; this.Y1 = y1; this.X2 = x2; this.Y2 = y2;
        }
        /// <summary>
        /// Calculates the area of the rectangle.
        /// </summary>
        /// <returns>The area of the rectangle.</returns>
        public double GetArea()
        {
            return Math.Abs(X2 - X1) * Math.Abs(Y2 - Y1);
        }
        /// <summary>
        /// Determines whether the specified point is in the rectangle.
        /// </summary>
        /// <param name="px">The X-coordinate of the point to test.</param>
        /// <param name="py">The Y-coordinate of the point to test.</param>
        /// <returns>Returns the answer if the point is in or 
        /// within the bounds of the rectangle or not</returns>
        public bool ContainsPoint(double px, double py)
        {
            double minX = Math.Min(X1, X2); double maxX = Math.Max(X1, X2);
            double minY = Math.Min(Y1, Y2); double maxY = Math.Max(Y1, Y2);
            return px >= minX && px <= maxX && py >= minY && py <= maxY;
        }
        /// <summary>
        /// Compares the current instance with another object.
        /// </summary>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Rectangle other = obj as Rectangle;
            return string.Compare(this.Name, other.Name);
        }
    }
}