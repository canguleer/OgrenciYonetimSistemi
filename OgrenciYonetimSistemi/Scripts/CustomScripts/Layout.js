$(function () {
    UstMesajlariGetir();
});


function UstMesajlariGetir() {
    $.ajax({
        type: "GET",
        url: "/Mesajlar/_ustMesajlariGetir",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#sohbetGecmisiListe").html(response);

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