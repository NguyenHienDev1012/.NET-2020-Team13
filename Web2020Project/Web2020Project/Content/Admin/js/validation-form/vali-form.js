$(document).ready(function () {
    const reg_mail = /^[A-Za-z0-9]+[_\.\-]?[A-Za-z0-9]*@[A-Za-z0-9]+[-\.\_]{1}[A-Za-z0-9]+[\.]?[A-Za-z]*[\.]?[A-Za-z]*$/;
    const reg_phone = /^0[1-9]{8,9}$/;
    const reg_usr = /^[a-zA-Z0-9]+$/
    const reg_pass = /^[a-zA-Z0-9!@#$%^&*()_.?\/]{6,}$/;
    const userName = $('#userName');
    const password = $('#password');
    const name = $('#name');
    const email = $('#email');
    const phone = $('#phone');
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
        if (userName.val() === '') {
            notEmpty(userName, 'Vui lòng nhập Tài khoản', null);
            flag = false;
        } else {
            if (!(reg_usr.test(userName.val())) && userName.val() !== undefined) {
                notEmpty(userName, 'Vui lòng nhập không dấu', userName.val());
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
        if (name.val() === '') {
            notEmpty(name, 'Vui lòng nhập Họ tên', null);
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
        if (phone.val() === '') {
            notEmpty(phone, 'Vui lòng nhập phone', null);
            flag = false;
        } else {
            if (!(reg_phone.test(phone.val())) && phone.val() !== undefined) {
                notEmpty(phone, 'Sai định dạng phone', phone.val());
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