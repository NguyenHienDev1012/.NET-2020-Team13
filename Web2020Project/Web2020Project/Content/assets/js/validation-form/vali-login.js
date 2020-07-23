$(document).ready(function () {
    const usr_name = $('#usr-name');
    const password = $('#password');
    const reg_mail = /^[A-Za-z0-9]+[_\.\-]?[A-Za-z0-9]*@[A-Za-z0-9]+[-\.\_]{1}[A-Za-z0-9]+[\.]?[A-Za-z]*[\.]?[A-Za-z]*$/;
    const email = $('#email');
    let flag = true;
    $('#form-login').submit(function () {
        flag = true;
        if (usr_name.val() === '') {
            notEmpty(usr_name, 'Vui lòng nhập Tài khoản');
            flag = false;
        }
        if (password.val() === '') {
            notEmpty(password, 'Vui lòng nhập Mật khẩu');
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