function openSolution(id, session) {
    var kategoriid = 1;
    $.ajax({
        url: '/KullaniciEkrani/KelimeListesineEkle',
        type: 'POST',
        dataType: 'json',
        data: { Kullaniciid: session, Kategoriid: kategoriid, Kelimeid: id },
        success: function (gelendeger) {
            if (gelendeger == "1") {
                toastr.success("Kelime Listenize Eklendi", "Eklendi", { timeOut: 1000 });
            }
            else if (gelendeger == "0") {
                toastr.warning("Kelime Listesinizde Zaten Var", "Uyarı!!", { timeOut: 1000 });
            }
            else if (gelendeger == "2") {
                toastr.error("Kelime Başka Listede Zaten Var", "Uyarı!!", { timeOut: 1000 });
            }
           
        }

    });

    $.ajax({

        url: '/KullaniciEkrani/KelimeSayisi',
        type: 'POST',
        dataType:'json',
        data: { Kullaniciid: session, Kategoriid: kategoriid  },
        success: function (veri) {
            $("#Kelimelistesayi").html(veri);
        },
        error: function (data) {
            console.log("Hata:", veri)
        }
    });

}

function sayi(session) {
   
    var kategoriid = 1;
    $.ajax({

        url: '/KullaniciEkrani/KelimeSayisi',
        type: 'POST',
        dataType: 'json',
        data: { Kullaniciid: session, Kategoriid: kategoriid },
        success: function (veri) {
            $("#Kelimelistesayi").html(veri);
        },
        error: function (data) {
            console.log("Hata:", veri)
        }
    });
    alert("Kelime Listesine Eklendi");
}






