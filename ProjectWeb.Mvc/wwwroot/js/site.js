$(document).ready(function () {
    AOS.init();
    $(".close-icon").click(function () {
        $(".close-alert").fadeOut();
        $(".close-alert").remove();
    });
});