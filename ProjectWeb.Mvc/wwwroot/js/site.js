AOS.init({
    once: true
});

$("#custom-tooltip").tooltip();
$("#logout-tooltip").tooltip();
$("#lock-tooltip").tooltip();
$("#logout-tooltip").tooltip();
$("#edit-tooltip").tooltip();
$("#twitter-tooltip").tooltip();
$("#instagram-tooltip").tooltip();
$("#linkdin-tooltip").tooltip();
$("#github-tooltip").tooltip();


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
            pos += 10;
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
                responsiveNav.style.display = "none";
            }
            else {
                pos -= 10;
                responsiveNav.style.right = pos + "px";
            }
        }
    });
}

