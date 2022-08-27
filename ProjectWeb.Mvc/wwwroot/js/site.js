AOS.init({
    once: true
});

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


// Responsive Nav
function ShowNav() {
    let responsiveNav = document.getElementById('responsive-nav');
    responsiveNav.style.display = "block";
    let pos = -220;
    let interval = setInterval(OpenNav, 1);
    function OpenNav() {
        if (pos == 0) {
            clearInterval(interval);
        }
        else {
            pos += 5;
            responsiveNav.style.right = pos + "px";
        }
    }
    let bgOverlay = document.createElement("div");
    bgOverlay.style.position = "absolute";
    bgOverlay.style.top = "0";
    bgOverlay.style.right = "0";
    bgOverlay.style.bottom = "0";
    bgOverlay.style.left = "0";
    bgOverlay.style.height = "100%";
    bgOverlay.style.background = "rgba(0, 0, 0, 0.4)";
    let body = document.getElementsByTagName("body")[0];
    body.appendChild(bgOverlay);
    bgOverlay.addEventListener("click", function () {
        this.remove();
        let pos = 0;
        let interval = setInterval(CloseNav, 1);
        function CloseNav() {
            if (pos == -220) {
                clearInterval(interval);
            }
            else {
                pos -= 5;
                responsiveNav.style.right = pos + "px";
            }
        }
    });
}