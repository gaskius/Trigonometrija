using System;

namespace Trigonometrija.App_Code
{
    public static class TaskUtils
    {
        /// <summary>
        /// Processes one rectangle against all triangles
        /// </summary>
        /// <param name="r">Rectangle being checked</param>
        /// <param name="ts">List of triangles</param>
        /// <param name="m1">Matches with one point inside</param>
        /// <param name="m2">Matches with full triangle inside</param>
        public static void ProcessSingleRectangle(Rectangle r, TriangleList ts, MatchList m1, MatchList m2)
        {
            for (ts.Begin(); ts.Exist(); ts.Next())
            {
                Triangle t = ts.Get();
                int pointsInside = 0;
                if (r.ContainsPoint(t.X1, t.Y1)) pointsInside++;
                if (r.ContainsPoint(t.X2, t.Y2)) pointsInside++;
                if (r.ContainsPoint(t.X3, t.Y3)) pointsInside++;

                if (pointsInside == 1)
                    m1.Add(new MatchResult(r.Name, t.Name, "Viena viršūnė"));
                else if (pointsInside == 3)
                    m2.Add(new MatchResult(r.Name, t.Name, "Visas trikampis"));
            }
        }

        public static void PerformCalculations(RectangleList rs, TriangleList ts, MatchList m1, MatchList m2)
        {
            for (rs.Begin(); rs.Exist(); rs.Next())
            {
                ProcessSingleRectangle(rs.Get(), ts, m1, m2);
            }
        }

        /// <summary>
        /// Finds the rectangle with the largest area in the specified list.
        /// </summary>
        /// <param name="rs">The list of rectangles to search</param>
        /// <returns>The <see cref="Rectangle"/> with the largest area in the list, or null if the list is empty.</returns>
        public static Rectangle FindMaxRectangle(RectangleList rs)
        {
            Rectangle maxR = null;
            for (rs.Begin(); rs.Exist(); rs.Next())
            {
                Rectangle curr = rs.Get();
                if (maxR == null || curr.GetArea() > maxR.GetArea())
                    maxR = curr;
            }
            return maxR;
        }

        /// <summary>
        /// Finds the triangle with the largest area in the specified list.
        /// </summary>
        /// <param name="ts">The list of triangles to search. Must not be null.</param>
        /// <returns>The <see cref="Triangle"/> with the largest area in the list, or null if the list is empty.</returns>
        public static Triangle FindMaxTriangle(TriangleList ts)
        {
            Triangle maxT = null;
            for (ts.Begin(); ts.Exist(); ts.Next())
            {
                Triangle curr = ts.Get();
                if (maxT == null || curr.GetArea() > maxT.GetArea())
                    maxT = curr;
            }
            return maxT;
        }
    }
}