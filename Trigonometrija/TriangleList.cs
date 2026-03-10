namespace Trigonometrija.App_Code
{
    public class TriangleList
    {
        private sealed class TriNode
        {
            public Triangle Data { get; set; }
            public TriNode Link { get; set; }
            public TriNode(Triangle data, TriNode link) { this.Data = data; this.Link = link; }
        }

        private TriNode head;
        private TriNode tail;
        private TriNode d;

        public TriangleList() { head = null; tail = null; }

        public void Begin() { d = head; }
        public void Next() { if (d != null) d = d.Link; }
        public bool Exist() => d != null;
        public Triangle Get() => d.Data;

        public void Add(Triangle data)
        {
            TriNode newNode = new TriNode(data, null);
            if (head != null) { tail.Link = newNode; tail = newNode; }
            else { head = newNode; tail = newNode; }
        }

        public void RemoveByName(string name)
        {
            TriNode prev = null;
            TriNode curr = head;
            while (curr != null)
            {
                if (curr.Data.Name == name)
                {
                    if (d == curr) d = curr.Link;

                    if (prev == null) head = curr.Link;
                    else prev.Link = curr.Link;
                    if (curr.Link == null) tail = prev;
                    return;
                }
                prev = curr;
                curr = curr.Link;
            }
        }
    }
}