$(document).ready(function () {
    $("#sezonid").hide();
    $("#DiziId").change(function () {
      
        $("#sezonid").toggle(1000);
       


    });

    $("#SezonEkle").click(function () {
        var id = $("#DiziId").val();
        var SezonAdi = $("#SezonAd").val();
        alert(SezonAdi);
        $.ajax({
            url: '/Admin/DiziSezonEkle',
            type: 'POST',
            dataType: 'json',
            data: { Sezon:SezonAdi, Diziid: id },
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