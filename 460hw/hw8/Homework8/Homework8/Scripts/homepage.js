$('.genre-button').on('click', function () {

    //get the value of the button. This will be the genre.
    var genreString = $(this).val();

    console.log(genreString);

    $.ajax({

        type: 'POST',
        url: '/Home/DisplayArtwork',
        data: { genre: genreString },
        dataType: 'html',
        success: function(response) {
            console.log("success!");
            
            $('#artwork-container').html(response);
            
            //Show the artwork section of the html here.
            //response probably wont be anything.
        },
        error: function() {
            console.log("Some error in ajax.");
        }

    });
    
});

