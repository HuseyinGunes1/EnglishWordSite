$(document).ready(function () {
    $("#bolumid").hide();
    $("#SezonId").change(function () {

        $("#bolumid").toggle(1000);



    });

    $("#BolumEkle").click(function () {
        var id = $("#SezonId").val();
        var BolumAdi = $("#BolumAd").val();
        alert(BolumAdi);
        $.ajax({
            url: '/Admin/DiziBolumEkle',
            type: 'POST',
            dataType: 'json',
            data: { BolumAdi: BolumAdi, Sezonid: id },
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