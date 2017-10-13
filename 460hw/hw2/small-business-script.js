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