$(document).ready(function () {
   

    $("#DiziEkle").click(function () {
       
        var Dizi = $("#DiziAd").val();
        
        $.ajax({
            url: '/Admin/DiziEkleme',
            type: 'POST',
            dataType: 'json',
            data: { DiziAdi: Dizi },
            success: function (gelendeger) {
                if (gelendeger == "1") {
                    swal({
                        title: "",
                        text: "Kelime Eklendi",
                        icon: "success",
                        button: "Tamam",
                    });
                }
                else if (gelendeger == "0") {
                    swal({
                        title: "",
                        text: "Kelime Eklenmedi",
                        icon: "warning",
                        button: "Tamam",
                    });
                }


            }

        });

    });


});