using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trigonometrija.App_Code
{
    public sealed class TriNode
    {
        public Triangle Data { get; set; }
        public TriNode Link { get; set; }
        public TriNode(Triangle data, TriNode link)
        {
            this.Data = data;
            this.Link = link;
        }
    }

    public class TriangleList
    {
        private TriNode head;
        private TriNode tail;

        public TriangleList()
        {
            this.head = null;
            this.tail = null;
        }

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

        public TriNode GetHead() { return head; }

        public void RemoveByName(string name)
        {
            TriNode prev = null;
            TriNode curr = head;
            while (curr != null)
            {
                if (curr.Data.Name == name)
                {
                    if (prev == null) head = curr.Link;
                    else prev.Link = curr.Link;
                    if (curr.Link == null) tail = prev;
                    return;
                }
                prev = curr;
                curr = curr.Link;
            }
        }

        public void Sort()
        {
            for (TriNode d1 = head; d1 != null; d1 = d1.Link)
            {
                TriNode minNode = d1;
                for (TriNode d2 = d1.Link; d2 != null; d2 = d2.Link)
                {
                    if (string.Compare(d2.Data.Name, minNode.Data.Name) < 0)
                    {
                        minNode = d2;
                    }
                }
                Triangle temp = d1.Data;
                d1.Data = minNode.Data;
                minNode.Data = temp;
            }
        }
    }
}