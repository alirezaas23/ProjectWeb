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
        if (isNaN(input)) throw "لطفا شماره تماس معتبری وارد کنید!";

        if (input.length < 11) {
            throw "شماره تماس وارد شده معتبر نیست!";
        }

        if (input.length > 11) {
            throw "شماره تماس وارد شده معتبر نیست!";
        }

        else {
            throw "";
        }
    }
    catch (error) {
        result.innerHTML = error;
    }
}