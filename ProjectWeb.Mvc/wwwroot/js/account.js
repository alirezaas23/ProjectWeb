var loginUserInput = document.getElementById('login-user-input');

loginUserInput.addEventListener("focusin", function () {
    let icon = document.getElementById('login-userName-icon');
    icon.style.color = "#54BAB9";
    loginUserInput.style.outline = "none";
    loginUserInput.style.borderBottom = "2px solid #54BAB9";
});

loginUserInput.addEventListener("focusout", function () {
    let icon = document.getElementById('login-userName-icon');
    if (loginUserInput.value == "") {
        icon.style.color = "red";
        loginUserInput.style.borderBottom = "2px solid red";
    }
    else {
        icon.style.color = "#7e8388";
        loginUserInput.style.borderBottom = "1px solid #d1d4d7";
    }
});

var loginPassInput = document.getElementById('login-pass-input');

loginPassInput.addEventListener("focusin", function () {
    let icon = document.getElementById('login-pass-icon');
    icon.style.color = "#54BAB9";
    loginPassInput.style.outline = "none";
    loginPassInput.style.borderBottom = "2px solid #54BAB9";
});

loginPassInput.addEventListener("focusout", function () {
    let icon = document.getElementById('login-pass-icon');
    if (loginPassInput.value == "") {
        icon.style.color = "red";
        loginPassInput.style.borderBottom = "2px solid red";
    }
    else {
        icon.style.color = "#7e8388";
        loginPassInput.style.borderBottom = "1px solid #d1d4d7";
    }
});

var showPass = document.getElementById('show-pass-icon');
showPass.addEventListener("mousedown", function () {
    loginPassInput.type = "text";
});