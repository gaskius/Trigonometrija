using System;
using System.Globalization;
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
                        double x1 = double.Parse(parts[1], 
                            CultureInfo.InvariantCulture);
                        double y1 = double.Parse(parts[2], 
                            CultureInfo.InvariantCulture);
                        double x2 = double.Parse(parts[3], 
                            CultureInfo.InvariantCulture);
                        double y2 = double.Parse(parts[4], 
                            CultureInfo.InvariantCulture);

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
                        double x1 = double.Parse(parts[1], 
                            CultureInfo.InvariantCulture);
                        double y1 = double.Parse(parts[2], 
                            CultureInfo.InvariantCulture);
                        double x2 = double.Parse(parts[3], 
                            CultureInfo.InvariantCulture);
                        double y2 = double.Parse(parts[4], 
                            CultureInfo.InvariantCulture);
                        double x3 = double.Parse(parts[5], 
                            CultureInfo.InvariantCulture);
                        double y3 = double.Parse(parts[6], 
                            CultureInfo.InvariantCulture);

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
        /// <summary>
        /// Pagrindinis rezultatų spausdinimo metodas
        /// </summary>
        public static void PrintCalculationResults(string fileName, MatchList m1, 
            MatchList m2, Rectangle maxR, Triangle maxT)
        {
            using (StreamWriter sw = new StreamWriter(fileName,false,Encoding.UTF8))
            {
                sw.WriteLine("REZULTATAI");
                sw.WriteLine();

                PrintMatchTable(sw, m1, "a) Stačiakampiai, " +
                    "kuriuose yra viena trikampio viršūnė:");
                sw.WriteLine();

                PrintMatchTable(sw, m2, "b) Stačiakampiai, " +
                    "kuriuose yra visas trikampis:");
                sw.WriteLine();

                sw.WriteLine("DIDŽIAUSI PLOTAI");
                sw.WriteLine(new string('-', 51));
                if (maxR != null)
                    sw.WriteLine("Max stačiakampis: {0,-10} | Plotas: {1,10:F2} |", 
                        maxR.Name, maxR.GetArea());
                else
                    sw.WriteLine("Max stačiakampis: Nerastas");

                if (maxT != null)
                    sw.WriteLine("Max trikampis:    {0,-10} | Plotas: {1,10:F2} |", 
                        maxT.Name, maxT.GetArea());
                else
                    sw.WriteLine("Max trikampis:    Nerastas");
                sw.WriteLine(new string('-', 51));
                sw.WriteLine();
                if (maxT.GetArea() > maxR.GetArea())
                {
                    sw.WriteLine("Trikampio plotas didesnis.");
                }
                if (maxT.GetArea() == maxR.GetArea())
                {
                    sw.WriteLine("Trikampio ir stačiakampio plotai lygūs.");
                }
                else
                {
                    sw.WriteLine("Stačiakampio plotas didesnis.");
                }
            }

        }

        /// <summary>
        /// Pagalbinis metodas MatchList sąrašui spausdinti
        /// </summary>
        private static void PrintMatchTable(StreamWriter sw, MatchList list, 
            string title)
        {
            sw.WriteLine(title);

            if (list.Count() == 0)
            {
                sw.WriteLine("Tokių stačiakampių nėra.");
                return;
            }

            sw.WriteLine(new string('-', 37));
            sw.WriteLine("| {0,-15} | {1,-15} |", "Stačiakampis", "Trikampis");
            sw.WriteLine(new string('-', 37));

            for (list.Begin(); list.Exist(); list.Next())
            {
                MatchResult m = list.Get();
                sw.WriteLine("| {0,-15} | {1,-15} |", m.RectName, m.TriName);
            }
            sw.WriteLine(new string('-', 37));
        }
    }
}