 # ASP .Net MVC 5, Razor and More C#!

## Homework #4
[Homework Repo](https://github.com/sonicScape211/sonicScape211.github.io/tree/master/460hw/hw4)

[Back to the Homepage](../../)

[Previous](../hw3)
[Next](../hw5)

### Overview

For this project we will be diving into learning ASP .Net MVC (Model, View, Controller) to build our websites with better seperation of the working parts and with easy access to databases! Sound exciting. Let's get started. I will be building a website which has 3 different pages, all of which will be able to take user input and return something. Page one contains a calculator for calculating a homebrewers potential alcohol by volume of their brew using the original gravity readings and the specific gravity readings. The second page will be a temperature adjuster for a specific gravity of a homebrew and then the third will be a simple loan calculator.

### MVC? What the heck is that?

We are going to be using this framework for the rest of the term so we should probably get a soild understanding of what this thing is doing for us! The Model - View - Controller relationship is really important here and the idea, in a nut shell, is that that each of these classes has a different job. The Model is where our data is going to be, but we wont start really using this til next week so we will leave that where it is right now. The View is where all of our HTML will be coming in! We will also be using Razor which is a Markup language created to allow programmers to easily create functionality between their code and the HTML. A nice example of this in action can be seen from my project in which I have created a list of links for each page required by this project. 
```csharp
<li>@Html.ActionLink("Page #1", "GravityCalculation", "GravityCalculation")</li>
            <li>@Html.ActionLink("Page #2", "TemperatureAdjustment", "TemperatureAdjustment")</li>
            <li>@Html.ActionLink("Page #3", "LoanCalculator", "LoanCalculator")</li>
```
The Razor code is denoted by the '@' symbol and here we are easily creating links to other Views. This is also allowing us to imbed our C# right into the HTML code for easy readability!

The Controller is a class which passes information between the Models and the Views and really is the part of the program which contains the functionality.

So we have Model = "Data", View = "Page Display/HTML" and Controller = "Functionality and intermediary between Model and Data".

### ViewBag
One of the most important concepts that we need to get down with this project is the idea of a `ViewBag` and `ViewData`. The `ViewBag` is a place for temporatry storage and transport of information from the Controller to the a given View. We can see in this: 

```csharp
[HttpPost]
        public ActionResult TemperatureAdjustment(FormCollection form)
        {
            double gravity = double.Parse(form.Get(0));
            double temperature = double.Parse(form.Get(1));

            double result = temperatureCalculation(gravity, temperature);

            ViewBag.adjustedGravity = result.ToString();
            ViewBag.gravity = gravity;

            return View();
        }

```
We are placing the information into the ViewBag under variable names, declared with `.`, so we get `ViewBag.adjustedGravity` holds `result.ToString`. The `ViewBag` is then transported to the TemperatureAdjustment.cshtml by the `return View();` code.
It is important to note that the ViewBag is ONLY temperary storage and the information will be lost after the first transfer to the view.
### ViewData
But there is another way to pass information around to eventually be transported to a View. This is where `ViewData` comes in. Here is a code sample.
```csharp
	ViewData["abv"] = Math.Round(((float.Parse(originalGravity) - float.Parse(specificGravity)) * 131), 2).ToString(); 
```
So ViewData here is actually storing the information within a Dictionary class and allows us to access our data based off of Key-Value pairs, the key here being "abv".

### TempData
We also have another way to pass data and this one is really useful! This is the `TempData` class and it allows our data to be stored longer so we can hold on to those values while the program executes other functions.

```csharp
public double calculatorLogic(double loanAmount, double interestRate, double termLength)
        {
            interestRate = interestRate * .01;
            double negitiveTermLength = termLength - (termLength * 2);
            double result = loanAmount * (interestRate / (1 - (Math.Pow((1 + interestRate), negitiveTermLength))));
            //Store the result in TempData in order to pass data to another method in the controller.
            TempData["paymentAmount"] = Math.Round(result, 2);
            return result;
        }
```

Here is an example where I wanted to be able to store the  paymentAmount away to be able to then transfer it to another View in this code:
```csharp
  }
            TempData["termLength"] = term;
            TempData["interestRate"] = rate;
            TempData["loanAmount"] = loan;
            calculatorLogic(loan, rate, term);
            return RedirectToAction("ResultPage");
        }
```
What is important to note here is that this data will not stay around forever. The TempData will only stay around for the lifetime of the HttpRequest. Basically what we will use it for is for transfering information between controllers or actions as we did here.

### Form Requests

So say that we have a form that we want a user to fill out. Kinda like the form we had in the [Homework#2](../hw2) website. Well we are now have an easy way of retrieving that information! That is through the `Request.Form` code. This is something we can use during a `Post` request to the server in which the controller can grab the information from the form the user filled out and do some operation on it. Here is some code:
```csharp
public ActionResult GravityFormInformation()
        {
            string originalGravity = Request.Form["original-gravity"];
            string specificGravity = Request.Form["specific-gravity"];
            ViewBag.originalGravity = originalGravity;
            ViewBag.specificGravity = specificGravity;

            ViewData["abv"] = Math.Round(((float.Parse(originalGravity) - float.Parse(specificGravity)) * 131), 	2).ToString(); 
            return View();
        }
```

And here is the accompanying View code
```csharp
	<form method="post" action="~/GravityCalculation/GravityFormInformation">
            <input class="form-control" type="text" name="original-gravity" placeholder ="Original Gravity (Ex. 1.056)" />

```
Here the action perameter specifies what action needs to be performed in the Controller and then the `Request.Form` uses the `name` in the HTML to locate the information it needs to grab.

We can also get form information in another way and that is through query strings.

```csharp
[HttpPost]
        public ActionResult TemperatureAdjustment(FormCollection form)
        {
            double gravity = double.Parse(form.Get(0));
            double temperature = double.Parse(form.Get(1));
```
Here we use the `(FormCollection form)` to get specific elements from the URL query string. The form will begin at index 0 and go from there. The disadvantage to this is that if a form element is added to the View then we will need to change our code in the controller as well to make sure we are still retrieving accurate information.

[Back to the Homepage](../../)

[Previous](../hw3)
[Next](../hw5)