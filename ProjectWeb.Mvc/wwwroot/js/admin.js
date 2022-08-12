$(document).ready(function () {
    AOS.init({
        once : true
    });
    $("#hamburger-icon img").click(function () {
        var responsiveMenu = $("#responsive-menu");
        responsiveMenu.show();
        responsiveMenu.animate({
            right: 0
        }, 400);

        $("body").append('<div class="body-container"></div>');
        $(".body-container").click(function () {
            responsiveMenu.animate({
                right: "-220px"
            }, 400, function () {
                responsiveMenu.hide();
            });
            $(this).remove();
        });
    });
});

$(".custom-tooltip").tooltip();
$(".ticket-tooltip").tooltip();