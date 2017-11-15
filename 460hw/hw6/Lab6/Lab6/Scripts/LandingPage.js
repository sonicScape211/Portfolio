$(document).ready(function () {
    $(".banner-nav-link").on('click', function () {
        
        swapDivVisibility(this, "#banner-drop-downs");
  
    });

    $(".product-categories-link").on("click", function () {
        swapDivVisibility(this, "#product-categories-container")
    });

    function swapDivVisibility(button, divContainer)
    {
        /*
            This will get get the drop down menus which are equal to the index of
            the button pressed. ie. mens-drop-down is in index 0 of the ul. This will get
            the div which is in the 0 index position of the banner-drop-downs container.
        */
        var $dropDown = $(divContainer).children().eq($(button).parent().index());

        //Toggle that divs visibility
        $dropDown.toggle();
        //Hide the rest.
        $dropDown.siblings().hide();
    }

});