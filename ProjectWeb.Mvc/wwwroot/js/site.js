$(document).ready(function () {
    AOS.init({
        once: true
    });
    $(".close-icon").click(function () {
        $(".close-alert").fadeOut();
        $(".close-alert").remove();
    });
});