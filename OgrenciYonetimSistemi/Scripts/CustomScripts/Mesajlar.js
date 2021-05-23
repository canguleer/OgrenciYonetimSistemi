
$(document).ready(function () {

    sohbetGecmisListesiYenile();

    $("#sohbetGecmisiAra").keyup(function () {
        PersonelAra("sohbetGecmisiAra");
    });

    $("#yeniMesajAra").keyup(function () {
        PersonelAra("yeniMesajAra");
    });


    //öğretmen listesi için kullanılıyor, sohbet geçmişi detay için ise foreach içinde onclik tanımlı..
    $(".chat_list").on("click", function () {
        var Id = $(event.target)[0].closest(".chat_list").id;
        sohbetDetaylariGetir(Id);
    })

    $("button.msg_send_btn").click(function () {
        MesajGonder();
    });

    $(document).keypress(function (event) {
        if (event.keyCode == 13) {
            var Mesaj = $(".write_msg").val();
            if (Mesaj.length > 0) {
                MesajGonder();
            }
        }
    });

    if ($("#MesajDetayiIstenilenUye_Id").val() > 0) {
        sohbetDetaylariGetir($("#MesajDetayiIstenilenUye_Id").val());
    }
});




function sohbetDetaylariGetir(Id) {

    $("div.chat_list").removeClass("active_chat");
    if (Id > 0) {
        $("div#" + Id + ".chat_list").addClass("active_chat");

    }

    $.ajax({
        type: "GET",
        url: "/Mesajlar/_sohbetDetaylariGetir",
        contentType: "application/json; charset=utf-8",
        data: { SohbetGecmisiIstenilenUye_Id: Id },
        success: function (response) {
            $(".msg_history").html(response);
            $(".msg_history").scrollTop($(".msg_history")[0].scrollHeight); //scrool en alta iner..
            if (!($($("div#" + Id + ".chat_list")[0]).hasClass("active_chat")))
            {
                $($("div#" + Id + ".chat_list")[0]).addClass("active_chat")
            }

        }
        , error: function (errorData) {
            console.log("error: " + errorData);
        }

    })
}

function sohbetGecmisListesiYenile(Id) {

    $.ajax({
        type: "GET",
        url: "/Mesajlar/_sohbetGecmisiListeGetir",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $(".sohbetGecmisiListe").html(response);
            if (Id > 0) { //sohnet yenilendikten sonra en son mesaj atılan kişiyi aktif işaretle
                $("div#" + Id + ".chat_list").addClass("active_chat");
            }
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


function MesajGonder() {
    var Mesaj = $(".write_msg").val();
    var AliciUye_Id = $("div.SohbetEdilecekUye").attr("id");


    if (!(AliciUye_Id > 0)) {
        Swal.fire(
            'Uyarı',
            'Mesajı göndereceğiniz kişiyi seçiniz.',
            'warning'
        );
        return;
    }

    if (!(Mesaj.length > 0)) {
        Swal.fire(
            'Uyarı',
            'Gönderilecek mesajı giriniz.',
            'warning'
        );
        return;
    }
    $.ajax({
        type: "POST",
        url: "/Mesajlar/MesajGonder",
        data: {
            Mesaj: Mesaj,
            AliciUye_Id: AliciUye_Id
        },
        success: function (result) {
            if (result.status == 1) {
                $.ajax({
                    type: "GET",
                    url: "/Mesajlar/_sohbetDetaylariGetir",
                    contentType: "application/json; charset=utf-8",
                    data: { SohbetGecmisiIstenilenUye_Id: AliciUye_Id },
                    success: function (response) {
                        $(".msg_history").html(response);
                        $(".msg_history").scrollTop($(".msg_history")[0].scrollHeight); //scrool en alta iner..
                        $(".write_msg").val("");
                        sohbetGecmisListesiYenile(AliciUye_Id);

                    },
                    error: function (errorData) {
                        console.log("error: " + errorData);
                    }
                });
            }
            else {
                Swal.fire(
                    'Hata',
                    result.message,
                    'danger'
                );
                return;
            }

        },
        error: function (errorData) {
            console.log("error: " + errorData);
        }

    })

}

