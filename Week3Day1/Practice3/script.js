$(document).ready(function () {

    let count = 0;
    $(".container").on("click", ".add-to-cart", function () {

        count++;
        $("#cart-count").text(count);

        $(this).prop("disabled", true);

        $(this).attr("data-added", "true");

        $(this).text("Added");


        $(this).siblings(".msg").text("✔ Added to cart");

    });

});