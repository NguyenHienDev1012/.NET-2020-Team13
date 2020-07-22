$(document).ready(function () {
    const reg_mail = /^[A-Za-z0-9]+[_\.\-]?[A-Za-z0-9]*@[A-Za-z0-9]+[-\.\_]{1}[A-Za-z0-9]+[\.]?[A-Za-z]*[\.]?[A-Za-z]*$/;
    // const reg_pass = /^[a-zA-Z0-9!@#$%^&*()_.?\/]{6,}$/;
    const email = $('#email');
    // const new_pass = $('#new-pass');
    // const c_new_pass = $('#c-new-pass');
    let flag = true;
    $('#form-forget').submit(function () {
        flag = true;
        if (email.val() !== '') {
            if (!(reg_mail.test(email.val())) && email.val() !== undefined) {
                notEmpty(email, 'Sai định dạng Email', email.val());
                flag = false;
            }
        } else {
            if (email.val() === '') {
                notEmpty(email, 'Vui lòng nhập Email', null);
                flag = false;
            }
        }
        // if (new_pass.val() !== '') {
        //     if (!(reg_pass.test(new_pass.val()))) {
        //         notEmpty(new_pass, 'Mật khẩu ít nhất 6 ký tự', new_pass.val());
        //         flag = false;
        //     }
        // } else {
        //     notEmpty(new_pass, 'Vui lòng nhập Mật khẩu', null);
        //     flag = false;
        // }
        // if (c_new_pass.val() === '') {
        //     notEmpty(c_new_pass, 'Vui lòng xác nhận mật khẩu', null);
        //     flag = false;
        // } else {
        //     if (c_new_pass.val() !== new_pass.val()) {
        //         notEmpty(c_new_pass, 'Mật khẩu nhập lại không khớp', c_new_pass.val());
        //         flag = false;
        //     }
        // }
        if (flag) {
            $.ajax({
                url: 'quen-mat-khau',
                method: 'POST',
                data: {
                    email: email.val(),
                },
                success: function (result) {
                    if (result === 'SUCCESS') {
                        $('#form-forget').html("<div class='succ-email'>Vui lòng kiểm tra Email và đặt lại mật khẩu. Sau 5 phút liên kết sẽ bị hủy</div>");
                    } else if (result === "ERROR") {
                        $('#err-mail').css('opacity', '1');
                    }
                }
            })
        }
        return false;
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