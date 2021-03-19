function Ogrenecekler(id, session) {
    var kategoriid = 2;
    $.ajax({
        url: '/KelimeListem/BildigimGuncelle',
        type: 'POST',
        dataType: 'json',
        data: { Kullaniciid: session, Kategoriid: kategoriid, Kelimeid: id },
        success: function (gelendeger) {
            if (gelendeger.result == true) {
                toastr.success(" Öğreneceğim Kelime Listesine Eklendi", "Eklendi", { timeOut: 1000 });
                $('#TableBody').empty();
                Bildigimler();
            }
            else {
                toastr.error("Listeye eklenemedi", "Uyarı!!", { timeOut: 1000 });
            }

        }

    });
    $.ajax({

        url: '/KullaniciEkrani/BildigimKelimeSayisi',
        type: 'POST',
        dataType: 'json',
        data: { Kullaniciid: session, Kategoriid: kategoriid },
        success: function (veri) {
            $("#BildigimKelimelistesayi").html(veri);
        },
        error: function (data) {
            console.log("Hata:", veri)
        }
    });
    $.ajax({

        url: '/KullaniciEkrani/OgrenecegimKelimeSayisi',
        type: 'POST',
        dataType: 'json',
        data: { Kullaniciid: session, Kategoriid:3 },
        success: function (veri) {
            $("#OgrenecegimKelimelistesayi").html(veri);
        },
        error: function (data) {
            console.log("Hata:", veri)
        }
    });
   

}
