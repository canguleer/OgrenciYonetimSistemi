$(function () {
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
            ogrenciEkleModal.find(".modal").modal("show");


        },
        error: function (errorData) {
            console.log("error: " + errorData);
        }

    })
}





