$("#search-button").on("click", function () {
    alert("here");

    search();

});

function search() {
    //Get the value out of the text element
    var searchInput = document.getElementById('search-input').value.trim();
    
    $.ajax({
        type: "GET",
        url: "/Home/Search",
        //type of data expected back from the server. .ajax will by default try and infer but we will just specify here.
        //dataType: "json",
        //Data to be passed to GET function.
        data: { searchInput: searchInput },

        success: function (data) {
            alert("Whoop");
            console.log(data);
            //alert(response);
        },

        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
        }
    });
}