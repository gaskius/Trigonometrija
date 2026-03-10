using System;

namespace Trigonometrija.App_Code
{
    public class RectangleList
    {
        private sealed class RectNode
        {
            public Rectangle Data { get; set; }
            public RectNode Link { get; set; }
            public RectNode(Rectangle data, RectNode link) { this.Data = data; this.Link = link; }
        }

        private RectNode head;
        private RectNode tail;
        private RectNode d;

        public RectangleList() { head = null; tail = null; d = null; }

        public void Begin() { d = head; }
        public void Next() { if (d != null) d = d.Link; }
        public bool Exist() => d != null;
        public Rectangle Get() => d.Data;

        public void Add(Rectangle data)
        {
            RectNode n = new RectNode(data, null);
            if (head != null) { tail.Link = n; tail = n; } else { head = n; tail = n; }
        }

        public void Sort()
        {
            for (RectNode i = head; i != null; i = i.Link)
            {
                RectNode min = i;
                for (RectNode j = i.Link; j != null; j = j.Link)
                    if (j.Data.CompareTo(min.Data) < 0) min = j;

                Rectangle temp = i.Data;
                i.Data = min.Data;
                min.Data = temp;
            }
        }
    }
}