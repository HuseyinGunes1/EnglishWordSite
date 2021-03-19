function Bildigim(id, session) {
    var kategoriid = 2;
    $.ajax({
        url: '/KullaniciEkrani/BildigimKelimeListesineEkle',
        type: 'POST',
        dataType: 'json',
        data: { Kullaniciid: session, Kategoriid: kategoriid, Kelimeid: id },
        success: function (gelendeger) {
            if (gelendeger == "1") {
                toastr.success(" Bildiğin Kelime Listesine Eklendi", "Eklendi", { timeOut: 1000 });
            }
            else if (gelendeger == "0") {
                toastr.warning(" Bildiğin Kelime Listesinde Zaten Var", "Uyarı!!", { timeOut: 1000 });
            }
            else if (gelendeger == "2") {
                toastr.error("Kelime Başka Listede Zaten Var", "Uyarı!!", { timeOut: 1000 });
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

}
