$(document).ready(function () {
    const reg_mail = /^[A-Za-z0-9]+[_\.\-]?[A-Za-z0-9]*@[A-Za-z0-9]+[-\.\_]{1}[A-Za-z0-9]+[\.]?[A-Za-z]*[\.]?[A-Za-z]*$/;
    const reg_sdt = /^0[1-9]{8,9}$/;
    const reg_usr = /^[a-zA-Z0-9]+$/
    const reg_pass = /^[a-zA-Z0-9!@#$%^&*()_.?\/]{6,}$/;
    const usr_name = $('#usr-name');
    const password = $('#password');
    const full_name = $('#full-name');
    const email = $('#email');
    const sdt = $('#sdt');
    const  id = $('#id');
    // producer
    const id_producer = $('#id-producer'), name_producer = $('#name-producer'), add_producer = $('#add-producer');
    //product
    const id_product = $('#id-product'), name_product = $('#name-product'), count_product = $('#count-product');
    //oder
    const  address_oder = $('#address-oder');
    let flag = true;
    $('#form-validate').submit(function () {
        flag = true;
        if (id.val() === '') {
            notEmpty(id, 'Vui lòng nhập ID', null);
            flag = false;
        }
        if (usr_name.val() === '') {
            notEmpty(usr_name, 'Vui lòng nhập Tài khoản', null);
            flag = false;
        } else {
            if (!(reg_usr.test(usr_name.val())) && usr_name.val() !== undefined) {
                notEmpty(usr_name, 'Vui lòng nhập không dấu', usr_name.val());
                flag = false;
            }
        }
        if (password.val() === '') {
            notEmpty(password, 'Vui lòng nhập Mật khẩu', null);
            flag = false;
        } else {
            if (!(reg_pass.test(password.val()))) {
                notEmpty(password, 'Mật khẩu ít nhất 6 ký tự', password.val());
                flag = false;
            }
        }
        if (full_name.val() === '') {
            notEmpty(full_name, 'Vui lòng nhập Họ tên', null);
            flag = false;
        }
        if (email.val() === '') {
            notEmpty(email, 'Vui lòng nhập Email', null);
            flag = false;
        } else {
            if (!(reg_mail.test(email.val())) && email.val() !== undefined) {
                notEmpty(email, 'Sai định dạng Email', email.val());
                flag = false;
            }
        }
        if (sdt.val() === '') {
            notEmpty(sdt, 'Vui lòng nhập SDT', null);
            flag = false;
        } else {
            if (!(reg_sdt.test(sdt.val())) && sdt.val() !== undefined) {
                notEmpty(sdt, 'Sai định dạng SDT', sdt.val());
                flag = false;
            }
        }
        // producer
        if (id_producer.val() === '') {
            notEmpty(id_producer, 'Vui lòng nhập Mã nhà cung cấp', null);
            flag = false;
        }
        if (name_producer.val() === '') {
            notEmpty(name_producer, 'Vui lòng nhập Tên nhà cung cấp', null);
            flag = false;
        }
        if (add_producer.val() === '') {
            notEmpty(add_producer, 'Vui lòng nhập Địa chỉ nhà cung cấp', null);
            flag = false;
        }
        //product
        if (id_product.val() === '') {
            notEmpty(id_product, 'Vui lòng nhập Mã sản phẩm', null);
            flag = false;
        }
        if (name_product.val() === '') {
            notEmpty(name_product, 'Vui lòng nhập Tên sản phẩm', null);
            flag = false;
        }
        if (count_product.val() === '') {
            notEmpty(count_product, 'Vui lòng nhập Số lượng', null);
            flag = false;
        }
        //oder
        if (address_oder.val() === '') {
            notEmpty(address_oder, 'Vui lòng nhập Địa chỉ giao hàng', null);
            flag = false;
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