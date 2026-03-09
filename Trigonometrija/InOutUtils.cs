using System.IO;
namespace Trigonometrija.App_Code
{
    public static class InOutUtils
    {
        public static RectangleList ReadRectangles(string path)
        {
            RectangleList list = new RectangleList();
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] p = line.Split(' ');
                    list.Add(new Rectangle(p[0], double.Parse(p[1]), double.Parse(p[2]), double.Parse(p[3]), double.Parse(p[4])));
                }
            }
            return list;
        }

        public static TriangleList ReadTriangles(string path)
        {
            TriangleList list = new TriangleList();
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] p = line.Split(' ');
                    list.Add(new Triangle(p[0], double.Parse(p[1]), double.Parse(p[2]), double.Parse(p[3]), double.Parse(p[4]), double.Parse(p[5]), double.Parse(p[6])));
                }
            }
            return list;
        }
    }
}