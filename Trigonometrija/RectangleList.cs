using System;

namespace Trigonometrija.App_Code
{
    /// <summary>
    /// Represents a collection of <see cref="Rectangle"/> objects 
    /// with sequential access and basic list operations.
    /// </summary>
    public class RectangleList
    {
        private sealed class RectNode
        {
            public Rectangle Data { get; set; }
            public RectNode Link { get; set; }
            /// <summary>
            /// Initializes a new instance of the <see cref="RectNode"/> 
            /// class with the specified rectangle data and link to the next node.
            /// </summary>
            /// <param name="data">The <see cref="Rectangle"/> value to 
            /// store in this node.</param>
            /// <param name="link">The next <see cref="RectNode"/> in the sequence,
            /// or <see langword="null"/> if this is the last node.</param>
            public RectNode(Rectangle data, RectNode link) 
            {
                this.Data = data;
                this.Link = link;
            }
        }

        private RectNode head;
        private RectNode tail;
        private RectNode d;
        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleList"/> class.
        /// </summary>
        public RectangleList() 
        { 
            head = null; 
            tail = null; 
            d = null;
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
        public Rectangle Get()
        {
            return d.Data;
        }
        /// <summary>
        /// Adds a new rectangle to the end of the list.
        /// </summary>
        /// <param name="data">The data of the rectangle object</param>
        public void Add(Rectangle data)
        {
            RectNode n = new RectNode(data, null);
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
        /// Sorts the rectangles in the list by their names using 
        /// selection sort algorithm.
        /// </summary>
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