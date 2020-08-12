$(document).ready(function () {
    const reg_pass = /^[a-zA-Z0-9!@#$%^&*()_.?\/]{6,}$/;
    const new_pass = $('#new-pass');
    const c_new_pass = $('#c-new-pass');
    const current_pass = $('#current-pass');
    let flag = true;
    $('#form-change-pass').submit(function () {
        flag = true;
        if (current_pass.val() === '') {
            notEmpty(current_pass, 'Vui lòng nhập Mật khẩu hiện tại', null);
            flag = false;
        }
        if (new_pass.val() === '') {
            notEmpty(new_pass, 'Vui lòng nhập Mật khẩu', null);
            flag = false;
        } else {
            if (!(reg_pass.test(new_pass.val()))) {
                notEmpty(new_pass, 'Mật khẩu ít nhất 6 ký tự', new_pass.val());
                flag = false;
            }
        }
        if (c_new_pass.val() === '') {
            notEmpty(c_new_pass, 'Vui lòng xác nhận Mật khẩu', null);
            flag = false;
        } else {
            if (c_new_pass.val() !== new_pass.val()) {
                notEmpty(c_new_pass, 'Mật khẩu nhập lại không khớp', c_new_pass.val());
                flag = false;
            }
        }
        return flag;
    });

    function notEmpty(ele, text, value) {
        ele.attr('placeholder', text).val('').addClass('holder-danger').on('focus', function () {
            if (value !== null) {
                ele.val(value);
            } else {
                ele.attr('placeholder', '');
            }
        }).on('blur', function () {
            ele.val(ele.val());
            ele.attr('placeholder', text);
        });
    }
});