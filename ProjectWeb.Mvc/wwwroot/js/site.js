AOS.init();

$(".close-icon").click(function () {
    $(".close-alert").fadeOut();
    $(".close-alert").remove();
});

function CheckInput() {
    let input = document.getElementById('phone-input').value;
    let result = document.getElementById('phone-error');
    try {
        if (isNaN(input)) {
            throw "لطفا شماره تماس معتبری وارد کنید!"
            return false;
        }

        if (input.length < 11) {
            throw "شماره تماس وارد شده معتبر نیست!";
            return false;
        }

        if (input.length > 11) {
            throw "شماره تماس وارد شده معتبر نیست!";
            return false;
        }

        else {
            document.getElementById('phone-error').innerHTML = "";
            return true;
        }
    }
    catch (error) {
        result.innerHTML = error;
        return false;
    }
}

$("#custom-tooltip").tooltip();
$("#logout-tooltip").tooltip();

function ShowMenu() {
    var responsiveNav = document.getElementById('responsive-nav');
    responsiveNav.style.display = "block";
    var pos = -220;
    var timer = setInterval(showNav, 1);
    function showNav() {
        if (pos == 0) {
            clearInterval(timer);
        }
        else {
            pos += 5;
            responsiveNav.style.right = pos + "px";
        }
    }

    var container = document.createElement("div");
    container.style.position = "absolute";
    container.style.top = "0";
    container.style.right = "0";
    container.style.bottom = "0";
    container.style.left = "0";
    container.style.background = "rgba(0, 0, 0, 0.7)";
    var body = document.getElementsByTagName("body")[0];
    body.appendChild(container);
}