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

function ScrolToProducts() {
    document.getElementById("products").scrollIntoView({ behavior: 'smooth' });
}

function OpenAvatarInput() {
    $("#userAvatar").click();
}

function ChangeUserAvatar(url) {
    var avatarInput = document.getElementById("userAvatar");
    var file = avatarInput.files[0];

    var formData = new FormData();
    formData.append("userAvatar", file);

    $.ajax({
        url: url,
        type: "post",
        data: formData,
        contentType: false,
        processData: false,
        beforeSend: function () {
            StartLoading();
        },
        success: function (response) {
            EndLoading();
            if (response.status === "Success") {
                location.reload();
            }

            else {
                swal({
                    title: "خطا",
                    text: "فرمت فایل وارد شده نامعتبر است.",
                    icon: "error",
                    button: "باشه"
                });
            }
        },
        error: function () {
            EndLoading();
            swal({
                title: "خطا",
                text: "عملیات با خطا مواجه شد.",
                icon: "error",
                button: "باشه"
            });
        }
    });
}

function StartLoading(selector = 'body') {
    $(selector).waitMe({
        effect: 'bounce',
        text: 'لطفا صبر کنید ...',
        bg: 'rgba(255, 255, 255, 0.7)',
        color: '#000'
    });
}

function EndLoading(selector = 'body') {
    $(selector).waitMe('hide');
}

var datepickers = document.querySelectorAll('.datepicker');
if (datepickers.length) {
    for (var datepicker of datepickers) {
        var id = $(datepicker).prop("id");
        kamaDatepicker(id,
            {
                placeholder: "مثال 1401/01/01",
                closeAfterSelect: false,
                buttonsColor: "red",
                forceFarsiDigits: true,
                markToday: true,
                markHolidays: true,
                highlightSelectedDay: true,
                sync: true,
                gotoToday: true
            });
    }
}

$("#CountryId").on("change", function () {
    var countryId = $("#CountryId").val();
    if (countryId != "" && countryId.length) {
        $.ajax({
            url: $("#CountryId").attr("data-url"),
            type: "get",
            data: { countryId: countryId },
            beforeSend: function () {
                StartLoading();
            },
            success: function (response) {
                EndLoading();
                $("#CityId option:not(:first)").remove();
                $("#CityId").prop("disabled", false);
                for (var city of response) {
                    $("#CityId").append(`<option value="${city.id}">${city.title}</option>`);
                }
            },
            error: function () {
                EndLoading();
                swal({
                    title: "خطا",
                    text: "عملیات با خطا مواجه شد.",
                    icon: "error",
                    button: "باشه"
                });
            }
        });
    }

    else {
        $("#CityId option:not(:first)").remove();
        $("#CityId").prop("disabled", true);
    }
});

$(function () {
    if ($("#CountryId").val() !== "") {
        $("#CityId").prop("disabled", false);
    }

    else {
        $("#CityId").prop("disabled", true);
    }
});