//Assistance from: https://stackoverflow.com/questions/26970867/html-beginform-using-onsubmit-to-validate
/*
This links with the html.begin from on the Artist Edit view. This will prevent anyone from editing and artist's
birthday to some date in the future. Though this is a very basic filter as users can still enter dates which are
one day behind the current date.
*/
function validateForm(event) {
    event = event || window.event || event.srcElement;
    //Get the current contents of the Birthday coloumn.
    var artistBirthday = document.getElementById("artist-birthday");
    //Set the birthday value from a string.
    var birthday = new Date(artistBirthday.value);
    //Get the current date.
    var date = new Date();

    if (birthday >= date) {
        console.log("Caught")
        $('#dateRangeErrorMessage').show();
        event.preventDefault();
    }
    else {
        $('#dateRangeErrorMessage').hide();
    }
};
   


