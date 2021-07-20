$(function () {
    UstMesajlariGetir();
    SessionExpiredControl();



});


function UstMesajlariGetir() {
    $.ajax({
        type: "GET",
        url: "/Mesajlar/_ustMesajlariGetir",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#sohbetUstMesaj").html(response);

        }
        , error: function (errorData) {
            console.log("error: " + errorData);
        }

    })
}



function mesajDetayiGetir(Id) {

    var pageLink = window.location.href;
    if (pageLink.includes("Mesajlar")) {
        sohbetDetaylariGetir(Id);
    }
    else {
        window.location.href = "../Mesajlar/Index/" + Id;
    }

}

function SessionExpiredControl() {
    var sessionTimeoutWarning = 30; //session süresi 20 dk ;

    var sTimeout = parseInt(sessionTimeoutWarning) * 60 * 1000;
    setTimeout('SessionEnd()', sTimeout);

}

function SessionEnd() {
    window.location = "/Account/LogOut";
}

function ValidateControl(o) {
    var obj = $(o).parents("div.modal.fade");
    var Id = $("form", obj).attr("id");

    //burada sadece $("form") da denilbilirdi biz burada örnekleri çoğaltmak istedik....
    var form = $("form#" + Id);
    var element_message;

    var IsValid = 1;


    $("input, select, textarea", form)
        .not(":submit")
        .each(function (i, element) {
            element = $(element);
            if ((element.is(".required") || element.prop("required")) && (element.val() == "" || element.val() == 0 || element.val() == null || element.val() == "null")) {

                if (IsValid == 1) {
                    IsValid = 0;
                }

                var elementName = element[0].name;
                element_message = element.attr("title");
                if (!$(element).hasClass('is-invalid')) {
                    $(element).addClass('is-invalid');
                    element.closest("div[class*='col-sm']").append('<span style="color:red; font-size:14px;">' + element_message + '</span>');

                }
            }
            else {
                if ($(element).hasClass('is-invalid')) {
                    $(element.removeClass("is-invalid"));
                    element.closest(".form-group").find("span").remove();
                }
            }
        });

    return IsValid;
}