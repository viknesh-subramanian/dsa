using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problems.DS
{
    public class Node
    {
        public int val;
        public Node next;

        public Node(int val)
        {
            this.val = val;
        }
        public Node(int val, Node next)
        {
            this.val = val;
            this.next = next;
        }
    }
}
