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

