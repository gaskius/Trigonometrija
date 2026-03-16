using System;
using System.IO;
using System.Text;
using Trigonometrija.App_Code;

namespace Trigonometrija.App_Code
{
    public static class InOutUtils
    {
        /// <summary>
        /// Reads rectangle data from a file and fills a RectangleList object
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <returns>A fill RectangleList object</returns>
        public static RectangleList ReadRectangles(string path)
        {
            RectangleList list = new RectangleList();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(new[] { ' ' }, 
                        StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 5)
                    {
                        string name = parts[0];
                        double x1 = double.Parse(parts[1]);
                        double y1 = double.Parse(parts[2]);
                        double x2 = double.Parse(parts[3]);
                        double y2 = double.Parse(parts[4]);

                        Rectangle rect = new Rectangle(name, x1, y1, x2, y2);
                        list.Add(rect);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Reads triangle data from a file and fills a TriangleList object
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <returns>Fully completed TriangleList object</returns>
        public static TriangleList ReadTriangles(string path)
        {
            TriangleList list = new TriangleList();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(new[] { ' ' }, 
                        StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 7)
                    {
                        string name = parts[0];
                        double x1 = double.Parse(parts[1]);
                        double y1 = double.Parse(parts[2]);
                        double x2 = double.Parse(parts[3]);
                        double y2 = double.Parse(parts[4]);
                        double x3 = double.Parse(parts[5]);
                        double y3 = double.Parse(parts[6]);

                        Triangle tri = new Triangle(name, x1, y1, x2, y2, x3, y3);
                        list.Add(tri);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// Prints the initial data of rectangles and triangles 
        /// to a file in a tabular format.
        /// </summary>
        public static void PrintInitialData
            (string fileName, RectangleList rs, TriangleList ts)
        {
            using (StreamWriter sw = new StreamWriter(fileName,false,Encoding.UTF8))
            {
                sw.WriteLine("PRADINIAI DUOMENYS");
                sw.WriteLine();

                PrintRectanglesTable(sw, rs);
                sw.WriteLine();
                PrintTrianglesTable(sw, ts);
            }
        }

        /// <summary>
        /// Prints the rectangle table to the specified StreamWriter.
        /// </summary>
        private static void PrintRectanglesTable(StreamWriter sw, RectangleList rs)
        {
            sw.WriteLine("Stačiakampiai:");
            sw.WriteLine(new string('-', 46));
            sw.WriteLine("| {0,-10} | {1,5} | {2,5} | {3,5} | {4,5} |",
                "Vardas", "X1", "Y1", "X2", "Y2");
            sw.WriteLine(new string('-', 46));

            for (rs.Begin(); rs.Exist(); rs.Next())
            {
                Rectangle r = rs.Get();
                sw.WriteLine("| {0,-10} | {1,5} | {2,5} | {3,5} | {4,5} |",
                    r.Name, r.X1, r.Y1, r.X2, r.Y2);
            }
            sw.WriteLine(new string('-', 46));
        }

        /// <summary>
        /// Prints the triangle table to the specified StreamWriter.
        /// </summary>
        private static void PrintTrianglesTable(StreamWriter sw, TriangleList ts)
        {
            sw.WriteLine("Trikampiai:");
            sw.WriteLine(new string('-', 50));
            sw.WriteLine
                ("| {0,-10} | {1,3} | {2,3} | {3,3} | {4,3} | {5,3} | {6,3} |",
                "Vardas", "X1", "Y1", "X2", "Y2", "X3", "Y3");
            sw.WriteLine(new string('-', 50));

            for (ts.Begin(); ts.Exist(); ts.Next())
            {
                Triangle t = ts.Get();
                sw.WriteLine
                    ("| {0,-10} | {1,3} | {2,3} | {3,3} | {4,3} | {5,3} | {6,3} |",
                    t.Name, t.X1, t.Y1, t.X2, t.Y2, t.X3, t.Y3);
            }
            sw.WriteLine(new string('-', 50));
        }
    }
}