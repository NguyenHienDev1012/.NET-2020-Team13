$(document).ready(function () {
    $('.buy-ajax').on('click',function () {
        let value = $(this).parent().children('.msp-ajax').val();
        $.ajax({
            url: 'Cart_Process',
            method: 'POST',
            data: {
                id: value,
                soluong: 1
            },
            success: function (result) {
                let value = result.split("-");
                $('.amount').html(value[0]);
            }
        })
    });

});