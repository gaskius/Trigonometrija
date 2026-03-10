namespace Trigonometrija.App_Code
{
    public class MatchList
    {
        private sealed class MatchNode
        {
            public MatchResult Data { get; set; }
            public MatchNode Link { get; set; }
            public MatchNode(MatchResult d, MatchNode l) { this.Data = d; this.Link = l; }
        }
        private MatchNode head;
        private MatchNode tail;
        private MatchNode d;

        public void Begin() { d = head; }
        public void Next() { if (d != null) d = d.Link; }
        public bool Exist() => d != null;
        public MatchResult Get() => d.Data;

        public void Add(MatchResult data)
        {
            MatchNode n = new MatchNode(data, null);
            if (head != null) { tail.Link = n; tail = n; } else { head = n; tail = n; }
        }
    }
}