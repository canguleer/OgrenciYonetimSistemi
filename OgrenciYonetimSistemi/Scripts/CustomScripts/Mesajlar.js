
$(document).ready(function () {

    $("#sohbetGecmisiAra").keyup(function () {
        PersonelAra("sohbetGecmisiAra");
    });

    $("#yeniMesajAra").keyup(function () {
        PersonelAra("yeniMesajAra");
    });

    $(".chat_list").click(function (event) {
        var Id = $(event.target)[0].closest(".chat_list").id;

        sohbetGecmisiGetir(Id);
    })



});

function sohbetGecmisiGetir(Id) {
    $.ajax({
        type: "GET",
        url: "/Mesajlar/_sohbetGecmisiGetir",
        contentType: "application/json; charset=utf-8",
        data: { SohbetGecmisiIstenilenUye_Id: Id },
        success: function (response) {
            $(".msg_history").html(response);
        }
        , error: function (errorData) {
            console.log("error: " + errorData);
        }

    })
}



function PersonelAra(data) {
    var input, filter, mylist, txtValue, name;
    if (data == "sohbetGecmisiAra") {
        name = "sohbetGecmisiAra";
        mylist = $(".sohbetGecmisiListe")[0];
    }
    else if (data == "yeniMesajAra") {
        name = "yeniMesajAra";
        mylist = $(".yeniMesajListe")[0];
    }


    input = $("#" + name);
    filter = input.val().toUpperCase();

    $(".chat_list", mylist).each(function (i, e) {
        if ($(this)) {
            txtValue = $("h5", $(this)).html().toUpperCase();
            if (txtValue.indexOf(filter) > -1) {

                $(".chat_list", mylist)[i].style.display = "";
            }
            else {
                $(".chat_list", mylist)[i].style.display = "none";
            }
        }
    })
}
