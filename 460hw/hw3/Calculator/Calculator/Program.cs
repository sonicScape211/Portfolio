using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {

        private IStackADT stack = new LinkedStack();

        static void Main(string[] args)
        {
            Calculator app = new Calculator();
            //Set the flag for if the calculator should close.
            bool playAgain = true;
            Console.Write("\nPostfix Calculator. Recognizes these operators: + - * /");
            while (playAgain)
            {
                playAgain = app.doCalculation();
            }
            Console.Write("Bye.");
        }

        private bool doCalculation()
        {
            Console.Write("Please enter q to quit\n");
            String input = "2 2 +";
            //Simple user prompt.
            Console.Write("> ");
            //Get the tokenized user input.
            input = Console.ReadLine();

            //Check to see if the user wants to quit the program.
            if (input.StartsWith("q") || input.StartsWith("Q"))
            {
                //Quit.
                return false;
            }

            String output = "4";
            try
            {
                output = evaluatePostFixInput(input);
            }
            catch (ArgumentException e)
            {
                //Set the output to print the exception message.
                output = e.Message;
            }

            Console.Write("\n\t>>> " + input + " = " + output + "\n");
            return true;
        }
    }

    interface IStackADT
    {
        ///<summary>
        ///This will push an item onto the top of the stack. This will return a reference
        ///to the Object (pointer address, but not the copy of the item.) that was pushed so that
        ///the anonymous object can be pushed to the stack and tehn used.
        ///<paramref name="newItem"/> Will be the object pushed to the top of the stack.
        ///<returns>A referance to the object that what pushed.</returns>
        ///</summary>

        Object Push(Object newItem);

        Object Pop();

        Object Peek();

        Boolean isEmpty();

        void clear();

    }

    //The LinkedStack class implements (:) the interface IStackADT.
    class LinkedStack : IStackADT
    {
        //The top of the stack.
        private Node top;

        public LinkedStack()
        {
            top = null;
        }

        public Object Push(Object newItem)
        {
            //We cannot push a null node.
            if (newItem == null)
            {
                //Reject.
                return null;
            }
            //Create a new node and have it point to the current top-of-stack node.
            Node newNode = new Node(newItem, top);
            //Push to the top of the stack.
            top = newNode;
            //return the node jsut pushed.
            return newItem;
        }

        public Object Pop()
        {
            //If the stack is empty we cant pop anything.
            if (isEmpty())
            {
                ///Reject.
                return null;
            }
            //Get the information from the top-of-stack node.
            Object topItem = top.data;
            //Change the var top pointer to the next element.
            top = top.next;
            //Return the pointer to the element that was poped off the stack.
            return topItem;

        }

        public Object Peek()
        {
            if (isEmpty())
            {
                return null;
            }
            return top.data;
        }

        /// <summary>
        /// Checks to see if there is a pointer stored in the 'top' variable.
        /// </summary>
        /// <returns>If null return false. Else true</returns>
        public Boolean isEmpty()
        {
            return top == null;
        }

        /// <summary>
        /// This will clear the entire stack by removing the pointer to the
        /// top element on the stack.
        /// </summary>
        public void clear()
        {
            top = null;
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
