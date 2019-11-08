function ModalInformation(baslik, aciklama) {
    $("mdlBaslik").text(baslik);
    $("mdlAciklama").text(aciklama);
    ModalShow("mdlInformation");
}

function ModalShow(modalID) {
    $("#" + modalID).modal("show");
}

function ModalHide(modalID) {
    $("#" + modalID).modal("hide");
}

var IslemSonucTurleri =
    {
        Basarili: "BAŞARILI",
        Hata: "HATA",
        Uyari: "UYARI",
        Bilgi: "BİLGİ"
    };

var IslemSonucKodlari =
    {
        Basarili: 1,
        Hata: 2,
        Uyari: 3,
        Bilgi: 4
    };

function YetkiliGiris()
{
    console.log("test");
    try {
        var yAd = $("#YetkiliAd").val();
        var psswrd = $("#YetkiliSifre").val();

        if(yAd === " ")
        {
            ModalInformation("UYARI", "Yetkili Adı Boş Geçilemez.");
            return false;
        }

        if (psswrd === " ") {
            ModalInformation("UYARI", "Yetkili Şifresi Boş Geçilemez.");
            return false;
        }

        console.log("test");
        $.ajax({
            type: "POST",
            url: "/Staff/StaffLogin",
            content: "application/json;",
            dataType: 'json',
            data: $('#FrmYetkiliGirisi').serialize(),
            async: true,
            success : function( data )
            {
                if (data.IslemKodu == 1) {
                    window.location.href = "../Anasayfa/Index"
                }
                else if (data.IslemKodu == 2) {
                    ModalInformation(IslemSonucTurleri.Hata, data.Aciklama);
                }
            },
            error: function (ex) {
                ModalInformation(IslemSonucTurleri.Hata, data.Aciklama);
            }
        })

    }
    catch (e) {
        console.log("Hata : " + e);
    }

}