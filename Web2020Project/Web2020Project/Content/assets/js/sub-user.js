$(document).ready(function () {
    let check = true;
    $('#user').click(function () {
        if (check) {
            $('.sub-user').css({'visibility': 'visible'});
            check = false;
        }else{
            $('.sub-user').css({'visibility': 'hidden'});
            check = true;
        }
    })
});