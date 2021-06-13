$(function () {

    ToasterMesajYukle()

    OgrenciTablosunuDatatableYap();

    $("#ogrenciEkle").click(function () {
        OgrenciEkleModalGizleGoster();
    });




});


function OgrenciTablosunuDatatableYap() {
    $("#example1").DataTable({

        "responsive": true, "lengthChange": false, "autoWidth": false,
        "buttons": [
            "copy", "excel", "pdf", "print",

            {
                text: 'Öğrenci Ekle',
                attr: {
                    id: "ogrenciEkle",
                },
                className: 'btn btn-success',
                //action: function (e, dt, node, config) {
                //    alert('Button activated');
                //}
            }

        ],
        language: {
            "emptyTable": "Tabloda herhangi bir veri mevcut değil",
            "info": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "infoEmpty": "Kayıt yok",
            "infoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "infoThousands": ".",
            "lengthMenu": "Sayfada _MENU_ kayıt göster",
            "loadingRecords": "Yükleniyor...",
            "processing": "İşleniyor...",
            "search": "Ara:",
            "zeroRecords": "Eşleşen kayıt bulunamadı",
            "paginate": {
                "first": "İlk",
                "last": "Son",
                "next": "Sonraki",
                "previous": "Önceki"
            },
            "aria": {
                "sortAscending": ": artan sütun sıralamasını aktifleştir",
                "sortDescending": ": azalan sütun sıralamasını aktifleştir"
            }
        },
    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
}

function OgrenciEkleModalGizleGoster() {
    var ogrenciEkleModal = $("#ogrenciEkleModal");

    $.ajax({
        type: "GET",
        url: "/OgrenciTanimlama/_ogrenciEklePartialView",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            ogrenciEkleModal.html(data);
            MaskeUygula();
            ogrenciEkleModal.find(".modal").modal("show");


        },
        error: function (errorData) {
            console.log("error: " + errorData);
        }

    })
}

function MaskeUygula() {
    $("#CepTel").mask("(999) 999-99-99");

    //$('#DogumTarihi').mask('00/00/0000');

}

function YeniOgrenciKaydet(o) {

    if (ValidateControl(o) == 0) {
        return true;
    }


    var obj = $(o).parents("div.modal.fade");
    var Id = $("form", obj).attr("id");

    //burada sadece $("form") da denilbilirdi biz burada örnekleri çoğaltmak istedik....
    var form = $("form#" + Id);
    var data = form.serialize();

    $.ajax({
        type: "POST",
        url: "/OgrenciTanimlama/OgrenciEkle",
        data: data,
        success: function (result) {
            if (result.status == 1) {
                $("#ogrenciEkleModal").find(".modal").modal("hide");

                var newRow = `
                  <tr>
                      <td id="Ogrenci_Id">${result.data.Ogrenci_Id}</td>
                      <td>${result.data.AdiSoyadi}</td>
                      <td>${result.data.OgrenciNumarasi}</td>
                      <td>${result.data.BolumAdi}</td>
                      <td>${result.data.TcNo}</td>
                      <td>${result.data.CepTel}</td>
                      <td>${ConvertToLocalDate(result.data.DogumTarihi)}</td>
                      <td>${result.data.Sinif}</td>
                      <td>${result.data.Donem}</td>
                  </tr>
                           `;
                var newRowObject = $(newRow);
                newRowObject.hide();
                $("#OgrenciTable").append(newRowObject);
                newRowObject.fadeIn(3000);

                toastr.success(`${result.data.AdiSoyadi} öğrencisi başarıyla eklendi.`, "Başarılı!");
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

function OgrenciListesliYenile() {
    $.ajax({
        type: "GET",
        url: "/OgrenciTanimlama/_ogrenciListesiPartial",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("tbody").html(response);

        },
        error: function (errorData) {
            console.log("error: " + errorData);
        }

    })
}

function ToasterMesajYukle() {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
}

function ConvertToLocalDate(date) {

    var localDate = new Date(parseInt((date).replace("/Date(", "").replace(")/", ""))).toLocaleDateString();
    return localDate;
}







