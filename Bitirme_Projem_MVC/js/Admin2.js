


$(document).ready(function () {
    $("#deneme").hide();
    $("#DiziId").change(function () {//dizi seçildiğinde
        var id = $(this).val();//bağlanılan idnin valuesi
        var sezonlist = $("#SezonId");
        //Ajax ile bir controler üzerine gidip o controlerdan DiziSezon verilerini json olarak getirme
        sezonlist.empty();
        $.ajax({ //Ajax bağlantısı gerçekleştirildi
            url: '/KullaniciEkrani/SezonListe',//bağlanacağımız url
            type: 'POST',
            dataType: 'json',
            data: { 'id': id }, //gönderilecek veri
            success: function (data) {
                //gelen data controlerdan dönen Itemlist
                sezonlist.append('<option value=' + "Bölüm Seçiniz" + '></option');
                $.each(data, function (index, option) {//foreach döngüsü ile sezonlistesi yazılacak
                    //datanın içinde dönerken ordaki her item option olarak nitelenir
                    sezonlist.append('<option value=' + option.Value + '> ' + option.Text + '</option');
                })
            }

        });
    });



    //Sezon Seçildiğinde

    $("#SezonId").change(function () {//sezon seçildiğinde
        var id = $(this).val();//bağlanılan idnin valuesi
        var Bölümlist = $("#B_l_mId");
        //Ajax ile bir controler üzerine gidip o controlerdan DiziSezon verilerini json olarak getirme
        Bölümlist.empty();
        $.ajax({ //Ajax bağlantısı gerçekleştirildi
            url: '/KullaniciEkrani/BölümListe',//bağlanacağımız url
            type: 'POST',
            dataType: 'json',
            data: { 'id': id }, //gönderilecek veri
            success: function (veri) {
                //gelen data controlerdan dönen Itemlist
                Bölümlist.append('<option value=' + "Bölüm Seçiniz" + '></option');
                $.each(veri, function (index, option) {//foreach döngüsü ile sezonlistesi yazılacak
                    //datanın içinde dönerken ordaki her item option olarak nitelenir
                    Bölümlist.append('<option value=' + option.Value + '> ' + option.Text + '</option');
                })
            }

        });
    });



    //Bölüm Seçildiğinde

    $("#B_l_mId").change(function () {//sezon seçildiğinde
       
        $("#deneme").toggle(1000);

    });
    $("#KelimeEkle").click(function () {
        var Kelimeing = $("#Kelimeing").val().toUpperCase();
        var KelimeAnlami = $("#Anlami").val().toUpperCase();
        var Tekrari = $("#Tekrar").val();
        var id = $("#B_l_mId").val();
        $.ajax({
            url: '/Admin/DiziKelimeEkle',
            type: 'POST',
            dataType: 'json',
            data: { Kelime: Kelimeing, Anlami: KelimeAnlami, TekrarSayisi: Tekrari, Bolumid: id },
            success: function (gelendeger) {
                if (gelendeger == "1") {
                    alert("Kelime Eklendi")
                }
                else  {
                    alert("Kelime Listesinde Zaten Var ")
                }
                

            }

        });
      











    });
            
            //var Kelimeing = $("#Kelimeing").val();
            //var KelimeAnlami = $("#Anlami").val();
            //var Tekrari = $("#Tekrar").val();
            
            //$.ajax({
            //    url:'/Admin/DiziKelimeEkle',
            //    type:'POST',
            //    dataType: "Json",
            //    data: { 'Kelime': Kelimeing, 'Anlami': KelimeAnlami, 'Tekrar': Tekrari },
            //    success:function (gelenveri) {
            //        if (gelenveri == "1") {
            //            toastr.success(" Bildiğin Kelime Listesine Eklendi", "Eklendi", { timeOut: 1000 });
            //        }
            //        else if (gelenveri == "0") {
            //            toastr.warning(" Bildiğin Kelime Listesinde Zaten Var", "Uyarı!!", { timeOut: 1000 });
            //        }
            //    }
                

            //});

     



    

});