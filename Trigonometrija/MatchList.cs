using System.Collections;

namespace Trigonometrija.App_Code
{
    /// <summary>
    /// Linked list for MatchResult objects
    /// </summary>
    public class MatchList : IEnumerable
    {
        private sealed class MatchNode
        {
            public MatchResult Data { get; set; }
            public MatchNode Link { get; set; }
            /// <summary>
            /// Basic constructor for MatchNode, which initializes the Data 
            /// and Link properties with the provided values.
            /// </summary>
            public MatchNode(MatchResult d, MatchNode l) 
            { 
                this.Data = d; 
                this.Link = l; 
            }
        }
        private MatchNode head;
        private MatchNode tail;
        private MatchNode d;

        public void Begin() 
        {
            d = head;
        }
        public void Next() 
        {
            if (d != null) d = d.Link;
        }
        public bool Exist()
        {
            return d != null;
        }
        public MatchResult Get()
        {
            return d.Data;
        }
        /// <summary>
        /// Adds new match result
        /// </summary>
        public void Add(MatchResult data)
        {
            MatchNode n = new MatchNode(data, null);
            if (head != null) 
            {
                tail.Link = n;
                tail = n; 
            } 
            else 
            { 
                head = n;
                tail = n;
            }
        }
        /// <summary>
        /// Returns number of elements
        /// </summary>
        public int Count()
        {
            int count = 0;
            for (MatchNode n = head; n != null; n = n.Link)
            {
                count++;
            }
            return count;
        }
        public IEnumerator GetEnumerator()
        {
            MatchNode current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Link;
            }
        }
        /// <summary>
        /// Sorts match results
        /// </summary>
        public void Sort()
        {
            for (MatchNode i = head; i != null; i = i.Link)
            {
                MatchNode min = i;
                for (MatchNode j = i.Link; j != null; j = j.Link)
                {
                    if (j.Data.CompareTo(min.Data) < 0)
                        min = j;
                }

                MatchResult temp = i.Data;
                i.Data = min.Data;
                min.Data = temp;
            }
        }
    }
}