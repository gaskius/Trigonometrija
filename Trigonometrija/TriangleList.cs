namespace Trigonometrija.App_Code
{
    /// <summary>
    /// The <see cref="TriangleList"/> class represents a 
    /// collection of <see cref="Triangle"/> objects.
    /// </summary>
    public class TriangleList
    {
        private sealed class TriNode
        {
            public Triangle Data { get; set; }
            public TriNode Link { get; set; }
            /// <summary>
            /// Basic constructor for the <see cref="TriNode"/> class with 
            /// instances Data and Link.
            /// </summary>
            public TriNode(Triangle data, TriNode link) 
            { 
                this.Data = data; 
                this.Link = link; 
            }
        }

        private TriNode head;
        private TriNode tail;
        private TriNode d;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangleList"/> class.
        /// </summary>
        public TriangleList() 
        { 
            head = null; 
            tail = null; 
        }

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
        public Triangle Get()
        {
            return d.Data;
        }
        /// <summary>
        /// Adds a new triangle to the end of the list.
        /// </summary>
        public void Add(Triangle data)
        {
            TriNode newNode = new TriNode(data, null);
            if (head != null) 
            { 
                tail.Link = newNode; 
                tail = newNode; 
            }
            else 
            { 
                head = newNode; 
                tail = newNode; 
            }
        }
        /// <summary>
        /// Removes the first triangle with the specified name from the list.
        /// </summary>
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
        /// <summary>
        /// Sorts the triangles in the list by their names using 
        /// selection sort algorithm.
        /// </summary>
        public void Sort()
        {
            for (TriNode i = head; i != null; i = i.Link)
            {
                TriNode min = i;
                for (TriNode j = i.Link; j != null; j = j.Link)
                {
                    if (j.Data.CompareTo(min.Data) < 0)
                        min = j;
                }

                Triangle temp = i.Data;
                i.Data = min.Data;
                min.Data = temp;
            }
        }
    }
}