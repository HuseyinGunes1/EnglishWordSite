 function ogrenecegim(id, session) {
    var kategoriid = 3;
    $.ajax({
        url: '/KullaniciEkrani/OgrenecegimKelimeListesineEkle',
        type: 'POST',
        dataType: 'json',
        data: { Kullaniciid: session, Kategoriid: kategoriid, Kelimeid: id },
        success: function (gelendeger) {
            if (gelendeger == "1") {
                toastr.success(" Öğreneceğin Kelime Listesine Eklendi", "Eklendi", { timeOut: 1000 });
            }
            else if (gelendeger == "0") {
                toastr.warning(" Öğreneceğin Kelime Listesinde Zaten Var", "Uyarı!!", { timeOut: 1000 });
            }
            else if (gelendeger == "2") {
                toastr.error("Kelime Başka Listede Zaten Var", "Uyarı!!", { timeOut: 1000 });
            }
            
        }

    });

    $.ajax({

        url: '/KullaniciEkrani/OgrenecegimKelimeSayisi',
        type: 'POST',
        dataType: 'json',
        data: { Kullaniciid: session, Kategoriid: kategoriid },
        success: function (veri) {
            $("#OgrenecegimKelimelistesayi").html(veri);
        },
        error: function (data) {
            console.log("Hata:", veri)
        }
    });

}