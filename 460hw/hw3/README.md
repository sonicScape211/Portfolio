# Introduction to C#, Learning to Move in Visual Studio, XML Comments and Java Translation

## Homework #3

### Overveiw

For this assignment we will be working within the Visual Studio IDE. I have really been looking forward to learning C# and beginning to understand how to make my way around another professional IDE. I have spent most of my time working in Eclipse with Java so I don't think the transition will be too difficult.

I will be taking a calculator application that is already written and functioning in Java and translating it into C# code. Along the way I will also be learning how to document my code with XML. Alright let's jump in!

### Plan of Attack

One of my goals for this term is to start each project with a soild plan of how to address my problem. Here I have decided that I will start my translation with the most basic elements first and build from there. I will work towards building the `Node` class first and then move towards the `StackADT Interface` and then hit the `LinkedStack`. By this time it should be a pretty easy implmentation of these classes to create the functionality of the calculator.  

### Namespaces

The first thing that I have noticed in my transition between Java and C# is C#'s lack of file seperated classes! The classes seem to be declared within a `Namespace` area which is the program container, then all of the classes that we will be using will be contained within that. I'm not sure if this will be something I will come to love or hate...I really enjoy Java's seperation for readabilities sake, but I can see how it will be nice to have everything just right in one area with C#.

### XML Comments

I have found that the XML Comments are really nice! They are implemented in a similar fashion to HTML and JavaDocs. Here is a quick snippit of some from my codebase. 
```csharp
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
```

### Seriously?... Where's the Scanner?

Well any hope of this project being a quick translation were quickly dashed during my attempt to implement user input for the calculator. I have found that the C# language does not have a build in scanner class like Java does and in addition to this, most of the scanners I have found online just dont seem well built or don't fit the program requirements....well....Guess we are gonna build our own! (Better now than later. We will save this class and it will be the first addition in my personal C# Library). 

For times sake I decided to implement only the methods that I will need for this program. These will be : `next()`, `hasNext()`, `nextDouble()` and `hasNextDouble()`. The scanner itself is pretty boilerplate, but here is the constructor for the `Scanner` class and the `hasNext()` method. Some things to note here is the use of a String array for user input storage and the flags for indications to whether or not a `hasNextDouble()` or `hasNext()` method has been called or not.

```csharp
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
```
 
Here we have an example of a very useful built in method for C# which was the `.TryParse()`. This was great for testing out if a string was a double and if it was then storing it immediately to a given variable.
       
```csharp
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
```
  
  Really other then the issue of not having a built in Scanner class and needing to write it myself, the transition from Java to C# went very smooth! I will definatly enjoy working in this language more over the school year!
  
  ![Caculator in Action](../CalculatorScreenShots/ItWorks!.PGN)
