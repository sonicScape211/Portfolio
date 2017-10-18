//customer information to include: what product and contact info.
var checkout_information = [];
//flag for confirmpage.
var confirmpage_is_visible = false;

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
//Function to reset the display of an element by its ID.
function show(a) {
    //What the fuck does this even do? Find out...
    "use strict";
    document.getElementById(a).style.display = "block";

}

function hide(a) {
    "use strict";
    document.getElementById(a).style.display = "none";
}

function checkIfElementIsVisible(a) {
    "use strict";
    if (document.getElementById(a).style.display === "block") {
        return true;
    } else {
        return false;
    }
}

function swapVisibility(a, b) {
    "use strict";
    
    //if the element is visible hide it.
    if (checkIfElementIsVisible(a)) {
        hide(a);
        show(b);
    }
    else {
        show(a);
        hide(b);
    }
}

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
    show(confirmation_page);
    //flag that the confirm page is up.
    confirmpage_is_visible = true;
}
