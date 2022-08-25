AOS.init();

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

function ShowNav() {
    let responsiveNav = document.getElementById('responsive-menu');
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
    let container = document.createElement("div");
    container.style.position = "absolute";
    container.style.top = "0";
    container.style.right = "0";
    container.style.bottom = "0";
    container.style.left = "0";
    container.style.background = "rgba(0, 0, 0, 0.4)";
    container.style.height = "100%";
    let body = document.getElementsByTagName("body")[0];
    body.appendChild(container);
    container.addEventListener("click", function () {
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
    window.addEventListener("resize", function () {
        responsiveNav.style.display = "none";
        container.style.display = "none";
    });
}