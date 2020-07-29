$(document).ready(function () {
    const userName = $('#userName');
    const password = $('#password');
    let flag = true;
    $('#form-login').submit(function () {
        flag = true;
        if (userName.val() === '') {
            notEmpty(userName, 'Vui lòng nhập tài khoản');
            flag = false;
        }
        if (password.val() === '') {
            notEmpty(password, 'Vui lòng nhập mật khẩu');
            flag = false;
        }

        return flag;
    });

    function notEmpty(ele, text) {
        ele.attr('placeholder', text).val('').addClass('holder-danger').on('focus', function () {
            ele.attr('placeholder', '');
        }).on('blur', function () {
            ele.attr('placeholder', text);
        });

    }
});