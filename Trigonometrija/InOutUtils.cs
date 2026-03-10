using System;
using System.IO;
using System.Text;
using Trigonometrija.App_Code;

namespace Trigonometrija.App_Code
{
    public static class InOutUtils
    {
        /// <summary>
        /// Nuskaito stačiakampių duomenis iš failo
        /// </summary>
        /// <param name="path">Kelias iki failo</param>
        /// <returns>Užpildytas RectangleList objektas</returns>
        public static RectangleList ReadRectangles(string path)
        {
            RectangleList list = new RectangleList();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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
        /// Nuskaito trikampių duomenis iš failo
        /// </summary>
        /// <param name="path">Kelias iki failo</param>
        /// <returns>Užpildytas TriangleList objektas</returns>
        public static TriangleList ReadTriangles(string path)
        {
            TriangleList list = new TriangleList();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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
    }
}