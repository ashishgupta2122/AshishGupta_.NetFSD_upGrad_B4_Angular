$(document).ready(function () {
    $('.question').click(function () {
        $(this).next('.answer').slideToggle();
        $(this).toggleClass('active');
    });
});