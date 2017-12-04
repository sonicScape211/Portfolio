function validateForm(event) {
    event = event || window.event || event.srcElement
    //Get the element from the form where the user inputs the DOB.
    var birthday = document.getElementById('artist-dob');
    //Convert the string into a date format for comparison.
    var birthdayDate = new Date(birthday.value);
    //Get the current system date to compare against.
    var currentDate = new Date();

    if (birthdayDate >= currentDate) {
        //Show the custom error message to the user.
        $('#date-range-error-message').show();
        //Prevent the DOM's default process (changing the page to the success view.)
        event.preventDefault();
    }
    else {
        //Keep the error message hidden. 
        $('#date-range-error-message').hide();
    }

}