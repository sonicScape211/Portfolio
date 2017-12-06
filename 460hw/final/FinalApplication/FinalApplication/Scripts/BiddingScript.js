function addTimeStamp(event) {
    event = event || window.event || event.srcElement;

    var timeForm = document.getElementById("bid-submit-button");

    var currentTime = new Date();

    timeForm.innerText = currentTime.toString();

    console.log(timeForm.innerText);
}