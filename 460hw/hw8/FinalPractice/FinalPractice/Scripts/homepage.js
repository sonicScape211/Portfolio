$('.genre-button').on('click', function () {
    //get the value of the button just clicked.
    var genre = $(this).val();

    $.ajax({

        type: 'POST',
        url: 'Home/GenreSelection',
        data: {genreID : genre},
        dataType: 'html',
        success: function (response) {
            $('#artworks-container').html(response);
        },
        fail: function () {
            console.log("Failed in AJAX");
        }

    });

});