# JavaScript, jQuery, User Input & Some Responsive Design
## Homework #2

### Overview
For the second assignment we will be working on learning how JavaScript and jQuery can allow us to create some really awesome responsive features in our websites, take some information from the user and also be able to do something with that information! We will also be working on some aspects of our version control skills including : `branching`, `merging` and `checkout`. Alright lets jump into what we have done with this!

This project was challenging in the way that I found myself spending a huge amount of time just creating different effects and researching how particular sites like [Wavelength Studios](http://www.wavelengthstudio.com) and [REI](https://www.rei.com/) were getting the types of styles that they were. This project really let me dive deep into UI design and style and got me really excited about starting to do my own web development outside of class.

### Responsive Element with jQuery

I decided in the my initial planning that I would continue to work off of my site from homework#1 because I wanted to be able to eventually use the site as a template for how to create a fully functioning webpage. Though the majority of the new code would be going into two new pages: the [ordering page](https://sonicscape211.github.io/460hw/hw2/small-business-ordering-page.html) and the [checkout page](https://sonicscape211.github.io/460hw/hw2/checkout-page.html) and would be manipulated by the JavaScript file. One of my implementations of the jQuery library was my creation of a smooth scroll effect on the main page of my website, although this will be able to be used on any anchors that I want to within the page as long as the JavaScript file is loaded. 
```javascript 
//Select any anchors with an event (click) to apply this effect (function) to.
$('a').on('click', function(event) {
    
    //This will check to see if the anchor even has a hash property
    //avalible to use. The hash would indicate that the anchor links to
    //another page.
    if (this.hash !== "") {
        //Stop default behavior because there is a relative link.
        event.preventDefault();
        //Store the hash value from the anchor.
        //This is our location!
        var hash = this.hash;
        //select (ie. query ($)) the html and body as the things to animate.
        $('html, body').animate({
            //The scrollTop function can be used to set the location of the scroll bar.
            //The 800 param is for the speed of the scroll. 
            scrollTop: $(hash).offset().top
        }, 800, function() {
            
            //When finished scrolling add the hash value to the location.
            //This is a default behavior of click so we need to replicate it.
            window.location.hash = hash;
        });
    }
});
```

### Problems and Solutions with JS
I also was able to use a combination of JavaScript and jQuery to solve an issue that I was running into with the [checkout page](https://sonicscape211.github.io/460hw/hw2/checkout-page.html). Whenever a user entered this page they would first be shown the Returning User view, which included a login form with username and password fields. There is also two buttons at the top for switching between the returning user and the guest checkout forms. 
![alt text][checkout-page]

If a user was on the login page and then tried to click on the "Sign in" button, the original code would swap the view to the Guest Form. Obviously this was a large UI flaw. Though I was able to create some functionality with JS in order to prevent users from doing this. This code would disable the button related the the form the user is currently viewing. Then when the other button is clicked it will swap the forms and disable the appropriate button.
```javascript

//This function will take in:
// a & b : elements to be swapped
// c & d : the buttons to be disabled to avoid logical errors created
// by the users while switching between views.
function swapVisibility(a, b, c, d) {
    "use strict";
    $(a).toggle();
    $(b).toggle();
    $(c).prop('disabled', function(i, v) {return !v});
    $(d).prop('disabled', function(i, v) {return !v});
    if(confirmpage_is_visible){
        $('#confirmation-page').hide();
    }
    
}
```
### User Input and Website Response
Then for the last section of the homework reqirements I took the user input from the guest checkout form, stored the information into an array, retrieved that information and inserted an HTML table into the page, below the form, to display the users contact information!

```javascript
//get and store the customer contact information into an array and start the 
//confirmation page creation.
function submitClick(email_id, phone_id, street_address_id, state_id, zip_id, confirmation_page_id) {
    "use strict"
    //push each argument.value to the array.
    for(var i = 0; i < arguments.length-1; i++) {
        checkout_information.push(document.getElementById(arguments[i]).value);
    }
    
    createContactConfirmationPage(confirmation_page_id);
    
}

//This will take in a value for the button pressed and then add the value to the checkout_information array.
function orderingPageSelectionButton(order_selection) {
    
    checkout_information.push(order_selection);

}

function createContactConfirmationPage(confirmation_page) {
    
    document.getElementById(confirmation_page).innerHTML = 
        "<table class=\"table\"> <thead> <tr> <th>#</th> </tr> <";
    
    
    
    document.getElementById(confirmation_page).innerHTML = "Email: " + checkout_information[0] + "<br>" + "Phone Number: " + checkout_information[1] + "<br>" + "Street Address: " + checkout_information[2] + "<br>" + "State: " + checkout_information[3] + "<br>" + "Zipcode: " + checkout_information[4];
    $('#confirmation-page').show();
    //flag that the confirm page is up.
    confirmpage_is_visible = true;
}
```

Overall I really enjoyed working on this project and know that what I have done here I will be coming back to complete on my own time (or if I'm lucky, as a starting point for another lab to add additional functionality to this simple webpage).

[Back to Homepage](../..)

[Previous Page](../hw1) [Next Page](../hw3)

[checkout-page]: (/LabScreenShots/checkoutpage.PNG)