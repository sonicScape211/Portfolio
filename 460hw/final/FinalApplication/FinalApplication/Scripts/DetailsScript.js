

var ajax_call = function () {
    $.ajax({

        type: 'POST',
        url: '/Items/UpdateBids',
        dataType: 'html',
        success: function (response) {
            console.log("Yep");


        },
        error: function () {

            console.log("Nope");
        }

    });
}

var interval = 1000 * 5;

window.setInterval(ajax_call, interval)

