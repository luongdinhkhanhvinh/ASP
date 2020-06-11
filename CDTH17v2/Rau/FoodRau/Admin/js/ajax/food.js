
$(this).ready(function () {
    checkPricePromo();
    checkEnable(false);
});


function checkEnable(check) {
    $('#cph_content_txtPrice_promo').attr("disabled", !check);
}

function checkPricePromo() {
    var price = $('#cph_content_txtPrice').val();
    var percent = $('#cph_content_txtPercent_Promo').val();
    if (price != "" && percent != "") {
        if (percent >= 0 && percent < 100) {
            var price_promo = price - (price * (percent / 100));
            $('#cph_content_txtPrice_promo').val(price_promo);
            $('#cph_content_hfPrice_Promo').val(price_promo);
        }
    } else {
        $('#cph_content_txtPrice_promo').val('');
    }
}
