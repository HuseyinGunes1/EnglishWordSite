function Bildigimogrenecegim(id, session) {
    var kategoriid = 1;
    $.ajax({
        url: '/KelimeListem/BildigimGuncelle',
        type: 'POST',
        dataType: 'json',
        data: { Kullaniciid: session, Kategoriid: kategoriid, Kelimeid: id },
        success: function (gelendeger) {
            if (gelendeger.result == true) {
                toastr.success(" Öğreneceğin Kelime Listesine Eklendi", "Eklendi", { timeOut: 1000 });
                $('#TableBody').empty();
                KelimeListesii();
            }
            else {
                toastr.error("Listeye eklenemedi", "Uyarı!!", { timeOut: 1000 });
            }

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

}

function BildigimListe(id, session) {
    var kategoriid = 1;
    $.ajax({
        url: '/KelimeListem/OgrenecegimGuncelle',
        type: 'POST',
        dataType: 'json',
        data: { Kullaniciid: session, Kategoriid: kategoriid, Kelimeid: id },
        success: function (gelendeger) {
            if (gelendeger.result == true) {
                toastr.success(" Bildiğin Kelime Listesine Eklendi", "Eklendi", { timeOut: 1000 });
                $('#TableBody').empty();
                KelimeListesii();
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
        data: { Kullaniciid: session, Kategoriid: 2 },
        success: function (veri) {
            $("#BildigimKelimelistesayi").html(veri);
        },
        error: function (data) {
            console.log("Hata:", veri)
        }
    });
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

}