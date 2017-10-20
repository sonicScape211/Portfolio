using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// This class will be a singly linked node class.
    /// </summary>
    class Node
    {
        public Object data; //The data within the current node.
        public Node next;   //The pointer to the node which is next in line.

        /*
         *This default constructor will create a new blank node with no data 
         * or pointer to other nodes.
         */
        public Node()
        {
            data = null;
            next = null;
        }
        /*
         * This nondefault constructor will create a node with data and a pointer
         * to the next node in line.
         */
        public Node(Object data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }
}
