$(document).ready(function () {
    $('.info-user').click(function () {
        $('#update-info').css('visibility', 'visible');
        $('#book-address').css('visibility', 'hidden');
        $('#change-pass').css('visibility', 'hidden');
        $(this).css('background', 'rgba(166, 166, 166, 0.73)');
        $('.address-user').css('background', 'transparent');
        $('.change-pass-user').css('background', 'transparent');
    });


    $('.address-user').click(function () {
        $('#update-info').css('visibility', 'hidden');
        $('#book-address').css('visibility', 'visible');
        $('#change-pass').css('visibility', 'hidden');
        $(this).css('background', 'rgba(166, 166, 166, 0.73)');
        $('.info-user').css('background', 'transparent');
        $('.change-pass-user').css('background', 'transparent');
    });

    $('.change-pass-user').click(function () {
        $('#update-info').css('visibility', 'hidden');
        $('#book-address').css('visibility', 'hidden');
        $('#change-pass').css('visibility', 'visible');
        $(this).css('background', 'rgba(166, 166, 166, 0.73)');
        $('.info-user').css('background', 'transparent');
        $('.address-user').css('background', 'transparent');
    })

});