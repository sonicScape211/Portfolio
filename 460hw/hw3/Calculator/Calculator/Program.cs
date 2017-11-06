using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator
{
    /// <summary>
    /// Calculator program using a postfix method. This calculator will implement a stack 
    /// to store data including: the nubmers to be calculated and the operator to be used.
    /// This program relies on the Scanner class within the Calculator namespace for processing
    /// user input and returning usable data to the part of the program which performs arithmetic
    /// operations.
    /// </summary>
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

        /// <summary>
        /// Method to prompt the user for an appropriate input or to quit out of the program.
        /// </summary>
        /// <returns>Boolean If the user wants to keep going.</returns>
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

        /// <summary>
        /// Logical method for evaluating the user input and parsing the input.
        /// It then passes in the parsed elements to the operation method for 
        /// the actual mathematical calculations. 
        /// </summary>
        /// <param name="input">String of the users input.</param>
        /// <returns>String representation of the equation result.</returns>
        public String evaluatePostFixInput(String input)
        {
            if (input == null || input.Equals(""))
            {
                throw new ArgumentException("Null or the empty string are not valid postfix expressions.");
            }
            //Clear the stack. ie any old data.
            stack.clear();

            String s;   //Temp var for token read.
            double a;   //Temp var for operand.
            double b;   //...for operand.
            double c;   //...for answer.

            Scanner st = new Scanner(input);

            while (st.hasNext())
            {
                if (st.hasNextDouble())
                {
                    //Push the returned double on to the stack.
                    stack.Push((double)st.nextDouble());
                }
                else
                {
                    //It must be an operator or another char.
                    s = st.next();
                    if (s.Length > 1)
                    {
                        throw new ArgumentException("Input Error: " + s + " is not an allowed number or operator.");
                    }
                    if (stack.isEmpty())
                    {
                        throw new ArgumentException("Improper input format. Stack became empty when expecting second operand.");
                    }
                    b = ((double)stack.Pop());
                    if (stack.isEmpty())
                    {
                        throw new ArgumentException("Improper input format. Stack became empty when expecting second operand.");
                    }
                    a = ((double)stack.Pop());

                    c = doOperation(a, b, s);

                    stack.Push(c);
                }
            }
            return ((double)stack.Pop()).ToString();
        }

        /// <summary>
        /// Evaluation of the user input and the mathematical functionality of
        /// the program. Take the inputs and the operator and do the operation.
        /// </summary>
        /// <param name="a">Double First Number</param>
        /// <param name="b">Double Second Number</param>
        /// <param name="s">String Mathematical Operator</param>
        /// <returns></returns>
        public double doOperation(double a, double b, String s)
        {
            double c = 0.0;
            if (s.Equals("+"))
                c = (a + b);
            else if (s.Equals("-"))
                c = (a - b);
            else if (s.Equals("*"))
                c = (a * b);
            else if (s.Equals("/"))
            {
                try
                {
                    c = (a / b);
                    if (c == double.NegativeInfinity || c == double.PositiveInfinity)
                    {
                        throw new ArgumentException("Yo. Can't divide by zero...");
                    }
                }
                catch (ArithmeticException e)
                {
                    throw new ArgumentException(e.Message);
                }

            }
            else
            {
                throw new ArgumentException("Improper operator: " + s + ", is not one of +, -, *, or /");
            }
            return c;

        }

    }

    /// <summary>
    /// Custom made Scanner class for parsing a String input.
    /// </summary>
    class Scanner
    {
        private String[] userInput;
        private int pointer;
        private bool hasNextFlag = false;
        private bool hasNextDoubleFlag = false;

        /// <summary>
        /// Take the input and parse into substrings then store into String[] userInput.
        /// </summary>
        /// <param name="input">String User input.</param>
        public Scanner(String input)
        {

            userInput = input.Split();
            //Pointer for where the scanner is at in the string.
            pointer = -1;
        }

        /// <summary>
        /// Method to check if there is another token in the user input.
        /// </summary>
        /// <returns>Boolean If there is another token availible.</returns>

        public bool hasNext()
        {
            //The pointer has moved though the entire array.
            if (pointer == userInput.Length - 1)
            {
                return false;
            }
            else
            {
                //Set the flag to allow the next method to be called.
                hasNextFlag = true;
                //There is another value.
                return true;
            }
        }

        /// <summary>
        /// Method to retrieve the next token in the string. Cannot be called without
        /// checking for the presence of the next token with the hasNext method.
        /// </summary>
        /// <returns>String The token of the user input.</returns>
        public String next()
        {
            if (hasNextFlag)
            {
                pointer++;
                //increment the pointer to the next element and convert to a string.
                return userInput[pointer];
            }
            else
            {
                throw new Exception("Cannot call next() without calling hasNext() first.");
            }
        }

        /// <summary>
        /// Method to check if there is another token in the user input and if that token is
        /// a double.
        /// </summary>
        /// <returns>Boolean If there is another token availible.</returns>
        public bool hasNextDouble()
        {
            //Throw away var holder to satisfy the TryParse method.
            double foundDouble;

            String inputToTest = userInput[pointer + 1];
            //If the parse works return true.
            if (double.TryParse(inputToTest, out foundDouble))
            {
                hasNextDoubleFlag = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method to retrieve the next double value of the token in the string. Cannot be 
        /// called without checking for the presence of the next token with the 
        /// hasNextDouble method.
        /// </summary>
        /// <returns>Double The token of the user input as a double.</returns>
        public double nextDouble()
        {
            if (hasNextDoubleFlag)
            {
                //Increment the pointer to reach the double.
                pointer++;
                //Var holder for the number.
                double foundDouble;
                //Try to convert the double.
                double.TryParse(userInput[pointer], out foundDouble);
                //return the double.
                return foundDouble;
            }
            else
            {
                throw new Exception("Cannot call nextDouble() without calling hasNextDouble() first. ");
            }
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

    ///<summary>
    ///This is a class for a the structure of a stack of Node objects.
    ///It will inculde all of the functionality of a stack; including
    ///the link to the Top of the stack, and the interface methods for
    ///push, pop, peek, isEmpty and clear.
    ///</summary>
    //The LinkedStack class implements (:) the interface IStackADT.
    class LinkedStack : IStackADT
    {
        //The top of the stack.
        private Node top;

        public LinkedStack()
        {
            top = null;
        }

        /// <summary>
        /// "Push" a node object onto the stack and update the 'top' pointer.
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns>the item that was pushed to the top of the stack.</returns>
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

        /// <summary>
        /// A method to remove the top Object from the stack and return that object.
        /// It will also reassign the pointers for the top of the stack to the next node
        /// in the stack.
        /// </summary>
        /// <returns>Object from the top of the stack.</returns>
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

        /// <summary>
        /// Method to retrieve the data in the top Node Object.
        /// </summary>
        /// <returns>The data held by the top node.</returns>
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
    /// This class will be a singily linked node class capable of holding some 
    /// data Object and a pointer to its neighbor node.
    /// </summary>
    class Node
    {
        public Object data; //The data within the current node.
        public Node next;   //The pointer to the node which is next in line.

        /// <summary>
        /// This default constructor will create a new blank node with no data 
        /// or pointer to other nodes.
        /// </summary>
        
        public Node()
        {
            data = null;
            next = null;
        }

        /// <summary>
        /// This nondefault constructor will create a node with data and a pointer
        ///  to the next node in line.
        /// </summary>
        /// <param name="data">Object Data to be held by the node.</param>
        /// <param name="next">Node Neighbor node.</param>
        public Node(Object data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }

}
