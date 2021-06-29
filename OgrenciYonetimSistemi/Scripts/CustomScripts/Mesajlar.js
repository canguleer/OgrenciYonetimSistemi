
$(document).ready(function () {
    var MesajDetayiIstenilenUye_Id = $("#MesajDetayiIstenilenUye_Id").val(); //Index html sayfasından html.Hidden ile gelen deger.. (üye seçilmiş demektir.)

    sohbetGecmisListesiYenile(MesajDetayiIstenilenUye_Id);

    $("#sohbetGecmisiAra").keyup(function () {
        PersonelAra("sohbetGecmisiAra");
    });

    $("#yeniMesajAra").keyup(function () {
        PersonelAra("yeniMesajAra");
    });

    $("#topluMesajModal").click(function () {
        TopluMesajModalGizleGoster();
    })

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



    if (MesajDetayiIstenilenUye_Id > 0) { //Yazışmalarım sayfasınında değilken üst mesajlardan sohbet detayı istenirse ilgili kişinin mesaj detaylarını aç..
        sohbetDetaylariGetir(MesajDetayiIstenilenUye_Id);
    }


});




function sohbetDetaylariGetir(Id) {
    $("#overlay").fadeIn(1);

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
            $("#overlay").fadeOut(300);
            $(".msg_history").html(response);
            $(".msg_history").scrollTop($(".msg_history")[0].scrollHeight); //scrool en alta iner..
            if (!($($("div#" + Id + ".chat_list")[0]).hasClass("active_chat"))) {
                $($("div#" + Id + ".chat_list")[0]).addClass("active_chat")


            }
            ustMesajOkunmaKontrol(Id);// okunmayan mesaj ifaesi varsa kaldır..
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

            var obj = $(".sohbetGecmisiListe");
            $("div.chat_list", obj).each(function (i, e) {
                var sayi = $(this).find("[name=OkunmayanMesajAdet]").val();
                if (sayi > 0) {
                    $(this).find("p#mesaj").css({
                        "color": "blue",
                        "font-weight": "bold"
                    });

                    $(this).find("h5").append("<span>(" + sayi + ")</span>")
                    $(this).find("span").css({
                        "font-size": "15px",
                        "color": "blue",
                        "font-weight": "800"
                    });
                }

            });

            if (Id > 0) {  // bir üyenin sohbet geçmişi isteniyor demektir..
                $("div#" + Id + ".chat_list").addClass("active_chat"); //sohnet yenilendikten sonra en son mesaj atılan kişiyi aktif işaretle
                //setTimeout('ustMesajOkunmaKontrol(' + Id + ')', 500); 0.5 sn bekletipte yönlendirme yapılabilir..
                ustMesajOkunmaKontrol(Id); //okunmayan mesajlar yüklenmiş , layout üst mesajlardan üye seçilmiş dolayısıyla mesaj okundu yap ve okunmamış mesaj özelliği kaldır..
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
                        sohbetGecmisListesiYenile(AliciUye_Id); //her yeni mesajdan sonra liste yenilenir..

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
                    'error'
                );
                return;
            }

        },
        error: function (errorData) {
            console.log("error: " + errorData);
        }
    })
}

function mesajOkunmaKontrol(o) {
    var obj = $(o);
    //$(o).find("[name=OkunmayanMesajAdet]").attr("value") bu şekilde de değer alınabilir..
    var okunmayanMesajAdet = $("#OkunmayanMesajAdet", obj).val();
    var mesajGonderenUye_Id = obj.attr("id");

    if (okunmayanMesajAdet > 0) {
        $.ajax({
            type: "POST",
            url: "/Mesajlar/MesajOkundu",
            data: {
                mesajGonderenUye_Id: mesajGonderenUye_Id
            },
            success: function (result) {
                if (result.status == 1) {
                    $("p#mesaj", obj).removeAttr("style");
                    //$("span", obj)[0].style.display = "none"; bu bir yöntem.. in javascript
                    $("span", obj).css("display", "none");

                    UstMesajlariGetir();
                }
            },
            error: function (errorData) {
                console.log("error: " + errorData);
            }
        });
    }

}


function ustMesajOkunmaKontrol(Id) {

    //$(o).find("[name=OkunmayanMesajAdet]").attr("value") bu şekilde de değer alınabilir..
    var sohbetObj = $.find("div#" + Id + ".chat_list:eq(0)"); // iki divden ilk child ı al dedim.
    var okunmayanMesajAdet = $("#OkunmayanMesajAdet", sohbetObj).val();

    if (okunmayanMesajAdet > 0) {
        $.ajax({
            type: "POST",
            url: "/Mesajlar/MesajOkundu",
            data: {
                mesajGonderenUye_Id: Id
            },
            success: function (result) {
                if (result.status == 1) {
                    $("p#mesaj", sohbetObj).removeAttr("style");
                    //$("span", obj)[0].style.display = "none"; bu bir yöntem.. in javascript
                    $("span", sohbetObj).css("display", "none");

                    UstMesajlariGetir();
                }
            },
            error: function (errorData) {
                console.log("error: " + errorData);
            }
        });
    }

}


function TopluMesajModalGizleGoster() {
    var topluMesajModal = $("#topluMesajGonder");
    topluMesajModal.find(".modal").modal("show");
}


function TopluMesajGonder(o) {

    if (ValidateControl(o) == 0) {

        return true;
    }
    $("#overlay").fadeIn(1);

    var obj = $(o).parents("div.modal.fade");
    var Id = $("form", obj).attr("id");

    //burada sadece $("form") da denilbilirdi biz burada örnekleri çoğaltmak istedik....
    var form = $("form#" + Id);
    var Mesaj = $("#mesaj", form).val();

    $.ajax({
        type: "POST",
        url: "/Mesajlar/TopluMesajGonder",
        data: {
            Mesaj: Mesaj
        },
        success: function (result) {
            if (result.status == 1) {
                $("#overlay").fadeOut(300);
                $("#topluMesajGonder").find(".modal").modal("hide");

                toastr.success(result.data.Message, "Başarılı!");
            }
            else {
                Swal.fire(
                    'Hata',
                    result.message,
                    'error'
                );
                return;
            }
        },
        error: function (errorData) {
            console.log("error: " + errorData);
        }
    })

}
