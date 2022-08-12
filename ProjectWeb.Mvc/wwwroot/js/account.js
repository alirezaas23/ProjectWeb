AOS.init({
    once: true
});

var loginUserInput = document.getElementById('login-user-input');

loginUserInput.addEventListener("focusin", function () {
    let icon = document.getElementById('login-userName-icon');
    icon.style.color = "#54BAB9";
});

loginUserInput.addEventListener("focusout", function () {
    let icon = document.getElementById('login-userName-icon');
    if (loginUserInput.value == "") {
        icon.style.color = "red";
    }
    else {
        icon.style.color = "#7e8388";
    }
});

var loginPassInput = document.getElementById('login-pass-input');

loginPassInput.addEventListener("focusin", function () {
    let icon = document.getElementById('login-pass-icon');
    icon.style.color = "#54BAB9";
});

loginPassInput.addEventListener("focusout", function () {
    let icon = document.getElementById('login-pass-icon');
    if (loginPassInput.value == "") {
        icon.style.color = "red";
    }
    else {
        icon.style.color = "#7e8388";
    }
});

var showPass = document.getElementById('show-pass-icon');
showPass.addEventListener("mousedown", function () {
    loginPassInput.type = "text";
});

showPass.addEventListener("click", function () {
    loginPassInput.type = "password";
});