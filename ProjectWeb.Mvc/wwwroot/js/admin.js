$(document).ready(function () {
    AOS.init();
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


var searchInput = document.getElementById('search-input');
searchInput.addEventListener("focusin", changeIconColor);
searchInput.addEventListener("focusout", backIconColor);

function changeIconColor() {
    let icon = document.getElementById('search-icon');
    icon.style.transition = "0.5s";
    icon.style.color = "#47B5FF";
}

function backIconColor() {
    let icon = document.getElementById('search-icon');
    icon.style.color = "#e5edf0";
}