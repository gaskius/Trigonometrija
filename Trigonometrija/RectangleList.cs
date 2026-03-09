using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trigonometrija.App_Code
{
    // Mazgas staciakampiams
    public sealed class RectNode
    {
        public Rectangle Data { get; set; }
        public RectNode Link { get; set; }
        public RectNode(Rectangle data, RectNode link) { this.Data = data; this.Link = link; }
    }

    public class RectangleList
    {
        private RectNode head;
        private RectNode tail;
        public void Add(Rectangle d)
        {
            RectNode n = new RectNode(d, null);
            if (head != null) { tail.Link = n; tail = n; } else { head = n; tail = n; }
        }
        public RectNode GetHead() { return head; }
        public void Sort()
        {
            for (RectNode d1 = head; d1 != null; d1 = d1.Link)
            {
                RectNode min = d1;
                for (RectNode d2 = d1.Link; d2 != null; d2 = d2.Link)
                    if (string.Compare(d2.Data.Name, min.Data.Name) < 0) min = d2;
                Rectangle t = d1.Data; d1.Data = min.Data; min.Data = t;
            }
        }
    }

    // Rezultatu sarasas
    public sealed class MatchNode
    {
        public MatchResult Data { get; set; }
        public MatchNode Link { get; set; }
        public MatchNode(MatchResult d, MatchNode l) { this.Data = d; this.Link = l; }
    }

    public class MatchList
    {
        private MatchNode head;
        private MatchNode tail;
        public void Add(MatchResult d)
        {
            MatchNode n = new MatchNode(d, null);
            if (head != null) { tail.Link = n; tail = n; } else { head = n; tail = n; }
        }
        public MatchNode GetHead() { return head; }
    }
}