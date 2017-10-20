using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator
{
    class Calculator
    {
        /**
         * 
         */
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

            Scanner st = new Scanner(input, input.Length);

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
    class Scanner
    {
        private String[] userInput;
        private int pointer;
        private bool hasNextFlag = false;
        private bool hasNextDoubleFlag = false;

        public Scanner(String input, int inputLength)
        {

            userInput = input.Split();
            //Pointer for where the scanner is at in the string.
            pointer = -1;
        }

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
    /// <summary>
    /// This class will replicate the functionality of the java.util.Scanner package.
    /// All credit for this class goes to nakov.com at:
    /// http://www.nakov.com/blog/2011/11/23/cin-class-for-csharp-read-from-console-nakov-io-cin/
    /// </summary>
    class CScanner
    {

        public static string NextToken()
        {
            //This will be the var for the tokens in our user input string.
            //The entire string will be held here and then we will break it down.
            StringBuilder tokenChars = new StringBuilder();
            bool tokenFinished = false;
            bool skipWhiteSpaceMode = true;
            //Loop to the end of the user String.
            while (!tokenFinished)
            {
                int nextChar = Console.Read();
                //Console.Read will return a -1 if there is nothing else to read in the string.
                if (nextChar == -1)
                {
                    //The string is finished.
                    tokenFinished = true;
                }
                else
                {
                    //Hold the character we just read from the users input.
                    char ch = (char)nextChar;
                    //Use the char function IsWhiteSpace to check for spaces.
                    if (char.IsWhiteSpace(ch))
                    {

                        if (!skipWhiteSpaceMode)
                        {
                            tokenFinished = true;
                            //If the ch is \r we need to check if our OS's 'new line' code
                            //is \r\n (this is typically in Windows or older OS's
                            //So if it is, just keep reading, we arent at the end.
                            if (ch == '\r' && (Environment.NewLine == "\r\n"))
                            {
                                Console.Read();
                            }
                        }
                    }
                    else
                    {
                        //Set the WhiteSpaceMode to false because we will only allow one
                        //Space in the string.
                        skipWhiteSpaceMode = false;
                        //Add the token to the string.
                        tokenChars.Append(ch);
                    }

                }
            }
            //Change the stringBuilder into a string and return.
            string token = tokenChars.ToString();
            return token;
        }

        public static int NextInt()
        {
            //Take in the user input and store.
            string token = CScanner.NextToken();
            //parse the returning string into integers and return.
            return int.Parse(token);
        }

        /// <summary>
        /// This will read floating-point number.
        /// This will also deal with any international decimal separator issues.
        /// </summary>
        /// <param name="acceptAnyDecimalSeparator"></param>
        /// <returns></returns>
        public static double NextDouble(bool acceptAnyDecimalSeparator = true)
        {
            string token = CScanner.NextToken();
            if (acceptAnyDecimalSeparator)
            {
                //This will replace and instance of ',' with a decimal
                token = token.Replace(',', '.');
                double result = double.Parse(token, CultureInfo.InvariantCulture);
                return result;
            }
            else
            {
                double result = double.Parse(token);
                return result;
            }
        }

        public static decimal NextDecimal(bool acceptAnyDecimalSeparator = true)
        {
            string token = CScanner.NextToken();
            if (acceptAnyDecimalSeparator)
            {
                token = token.Replace(',', '.');
                decimal result = decimal.Parse(token, CultureInfo.InvariantCulture);
                return result;
            }
            else
            {
                decimal result = decimal.Parse(token);
                return result;
            }
        }

    }

}
